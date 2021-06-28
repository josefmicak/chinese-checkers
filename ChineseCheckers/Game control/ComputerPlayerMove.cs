using System;
using System.Collections.Generic;
using ChineseCheckers.Forms;
using ChineseCheckers.Game_entities;

namespace ChineseCheckers.Game_control
{
    class ComputerPlayerMove
    {
        private int amountOfPlayers;
        private int firstMove;
        private int fieldWidth;
        private int fieldLength;
        private int distance;
        private int upperOffset;
        private int leftOffset;
        private int amountOfMoves;
        private bool simulationMode;

        private bool checkMoveFavorability;

        private List<Field> gameFields = new List<Field>();
        private List<HumanPlayer> humanPlayerFields = new List<HumanPlayer>();
        private List<ComputerPlayer> computerPlayerFields = new List<ComputerPlayer>();
        private List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer = new List<PossibleMoveOfHumanPlayer>();
        private List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer = new List<PossibleMoveOfComputerPlayer>();
        private List<PreviousFieldOfComputerPlayer> previousFieldsOfComputerPlayer = new List<PreviousFieldOfComputerPlayer>();
        private List<HighlightedFieldOfComputerPlayer> highlightedFieldsOfComputerPlayer = new List<HighlightedFieldOfComputerPlayer>();

        private PossibleMovesCalculation possibleMovesCalculation;
        Random random = new Random();

        public ComputerPlayerMove(int amountOfPlayers, int firstMove, int amountOfMoves, int fieldWidth, int fieldLength, int distance, int upperOffset, int leftOffset, List<Field> gameFields, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, List<HighlightedFieldOfComputerPlayer> highlightedFieldsOfComputerPlayer, List<PreviousFieldOfComputerPlayer> previousFieldsOfComputerPlayer, bool simulationMode)
        {
            this.amountOfPlayers = amountOfPlayers;
            this.firstMove = firstMove;
            this.amountOfMoves = amountOfMoves;
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
            this.distance = distance;
            this.upperOffset = upperOffset;
            this.leftOffset = leftOffset;
            this.gameFields = gameFields;
            this.computerPlayerFields = computerPlayerFields;
            this.humanPlayerFields = humanPlayerFields;
            this.possibleMovesOfHumanPlayer = possibleMovesOfHumanPlayer;
            this.possibleMovesOfComputerPlayer = possibleMovesOfComputerPlayer;
            this.highlightedFieldsOfComputerPlayer = highlightedFieldsOfComputerPlayer;
            this.previousFieldsOfComputerPlayer = previousFieldsOfComputerPlayer;
            this.simulationMode = simulationMode;
        }

