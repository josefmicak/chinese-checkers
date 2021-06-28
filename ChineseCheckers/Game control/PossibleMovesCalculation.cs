using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCheckers.Forms;
using ChineseCheckers.Game_entities;

namespace ChineseCheckers.Game_control
{
    class PossibleMovesCalculation
    {
        private int fieldWidth;
        private int fieldLength;
        private int distance;
        private int upperOffset;
        private int leftOffset;
        private List<Field> gameFields = new List<Field>();

        public PossibleMovesCalculation(int fieldWidth, int fieldLength, int distance, int upperOffset, int leftOffset, List<Field> gameFields)
        {
            this.fieldWidth = fieldWidth;
            this.fieldLength = fieldLength;
            this.distance = distance;
            this.gameFields = gameFields;
            this.upperOffset = upperOffset;
            this.leftOffset = leftOffset;
        }

        public (List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer) AddPossibleMoves(int pos_X_SF, int pos_Y_SF, int playerId, int amountOfPlayers, bool playerPerformedAJump, int jumpLengthX, int jumpLengthY, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer)
        {
            int pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_CP, pos_Y_CP;

            if (!playerPerformedAJump)
            {
                jumpLengthX = 0;
                jumpLengthY = 0;
            }

            for (int i = 0; i < gameFields.Count; i++)
            {
                Field f = gameFields[i];
                pos_X_F = f.Get_pos_X_F();
                pos_Y_F = f.Get_pos_Y_F();

                //first of all we have to restrict access to all triangles besides the starting (spawn) triangle and the destination triangle
                if (isMoveInvalid(playerId, amountOfPlayers, pos_X_F, pos_Y_F))
                {
                    continue;
                }

                //handles adding possible moves of fields that are neighboring the given field
                if (ConditionsFulfilledNeighboringField(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump))
                {
                    if (playerId == 1)
                    {
                        PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                        possibleMovesOfHumanPlayer.Add(move);
                    }
                    else
                    {
                        PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                        possibleMovesOfComputerPlayer.Add(move);
                    }
                }

                //handles adding possible moves reachable by jumping on the horizontal axis
                for (int j = 0; j < humanPlayerFields.Count; j++)
                {
                    HumanPlayer humanPlayer = humanPlayerFields[j];
                    pos_X_HP = humanPlayer.Get_pos_X_HP();
                    pos_Y_HP = humanPlayer.Get_pos_Y_HP();

                    if (ConditionsFulfilledHorizontalAxis(pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump))
                    {
                        if (playerId == 1)
                        {
                            PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                            possibleMovesOfHumanPlayer.Add(move);
                        }
                        else
                        {
                            PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                            possibleMovesOfComputerPlayer.Add(move);
                        }
                    }
                }

                //handles adding possible moves reachable by jumping on the horizontal axis - computer player
                for (int j = 0; j < computerPlayerFields.Count; j++)
                {
                    ComputerPlayer computerPlayer = computerPlayerFields[j];
                    pos_X_CP = computerPlayer.Get_pos_X_CP();
                    pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                    if (ConditionsFulfilledHorizontalAxis(pos_X_CP, pos_Y_CP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump))
                    {
                        if (playerId == 1)
                        {
                            PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                            possibleMovesOfHumanPlayer.Add(move);
                        }
                        else
                        {
                            PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                            possibleMovesOfComputerPlayer.Add(move);
                        }
                    }
                }

                //handles adding possible moves reachable by jumping in the 4 remaining directions
                for (int j = 0; j < humanPlayerFields.Count; j++)
                {
                    HumanPlayer humanPlayer = humanPlayerFields[j];
                    pos_X_HP = humanPlayer.Get_pos_X_HP();
                    pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                    if (ConditionsFulfilledFirstJumps(pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump))
                    {
                        if (playerId == 1)
                        {
                            PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                            possibleMovesOfHumanPlayer.Add(move);
                        }
                        else
                        {
                            PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                            possibleMovesOfComputerPlayer.Add(move);
                        }
                    }
                }

                //handles adding possible moves reachable by jumping in the 4 remaining directions - computer player
                for (int j = 0; j < computerPlayerFields.Count; j++)
                {
                    ComputerPlayer computerPlayer = computerPlayerFields[j];
                    pos_X_CP = computerPlayer.Get_pos_X_CP();
                    pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                    if (ConditionsFulfilledFirstJumps(pos_X_CP, pos_Y_CP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump))
                    {
                        if (playerId == 1)
                        {
                            PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                            possibleMovesOfHumanPlayer.Add(move);
                        }
                        else
                        {
                            PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                            possibleMovesOfComputerPlayer.Add(move);
                        }
                    }
                }
                //the remaining part of this function handles possible moves that become available after the player jumps (in a given move the player can always jump a distance that is equal to the distance of the first jump)
                //the player performed a jump forward or backward on the y-axis
                if (playerPerformedAJump && jumpLengthY != 0)
                {
                    if (pos_Y_F == pos_Y_SF)//the field that's being checked right now and the field that the player's selected are at the same y-axis coordinates
                    {
                        for (int j = 0; j < humanPlayerFields.Count; j++)
                        {
                            HumanPlayer humanPlayer = humanPlayerFields[j];
                            pos_X_HP = humanPlayer.Get_pos_X_HP();
                            pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                            if (ConditionsFulfilledJumpAtTheSameCoordinatesOnBothAxis(pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX, jumpLengthY))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }

                        for (int j = 0; j < computerPlayerFields.Count; j++)
                        {
                            ComputerPlayer computerPlayer = computerPlayerFields[j];
                            pos_X_CP = computerPlayer.Get_pos_X_CP();
                            pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                            if (ConditionsFulfilledJumpAtTheSameCoordinatesOnBothAxis(pos_X_CP, pos_Y_CP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX, jumpLengthY))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }
                    }
                    else//the field that's being checked right now and the field that the player's selected are not at the same y-axis coordinates
                    {
                        for (int j = 0; j < humanPlayerFields.Count; j++)
                        {
                            HumanPlayer humanPlayer = humanPlayerFields[j];
                            pos_X_HP = humanPlayer.Get_pos_X_HP();
                            pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                            if (ConditionsFulfilledJumpAtDifferentCoordinatesOnBothAxis(pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX, jumpLengthY))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }

                        for (int j = 0; j < computerPlayerFields.Count; j++)
                        {
                            ComputerPlayer computerPlayer = computerPlayerFields[j];
                            pos_X_CP = computerPlayer.Get_pos_X_CP();
                            pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                            if (ConditionsFulfilledJumpAtDifferentCoordinatesOnBothAxis(pos_X_CP, pos_Y_CP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX, jumpLengthY))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }
                    }
                }

                //the player performed a jump on the vertical axis
                if (playerPerformedAJump && jumpLengthY == 0)
                {
                    if (pos_Y_F == pos_Y_SF)//the field that's being checked right now and the field that the player's selected are at the same y-axis coordinates
                    {
                        for (int j = 0; j < humanPlayerFields.Count; j++)
                        {
                            HumanPlayer humanPlayer = humanPlayerFields[j];
                            pos_X_HP = humanPlayer.Get_pos_X_HP();
                            pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                            if (ConditionsFulfilledJumpAtTheSameCoordinatesOnOneAxis(pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }

                        for (int j = 0; j < computerPlayerFields.Count; j++)
                        {
                            ComputerPlayer computerPlayer = computerPlayerFields[j];
                            pos_X_CP = computerPlayer.Get_pos_X_CP();
                            pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                            if (ConditionsFulfilledJumpAtTheSameCoordinatesOnOneAxis(pos_X_CP, pos_Y_CP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }
                    }
                    else//the field that's being checked right now and the field that the player's selected are not at the same y-axis coordinates
                    {
                        for (int j = 0; j < humanPlayerFields.Count; j++)
                        {
                            HumanPlayer humanPlayer = humanPlayerFields[j];
                            pos_X_HP = humanPlayer.Get_pos_X_HP();
                            pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                            if (ConditionsFulfilledJumpAtDifferentCoordinatesOnOneAxis(pos_X_HP, pos_Y_HP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }

                        for (int j = 0; j < computerPlayerFields.Count; j++)
                        {
                            ComputerPlayer computerPlayer = computerPlayerFields[j];
                            pos_X_CP = computerPlayer.Get_pos_X_CP();
                            pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                            if (ConditionsFulfilledJumpAtDifferentCoordinatesOnOneAxis(pos_X_CP, pos_Y_CP, pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, playerPerformedAJump, jumpLengthX))
                            {
                                if (playerId == 1)
                                {
                                    PossibleMoveOfHumanPlayer move = new PossibleMoveOfHumanPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, fieldWidth, fieldLength);
                                    possibleMovesOfHumanPlayer.Add(move);
                                }
                                else
                                {
                                    PossibleMoveOfComputerPlayer move = new PossibleMoveOfComputerPlayer(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId);
                                    possibleMovesOfComputerPlayer.Add(move);
                                }
                            }
                        }
                    }
                }
            }
            return (possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
        }

        private bool IsMoveDuplicate(int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer)//checks whether the possible move is duplicate (if there is already an identical possible move located at the field)
        {
            int pos_X_PM, pos_Y_PM, _pos_X_SF, _pos_Y_SF;
            if (playerId == 1)
            {
                for (int i = 0; i < possibleMovesOfHumanPlayer.Count; i++)
                {
                    PossibleMoveOfHumanPlayer possibleMove = possibleMovesOfHumanPlayer[i];
                    pos_X_PM = possibleMove.Get_pos_X_PM();
                    pos_Y_PM = possibleMove.Get_pos_Y_PM();
                    _pos_X_SF = possibleMove.Get_pos_X_PFPMHP();
                    _pos_Y_SF = possibleMove.Get_pos_Y_PFPMHP();
                    if (pos_X_F == pos_X_PM && pos_Y_F == pos_Y_PM && pos_X_SF == _pos_X_SF && pos_Y_SF == _pos_Y_SF)//we have found a possible move whose coordinates are identical to the coordinates of the possible move that we were about to create
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < possibleMovesOfComputerPlayer.Count; i++)
                {
                    PossibleMoveOfComputerPlayer possibleMove = possibleMovesOfComputerPlayer[i];
                    pos_X_PM = possibleMove.Get_pos_X_PM();
                    pos_Y_PM = possibleMove.Get_pos_Y_PM();
                    _pos_X_SF = possibleMove.Get_pos_X_PFPMCP();
                    _pos_Y_SF = possibleMove.Get_pos_Y_PFPMCP();
                    if (pos_X_F == pos_X_PM && pos_Y_F == pos_Y_PM && pos_X_SF == _pos_X_SF && pos_Y_SF == _pos_Y_SF)//we have found a possible move whose coordinates are identical to the coordinates of the possible move that we were about to create
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private bool JeHracovoPole(int pos_X_F, int pos_Y_F, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields)//checks whether there's any player's field located within the given field
        {
            int pos_X_HP, pos_Y_HP, pos_X_CP, pos_Y_CP;
            for (int i = 0; i < humanPlayerFields.Count; i++)
            {
                HumanPlayer humanPlayer = humanPlayerFields[i];
                pos_X_HP = humanPlayer.Get_pos_X_HP();
                pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                if (pos_X_F == pos_X_HP && pos_Y_F == pos_Y_HP)//we have found a human player's field whose coordinates are identical to the given coordinates
                {
                    return true;
                }
            }

            for (int i = 0; i < computerPlayerFields.Count; i++)
            {
                ComputerPlayer computerPlayer = computerPlayerFields[i];
                pos_X_CP = computerPlayer.Get_pos_X_CP();
                pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                if (pos_X_F == pos_X_CP && pos_Y_F == pos_Y_CP)//we have found a computer player's field whose coordinates are identical to the given coordinates
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoMorePlayerFieldsExist(int pos_X_SF, int pos_Y_SF, int pos_X_F, int pos_Y_F, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields)//checks that there's exactly one human or computer player's field between the two given fields
        {
            int pos_X_HP, pos_Y_HP, pos_X_CP, pos_Y_CP, amount = 0;
            //we divide the function into 6 parts (there are 6 possible directions)
            if (pos_Y_F < pos_Y_SF)//the field that's being checked right now is lower than the field that the player's selected on the y-axis
            {
                if (pos_X_SF > pos_X_F)//the field that's being checked right now is lower than the field that the player's selected on the x-axis (direction - up + left)
                {
                    for (int i = 0; i < humanPlayerFields.Count; i++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[i];
                        pos_X_HP = humanPlayer.Get_pos_X_HP();
                        pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                        //1st condition: the distance between the field that's being checked right now and the field that the human player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the human player's selected on the y-axis
                        //2nd condition: the checked field is lower than the human player's field that's being checked right now on the y-axis
                        //3rd condition: the human player's field that's being checked right now is lower than the human player's selected field on the x-axis
                        if (((pos_X_SF - pos_X_HP) * 2) == (pos_Y_SF - pos_Y_HP) && (pos_Y_F < pos_Y_HP) && (pos_X_HP < pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        //1st condition: the distance between the field that's being checked right now and the field that the computer player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the computer player's selected on the y-axis
                        //2nd condition: the checked field is lower than the computer player's field that's being checked right now on the y-axis
                        //3rd condition: the computer player's field that's being checked right now is lower than the computer player's selected field on the x-axis
                        if (((pos_X_SF - pos_X_CP) * 2) == (pos_Y_SF - pos_Y_CP) && (pos_Y_F < pos_Y_CP) && (pos_X_CP < pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    if (amount == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else//the field that's being checked right now is higher than the field that the player's selected on the x-axis (direction - up + right)
                {
                    for (int i = 0; i < humanPlayerFields.Count; i++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[i];
                        pos_X_HP = humanPlayer.Get_pos_X_HP();
                        pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                        //1st condition: the distance between the field that's being checked right now and the field that the human player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the human player's selected on the y-axis
                        //2nd condition: the checked field is lower than the human player's field that's being checked right now on the y-axis
                        //3rd condition: the human player's field that's being checked right now is higher than the human player's selected field on the x-axis
                        if (((pos_X_HP - pos_X_SF) * 2) == (pos_Y_SF - pos_Y_HP) && (pos_Y_F < pos_Y_HP) && (pos_X_HP > pos_X_SF))
                        {
                            amount++;
                        }
                    }
                    
                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        //1st condition: the distance between the field that's being checked right now and the field that the computer player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the computer player's selected on the y-axis
                        //2nd condition: the checked field is lower than the computer player's field that's being checked right now on the y-axis
                        //3rd condition: the computer player's field that's being checked right now is higher than the computer player's selected field on the x-axis
                        if (((pos_X_CP - pos_X_SF) * 2) == (pos_Y_SF - pos_Y_CP) && (pos_Y_F < pos_Y_CP) && (pos_X_CP > pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    if (amount == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (pos_Y_F > pos_Y_SF)//the field that's being checked right now is higher than the field that the player's selected on the y-axis (direction - down)
            {
                if (pos_X_SF > pos_X_F)//the field that's being checked right now is lower than the field that the player's selected on the x-axis (direction - down + left)
                {
                    for (int i = 0; i < humanPlayerFields.Count; i++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[i];
                        pos_X_HP = humanPlayer.Get_pos_X_HP();
                        pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                        //1st condition: the distance between the field that's being checked right now and the field that the human player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the human player's selected on the y-axis
                        //2nd condition: the checked field is higher than the human player's field that's being checked right now on the y-axis
                        //3rd condition: the human player's field that's being checked right now is lower than the human player's selected field on the x-axis
                        if (((pos_X_SF - pos_X_HP) * 2) == (pos_Y_HP - pos_Y_SF) && (pos_Y_F > pos_Y_HP) && (pos_X_HP < pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        //1st condition: the distance between the field that's being checked right now and the field that the computer player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the computer player's selected on the y-axis
                        //2nd condition: the checked field is higher than the computer player's field that's being checked right now on the y-axis
                        //3rd condition: the computer player's field that's being checked right now is lower than the computer player's selected field on the x-axis
                        if (((pos_X_SF - pos_X_CP) * 2) == (pos_Y_CP - pos_Y_SF) && (pos_Y_F > pos_Y_CP) && (pos_X_CP < pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    if (amount == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else//the field that's being checked right now is higher than the field that the player's selected on the x-axis (direction - down + right)
                {
                    for (int i = 0; i < humanPlayerFields.Count; i++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[i];
                        pos_X_HP = humanPlayer.Get_pos_X_HP();
                        pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                        //1st condition: the distance between the field that's being checked right now and the field that the human player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the human player's selected on the y-axis
                        //2nd condition: the checked field is higher than the human player's field that's being checked right now on the y-axis
                        //3rd condition: the human player's field that's being checked right now is higher than the human player's selected field on the x-axis
                        if (((pos_X_HP - pos_X_SF) * 2) == (pos_Y_HP - pos_Y_SF) && (pos_Y_F > pos_Y_HP) && (pos_X_HP > pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        //1st condition: the distance between the field that's being checked right now and the field that the computer player's selected on the x-axis is two times lower than the distance between the field that's being checked right now and the field that the computer player's selected on the y-axis
                        //2nd condition: the checked field is higher than the computer player's field that's being checked right now on the y-axis
                        //3rd condition: the computer player's field that's being checked right now is higher than the computer player's selected field on the x-axis
                        if (((pos_X_CP - pos_X_SF) * 2) == (pos_Y_CP - pos_Y_SF) && (pos_Y_F > pos_Y_CP) && (pos_X_CP > pos_X_SF))
                        {
                            amount++;
                        }
                    }

                    if (amount == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else//the field that's being checked right now is at the same coordinates as the field that the player's selected on the y-axis (direction - left/right)
            {
                if (pos_X_SF > pos_X_F)//the field that's being checked right now is lower than the field that the player's selected on the x-axis (direction - left)
                {
                    for (int i = 0; i < humanPlayerFields.Count; i++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[i];
                        pos_X_HP = humanPlayer.Get_pos_X_HP();
                        pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                        //1st condition: ověřované pole je na y-ové ose na stejné výši jako právě procházené hráčovo pole
                        //2nd condition: právě procházené hráčovo pole je na x-ové souřadnici níže než kliknuté hráčovo pole
                        //3rd condition: právě procházené hráčovo pole je na x-ové souřadnici výše než ověřované pole
                        if ((pos_Y_F == pos_Y_HP) && (pos_X_HP < pos_X_SF) && (pos_X_HP > pos_X_F))
                        {
                            amount++;
                        }
                    }

                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        //1st condition: ověřované pole je na y-ové ose na stejné výši jako právě procházené nepřítelovo pole
                        //2nd condition: právě procházené nepřítelovo pole je na x-ové souřadnici níže než kliknuté hráčovo pole
                        //3rd condition: právě procházené nepřítelovo pole je na x-ové souřadnici výše než ověřované pole
                        if ((pos_Y_F == pos_Y_CP) && (pos_X_CP < pos_X_SF) && (pos_X_CP > pos_X_F))
                        {
                            amount++;
                        }
                    }

                    if (amount == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else//the field that's being checked right now is higher than the field that the player's selected on the x-axis (direction - right)
                {
                    for (int i = 0; i < humanPlayerFields.Count; i++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[i];
                        pos_X_HP = humanPlayer.Get_pos_X_HP();
                        pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                        //1st condition: the checked field is at the same coordinates as the human player's field that's being checked right now on the y-axis
                        //2nd condition: the human player's field that's being checked right now is higher than the human player's selected field on the x-axis
                        //3rd condition: the human player's field that's being checked right now is lower than the checked field on the x-axis
                        if ((pos_Y_F == pos_Y_HP) && (pos_X_HP > pos_X_SF) && (pos_X_HP < pos_X_F))
                        {
                            amount++;
                        }
                    }

                    for (int i = 0; i < computerPlayerFields.Count; i++)
                    {
                        ComputerPlayer computerPlayer = computerPlayerFields[i];
                        pos_X_CP = computerPlayer.Get_pos_X_CP();
                        pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                        //1st condition: the checked field is at the same coordinates as the computer player's field that's being checked right now on the y-axis
                        //2nd condition: the computer player's field that's being checked right now is higher than the computer player's selected field on the x-axis
                        //3rd condition: the computer player's field that's being checked right now is lower than the checked field on the x-axis
                        if ((pos_Y_F == pos_Y_CP) && (pos_X_CP > pos_X_SF) && (pos_X_CP < pos_X_F))
                        {
                            amount++;
                        }
                    }

                    if (amount == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private bool isMoveInvalid(int playerId, int amountOfPlayers, int pos_X_F, int pos_Y_F)
        {
            if (((playerId == 0 || playerId == 2 || (playerId == 1 && amountOfPlayers != 4)) && (MoveToBothUpperCorners(pos_X_F, pos_Y_F) || MoveToBothLowerCorners(pos_X_F, pos_Y_F))) ||
                (playerId == 3 && (MoveToMostLowerAndMostUpperCorner(pos_Y_F) || MoveToUpperRightCorner(pos_X_F, pos_Y_F) || MoveToLowerLeftCorner(pos_X_F, pos_Y_F))) ||
                (playerId == 4 && (MoveToMostLowerAndMostUpperCorner(pos_Y_F) || MoveToUpperLeftCorner(pos_X_F, pos_Y_F) || MoveToLowerRightCorner(pos_X_F, pos_Y_F))) ||
                ((playerId == 5 || (playerId == 1 && amountOfPlayers == 4)) && (MoveToMostLowerAndMostUpperCorner(pos_Y_F) || MoveToUpperLeftCorner(pos_X_F, pos_Y_F) || MoveToLowerRightCorner(pos_X_F, pos_Y_F))) ||
                ((playerId == 6) && (MoveToMostLowerAndMostUpperCorner(pos_Y_F) || MoveToUpperRightCorner(pos_X_F, pos_Y_F) || MoveToLowerLeftCorner(pos_X_F, pos_Y_F))))
            {
                return true;
            }
            return false;
        }

        private bool MoveToBothLowerCorners(int pos_X_PM, int pos_Y_PM)
        {
            if ((pos_Y_PM <= upperOffset + distance * 8) || (pos_Y_PM >= upperOffset + distance * 13) || (pos_Y_PM == upperOffset + distance * 9 && pos_X_PM != leftOffset - distance * 4 - distance / 2 && pos_X_PM != leftOffset + distance * 4 + distance / 2) || (pos_Y_PM == upperOffset + distance * 10 && pos_X_PM > leftOffset - distance * 4 && pos_X_PM < leftOffset + distance * 4) || (pos_Y_PM == upperOffset + distance * 11 && pos_X_PM > leftOffset - distance * 3 - distance / 2 && pos_X_PM < leftOffset + distance * 3 + distance / 2) || (pos_Y_PM == upperOffset + distance * 12 && pos_X_PM > leftOffset - distance * 3 && pos_X_PM < leftOffset + distance * 3))
            {
                return false;
            }
            return true;
        }

        private bool MoveToBothUpperCorners(int pos_X_PM, int pos_Y_PM)
        {
            if ((pos_Y_PM >= upperOffset + distance * 8) || (pos_Y_PM <= upperOffset + distance * 3) || (pos_Y_PM == upperOffset + distance * 7 && pos_X_PM != leftOffset - distance * 4 - distance / 2 && pos_X_PM != leftOffset + distance * 4 + distance / 2) || (pos_Y_PM == upperOffset + distance * 6 && pos_X_PM > leftOffset - distance * 4 && pos_X_PM < leftOffset + distance * 4) || (pos_Y_PM == upperOffset + distance * 5 && pos_X_PM > leftOffset - distance * 3 - distance / 2 && pos_X_PM < leftOffset + distance * 3 + distance / 2) || (pos_Y_PM == upperOffset + distance * 4 && pos_X_PM > leftOffset - distance * 3 && pos_X_PM < leftOffset + distance * 3))
            {
                return false;
            }
            return true;
        }

        private bool MoveToMostLowerAndMostUpperCorner(int pos_Y_PM)
        {
            if (pos_Y_PM <= upperOffset + distance * 13 || pos_Y_PM >= upperOffset + distance * 3)
            {
                return false;
            }
            return true;
        }

        private bool MoveToLowerLeftCorner(int pos_X_PM, int pos_Y_PM)
        {
            if ((pos_Y_PM <= upperOffset + distance * 8) || (pos_Y_PM == distance * 9 + upperOffset && pos_X_PM > leftOffset - distance * 4 - distance / 2) || (pos_Y_PM == distance * 10 + upperOffset && pos_X_PM > leftOffset - distance * 4) || (pos_Y_PM == distance * 11 + upperOffset && pos_X_PM > leftOffset - distance * 3 - distance / 2) || (pos_Y_PM == distance * 12 + upperOffset && pos_X_PM > leftOffset - distance * 3))
            {
                return false;
            }
            return true;
        }

        private bool MoveToUpperRightCorner(int pos_X_PM, int pos_Y_PM)
        {
            if ((pos_Y_PM >= upperOffset + distance * 8) || (pos_Y_PM == upperOffset + distance * 7 && pos_X_PM < leftOffset + distance * 4 + distance / 2) || (pos_Y_PM == upperOffset + distance * 6 && pos_X_PM < leftOffset + distance * 4) || (pos_Y_PM == upperOffset + distance * 5 && pos_X_PM < leftOffset + distance * 3 + distance / 2) || (pos_Y_PM == upperOffset + distance * 4 && pos_X_PM < leftOffset + distance * 3))
            {
                return false;
            }
            return true;
        }

        private bool MoveToLowerRightCorner(int pos_X_PM, int pos_Y_PM)
        {
            if ((pos_Y_PM <= upperOffset + distance * 8) || (pos_Y_PM == distance * 9 + upperOffset && pos_X_PM < leftOffset + distance * 4 + distance / 2) || (pos_Y_PM == distance * 10 + upperOffset && pos_X_PM < leftOffset + distance * 4) || (pos_Y_PM == distance * 11 + upperOffset && pos_X_PM < leftOffset + distance * 3 + distance / 2) || (pos_Y_PM == distance * 12 + upperOffset && pos_X_PM < leftOffset + distance * 3))
            {
                return false;
            }
            return true;
        }

        private bool MoveToUpperLeftCorner(int pos_X_PM, int pos_Y_PM)
        {
            if ((pos_Y_PM >= upperOffset + distance * 8) || (pos_Y_PM == upperOffset + distance * 7 && pos_X_PM > leftOffset - distance * 4 - distance / 2) || (pos_Y_PM == upperOffset + distance * 6 && pos_X_PM > leftOffset - distance * 4) || (pos_Y_PM == upperOffset + distance * 5 && pos_X_PM > leftOffset - distance * 3 - distance / 2) || (pos_Y_PM == upperOffset + distance * 4 && pos_X_PM > leftOffset - distance * 3))
            {
                return false;
            }
            return true;
        }


        //1st condition: the distance between the selected player's field and the field that's being checked right now is not higher than the given offset between fields (on y-axis)
        //2nd condition: the distance between the selected player's field and the field that's being checked right now is not higher than the given offset between fields (on x-axis)
        //3rd condition: the move is not duplicate (there's not an identical possible move on the given field)
        //4th condition: there's not any human or computer player's field on the given field
        //5th condition: the player did not perform a jump during his move
        private bool ConditionsFulfilledNeighboringField(int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump)
        {
            if (Math.Abs(pos_Y_SF - pos_Y_F) <= distance && (Math.Abs(pos_X_SF - pos_X_F) <= distance) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !playerPerformedAJump)
            {
                return true;
            }
            return false;
        }

        //1st condition: the distance between the player's selected field and the player's field that's being checked right now is equal to the distance between the player's field that's being checked right now and the field that's being checked right now
        //2nd condition: the selected player's field and the player's field that's being checked right now are on the same axis
        //3rd condition: the selected player's field and the field that's being checked right now are on the same axis
        //6th condition: there's exactly one player's field between the field that's being checked right now and the player's selected field
        private bool ConditionsFulfilledHorizontalAxis(int pos_X_HP, int pos_Y_HP, int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump)
        {
            if ((pos_X_SF - pos_X_HP == pos_X_HP - pos_X_F) && (pos_Y_SF == pos_Y_HP) && (pos_Y_SF == pos_Y_F) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !DoMorePlayerFieldsExist(pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !playerPerformedAJump)
            {
                return true;
            }
            return false;
        }

        //1st condition: the distance between the player's field that's being checked right now and the selected player's field is equal to the distance between the field that's being checked right now and the player's field that's being checked right now (on x-axis)
        //2nd condition: the distance between the player's field that's being checked right now and the selected player's field is equal to the distance between the field that's being checked right now and the player's field that's being checked right now (on y-axis)
        //3rd condition: the distance between the selected player's field and the field that's being checked right now on the y-axis is 2 times greater than the distance between the selected player's field and the field that's being checked right now on the x-axis
        private bool ConditionsFulfilledFirstJumps(int pos_X_HP, int pos_Y_HP, int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump)
        {
            if ((pos_X_HP - pos_X_SF == pos_X_F - pos_X_HP) && (pos_Y_HP - pos_Y_SF == pos_Y_F - pos_Y_HP) && (Math.Abs(pos_Y_SF - pos_Y_F) == 2 * Math.Abs(pos_X_SF - pos_X_F)) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !DoMorePlayerFieldsExist(pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !playerPerformedAJump)
            {
                return true;
            }
            return false;
        }//

        //1st condition: the distance between the player's field that's being checked right now and the field that's being checked right now is equal to the distance between the selected player's field and the field that's being checked right (on x-axis)
        //2nd condition: the distance between the selected player's field and the field that's being checked right now is two times greater than the length of the jump on x-axis
        //3rd condition: the distance between the field that's being checked right now and the player's field that's being checked right now is equal to the length of the jump (on x-axis)
        //4th condition: the distance between the field that's being checked right now and the selected player's field is equal to the length of the jump (on y-axis)
        //5th condition: the player's field that's being checked right now and the field that's being checked right now are on the same cooridnates on the y-axis
        private bool ConditionsFulfilledJumpAtTheSameCoordinatesOnBothAxis(int pos_X_HP, int pos_Y_HP, int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump, int jumpLengthX, int jumpLengthY)
        {
            if ((Math.Abs(pos_X_HP - pos_X_F) == Math.Abs(pos_X_SF - pos_X_HP)) && (Math.Abs(pos_X_SF - pos_X_F) == jumpLengthX * 2) && (Math.Abs(pos_X_F - pos_X_HP) == jumpLengthX) && (Math.Abs(pos_X_F - pos_X_SF) == jumpLengthY) && (pos_Y_HP == pos_Y_F) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !DoMorePlayerFieldsExist(pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields))
            {
                return true;
            }
            return false;
        }//

        //1st condition: the distance between the selected player's field and the field that's being checked right now is equal to the length of the jump (on x-axis)
        //2nd condition: the distance between the field that's being checked right now and the player's field that's being checked right now is two times fewer than the length of the jump on x-axis
        //3rd condition: the distance between the field that's being checked right now and the selected player's field on the x-axis is two times fewer than the length of the jump on the y-axis
        //4th condition: the distance between the selected player's field and the field that's being checked right now is equal to the length of the jump (on y-axis)
        //5th condition: the distance between the selected player's field and the player's field that's being checked right now is two times fewer than the length of the jump (on x-axis)
        //6th condition: he distance between the player's field that's being checked right now and the selected player's field is equal to the distance between the field that's being checked right now and the player's field that's being checked right now (on y-axis)
        //7th condition: he distance between the player's field that's being checked right now and the selected player's field is equal to the distance between the field that's being checked right now and the player's field that's being checked right now (on x-axis)
        private bool ConditionsFulfilledJumpAtDifferentCoordinatesOnBothAxis(int pos_X_HP, int pos_Y_HP, int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump, int jumpLengthX, int jumpLengthY)
        {
            if ((Math.Abs(pos_X_SF - pos_X_F) == jumpLengthX) && (Math.Abs(pos_X_F - pos_X_HP) == jumpLengthX / 2) && (Math.Abs(pos_X_F - pos_X_SF) == jumpLengthY / 2) && (Math.Abs(pos_Y_SF - pos_Y_F) == jumpLengthY) && (Math.Abs(pos_Y_SF - pos_Y_HP) == jumpLengthY / 2) && (pos_Y_HP - pos_Y_SF == pos_Y_F - pos_Y_HP) && (pos_X_HP - pos_X_SF == pos_X_F - pos_X_HP) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !DoMorePlayerFieldsExist(pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields))
            {
                return true;
            }
            return false;
        }

        //1st condition: the distance between the player's field that's being checked right now and the field that's being checked right now is equal to the distance between the field that the player jumped onto and the field that's being checked right now (on x-axis)
        //2nd condition: the distance between the field that the player jumped onto and the field that's being checked right now is equal to the length of the jump on the x-axis
        //3rd condition: the player's field that's being checked right now is on the same coordinates on the y-axis as the field that's being checked right now 
        private bool ConditionsFulfilledJumpAtTheSameCoordinatesOnOneAxis(int pos_X_HP, int pos_Y_HP, int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump, int jumpLengthX)
        {
            if ((Math.Abs(pos_X_HP - pos_X_F) == Math.Abs(pos_X_SF - pos_X_HP)) && (Math.Abs(pos_X_SF - pos_X_F) == jumpLengthX) && (pos_Y_HP == pos_Y_F) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !DoMorePlayerFieldsExist(pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields))
            {
                return true;
            }
            return false;
        }

        //1st condition: the distance between the player's field that's being checked right now and the field that's being checked right now is equal to the distance between the field that the player jumped onto and the field that's being checked right now (on x-axis)
        //2nd condition: the distance between the player's field that's being checked right now and the field that's being checked right now is equal to the distance between the field that the player jumped onto and the field that's being checked right now (on y-axis)
        //3rd condition: the distance between the field that the player jumped onto and the field that's being checked right now on the y-axis is equal to the length of the jump on the x-axis
        //4th condition: the distance between the field that the player jumped onto and the player's field that's being checked right now on the y-axis is two times fewer than the length of the jump on the x-axis
        //5th condition: the distance between the field that the player jumped onto and the field that's being checked right now on the y-axis is two times fewer than the length of the jump on the x-axis
        private bool ConditionsFulfilledJumpAtDifferentCoordinatesOnOneAxis(int pos_X_HP, int pos_Y_HP, int pos_X_F, int pos_Y_F, int pos_X_SF, int pos_Y_SF, int playerId, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer, bool playerPerformedAJump, int jumpLengthX)
        {
            if ((Math.Abs(pos_X_HP - pos_X_F) == Math.Abs(pos_X_SF - pos_X_HP)) && (Math.Abs(pos_Y_HP - pos_Y_F) == Math.Abs(pos_Y_SF - pos_Y_HP)) && (Math.Abs(pos_Y_SF - pos_Y_F) == jumpLengthX) && Math.Abs(pos_Y_SF - pos_Y_HP) * 2 == jumpLengthX && (Math.Abs(pos_X_SF - pos_X_F) * 2 == jumpLengthX) && !IsMoveDuplicate(pos_X_F, pos_Y_F, pos_X_SF, pos_Y_SF, playerId, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer) && !JeHracovoPole(pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields) && !DoMorePlayerFieldsExist(pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, humanPlayerFields, computerPlayerFields))
            {
                return true;
            }
            return false;
        }//
    }
}
