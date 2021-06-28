using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCheckers.Forms;
using ChineseCheckers.Game_entities;

namespace ChineseCheckers.Game_control
{
    class Game
    {
        private int amountOfPlayers;//amount of players including the human player
        private int firstMove;
        private int difficulty;
        private bool simulationMode;
        private int[] simulationDifficulty = { };
        private static int fieldWidth = 35;
        private static int fieldHeight = 35;
        private int upperOffset = 13;//offset of the first field on the map that's under the upper border
        private int leftOffset;
        private static int distance = 40;//distance between individual fields of the map
        private int amountOfFields = 121;
        private int amountOfMoves = 0;
        private static int consoleMessage;
        private static int winningComputerPlayer;
        private bool clickedPossibleMove = false;
        private bool playerPerformedAJump = false;
        private int defaultWinPlayer = 0;
        private bool defaultWin;

        private List<Field> gameFields = new List<Field>();//all game fields (121)
        private List<HumanPlayer> humanPlayerFields = new List<HumanPlayer>();//all human's fields (10)
        private List<ComputerPlayer> computerPlayerFields = new List<ComputerPlayer>();//all computer's fields (10 - 50)
        private List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer = new List<PossibleMoveOfHumanPlayer>();//all fields that the human can move to
        private List<PossibleMoveOfComputerPlayer> possibleMovesOfComputerPlayer = new List<PossibleMoveOfComputerPlayer>();//all fields that the computer can move to
        private List<PreviousFieldOfComputerPlayer> previousFieldsOfComputerPlayer = new List<PreviousFieldOfComputerPlayer>();//highlights the field that the computer moved from
        private HighlightedFieldOfHumanPlayer highlightedFieldOfHumanPlayer;
        private List<HighlightedFieldOfComputerPlayer> highlightedFieldsOfComputerPlayer = new List<HighlightedFieldOfComputerPlayer>();//highlights the field that the computer moved to

        public Game(int amountOfPlayers, int firstMove, int difficulty, bool simulationMode, int[] simulationDifficulty)
        {
            this.amountOfPlayers = amountOfPlayers;
            this.firstMove = firstMove;
            this.difficulty = difficulty;
            this.simulationMode = simulationMode;
            this.simulationDifficulty = simulationDifficulty;
            if (consoleMessage == 7)
            {
                consoleMessage = 2;
            }
        }

        public (List<Field>, List<HumanPlayer>, List<ComputerPlayer>, List<PossibleMoveOfHumanPlayer>, HighlightedFieldOfHumanPlayer, List<HighlightedFieldOfComputerPlayer>, List<PreviousFieldOfComputerPlayer>) GameElements()
        {
            return (gameFields, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, highlightedFieldOfHumanPlayer, highlightedFieldsOfComputerPlayer, previousFieldsOfComputerPlayer);
        }