        public (List<ComputerPlayer>, List<PreviousFieldOfComputerPlayer>, List<HighlightedFieldOfComputerPlayer>) PerformMove(GameForm gameform, int obtiznost, int[] simulationDifficulty)
        {
            int pos_X_CP, pos_Y_CP, pos_X_PM, pos_Y_PM, removedFieldId = 0, newFieldX, newFieldY, fieldToCheckX, fieldToCheckY, jumpLengthX = 0, jumpLengthY = 0;
            int maxDifferenceY, differenceX = 0, computerPlayerId, maxDifference, lastRowAmount, penultimateRowAmount, posXLastRow = 0, posXPenultimateRow = 0;

            bool playerPerformedAJump, performMove = true;

            List<int> unfavorableFieldsX = new List<int>();//a list of fields that are unfavorable for the computer player to move onto during the given move (x-axis)
            List<int> unfavorableFieldsY = new List<int>();//a list of fields that are unfavorable for the computer player to move onto during the given move (x-axis)

            possibleMovesCalculation = new PossibleMovesCalculation(fieldWidth, fieldLength, distance, upperOffset, leftOffset, gameFields);

            previousFieldsOfComputerPlayer.Clear();
            highlightedFieldsOfComputerPlayer.Clear();

            CreationOfPossibleMovesOfHumanPlayer();
            int mostFavorableMoveOfHumanPlayer = CalculationOfMostFavorableMoveOfHumanPlayer(amountOfPlayers);

            for (int n = 0; n <= 6; n++)
            {
                if (!FulfilledConditionsForMove(n, simulationMode))
                {
                    continue;
                }
                if (simulationMode)
                {
                    obtiznost = DifficultySetting(n, simulationDifficulty);
                }
                if (obtiznost <= 2)
                {
                    possibleMovesOfComputerPlayer.Clear();
                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        playerPerformedAJump = false;

                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        computerPlayerId = computerPlayer.Get_computerPlayerId();
                        if (computerPlayerId != n)
                        {
                            continue;
                        }
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                    }

                    List<int> performableMovements = new List<int>();
                    for (int i = 0; i < possibleMovesOfComputerPlayer.Count; i++)
                    {
                        if (n != possibleMovesOfComputerPlayer[i].Get_computerPlayerId())
                        {
                            continue;
                        }
                        if (AddPlayerMove(obtiznost, n, possibleMovesOfComputerPlayer[i].Get_pos_X_PM(), possibleMovesOfComputerPlayer[i].Get_pos_Y_PM(), possibleMovesOfComputerPlayer[i].Get_pos_X_PFPMCP(), possibleMovesOfComputerPlayer[i].Get_pos_Y_PFPMCP(), 0))
                        {
                            performableMovements.Add(i);
                        }
                    }
                    int number = random.Next(0, performableMovements.Count);
                    int moveId;
                    if (performableMovements.Count == 0)//if there's no move available, we perform a randomly selected move
                    {
                        moveId = random.Next(0, possibleMovesOfComputerPlayer.Count);
                    }
                    else
                    {
                        moveId = performableMovements[number]; 
                    }
                    if (possibleMovesOfComputerPlayer.Count > 0)//there's a very narrow possibility that during games with multiple players there may be no possible move available
                    {
                        for (int i = 0; i < computerPlayerFields.Count; i++)
                        {
                            ComputerPlayer computerPlayer = computerPlayerFields[i];
                            if (computerPlayer.Get_pos_X_CP() == possibleMovesOfComputerPlayer[moveId].Get_pos_X_PFPMCP() && computerPlayer.Get_pos_Y_CP() == possibleMovesOfComputerPlayer[moveId].Get_pos_Y_PFPMCP())
                            {
                                removedFieldId = i;
                                break;
                            }
                        }
                        AddComputerPlayerFields(removedFieldId, possibleMovesOfComputerPlayer[moveId].Get_pos_X_PM(), possibleMovesOfComputerPlayer[moveId].Get_pos_Y_PM(), n);
                    }
                }
                else
                {
                    gameform.ConsoleRefresh(n);
                    maxDifference = 0;
                    maxDifferenceY = 0;
                    lastRowAmount = 0;
                    penultimateRowAmount = 0;
                    newFieldX = 0;
                    newFieldY = 0;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;

                    if (n == 3 || n == 5)
                    {
                        posXLastRow = 1000;
                        posXPenultimateRow = 1000;
                    }
                    else if (n == 4 || n == 6)
                    {
                        posXLastRow = 0;
                        posXPenultimateRow = 0;
                    }

                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        possibleMovesOfComputerPlayer.Clear();
                        playerPerformedAJump = false;

                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        computerPlayerId = computerPlayer.Get_computerPlayerId();
                        if (computerPlayerId != n)
                        {
                            continue;
                        }

                        (lastRowAmount, penultimateRowAmount, posXLastRow, posXPenultimateRow) = FinalMovesPreparation(n, lastRowAmount, penultimateRowAmount, posXLastRow, posXPenultimateRow, pos_X_CP, pos_Y_CP);

                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            bool addPossibleMove = true;
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (Math.Abs(pos_Y_PM - pos_Y_CP) > distance || Math.Abs(pos_X_PM - pos_X_CP) > distance)//we are going to have to perform a jump in order to get to the checked possible move
                            {
                                playerPerformedAJump = true;
                            }
                            else
                            {
                                playerPerformedAJump = false;
                            }

                            if (playerPerformedAJump)// we got onto the checked field by a jump - so we check possible moves from this field
                            {
                                jumpLengthX = Math.Abs(possibleMove.Get_pos_X_PM() - possibleMove.Get_pos_X_PFPMCP());
                                jumpLengthY = Math.Abs(possibleMove.Get_pos_Y_PM() - possibleMove.Get_pos_Y_PFPMCP());
                                possibleMovesCalculation.AddPossibleMoves(pos_X_PM, pos_Y_PM, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                            }
                            if (n == 0)
                            {
                                if (pos_Y_CP - pos_Y_PM > maxDifferenceY)//a jump that gets the computer player the most further away possible on the y-axis
                                {
                                    for (int k = 0; k < unfavorableFieldsX.Count; k++)
                                    {
                                        if (pos_X_PM == unfavorableFieldsX[k] && pos_Y_PM == unfavorableFieldsY[k])
                                        {
                                            addPossibleMove = false;
                                        }
                                    }
                                    if (addPossibleMove)
                                    {
                                        maxDifferenceY = pos_Y_CP - pos_Y_PM;
                                        differenceX = Math.Abs(leftOffset - pos_X_PM);
                                        removedFieldId = i;
                                        newFieldX = pos_X_PM;
                                        newFieldY = pos_Y_PM;
                                        fieldToCheckX = pos_X_CP;
                                        fieldToCheckY = pos_Y_CP;
                                    }
                                }
                                else if (pos_Y_CP - pos_Y_PM == maxDifferenceY)
                                {
                                    if (Math.Abs(leftOffset - pos_X_PM) < differenceX)//a jump that gets the computer player away the same distance on the y-axis, but closer to the center of the map on the x-axis
                                    {
                                        for (int k = 0; k < unfavorableFieldsX.Count; k++)
                                        {
                                            if (pos_X_PM == unfavorableFieldsX[k] && pos_Y_PM == unfavorableFieldsY[k])
                                            {
                                                addPossibleMove = false;
                                            }
                                        }
                                        if (addPossibleMove)
                                        {
                                            differenceX = Math.Abs(leftOffset - pos_X_PM);
                                            removedFieldId = i;
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            fieldToCheckX = pos_X_CP;
                                            fieldToCheckY = pos_Y_CP;
                                        }
                                    }
                                }
                            }
                            else if (n == 2)
                            {
                                if (pos_Y_PM - pos_Y_CP > maxDifferenceY)//a jump that gets the computer player the most further away possible on the y-axis
                                {
                                    for (int k = 0; k < unfavorableFieldsX.Count; k++)
                                    {
                                        if (pos_X_PM == unfavorableFieldsX[k] && pos_Y_PM == unfavorableFieldsY[k])
                                        {
                                            addPossibleMove = false;
                                        }
                                    }
                                    if (addPossibleMove)
                                    {
                                        maxDifferenceY = pos_Y_PM - pos_Y_CP;
                                        differenceX = Math.Abs(leftOffset - pos_X_PM);
                                        removedFieldId = i;
                                        newFieldX = pos_X_PM;
                                        newFieldY = pos_Y_PM;
                                        fieldToCheckX = pos_X_CP;
                                        fieldToCheckY = pos_Y_CP;
                                    }
                                }
                                else if (pos_Y_PM - pos_Y_CP == maxDifferenceY)//a jump that gets the computer player away the same distance on the y-axis, but closer to the center of the map on the x-axis
                                {
                                    if (Math.Abs(leftOffset - pos_X_PM) < differenceX)
                                    {
                                        for (int k = 0; k < unfavorableFieldsX.Count; k++)
                                        {
                                            if (pos_X_PM == unfavorableFieldsX[k] && pos_Y_PM == unfavorableFieldsY[k])
                                            {
                                                addPossibleMove = false;
                                            }
                                        }
                                        if (addPossibleMove)
                                        {
                                            differenceX = Math.Abs(leftOffset - pos_X_PM);
                                            removedFieldId = i;
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            fieldToCheckX = pos_X_CP;
                                            fieldToCheckY = pos_Y_CP;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (AddPlayerMove(obtiznost, n, pos_X_PM, pos_Y_PM, pos_X_CP, pos_Y_CP, maxDifference))
                                {
                                    for (int k = 0; k < unfavorableFieldsX.Count; k++)
                                    {
                                        if (pos_X_PM == unfavorableFieldsX[k] && pos_Y_PM == unfavorableFieldsY[k])
                                        {
                                            addPossibleMove = false;
                                        }
                                    }
                                    if (addPossibleMove)
                                    {
                                        switch (n)
                                        {
                                            case 3:
                                                maxDifference = (pos_X_PM - pos_X_CP) + (pos_Y_PM - pos_Y_CP);
                                                break;
                                            case 4:
                                                maxDifference = (pos_X_CP - pos_X_PM) + (pos_Y_PM - pos_Y_CP);
                                                break;
                                            case 5:
                                                maxDifference = (pos_X_PM - pos_X_CP) + (pos_Y_CP - pos_Y_PM);
                                                break;
                                            case 6:
                                                maxDifference = (pos_X_CP - pos_X_PM) + (pos_Y_CP - pos_Y_PM);
                                                break;
                                        }

                                        removedFieldId = i;
                                        newFieldX = pos_X_PM;
                                        newFieldY = pos_Y_PM;
                                        fieldToCheckX = pos_X_CP;
                                        fieldToCheckY = pos_Y_CP;
                                    }
                                }
                            }
                        }
                    }
                    //counting the amount of marbles of the player that's started in the certain triangle (if we were to not count these marbles, there's a possibility that the blocked player would not be able to finish the game)
                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        computerPlayerId = computerPlayer.Get_computerPlayerId();
                        if ((n == 3 && computerPlayerId != 6) || (n == 4 && computerPlayerId != 5) || (n == 5 && computerPlayerId != 4) || (n == 6 && computerPlayerId != 3))
                        {
                            continue;
                        }
                        (lastRowAmount, penultimateRowAmount) = OriginalPlayerMarblesCalculation(n, lastRowAmount, penultimateRowAmount, pos_X_CP, pos_Y_CP);
                    }
                    
                    if (n == 0)
                    {
                        (removedFieldId, newFieldX, newFieldY, fieldToCheckX, fieldToCheckY) = StartingMovesPerformance(n, amountOfMoves, removedFieldId, newFieldX, newFieldY, fieldToCheckX, fieldToCheckY, firstMove, simulationMode);
                        if (newFieldX == 0 && newFieldY == 0)//resolving a situation that may happen at the end of the game, when the computer player cannot move back on the y-axis 
                        {
                            int distanceX = 1000;
                            checkMoveFavorability = false;
                            bool missingField = false;
                            for (int i = 0; i < computerPlayerFields.Count; i++)
                            {
                                ComputerPlayer computerPlayer = computerPlayerFields[i];
                                pos_X_CP = computerPlayer.Get_pos_X_CP();
                                pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                                int _computerPlayerId = computerPlayer.Get_computerPlayerId();
                                if (_computerPlayerId != 0)
                                {
                                    continue;
                                }
                                if (pos_X_CP == leftOffset - distance - distance / 2 && pos_Y_CP == upperOffset + distance * 3)
                                {
                                    missingField = true;
                                }
                                if (pos_Y_CP <= upperOffset + distance * 3)
                                {
                                    continue;
                                }
                                possibleMovesOfComputerPlayer.Clear();
                                playerPerformedAJump = false;
                                possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);

                                for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                                {
                                    PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                    pos_X_PM = possibleMove.Get_pos_X_PM();
                                    pos_Y_PM = possibleMove.Get_pos_Y_PM();
                                    if (pos_X_CP == leftOffset && pos_Y_CP == upperOffset + distance * 4)
                                    {
                                        removedFieldId = i;
                                        fieldToCheckX = 0;
                                        fieldToCheckY = 0;
                                        newFieldY = upperOffset + distance * 4;
                                        if (missingField)
                                        {
                                            newFieldX = leftOffset + distance;
                                        }
                                        else
                                        {
                                            newFieldX = leftOffset - distance;
                                        }
                                    }
                                    else
                                    {
                                        if (Math.Abs(leftOffset - pos_X_PM) < distanceX)
                                        {
                                            removedFieldId = i;
                                            distanceX = Math.Abs(leftOffset - pos_X_PM);
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            fieldToCheckX = 0;
                                            fieldToCheckY = 0;
                                            performMove = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (n == 2)
                    {
                        if (!IsMoveFavorable(fieldToCheckX, fieldToCheckY, newFieldX, newFieldY, n, mostFavorableMoveOfHumanPlayer, amountOfPlayers))
                        {
                            performMove = false;
                            unfavorableFieldsX.Add(newFieldX);
                            unfavorableFieldsY.Add(newFieldY);
                        }
                        if (amountOfPlayers == 2)
                        {
                            (removedFieldId, newFieldX, newFieldY, fieldToCheckX, fieldToCheckY) = StartingMovesPerformance(n, amountOfMoves, removedFieldId, newFieldX, newFieldY, fieldToCheckX, fieldToCheckY, firstMove, simulationMode);
                        }
                        if (newFieldX == 0 && newFieldY == 0)//resolving a situation that may happen at the end of the game, when the computer player cannot move forward on the y-axis 
                        {
                            int distanceX = 1000;
                            checkMoveFavorability = false;
                            bool missingField = false;
                            for (int i = 0; i < computerPlayerFields.Count; i++)
                            {
                                ComputerPlayer computerPlayer = computerPlayerFields[i];
                                pos_X_CP = computerPlayer.Get_pos_X_CP();
                                pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                                int _computerPlayerId = computerPlayer.Get_computerPlayerId();
                                if (_computerPlayerId != 2)
                                {
                                    continue;
                                }
                                if (pos_X_CP == leftOffset - distance - distance / 2 && pos_Y_CP == upperOffset + distance * 13)
                                {
                                    missingField = true;
                                }
                                if (pos_Y_CP >= upperOffset + distance * 13)
                                {
                                    continue;
                                }
                                possibleMovesOfComputerPlayer.Clear();
                                playerPerformedAJump = false;
                                possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);

                                for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                                {
                                    PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                    pos_X_PM = possibleMove.Get_pos_X_PM();
                                    pos_Y_PM = possibleMove.Get_pos_Y_PM();
                                    if (pos_X_CP == leftOffset && pos_Y_CP == upperOffset + distance * 12)
                                    {
                                        removedFieldId = i;
                                        fieldToCheckX = 0;
                                        fieldToCheckY = 0;
                                        newFieldY = upperOffset + distance * 12;
                                        if (missingField)
                                        {
                                            newFieldX = leftOffset + distance;
                                        }
                                        else
                                        {
                                            newFieldX = leftOffset - distance;
                                        }
                                    }
                                    else
                                    {
                                        if (Math.Abs(leftOffset - pos_X_PM) < distanceX)
                                        {
                                            removedFieldId = i;
                                            distanceX = Math.Abs(leftOffset - pos_X_PM);
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            fieldToCheckX = 0;
                                            fieldToCheckY = 0;
                                            performMove = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        (newFieldX, newFieldY, removedFieldId, fieldToCheckX, fieldToCheckY) = FinalMovesManagement(n, lastRowAmount, penultimateRowAmount, posXLastRow, posXPenultimateRow, newFieldX, newFieldY, removedFieldId, jumpLengthX, jumpLengthY, fieldToCheckX, fieldToCheckY);
                        
                        //resolving a situation where there was no favorable move found
                        if (newFieldX == 0 && newFieldY == 0)
                        {
                            if (checkMoveFavorability)//we are going to try to find a favorable move again, but this time we won't take human player's fields positions into consideration
                            {
                                checkMoveFavorability = false;
                                performMove = false;
                                unfavorableFieldsX.Clear();
                                unfavorableFieldsY.Clear();
                            }
                            else//we haven't found any favorable move even without taking human player's fields positions into consideration, therefore we are going to perform a randomly selected move, that however won't move the computer player further away from his destination triangle
                            {
                                playerPerformedAJump = false;
                                for (int i = 0; i < computerPlayerFields.Count; i++)
                                {
                                    ComputerPlayer computerPlayer = computerPlayerFields[i];
                                    pos_X_CP = computerPlayer.Get_pos_X_CP();
                                    pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                                    int _computerPlayerId = computerPlayer.Get_computerPlayerId();
                                    possibleMovesOfComputerPlayer.Clear();
                                    possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                                    for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                                    {
                                        PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                        pos_X_PM = possibleMove.Get_pos_X_PM();
                                        pos_Y_PM = possibleMove.Get_pos_Y_PM();
                                        if (n == 3 && pos_X_PM >= pos_X_CP && pos_Y_PM >= pos_Y_CP && n == _computerPlayerId)
                                        {
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            removedFieldId = i;
                                            break;
                                        }

                                        if (n == 4 && pos_X_PM <= pos_X_CP && pos_Y_PM >= pos_Y_CP && n == _computerPlayerId)
                                        {
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            removedFieldId = i;
                                            break;
                                        }

                                        if (n == 5 && pos_X_PM >= pos_X_CP && pos_Y_PM >= pos_Y_CP && n == _computerPlayerId)
                                        {
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            removedFieldId = i;
                                            break;
                                        }

                                        if (n == 6 && pos_X_PM <= pos_X_CP && pos_Y_PM >= pos_Y_CP && n == _computerPlayerId)
                                        {
                                            newFieldX = pos_X_PM;
                                            newFieldY = pos_Y_PM;
                                            removedFieldId = i;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (checkMoveFavorability)
                        {
                            if (!IsMoveFavorable(fieldToCheckX, fieldToCheckY, newFieldX, newFieldY, n, mostFavorableMoveOfHumanPlayer, amountOfPlayers))
                            {
                                performMove = false;
                                unfavorableFieldsX.Add(newFieldX);
                                unfavorableFieldsY.Add(newFieldY);
                            }
                        }
                    }
                    if (performMove)
                    {
                        for (int i = 0; i < computerPlayerFields.Count; i++)
                        {
                            ComputerPlayer computerPlayer = computerPlayerFields[i];
                            if (computerPlayer.Get_pos_X_CP() == fieldToCheckX && computerPlayer.Get_pos_Y_CP() == fieldToCheckY)
                            {
                                removedFieldId = i;
                            }
                        }
                        AddComputerPlayerFields(removedFieldId, newFieldX, newFieldY, n);
                    }
                    else
                    {
                        n--;
                        performMove = true;
                    }
                }
            }
            possibleMovesOfHumanPlayer.Clear();
            possibleMovesOfComputerPlayer.Clear();
            unfavorableFieldsX.Clear();
            unfavorableFieldsY.Clear();
            return (computerPlayerFields, previousFieldsOfComputerPlayer, highlightedFieldsOfComputerPlayer);
        }

        private int DifficultySetting(int n, int[] simulationDifficulty)
        {
            if (n == 0)
            {
                return simulationDifficulty[5];
            }
            if (n == 2)
            {
                return simulationDifficulty[0];
            }
            if (n == 3)
            {
                return simulationDifficulty[1];
            }
            if (n == 4)
            {
                return simulationDifficulty[2];
            }
            if (n == 5)
            {
                return simulationDifficulty[3];
            }
            if (n == 6)
            {
                return simulationDifficulty[4];
            }
            return 0;
        }

        private bool AddPlayerMove(int obtiznost, int n, int pos_X_PM, int pos_Y_PM, int pos_X_CP, int pos_Y_CP, int maxDifference)
        {
            if (obtiznost == 1)
            {
                if ((n == 0 && pos_Y_PM <= pos_Y_CP) ||
                    (n == 2 && pos_Y_PM >= pos_Y_CP) ||
                    (n == 3 && pos_X_PM > pos_X_CP && pos_Y_PM > pos_Y_CP) ||
                    (n == 4 && pos_X_PM < pos_X_CP && pos_Y_PM > pos_Y_CP) ||
                    (n == 5 && pos_X_PM > pos_X_CP && pos_Y_PM < pos_Y_CP) ||
                    (n == 6 && pos_X_PM < pos_X_CP && pos_Y_PM < pos_Y_CP))
                {
                    return true;
                }
            }
            else if (obtiznost == 2)
            {
                if ((n == 0 && pos_Y_PM < pos_Y_CP) ||
                    (n == 2 && pos_Y_PM > pos_Y_CP) ||
                    (n == 3 && pos_X_PM >= pos_X_CP && pos_Y_PM >= pos_Y_CP) ||
                    (n == 4 && pos_X_PM <= pos_X_CP && pos_Y_PM >= pos_Y_CP) ||
                    (n == 5 && pos_X_PM >= pos_X_CP && pos_Y_PM <= pos_Y_CP) ||
                    (n == 6 && pos_X_PM <= pos_X_CP && pos_Y_PM <= pos_Y_CP))
                {
                    return true;
                }
            }
            else if (obtiznost == 3)
            {
                if ((n == 3 && (pos_X_PM - pos_X_CP) + (pos_Y_PM - pos_Y_CP) > maxDifference) ||
                    (n == 4 && (pos_X_CP - pos_X_PM) + (pos_Y_PM - pos_Y_CP) > maxDifference) ||
                    (n == 5 && (pos_X_PM - pos_X_CP) + (pos_Y_CP - pos_Y_PM) > maxDifference ||
                    (n == 6 && (pos_X_CP - pos_X_PM) + (pos_Y_CP - pos_Y_PM) > maxDifference)))
                    return true;
            }
            return false;
        }

        private (int, int, int, int, int) StartingMovesPerformance(int n, int amountOfMoves, int removedFieldId, int newFieldX, int newFieldY, int fieldToCheckX, int fieldToCheckY, int firstMove, bool simulationMode)
        {
            if (n == 0)
            {
                if (amountOfMoves == 0)
                {
                    removedFieldId = 10;
                    newFieldX = leftOffset - distance;
                    newFieldY = upperOffset + distance * 12;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;
                }
                if (amountOfMoves == 1)
                {
                    removedFieldId = 11;
                    newFieldX = leftOffset + distance;
                    newFieldY = upperOffset + distance * 12;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;
                }
                if (amountOfMoves == 4)
                {
                    removedFieldId = 11;
                    newFieldX = leftOffset + distance * 2;
                    newFieldY = upperOffset + distance * 12;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;
                }
            }
            else if (n == 2)
            {
                if ((firstMove == 1 && amountOfMoves == 1 && !simulationMode) || (firstMove == 2 && amountOfMoves == 0 && !simulationMode) || (simulationMode && amountOfMoves == 0))//first move - determined in advance
                {
                    removedFieldId = 6;
                    newFieldX = leftOffset - distance;
                    newFieldY = upperOffset + distance * 4;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;
                }
                if ((firstMove == 1 && amountOfMoves == 2 && !simulationMode) || (firstMove == 2 && amountOfMoves == 1 && !simulationMode) || (simulationMode && amountOfMoves == 1))//second move - determined in advance
                {
                    removedFieldId = 8;
                    newFieldX = leftOffset + distance;
                    newFieldY = upperOffset + distance * 4;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;
                }
                if ((firstMove == 1 && amountOfMoves == 5 && !simulationMode) || (firstMove == 2 && amountOfMoves == 4 && !simulationMode) || (simulationMode && amountOfMoves == 4))//ensures that the computer player's field that's lowest on the y-axis won't be left back alone
                {
                    removedFieldId = 0;
                    newFieldX = leftOffset - distance * 2;
                    newFieldY = upperOffset + distance * 4;
                    fieldToCheckX = 0;
                    fieldToCheckY = 0;
                }
            }
            return (removedFieldId, newFieldX, newFieldY, fieldToCheckX, fieldToCheckY);
        }

        private (int, int, int, int) FinalMovesPreparation(int n, int lastRowAmount, int penultimateRowAmount, int posXLastRow, int posXPenultimateRow, int pos_X_CP, int pos_Y_CP)
        {
            if (n == 3 && pos_Y_CP == upperOffset + distance * 12 && pos_X_CP >= leftOffset + distance + 2)
            {
                lastRowAmount++;
                if (pos_X_CP < posXLastRow)
                {
                    posXLastRow = pos_X_CP;
                }
            }

            if (n == 4 && pos_Y_CP == upperOffset + distance * 12 && pos_X_CP <= leftOffset - distance - 2)
            {
                lastRowAmount++;
                if (pos_X_CP > posXLastRow)
                {
                    posXLastRow = pos_X_CP;
                }
            }

            if (n == 5 && pos_Y_CP == upperOffset + distance * 4 && pos_X_CP >= leftOffset + distance + 2)
            {
                lastRowAmount++;
                if (pos_X_CP < posXLastRow)
                {
                    posXLastRow = pos_X_CP;
                }
            }

            if (n == 6 && pos_Y_CP == upperOffset + distance * 4 && pos_X_CP <= leftOffset - distance - 2)
            {
                lastRowAmount++;
                if (pos_X_CP > posXLastRow)
                {
                    posXLastRow = pos_X_CP;
                }
            }

            if (n == 3 && pos_Y_CP == upperOffset + distance * 11 && pos_X_CP >= leftOffset + distance * 2 + distance / 2)
            {
                penultimateRowAmount++;
                if (pos_X_CP < posXPenultimateRow)
                {
                    posXPenultimateRow = pos_X_CP;
                }
            }

            if (n == 4 && pos_Y_CP == upperOffset + distance * 11 && pos_X_CP <= leftOffset - distance * 2 - distance / 2)
            {
                penultimateRowAmount++;
                if (pos_X_CP > posXPenultimateRow)
                {
                    posXPenultimateRow = pos_X_CP;
                }
            }

            if (n == 5 && pos_Y_CP == upperOffset + distance * 5 && pos_X_CP >= leftOffset + distance * 2 + distance / 2)
            {
                penultimateRowAmount++;
                if (pos_X_CP < posXPenultimateRow)
                {
                    posXPenultimateRow = pos_X_CP;
                }
            }

            if (n == 6 && pos_Y_CP == upperOffset + distance * 5 && pos_X_CP <= leftOffset - distance * 2 - distance / 2)
            {
                penultimateRowAmount++;
                if (pos_X_CP > posXPenultimateRow)
                {
                    posXPenultimateRow = pos_X_CP;
                }
            }
            return (lastRowAmount, penultimateRowAmount, posXLastRow, posXPenultimateRow);
        }

        private (int, int) OriginalPlayerMarblesCalculation(int n, int lastRowAmount, int penultimateRowAmount, int pos_X_CP, int pos_Y_CP)
        {
            if (n == 3 && pos_X_CP >= leftOffset + distance * 5 && pos_Y_CP == upperOffset + distance * 12)
            {
                lastRowAmount++;
            }
            if (n == 3 && pos_X_CP == leftOffset + distance * 4 + distance / 2 && pos_Y_CP == upperOffset + distance * 11)
            {
                penultimateRowAmount++;
            }

            if (n == 4 && pos_X_CP <= leftOffset - distance * 5 && pos_Y_CP == upperOffset + distance * 12)
            {
                lastRowAmount++;
            }
            if (n == 4 && pos_X_CP == leftOffset - distance * 4 - distance / 2 && pos_Y_CP == upperOffset + distance * 11)
            {
                penultimateRowAmount++;
            }

            if (n == 5 && pos_X_CP >= leftOffset + distance * 5 && pos_Y_CP == upperOffset + distance * 4)
            {
                lastRowAmount++;
            }
            if (n == 5 && pos_X_CP == leftOffset + distance * 4 + distance / 2 && pos_Y_CP == upperOffset + distance * 5)
            {
                penultimateRowAmount++;
            }

            if (n == 6 && pos_X_CP <= leftOffset - distance * 5 && pos_Y_CP == upperOffset + distance * 4)
            {
                lastRowAmount++;
            }
            if (n == 6 && pos_X_CP == leftOffset - distance * 4 - distance / 2 && pos_Y_CP == upperOffset + distance * 5)
            {
                penultimateRowAmount++;
            }
            return (lastRowAmount, penultimateRowAmount);
        }

        private (int, int, int, int, int) FinalMovesManagement(int n, int lastRowAmount, int penultimateRowAmount, int posXLastRow, int posXPenultimateRow, int newFieldX, int newFieldY, int removedFieldId, int jumpLengthX, int jumpLengthY, int fieldToCheckX, int fieldToCheckY)
        {
            int pos_X_CP, pos_Y_CP, pos_X_PM, pos_Y_PM;
            bool playerPerformedAJump;

            if ((lastRowAmount == 5 && penultimateRowAmount >= 3) || (lastRowAmount >= 4 && penultimateRowAmount == 4))
            {
                fieldToCheckX = 0;
                fieldToCheckY = 0;
                checkMoveFavorability = false;
                playerPerformedAJump = false;
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    ComputerPlayer computerPlayer = computerPlayerFields[i];
                    pos_X_CP = computerPlayer.Get_pos_X_CP();
                    pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                    int _computerPlayerId = computerPlayer.Get_computerPlayerId();
                    if (_computerPlayerId != n)
                    {
                        continue;
                    }

                    if (n == 3 && ((pos_X_CP == leftOffset + distance * 2 && pos_Y_CP == upperOffset + distance * 12) || (pos_X_CP == leftOffset + distance * 2 + distance / 2 && pos_Y_CP == upperOffset + distance * 11)))
                    {
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM > pos_X_CP && pos_Y_PM < pos_Y_CP && pos_Y_CP - pos_Y_PM == distance)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                            }
                        }
                    }

                    if (n == 4 && ((pos_X_CP == leftOffset - distance * 2 && pos_Y_CP == upperOffset + distance * 12) || (pos_X_CP == leftOffset - distance * 2 - distance / 2 && pos_Y_CP == upperOffset + distance * 11)))
                    {
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM < pos_X_CP && pos_Y_PM < pos_Y_CP && pos_Y_CP - pos_Y_PM == distance)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                            }
                        }
                    }

                    if (n == 5 && ((pos_X_CP == leftOffset + distance * 2 && pos_Y_CP == upperOffset + distance * 4) || (pos_X_CP == leftOffset + distance * 2 + distance / 2 && pos_Y_CP == upperOffset + distance * 5)))
                    {
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM > pos_X_CP && pos_Y_PM > pos_Y_CP && pos_Y_PM - pos_Y_CP == distance)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                            }
                        }
                    }

                    if (n == 6 && ((pos_X_CP == leftOffset - distance * 2 && pos_Y_CP == upperOffset + distance * 4) || (pos_X_CP == leftOffset - distance * 2 - distance / 2 && pos_Y_CP == upperOffset + distance * 5)))
                    {
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM < pos_X_CP && pos_Y_PM > pos_Y_CP && pos_Y_PM - pos_Y_CP == distance)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                            }
                        }
                    }
                }
            }

            //if the computer player has correctly placed his fields on the last and penultimate rows in order to finish the game, we are going to ensure that the incorrectly placed field that's located on the third row from the bottom reaches its destination
            //the movement is performed on the x-axis, the way it's performed depends on whose the given marble is (optionally if this movement isn't possible, we perform a movement directed down on the y-axis)
            if (lastRowAmount == 4 && penultimateRowAmount == 3)
            {
                fieldToCheckX = 0;
                fieldToCheckY = 0;
                checkMoveFavorability = false;
                playerPerformedAJump = false;
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    ComputerPlayer computerPlayer = computerPlayerFields[i];
                    pos_X_CP = computerPlayer.Get_pos_X_CP();
                    pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                    int _computerPlayerId = computerPlayer.Get_computerPlayerId();
                    if (_computerPlayerId != n)
                    {
                        continue;
                    }

                    //we look for a favorable move on the x-axis
                    if (n == 3 && posXLastRow == leftOffset + distance * 3 && posXPenultimateRow == leftOffset + distance * 3 + distance / 2 && pos_X_CP == leftOffset + distance * 3 && pos_Y_CP == upperOffset + distance * 10)
                    {
                        bool moveFound = false;
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM > pos_X_CP && pos_Y_PM == pos_Y_CP)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                                moveFound = true;
                            }
                        }

                        if (!moveFound)//we haven't found a favorable move on the x-axis, therefore we perform a movement directed down on the y-axis
                        {
                            possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                            for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                            {
                                PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                pos_X_PM = possibleMove.Get_pos_X_PM();
                                pos_Y_PM = possibleMove.Get_pos_Y_PM();

                                if (pos_Y_PM < pos_Y_CP && pos_X_PM > pos_X_CP)
                                {
                                    newFieldX = pos_X_PM;
                                    newFieldY = pos_Y_PM;
                                    removedFieldId = i;
                                }
                            }
                        }
                    }