        public void NewGame(int panelWidth, GameForm gameform)//creates all game fields
        {
            //resets the parameters from the previous game
            winningComputerPlayer = 0;
            defaultWinPlayer = 0;
            defaultWin = false;

            leftOffset = (panelWidth / 2) - (fieldWidth / 2);

            int pos_X_F = leftOffset;
            int pos_Y_F = upperOffset;

            for (int i = 0; i < amountOfFields; i++)
            {
                Field field = new Field(pos_X_F, pos_Y_F, fieldWidth, fieldHeight, true);
                gameFields.Add(field);
                (pos_X_F, pos_Y_F) = RecalculationOfFieldsPositions(i, pos_X_F, pos_Y_F);
            }

            for (int i = 0; i < gameFields.Count; i++)
            {
                Field field = gameFields[i];
                pos_X_F = field.Get_pos_X_F();
                pos_Y_F = field.Get_pos_Y_F();

                if (!simulationMode)
                {
                    if (amountOfPlayers != 4)
                    {
                        if (IsFieldInLowestCorner(pos_Y_F, true) && humanPlayerFields.Count < 10)
                        {
                            HumanPlayer humanPlayer = new HumanPlayer(pos_X_F, pos_Y_F, fieldWidth, fieldHeight);
                            humanPlayerFields.Add(humanPlayer);
                        }
                    }
                    else
                    {
                        if (IsFieldInLowerLeftCorner(pos_X_F, pos_Y_F, true) && humanPlayerFields.Count < 10)
                        {
                            HumanPlayer humanPlayer = new HumanPlayer(pos_X_F, pos_Y_F, fieldWidth, fieldHeight);
                            humanPlayerFields.Add(humanPlayer);
                        }
                    }
                }

                //greys out inactive fields
                if (GreyOutField(amountOfPlayers, pos_X_F, pos_Y_F))
                {
                    gameFields[i].Set_isActive(false);
                }

                for (int n = 0; n <= 6; n++)
                {
                    if (AmountOfFieldsExceeded(amountOfPlayers, n, simulationMode, computerPlayerFields.Count))
                    {
                        continue;
                    }
                    if (AddComputerPlayerFields(n, pos_X_F, pos_Y_F, simulationMode))
                    {
                        ComputerPlayer computerPlayer = new ComputerPlayer(pos_X_F, pos_Y_F, fieldWidth, fieldHeight, n);
                        computerPlayerFields.Add(computerPlayer);
                    }
                }
            }
            if (firstMove == 2)
            {
                ComputerPlayerMove(gameform);
            }
        }

        private (int, int) RecalculationOfFieldsPositions(int i, int pos_X_F, int pos_Y_F)
        {
            switch (i)
            {
                case 0:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + distance;
                    break;
                case 2:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 2);
                    break;
                case 5:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 3);
                    break;
                case 9:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 8);
                    break;
                case 22:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 12);
                    break;
                case 34:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 11);
                    break;
                case 45:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 10);
                    break;
                case 55:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 9);
                    break;
                case 64:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 9);
                    break;
                case 74:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 10);
                    break;
                case 85:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 11);
                    break;
                case 97:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 12);
                    break;
                case 110:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 8);
                    break;
                case 114:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 3);
                    break;
                case 117:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + (distance * 2);
                    break;
                case 119:
                    pos_Y_F += distance;
                    pos_X_F -= (distance / 2) + distance;
                    break;
            }
            pos_X_F += distance;
            return (pos_X_F, pos_Y_F);
        }

        public void PanelClick(int x, int y, GameForm gameform)
        {
            consoleMessage = 0;
            int pos_X_HP, pos_Y_HP, pos_X_SF, pos_Y_SF, pos_X_F, pos_Y_F, pos_X_F_S, pos_Y_F_S;
            int pos_X_PM, pos_Y_PM;
            int jumpLengthX = 0, jumpLengthY = 0;
            PossibleMovesCalculation possibleMovesCalculation = new PossibleMovesCalculation(fieldWidth, fieldHeight, distance, upperOffset, leftOffset, gameFields);
            bool endMove = false;

            for (int i = 0; i < gameFields.Count; i++)
            {
                Field field = gameFields[i];
                pos_X_F = field.Get_pos_X_F();
                pos_Y_F = field.Get_pos_Y_F();
                pos_X_F_S = pos_X_F + (fieldWidth / 2);
                pos_Y_F_S = pos_Y_F + (fieldHeight / 2);

                bool vPoli = IsInField(pos_X_F_S, pos_Y_F_S, fieldWidth / 2, x, y);//checks whether the coordinates of player's mouse click are inside a field
                if (vPoli)
                {
                    for (int j = 0; j < humanPlayerFields.Count; j++)
                    {
                        HumanPlayer humanPlayer = humanPlayerFields[j];
                        pos_X_SF = humanPlayer.Get_pos_X_HP();
                        pos_Y_SF = humanPlayer.Get_pos_Y_HP();
                        if (pos_X_F == pos_X_SF && pos_Y_F == pos_Y_SF)//we have found the field that the player selected by clicking it
                        {
                            GameForm.PlaySound(1);
                            if (highlightedFieldOfHumanPlayer != null && (pos_X_F == highlightedFieldOfHumanPlayer.Get_pos_X_HFHP() && pos_Y_F == highlightedFieldOfHumanPlayer.Get_pos_Y_HFHP()) && playerPerformedAJump)//the player selected the field that he moved onto - this means that he wants to finish his move
                            {
                                endMove = true;
                            }
                            possibleMovesOfHumanPlayer.Clear();
                            possibleMovesCalculation.AddPossibleMoves(pos_X_SF, pos_Y_SF, 1, amountOfPlayers, false, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);

                            highlightedFieldOfHumanPlayer = new HighlightedFieldOfHumanPlayer(pos_X_SF, pos_Y_SF, fieldWidth, fieldHeight);
                            break;
                        }
                    }

                    for (int j = 0; j < possibleMovesOfHumanPlayer.Count; j++)
                    {
                        PossibleMoveOfHumanPlayer possibleMove = possibleMovesOfHumanPlayer[j];
                        pos_X_PM = possibleMove.Get_pos_X_PM();
                        pos_Y_PM = possibleMove.Get_pos_Y_PM();
                        if (pos_X_F == pos_X_PM && pos_Y_F == pos_Y_PM)//we have found the possible move that the player selected by clicking it
                        {
                            if (!clickedPossibleMove)
                            {
                                gameform.EndMoveButton();
                            }
                            clickedPossibleMove = true;
                            GameForm.PlaySound(1);
                            possibleMovesOfHumanPlayer.Clear();
                            for (int k = 0; k < humanPlayerFields.Count; k++)
                            {
                                HumanPlayer h = humanPlayerFields[k];
                                pos_X_HP = h.Get_pos_X_HP();
                                pos_Y_HP = h.Get_pos_Y_HP();
                                if (pos_X_HP == highlightedFieldOfHumanPlayer.Get_pos_X_HFHP() && pos_Y_HP == highlightedFieldOfHumanPlayer.Get_pos_Y_HFHP())
                                {
                                    humanPlayerFields.Remove(h);
                                }
                            }
                            HumanPlayer humanPlayer = new HumanPlayer(pos_X_F, pos_Y_F, fieldWidth, fieldHeight);
                            humanPlayerFields.Add(humanPlayer);
                            if (Math.Abs(pos_X_PM - highlightedFieldOfHumanPlayer.Get_pos_X_HFHP()) > distance + 1 || Math.Abs(pos_Y_PM - highlightedFieldOfHumanPlayer.Get_pos_Y_HFHP()) > distance + 1)//the player moved using a jump - so we are going to calculate possible moves from the field that he jumped on
                            {
                                jumpLengthX = Math.Abs(pos_X_PM - highlightedFieldOfHumanPlayer.Get_pos_X_HFHP());
                                jumpLengthY = Math.Abs(pos_Y_PM - highlightedFieldOfHumanPlayer.Get_pos_Y_HFHP());
                                playerPerformedAJump = true;
                                possibleMovesCalculation.AddPossibleMoves(pos_X_F, pos_Y_F, 1, amountOfPlayers, playerPerformedAJump, jumpLengthX, jumpLengthY, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer);
                                highlightedFieldOfHumanPlayer = new HighlightedFieldOfHumanPlayer(pos_X_PM, pos_Y_PM, fieldWidth, fieldHeight);
                            }
                            else//the player moved onto a neighboring field - so we are going to end his move
                            {
                                endMove = true;
                            }
                        }
                    }
                }
            }
            if (endMove)
            {
                EndMove(gameform);
            }
        }

        private bool IsInField(int pos_X_F_S, int pos_Y_F_S, int fieldDiameter, int eX, int eY)//checks whether the coordinates that the player clicked on are a part of some game field
        {
            int pozX = pos_X_F_S - eX;
            int pozY = pos_Y_F_S - eY;
            return pozX * pozX + pozY * pozY <= fieldDiameter * fieldDiameter;
        }

        public void EndMove(GameForm gameform)
        {
            possibleMovesOfHumanPlayer.Clear();
            amountOfMoves++;
            highlightedFieldOfHumanPlayer = null;
            playerPerformedAJump = false;
            gameform.EndMoveButton();
            clickedPossibleMove = false;
            GameForm.PlaySound(2);
            if (firstMove == 2)
            {
                WinCheck();
            }
            if (consoleMessage < 4)
            {
                ComputerPlayerMove(gameform);
            }
            if (firstMove == 1)
            {
                WinCheck();
            }
        }

        private void WinCheck()//after all players perform their move, we check whether some of them has won the game (all his fields are in the opposite triangle)
        {
            DrawControl();
            int pos_X_HP, pos_Y_HP, pos_X_CP, pos_Y_CP, computerPlayerId;
            bool humanPlayerWon = true;

            for (int i = 0; i < humanPlayerFields.Count; i++)
            {
                HumanPlayer humanPlayer = humanPlayerFields[i];
                pos_X_HP = humanPlayer.Get_pos_X_HP();
                pos_Y_HP = humanPlayer.Get_pos_Y_HP();
                if (amountOfPlayers != 4)
                {
                    if (!IsFieldInHighestCorner(pos_Y_HP, true))
                    {
                        humanPlayerWon = false;
                    }
                }
                else
                {
                    if (!IsFieldInUpperRightCorner(pos_X_HP, pos_Y_HP, true))
                    {
                        humanPlayerWon = false;
                    }
                }
            }

            int[] amountOfFieldsOfComputerPlayer = new int[] { 0, 0, 0, 0, 0, 0 };
            bool[] computerPlayerWin = new bool[] { true, true, true, true, true, true };

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j < computerPlayerFields.Count; j++)
                {
                    ComputerPlayer computerPlayer = computerPlayerFields[j];
                    pos_X_CP = computerPlayer.Get_pos_X_CP();
                    pos_Y_CP = computerPlayer.Get_pos_Y_CP();
                    computerPlayerId = computerPlayer.Get_computerPlayerId();

                    if (computerPlayerId != i)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        amountOfFieldsOfComputerPlayer[5] += 1;
                    }
                    else
                    {
                        amountOfFieldsOfComputerPlayer[computerPlayerId - 2] += 1;
                    }

                    if (computerPlayerId == 0 && !IsFieldInHighestCorner(pos_Y_CP, true))
                    {
                        computerPlayerWin[5] = false;
                    }

                    if (computerPlayerId == 2 && !IsFieldInLowestCorner(pos_Y_CP, true))
                    {
                        computerPlayerWin[0] = false;
                    }

                    if (computerPlayerId == 3 && !IsFieldInLowerRightCorner(pos_X_CP, pos_Y_CP, true))
                    {
                        computerPlayerWin[1] = false;
                    }

                    if (computerPlayerId == 4 && !IsFieldInLowerLeftCorner(pos_X_CP, pos_Y_CP, true))
                    {
                        computerPlayerWin[2] = false;
                    }

                    if (computerPlayerId == 5 && !IsFieldInUpperRightCorner(pos_X_CP, pos_Y_CP, true))
                    {
                        computerPlayerWin[3] = false;
                    }

                    if (computerPlayerId == 6 && !IsFieldInUpperLeftCorner(pos_X_CP, pos_Y_CP, true))
                    {
                        computerPlayerWin[4] = false;
                    }
                }
            }

            winningComputerPlayer = 0;
            for (int i = 0; i < 6; i++)
            {
                if (amountOfFieldsOfComputerPlayer[i] > 0 && computerPlayerWin[i] == true)
                {
                    winningComputerPlayer = i + 2;
                }
            }

            if (defaultWinPlayer != 0)
            {
                defaultWin = true;
                if (defaultWinPlayer == 1)
                {
                    humanPlayerWon = true;
                }
                else
                {
                    winningComputerPlayer = defaultWinPlayer;
                }
            }

            if (winningComputerPlayer != 0 && simulationMode)
            {
                EntryIntoStatistics(winningComputerPlayer);
                consoleMessage = 7;
            }

            bool draw = false;
            if (winningComputerPlayer != 0 && !simulationMode)
            {
                if (humanPlayerWon)
                {
                    draw = true;
                    consoleMessage = 6;
                }
                else
                {
                    consoleMessage = 5;
                }
            }

            if (humanPlayerWon && !draw && !simulationMode)
            {
                consoleMessage = 4;
            }
        }

        private void DrawControl()
        {
            if (!simulationMode)
            {
                int amountOfMarblesOfHumanPlayerInDestinationTriangle = 0;
                int amountOfMarblesOfComputerPlayerInDestinationTriangle = 0;
                for (int i = 0; i < humanPlayerFields.Count; i++)
                {
                    if (amountOfPlayers != 4)
                    {
                        if (IsFieldInHighestCorner(humanPlayerFields[i].Get_pos_Y_HP(), true))
                        {
                            amountOfMarblesOfHumanPlayerInDestinationTriangle++;
                        }
                    }
                    else
                    {
                        if (IsFieldInUpperRightCorner(humanPlayerFields[i].Get_pos_X_HP(), humanPlayerFields[i].Get_pos_Y_HP(), true))
                        {
                            amountOfMarblesOfHumanPlayerInDestinationTriangle++;
                        }
                    }
                }
                for (int i = 0; i < computerPlayerFields.Count; i++)
                {
                    if (amountOfPlayers != 4)
                    {
                        if (computerPlayerFields[i].Get_computerPlayerId() == 2 && IsFieldInHighestCorner(computerPlayerFields[i].Get_pos_Y_CP(), false))
                        {
                            amountOfMarblesOfComputerPlayerInDestinationTriangle++;
                        }
                    }
                    else
                    {
                        if (computerPlayerFields[i].Get_computerPlayerId() == 4 && IsFieldInUpperRightCorner(computerPlayerFields[i].Get_pos_X_CP(), computerPlayerFields[i].Get_pos_Y_CP(), false))
                        {
                            amountOfMarblesOfComputerPlayerInDestinationTriangle++;
                        }
                    }
                }
                if (amountOfMarblesOfHumanPlayerInDestinationTriangle + amountOfMarblesOfComputerPlayerInDestinationTriangle == 10 && amountOfMarblesOfComputerPlayerInDestinationTriangle > 0)
                {
                    defaultWinPlayer = 1;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                int amountOfOriginalMarblesInDestinationTriangle = 0;
                int amountOfForeignMarblesInDestinationTriangle = 0;
                for (int j = 0; j < computerPlayerFields.Count; j++)
                {
                    switch (i)
                    {
                        case 0:
                            if (computerPlayerFields[j].Get_computerPlayerId() == 0 && IsFieldInHighestCorner(computerPlayerFields[j].Get_pos_Y_CP(), true))
                            {
                                amountOfForeignMarblesInDestinationTriangle++;
                            }
                            if (computerPlayerFields[j].Get_computerPlayerId() == 2 && IsFieldInHighestCorner(computerPlayerFields[j].Get_pos_Y_CP(), false))
                            {
                                amountOfOriginalMarblesInDestinationTriangle++;
                            }
                            if (amountOfForeignMarblesInDestinationTriangle + amountOfOriginalMarblesInDestinationTriangle == 10 && amountOfOriginalMarblesInDestinationTriangle > 0)
                            {
                                defaultWinPlayer = 7;
                            }
                            break;

                        case 2:
                            if (computerPlayerFields[j].Get_computerPlayerId() == 2 && IsFieldInLowestCorner(computerPlayerFields[j].Get_pos_Y_CP(), true))
                            {
                                amountOfForeignMarblesInDestinationTriangle++;
                            }
                            if (computerPlayerFields[j].Get_computerPlayerId() == 0 && IsFieldInLowestCorner(computerPlayerFields[j].Get_pos_Y_CP(), false))
                            {
                                amountOfOriginalMarblesInDestinationTriangle++;
                            }
                            if (amountOfForeignMarblesInDestinationTriangle + amountOfOriginalMarblesInDestinationTriangle == 10 && amountOfOriginalMarblesInDestinationTriangle > 0)
                            {
                                defaultWinPlayer = 2;
                            }
                            break;

                        case 3:
                            if (computerPlayerFields[j].Get_computerPlayerId() == 3 && IsFieldInLowerRightCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), true))
                            {
                                amountOfForeignMarblesInDestinationTriangle++;
                            }
                            if (computerPlayerFields[j].Get_computerPlayerId() == 6 && IsFieldInLowerRightCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), false))
                            {
                                amountOfOriginalMarblesInDestinationTriangle++;
                            }
                            if (amountOfForeignMarblesInDestinationTriangle + amountOfOriginalMarblesInDestinationTriangle == 10 && amountOfOriginalMarblesInDestinationTriangle > 0)
                            {
                                defaultWinPlayer = 3;
                            }
                            break;

                        case 4:
                            if (computerPlayerFields[j].Get_computerPlayerId() == 4 && IsFieldInLowerLeftCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), true))
                            {
                                amountOfForeignMarblesInDestinationTriangle++;
                            }
                            if (computerPlayerFields[j].Get_computerPlayerId() == 5 && IsFieldInLowerLeftCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), false))
                            {
                                amountOfOriginalMarblesInDestinationTriangle++;
                            }
                            if (amountOfForeignMarblesInDestinationTriangle + amountOfOriginalMarblesInDestinationTriangle == 10 && amountOfOriginalMarblesInDestinationTriangle > 0)
                            {
                                defaultWinPlayer = 4;
                            }
                            break;

                        case 5:
                            if (computerPlayerFields[j].Get_computerPlayerId() == 5 && IsFieldInUpperRightCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), true))
                            {
                                amountOfForeignMarblesInDestinationTriangle++;
                            }
                            if (computerPlayerFields[j].Get_computerPlayerId() == 4 && IsFieldInUpperRightCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), false))
                            {
                                amountOfOriginalMarblesInDestinationTriangle++;
                            }
                            if (amountOfForeignMarblesInDestinationTriangle + amountOfOriginalMarblesInDestinationTriangle == 10 && amountOfOriginalMarblesInDestinationTriangle > 0)
                            {
                                defaultWinPlayer = 5;
                            }
                            break;

                        case 6:
                            if (computerPlayerFields[j].Get_computerPlayerId() == 6 && IsFieldInUpperLeftCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), true))
                            {
                                amountOfForeignMarblesInDestinationTriangle++;
                            }
                            if (computerPlayerFields[j].Get_computerPlayerId() == 3 && IsFieldInUpperLeftCorner(computerPlayerFields[j].Get_pos_X_CP(), computerPlayerFields[j].Get_pos_Y_CP(), false))
                            {
                                amountOfOriginalMarblesInDestinationTriangle++;
                            }
                            if (amountOfForeignMarblesInDestinationTriangle + amountOfOriginalMarblesInDestinationTriangle == 10 && amountOfOriginalMarblesInDestinationTriangle > 0)
                            {
                                defaultWinPlayer = 6;
                            }
                            break;
                    }
                }
            }
        }

        private void EntryIntoStatistics(int winningComputerPlayer)
        {
            string[] lines = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Statistics.txt");

            string difficultyText = "";
            switch (amountOfPlayers)
            {
                case 2:
                    difficultyText = simulationDifficulty[0] + ";" + simulationDifficulty[5];
                    break;
                case 3:
                    difficultyText = simulationDifficulty[1] + ";" + simulationDifficulty[2] + ";" + simulationDifficulty[5];
                    break;
                case 4:
                    difficultyText = simulationDifficulty[1] + ";" + simulationDifficulty[2] + ";" + simulationDifficulty[3] + ";" + simulationDifficulty[4];
                    break;
                case 6:
                    difficultyText = simulationDifficulty[0] + ";" + simulationDifficulty[1] + ";" + simulationDifficulty[2] + ";" + simulationDifficulty[3] + ";" + simulationDifficulty[4] + ";" + simulationDifficulty[5];
                    break;
            }

            string resultText = "";
            if (lines.Length != 0)
            {
                resultText += "\n";
            }
            resultText += amountOfPlayers.ToString() + ";" + amountOfMoves + ";" + Convert.ToInt32(defaultWin) + ";" + difficultyText + ";" + winningComputerPlayer;
            File.AppendAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Statistics.txt", resultText);
        }

        public void ComputerPlayerMove(GameForm gameform)
        {
            if (consoleMessage < 4)
            {
                consoleMessage = 1;
            }
            gameform.ConsoleRefresh(0);
            ComputerPlayerMove computerPlayerMove = new ComputerPlayerMove(amountOfPlayers, firstMove, amountOfMoves, fieldWidth, fieldHeight, distance, upperOffset, leftOffset, gameFields, humanPlayerFields, computerPlayerFields, possibleMovesOfHumanPlayer, possibleMovesOfComputerPlayer, highlightedFieldsOfComputerPlayer, previousFieldsOfComputerPlayer, simulationMode);
            (computerPlayerFields, previousFieldsOfComputerPlayer, highlightedFieldsOfComputerPlayer) = computerPlayerMove.PerformMove(gameform, difficulty, simulationDifficulty);
            if (simulationMode)
            {
                amountOfMoves++;
                WinCheck();
            }
            if (consoleMessage < 4)
            {
                if (amountOfMoves == 0)
                {
                    consoleMessage = 2;
                }
                else
                {
                    consoleMessage = 0;
                }
            }
            gameform.ConsoleRefresh(0);
        }

        public int GetAmountOfMoves()
        {
            return amountOfMoves;
        }

        public (int, int, bool) GetConsoleMessage()
        {
            return (consoleMessage, winningComputerPlayer, defaultWin);
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

        private bool AddComputerPlayerFields(int n, int pos_X_F, int pos_Y_F, bool simulationMode)
        {
            if ((n == 0 && IsFieldInLowestCorner(pos_Y_F, true) && simulationMode) ||
                (n == 2 && IsFieldInHighestCorner(pos_Y_F, true)) ||
                (n == 3 && IsFieldInUpperLeftCorner(pos_X_F, pos_Y_F, true)) ||
                (n == 4 && IsFieldInUpperRightCorner(pos_X_F, pos_Y_F, true)) ||
                (n == 5 && IsFieldInLowerLeftCorner(pos_X_F, pos_Y_F, true)) ||
                (n == 6 && IsFieldInLowerRightCorner(pos_X_F, pos_Y_F, true)))
            {
                return true;
            }
            return false;
        }

        private bool GreyOutField(int amountOfPlayers, int pos_X_F, int pos_Y_F)
        {
            if ((amountOfPlayers == 2 && (IsFieldInUpperLeftCorner(pos_X_F, pos_Y_F, true) || IsFieldInUpperRightCorner(pos_X_F, pos_Y_F, true) || IsFieldInLowerLeftCorner(pos_X_F, pos_Y_F, true) || IsFieldInLowerRightCorner(pos_X_F, pos_Y_F, true))) ||
                (amountOfPlayers == 4 && (IsFieldInLowestCorner(pos_Y_F, true) || IsFieldInHighestCorner(pos_Y_F, true))))
            {
                return true;
            }
            return false;
        }

        private bool AmountOfFieldsExceeded(int amountOfPlayers, int n, bool simulationMode, int amountOfFields)
        {
            if ((amountOfPlayers == 2 && ((n > 2) || ((!simulationMode && amountOfFields == 10) || (simulationMode && amountOfFields == 20)))) ||
                (amountOfPlayers == 3 && ((n == 2 || n > 4) || (!simulationMode && amountOfFields == 20) || (simulationMode && amountOfFields == 30))) ||
                (amountOfPlayers == 4 && ((n == 2 || (!simulationMode && n == 5) || (simulationMode && n == 0)) || (!simulationMode && amountOfFields == 30) || (simulationMode && amountOfFields == 40))) ||
                (amountOfPlayers == 6 && (!simulationMode && amountOfFields == 50) || (simulationMode && amountOfFields == 60)))
            {
                return true;
            }
            return false;
        }
    }
}