                    //we look for a favorable move on the x-axis
                    if (n == 4 && posXLastRow == leftOffset - distance * 3 && posXPenultimateRow == leftOffset - distance * 3 - distance / 2 && pos_X_CP == leftOffset - distance * 3 && pos_Y_CP == upperOffset + distance * 10)
                    {
                        bool moveFound = false;
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM < pos_X_CP && pos_Y_PM == pos_Y_CP)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                                moveFound = true;
                            }
                        }

                        if (!moveFound)//tah na x-ové ose nenalezen, provedeme tedy tah směrem dolů na y-ové ose
                        {
                            possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                            for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                            {
                                PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                pos_X_PM = possibleMove.Get_pos_X_PM();
                                pos_Y_PM = possibleMove.Get_pos_Y_PM();

                                if (pos_Y_PM < pos_Y_CP && pos_X_PM < pos_X_CP)
                                {
                                    newFieldX = pos_X_PM;
                                    newFieldY = pos_Y_PM;
                                    removedFieldId = i;
                                }
                            }
                        }
                    }

                    //we look for a favorable move on the x-axis
                    if (n == 5 && posXLastRow == leftOffset + distance * 3 && posXPenultimateRow == leftOffset + distance * 3 + distance / 2 && pos_X_CP == leftOffset + distance * 3 && pos_Y_CP == upperOffset + distance * 6)
                    {
                        bool moveFound = false;
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM > pos_X_CP && pos_Y_PM == pos_Y_CP)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                                moveFound = true;
                            }
                        }

                        if (!moveFound)//we haven't found a favorable move on the x-axis, therefore we perform a movement directed down on the y-axis
                        {
                            possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                            for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                            {
                                PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                pos_X_PM = possibleMove.Get_pos_X_PM();
                                pos_Y_PM = possibleMove.Get_pos_Y_PM();

                                if (pos_Y_PM > pos_Y_CP && pos_X_PM > pos_X_CP)
                                {
                                    newFieldX = pos_X_PM;
                                    newFieldY = pos_Y_PM;
                                    removedFieldId = i;
                                }
                            }
                        }
                    }

                    //we look for a favorable move on the x-axis
                    if (n == 6 && posXLastRow == leftOffset - distance * 3 && posXPenultimateRow == leftOffset - distance * 3 - distance / 2 && pos_X_CP == leftOffset - distance * 3 && pos_Y_CP == upperOffset + distance * 6)
                    {
                        bool moveFound = false;
                        possibleMovesOfComputerPlayer.Clear();
                        possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                        for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                        {
                            PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                            pos_X_PM = possibleMove.Get_pos_X_PM();
                            pos_Y_PM = possibleMove.Get_pos_Y_PM();

                            if (pos_X_PM < pos_X_CP && pos_Y_PM == pos_Y_CP)
                            {
                                newFieldX = pos_X_PM;
                                newFieldY = pos_Y_PM;
                                removedFieldId = i;
                                moveFound = true;
                            }
                        }

                        if (!moveFound)//we haven't found a favorable move on the x-axis, therefore we perform a movement directed down on the y-axis
                        {
                            possibleMovesCalculation.AddPossibleMoves(pos_X_CP, pos_Y_CP, n, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                            for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                            {
                                PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[j];
                                pos_X_PM = possibleMove.Get_pos_X_PM();
                                pos_Y_PM = possibleMove.Get_pos_Y_PM();

                                if (pos_Y_PM > pos_Y_CP && pos_X_PM < pos_X_CP)
                                {
                                    newFieldX = pos_X_PM;
                                    newFieldY = pos_Y_PM;
                                    removedFieldId = i;
                                }
                            }
                        }
                    }
                }
            }

            //resolving a situation that happens when the computer player is being blocked by the opposite player, and all he has left to do is to move one marble to the corner that's closest to the center of the map
            if (n == 3)
            {//
                bool[] marblesLocations = { false, false, false };
                int amountOfMarbles = 0;
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    if (computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 3 + distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 9)
                    {
                        marblesLocations[2] = true;
                    }
                    if (!(computerPlayerFields[i].Get_computerPlayerId() == 3 || computerPlayerFields[i].Get_computerPlayerId() == 6))
                    {
                        continue;
                    }
                    if ((computerPlayerFields[i].Get_computerPlayerId() == 3 && IsFieldInLowerRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                        (computerPlayerFields[i].Get_computerPlayerId() == 6 && IsFieldInLowerRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), false)))
                    {
                        amountOfMarbles++;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 3 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 4 + distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 9)
                    {
                        marblesLocations[0] = true;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 3 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 3 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 10)
                    {
                        marblesLocations[1] = true;
                    }
                }
                if (amountOfMarbles == 9 && marblesLocations[0] == false)
                {
                    if (marblesLocations[1] == true && marblesLocations[2] == false)
                    {
                        newFieldX = leftOffset + distance * 3 + distance / 2;
                        newFieldY = upperOffset + distance * 9;
                    }
                }
            }
            else if (n == 4)
            {
                bool[] marblesLocations = { false, false, false };
                int amountOfMarbles = 0;
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    if (computerPlayerFields[i].Get_pos_X_CP() == leftOffset - distance * 3 - distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 9)
                    {
                        marblesLocations[2] = true;
                    }
                    if (!(computerPlayerFields[i].Get_computerPlayerId() == 4 || computerPlayerFields[i].Get_computerPlayerId() == 5))
                    {
                        continue;
                    }
                    if ((computerPlayerFields[i].Get_computerPlayerId() == 4 && IsFieldInLowerLeftCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                        (computerPlayerFields[i].Get_computerPlayerId() == 5 && IsFieldInLowerLeftCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), false)))
                    {
                        amountOfMarbles++;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 4 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset - distance * 4 - distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 9)
                    {
                        marblesLocations[0] = true;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 4 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset - distance * 3 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 10)
                    {
                        marblesLocations[1] = true;
                    }
                }
                if (amountOfMarbles == 9 && marblesLocations[0] == true)
                {
                    if (marblesLocations[1] == true && marblesLocations[2] == false)
                    {
                        newFieldX = leftOffset - distance * 3 - distance / 2;
                        newFieldY = upperOffset + distance * 9;
                    }
                }
            }
            else if (n == 5)
            {
                bool[] marblesLocations = { false, false, false };
                int amountOfMarbles = 0;
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    if (computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 3 + distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 7)
                    {
                        marblesLocations[2] = true;
                    }
                    if (!(computerPlayerFields[i].Get_computerPlayerId() == 5 || computerPlayerFields[i].Get_computerPlayerId() == 4))
                    {
                        continue;
                    }
                    if ((computerPlayerFields[i].Get_computerPlayerId() == 5 && IsFieldInUpperRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                        (computerPlayerFields[i].Get_computerPlayerId() == 4 && IsFieldInUpperRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), false)))
                    {
                        amountOfMarbles++;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 5 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 4 + distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 7)
                    {
                        marblesLocations[0] = true;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 5 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 3 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 6)
                    {
                        marblesLocations[1] = true;
                    }
                }
                if (amountOfMarbles == 9 && marblesLocations[0] == true)
                {
                    if (marblesLocations[1] == true && marblesLocations[2] == false)
                    {
                        newFieldX = leftOffset + distance * 3 + distance / 2;
                        newFieldY = upperOffset + distance * 7;
                    }
                }
            }
            else if (n == 6)
            {
                bool[] marblesLocations = { false, false, false };
                int amountOfMarbles = 0;
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    if (computerPlayerFields[i].Get_pos_X_CP() == leftOffset - distance * 3 - distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 7)
                    {
                        marblesLocations[2] = true;
                    }
                    if (!(computerPlayerFields[i].Get_computerPlayerId() == 6 || computerPlayerFields[i].Get_computerPlayerId() == 3))
                    {
                        continue;
                    }
                    if ((computerPlayerFields[i].Get_computerPlayerId() == 6 && IsFieldInUpperLeftCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                        (computerPlayerFields[i].Get_computerPlayerId() == 3 && IsFieldInUpperLeftCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), false)))
                    {
                        amountOfMarbles++;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 6 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset - distance * 4 - distance / 2 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 7)
                    {
                        marblesLocations[0] = true;
                    }
                    if (computerPlayerFields[i].Get_computerPlayerId() == 6 && computerPlayerFields[i].Get_pos_X_CP() == leftOffset + distance * 3 && computerPlayerFields[i].Get_pos_Y_CP() == upperOffset + distance * 6)
                    {
                        marblesLocations[1] = true;
                    }
                }
                if (amountOfMarbles == 9 && marblesLocations[0] == true)
                {
                    if (marblesLocations[1] == true && marblesLocations[2] == false)
                    {
                        newFieldX = leftOffset - distance * 3 - distance / 2;
                        newFieldY = upperOffset + distance * 7;
                    }
                }
            }

            return (newFieldX, newFieldY, removedFieldId, fieldToCheckX, fieldToCheckY);
        }

        private bool FulfilledConditionsForMove(int n, bool simulationMode)
        {
            if ((n == 0 && !simulationMode) || n == 1 || (amountOfPlayers == 2 && n > 2) || (amountOfPlayers == 3 && (n == 2 || n > 4)) || (amountOfPlayers == 4 && (!simulationMode && (n == 2 || n == 5) || simulationMode && (n == 0 || n == 2))))
            {
                return false;
            }
            return true;
        }

        private void CreationOfPossibleMovesOfHumanPlayer()
        {
            int pos_X_PM, pos_Y_PM, pos_X_HP, pos_Y_HP, jumpLengthX = 0, jumpLengthY = 0;
            bool playerPerformedAJump;

            for (int i = 0; i < humanPlayerFields.Count; i++)
            {
                playerPerformedAJump = false;
                HumanPlayer humanPlayer = humanPlayerFields[i];
                pos_X_HP = humanPlayer.Get_pos_X_HP();
                pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                possibleMovesCalculation.AddPossibleMoves(pos_X_HP, pos_Y_HP, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);

                for (int j = 0; j < possibleMovesOfHumanPlayer.Count; j++)
                {
                    PossibleMoveOfHumanPlayer possibleMove = possibleMovesOfHumanPlayer[j];
                    pos_X_PM = possibleMove.Get_pos_X_PM();
                    pos_Y_PM = possibleMove.Get_pos_Y_PM();

                    if (pos_Y_PM - pos_Y_HP > distance)//we are going to have to perform a jump in order to get to the checked possible move
                    {
                        playerPerformedAJump = true;
                    }
                    else
                    {
                        playerPerformedAJump = false;
                    }

                    if (playerPerformedAJump)//we got onto the checked field by a jump - so we check possible moves from this field
                    {
                        jumpLengthX = Math.Abs(possibleMove.Get_pos_X_PM() - possibleMove.Get_pos_X_PFPMHP());
                        jumpLengthY = Math.Abs(possibleMove.Get_pos_Y_PM() - possibleMove.Get_pos_Y_PFPMHP());
                        possibleMovesCalculation.AddPossibleMoves(pos_X_PM, pos_Y_PM, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                    }
                }
            }
        }

        private int CalculationOfMostFavorableMoveOfHumanPlayer(int amountOfPlayers)
        {
            int maxDifferenceHumanPlayer = 0, pos_X_HP, pos_Y_HP, pos_X_PM, pos_Y_PM, jumpLengthX = 0, jumpLengthY = 0;
            bool playerPerformedAJump;
            possibleMovesOfHumanPlayer.Clear();

            for (int i = 0; i < humanPlayerFields.Count; i++)
            {
                possibleMovesOfHumanPlayer.Clear();
                playerPerformedAJump = false;
                HumanPlayer humanPlayer = humanPlayerFields[i];
                pos_X_HP = humanPlayer.Get_pos_X_HP();
                pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                possibleMovesCalculation.AddPossibleMoves(pos_X_HP, pos_Y_HP, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);

                for (int j = 0; j < possibleMovesOfHumanPlayer.Count; j++)
                {
                    PossibleMoveOfHumanPlayer possibleMove = possibleMovesOfHumanPlayer[j];
                    pos_X_PM = possibleMove.Get_pos_X_PM();
                    pos_Y_PM = possibleMove.Get_pos_Y_PM();

                    if (Math.Abs(pos_Y_HP - pos_Y_PM) > distance || Math.Abs(pos_X_HP - pos_X_PM) > distance)//we are going to have to perform a jump in order to get to the checked possible move
                    {
                        playerPerformedAJump = true;
                    }
                    else
                    {
                        playerPerformedAJump = false;
                    }

                    if (playerPerformedAJump)//we got onto the checked field by a jump - so we check possible moves from this field
                    {
                        jumpLengthX = Math.Abs(possibleMove.Get_pos_X_PM() - possibleMove.Get_pos_X_PFPMHP());
                        jumpLengthY = Math.Abs(possibleMove.Get_pos_Y_PM() - possibleMove.Get_pos_Y_PFPMHP());
                        possibleMovesCalculation.AddPossibleMoves(pos_X_PM, pos_Y_PM, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                    }

                    if (amountOfPlayers != 4)
                    {
                        if (pos_Y_HP - pos_Y_PM > maxDifferenceHumanPlayer)//we have found a possible move that will get the human player further on the y-axis than any possible move that's been found earlier
                        {
                            maxDifferenceHumanPlayer = pos_Y_HP - pos_Y_PM;
                        }
                    }
                    else
                    {
                        if ((pos_Y_HP - pos_Y_PM) + (pos_X_PM - pos_Y_HP) > maxDifferenceHumanPlayer)//we have found a possible move that will get the human player further on the y-axis than any possible move that's been found earlier
                        {
                            maxDifferenceHumanPlayer = (pos_Y_HP - pos_Y_PM) + (pos_X_PM - pos_Y_HP);
                        }
                    }
                }
            }
            return maxDifferenceHumanPlayer;
        }
        //checks whether the computer player's given move is favorable in terms of human player's possible moves - whether by performing the given move we would allow the human player to jump further than he could before performing the given move
        private bool IsMoveFavorable(int pos_X_CP, int pos_Y_CP, int pos_X_PM, int pos_Y_PM, int computerPlayerId, int mostFavorableMoveOfHumanPlayer, int amountOfPlayers)
        {
            if (simulationMode || (pos_X_CP == 0 && pos_Y_CP == 0))
            {
                return true;
            }
            bool playerPerformedAJump;
            int pos_X_HP, pos_Y_HP, _pos_X_PM, _pos_Y_PM, jumpLengthX = 0, jumpLengthY = 0;
            possibleMovesOfHumanPlayer.Clear();
            int removedComputerPlayerFields = 0;
            bool found = false;
            for (int i = 0; i < computerPlayerFields.Count; i++)
            {
                ComputerPlayer odebiranyPocitacovyHracOld = computerPlayerFields[i];
                if (pos_X_CP == odebiranyPocitacovyHracOld.Get_pos_X_CP() && pos_Y_CP == odebiranyPocitacovyHracOld.Get_pos_Y_CP())
                {
                    removedComputerPlayerFields = i;
                    found = true;
                    computerPlayerFields.Remove(odebiranyPocitacovyHracOld);
                    break;
                }
            }
            if (!found)
            {
                return false;
            }

            ComputerPlayer addedComputerPlayerOld = new ComputerPlayer(pos_X_PM, pos_Y_PM, fieldWidth, fieldLength, computerPlayerId);
            computerPlayerFields.Add(addedComputerPlayerOld);
            for (int i = 0; i < humanPlayerFields.Count; i++)
            {
                possibleMovesOfHumanPlayer.Clear();
                playerPerformedAJump = false;
                HumanPlayer humanPlayer = humanPlayerFields[i];
                pos_X_HP = humanPlayer.Get_pos_X_HP();
                pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                possibleMovesCalculation.AddPossibleMoves(pos_X_HP, pos_Y_HP, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                for (int j = 0; j < possibleMovesOfHumanPlayer.Count; j++)
                {
                    PossibleMoveOfHumanPlayer possibleMove = possibleMovesOfHumanPlayer[j];
                    _pos_X_PM = possibleMove.Get_pos_X_PM();
                    _pos_Y_PM = possibleMove.Get_pos_Y_PM();

                    if (Math.Abs(pos_Y_HP - _pos_Y_PM) > distance || Math.Abs(pos_X_HP - _pos_X_PM) > distance)//we are going to have to perform a jump in order to get to the checked possible move
                    {
                        playerPerformedAJump = true;
                    }
                    else
                    {
                        playerPerformedAJump = false;
                    }

                    if (playerPerformedAJump)// we got onto the checked field by a jump - so we check possible moves from this field
                    {
                        jumpLengthX = Math.Abs(possibleMove.Get_pos_X_PM() - possibleMove.Get_pos_X_PFPMHP());
                        jumpLengthY = Math.Abs(possibleMove.Get_pos_Y_PM() - possibleMove.Get_pos_Y_PFPMHP());
                        possibleMovesCalculation.AddPossibleMoves(_pos_X_PM, _pos_Y_PM, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                    }

                    if ((amountOfPlayers != 4 && pos_Y_HP - _pos_Y_PM > mostFavorableMoveOfHumanPlayer) || (amountOfPlayers == 4 && (pos_Y_HP - _pos_Y_PM) + (_pos_X_PM - pos_Y_HP) > mostFavorableMoveOfHumanPlayer))
                    {
                        possibleMovesOfHumanPlayer.Clear();
                        computerPlayerFields.Remove(addedComputerPlayerOld);
                        ComputerPlayer addedComputerPlayerNew = new ComputerPlayer(pos_X_CP, pos_Y_CP, fieldWidth, fieldLength, computerPlayerId);
                        computerPlayerFields.Insert(removedComputerPlayerFields, addedComputerPlayerNew);
                        CreationOfPossibleMovesOfHumanPlayer();
                        return false;
                    }
                }
            }

            possibleMovesOfHumanPlayer.Clear();
            computerPlayerFields.Remove(addedComputerPlayerOld);
            ComputerPlayer addedComputerPlayerNew2 = new ComputerPlayer(pos_X_CP, pos_Y_CP, fieldWidth, fieldLength, computerPlayerId);
            computerPlayerFields.Insert(removedComputerPlayerFields, addedComputerPlayerNew2);
            CreationOfPossibleMovesOfHumanPlayer();
            return true;
        }

        private void AddComputerPlayerFields(int removedFieldId, int newFieldX, int newFieldY, int computerPlayerId)
        {
            if (newFieldX == 0 && newFieldY == 0)//this error can happen when the target fields of the given computer player are being blocked by a player that spawned on these fields
            {
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    if (computerPlayerFields[i].Get_computerPlayerId() == computerPlayerId)
                    {
                        if ((computerPlayerId == 0 && !IsFieldInHighestCorner(computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                            (computerPlayerId == 2 && !IsFieldInLowestCorner(computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                            (computerPlayerId == 3 && !IsFieldInLowerRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                            (computerPlayerId == 4 && !IsFieldInLowerLeftCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                            (computerPlayerId == 5 && !IsFieldInUpperRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)) ||
                            (computerPlayerId == 6 && !IsFieldInUpperLeftCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), true)))
                        {
                            for (int j = 0; j < possibleMovesOfComputerPlayer.Count; j++)
                            {
                                if (possibleMovesOfComputerPlayer[j].Get_pos_X_PFPMCP() == computerPlayerFields[i].Get_pos_X_CP() && possibleMovesOfComputerPlayer[j].Get_pos_Y_PFPMCP() == computerPlayerFields[i].Get_pos_Y_CP())
                                {
                                    AddComputerPlayerFields(i, possibleMovesOfComputerPlayer[j].Get_pos_X_PM(), possibleMovesOfComputerPlayer[j].Get_pos_Y_PM(), computerPlayerId);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                checkMoveFavorability = true;
                ComputerPlayer oldComputerPlayer = computerPlayerFields[removedFieldId];
                int playerId = oldComputerPlayer.Get_computerPlayerId();
                PreviousFieldOfComputerPlayer pole = new PreviousFieldOfComputerPlayer(oldComputerPlayer.Get_pos_X_CP(), oldComputerPlayer.Get_pos_Y_CP(), fieldWidth, fieldLength, oldComputerPlayer.Get_computerPlayerId());
                previousFieldsOfComputerPlayer.Add(pole);
                computerPlayerFields.Remove(oldComputerPlayer);
                ComputerPlayer newComputerPlayer = new ComputerPlayer(newFieldX, newFieldY, fieldWidth, fieldLength, playerId);
                computerPlayerFields.Add(newComputerPlayer);
                HighlightedFieldOfComputerPlayer zvyrazneni = new HighlightedFieldOfComputerPlayer(newFieldX, newFieldY, fieldWidth, fieldLength);
                highlightedFieldsOfComputerPlayer.Add(zvyrazneni);
            }
        }

        private bool IsFieldInHighestCorner(int pos_Y_CP, bool checkTheEntireTriangle)
        {
            if (checkTheEntireTriangle)
            {
                if (pos_Y_CP > upperOffset + distance * 3)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (pos_Y_CP <= upperOffset + distance)
                {
                    return true;
                }
                return false;
            }

        }

        private bool IsFieldInLowestCorner(int pos_Y_CP, bool checkTheEntireTriangle)
        {
            if (checkTheEntireTriangle)
            {
                if (pos_Y_CP < upperOffset + distance * 13)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (pos_Y_CP >= upperOffset + distance * 15)
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsFieldInLowerLeftCorner(int pos_X_CP, int pos_Y_CP, bool checkTheEntireTriangle)
        {
            if (checkTheEntireTriangle)
            {
                if ((pos_Y_CP <= upperOffset + distance * 8) || (pos_Y_CP >= upperOffset + distance * 13) || (pos_Y_CP == distance * 9 + upperOffset && pos_X_CP > leftOffset - distance * 4 - distance / 2) || (pos_Y_CP == distance * 10 + upperOffset && pos_X_CP > leftOffset - distance * 4) || (pos_Y_CP == distance * 11 + upperOffset && pos_X_CP > leftOffset - distance * 3 - distance / 2) || (pos_Y_CP == distance * 12 + upperOffset && pos_X_CP > leftOffset - distance * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((pos_Y_CP == distance * 11 + upperOffset && pos_X_CP == leftOffset - distance * 5 - distance / 2) || (pos_Y_CP == distance * 12 + upperOffset && pos_X_CP <= leftOffset - distance * 5))
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsFieldInUpperRightCorner(int pos_X_CP, int pos_Y_CP, bool checkTheEntireTriangle)
        {
            if (checkTheEntireTriangle)
            {
                if ((pos_Y_CP >= upperOffset + distance * 8) || (pos_Y_CP <= upperOffset + distance * 3) || (pos_Y_CP == upperOffset + distance * 7 && pos_X_CP < leftOffset + distance * 4 + distance / 2) || (pos_Y_CP == upperOffset + distance * 6 && pos_X_CP < leftOffset + distance * 4) || (pos_Y_CP == upperOffset + distance * 5 && pos_X_CP < leftOffset + distance * 3 + distance / 2) || (pos_Y_CP == upperOffset + distance * 4 && pos_X_CP < leftOffset + distance * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((pos_Y_CP == distance * 5 + upperOffset && pos_X_CP == leftOffset + distance * 5 + distance / 2) || (pos_Y_CP == distance * 4 + upperOffset && pos_X_CP >= leftOffset + distance * 5))
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsFieldInLowerRightCorner(int pos_X_CP, int pos_Y_CP, bool checkTheEntireTriangle)
        {
            if (checkTheEntireTriangle)
            {
                if ((pos_Y_CP <= upperOffset + distance * 8) || (pos_Y_CP >= upperOffset + distance * 13) || (pos_Y_CP == distance * 9 + upperOffset && pos_X_CP < leftOffset + distance * 4 + distance / 2) || (pos_Y_CP == distance * 10 + upperOffset && pos_X_CP < leftOffset + distance * 4) || (pos_Y_CP == distance * 11 + upperOffset && pos_X_CP < leftOffset + distance * 3 + distance / 2) || (pos_Y_CP == distance * 12 + upperOffset && pos_X_CP < leftOffset + distance * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((pos_Y_CP == distance * 11 + upperOffset && pos_X_CP == leftOffset + distance * 5 + distance / 2) || (pos_Y_CP == distance * 12 + upperOffset && pos_X_CP >= leftOffset + distance * 5))
                {
                    return true;
                }
                return false;
            }
        }

        private bool IsFieldInUpperLeftCorner(int pos_X_CP, int pos_Y_CP, bool checkTheEntireTriangle)
        {
            if (checkTheEntireTriangle)
            {
                if ((pos_Y_CP >= upperOffset + distance * 8) || (pos_Y_CP <= upperOffset + distance * 3) || (pos_Y_CP == upperOffset + distance * 7 && pos_X_CP > leftOffset - distance * 4 - distance / 2) || (pos_Y_CP == upperOffset + distance * 6 && pos_X_CP > leftOffset - distance * 4) || (pos_Y_CP == upperOffset + distance * 5 && pos_X_CP > leftOffset - distance * 3 - distance / 2) || (pos_Y_CP == upperOffset + distance * 4 && pos_X_CP > leftOffset - distance * 3))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((pos_Y_CP == distance * 5 - upperOffset && pos_X_CP == leftOffset - distance * 5 - distance / 2) || (pos_Y_CP == distance * 4 + upperOffset && pos_X_CP <= leftOffset - distance * 5))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
