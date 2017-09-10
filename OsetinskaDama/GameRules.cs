using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    public class GameRules
    {
        private int piecesCnt = 49;
        private int deskSize = 7;
        private int piecesPerPlayer = 21;
        private int piecesDifferenceWeight = 50;
        private int piecesPositionWeight = 1;
        private bool evalPiecePosition;
        private short startingPlayer = GameVar.PLAYER_WHITE;

        private short[][] directionsNormal;
        private short[] directionsJump;

        public GameRules()
        {
            //set up possible directions for move and jump for white and black
            directionsJump = new short[] { GameVar.DIR_UP_LEFT, GameVar.DIR_UP, GameVar.DIR_UP_RIGHT, GameVar.DIR_RIGHT, GameVar.DIR_LEFT, GameVar.DIR_DOWN_LEFT, GameVar.DIR_DOWN, GameVar.DIR_DOWN_RIGHT };
            short[] direction_normal_white = new short[] { GameVar.DIR_UP_LEFT, GameVar.DIR_UP, GameVar.DIR_UP_RIGHT };
            short[] direction_normal_black = new short[] { GameVar.DIR_DOWN_LEFT, GameVar.DIR_DOWN, GameVar.DIR_DOWN_RIGHT };
            directionsNormal = new short[3][];
            directionsNormal[GameVar.PLAYER_WHITE] = direction_normal_white;
            directionsNormal[GameVar.PLAYER_BLACK] = direction_normal_black;
        }

        public int[,] getInitPiecesWhite()
        {
            return new int[,] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 0, 2 }, { 1, 2 }, { 2, 2 }, { 3, 2 }, { 4, 2 }, { 5, 2 }, { 6, 2 } };
        }

        public int[,] getInitPiecesBlack()
        {
            return new int[,] { { 0, 4 }, { 1, 4 }, { 2, 4 }, { 3, 4 }, { 4, 4 }, { 5, 4 }, { 6, 4 }, { 0, 5 }, { 1, 5 }, { 2, 5 }, { 3, 5 }, { 4, 5 }, { 5, 5 }, { 6, 5 }, { 0, 6 }, { 1, 6 }, { 2, 6 }, { 3, 6 }, { 4, 6 }, { 5, 6 }, { 6, 6 } };
        }

        public int getXCoord(string letter)
        {
            if (letter.Length != 1)
                throw new Exception("Not valid coord");
            int coord = (int)letter[0] - (int)GameVar.LetterXStart;
            if (coord < 0 || coord > 6)
            {
                throw new Exception("Not valid coord");
            }
            return coord;
        }

        public int getYCoord(int coord)
        {
            if (coord < 1 || coord > 7)
            {
                throw new Exception("Not valid coord");
            }
            return coord - 1;
        }

        public int getPiecesPerPlayer()
        {
            return piecesPerPlayer;
        }

        public short getOppositePlayer(short player)
        {
            return player == GameVar.PLAYER_WHITE ? GameVar.PLAYER_BLACK : GameVar.PLAYER_WHITE;
        }

        public void setEvalPiecePosition(bool flag)
        {
            evalPiecePosition = flag;
        }

        public short getNextPlayer(Desk desk)
        {
            //get opposite player, check if players can move
            short oppositePlayer = getOppositePlayer(desk.getCurrentPlayer());
            if (getPossibleMoves(desk, oppositePlayer, true).Count > 0)
                return oppositePlayer;
            else if (getPossibleMoves(desk, desk.getCurrentPlayer(), true).Count > 0)
                return desk.getCurrentPlayer();
            return -1;      //neither of players can move
        }

        public short getStartingPlayer()
        {
            return startingPlayer;
        }

        public int getPiecesCnt()
        {
            return piecesCnt;
        }

        public int getDeskSize()
        {
            return deskSize;
        }

        public void addMove(ArrayList possibleMoves, int xFrom, int yFrom, int xTo, int yTo)
        {
            Move newMove = new Move(xFrom, yFrom, xTo, yTo);
            possibleMoves.Add(newMove);
        }

        public void addMove(ArrayList possibleMoves, Move move)
        {
            possibleMoves.Add(move);
        }

        public bool isGameEnd(Desk desk)
        {
            int fieldsBlackCnt = desk.getPlayerFields(GameVar.PLAYER_BLACK).Count;
            int fieldsWhiteCnt = desk.getPlayerFields(GameVar.PLAYER_WHITE).Count;
            if (fieldsBlackCnt == 0 || fieldsWhiteCnt == 0)
                return true;
            if (getPossibleMoves(desk, GameVar.PLAYER_WHITE, true).Count > 0)
                return false;
            if (getPossibleMoves(desk, GameVar.PLAYER_BLACK, true).Count > 0)
                return false;
            return true;
        }

        public short decideGameResult(Desk desk)
        {
            int whitePlayerResult = getGameEvaluation(desk, GameVar.PLAYER_WHITE);
            if (whitePlayerResult > 0)
                return GameVar.PLAYER_WHITE;
            if (whitePlayerResult < 0)
                return GameVar.PLAYER_BLACK;
            return 0;
        }

        private int getPiecesPositionEvaluation(ArrayList fields)
        {
            int x, y;
            int eval = 0;
            int fieldsCnt = fields.Count;
            for (int i = 0; i < fieldsCnt; i++)
            {
                x = (int)(fields[i] as Array).GetValue(0);
                y = (int)(fields[i] as Array).GetValue(1);
                if (x == 0 || x == 6 || y == 0 || y == 6)
                    eval++;
            }
            return eval;
        }

        public int getGameEvaluation(Desk desk, short player)
        {
            int whitePiecesCnt = desk.getPlayerFields(GameVar.PLAYER_WHITE).Count;
            int blackPiecesCnt = desk.getPlayerFields(GameVar.PLAYER_BLACK).Count;
            int piecesDifference = 0, piecesPositionVal = 0, x, y;

            //white player
            if (player == GameVar.PLAYER_WHITE)
            {
                if (evalPiecePosition)
                    piecesPositionVal += getPiecesPositionEvaluation(desk.getPlayerFields(GameVar.PLAYER_WHITE));
                if (blackPiecesCnt == 0 && whitePiecesCnt > 0)
                    return int.MaxValue;
                if (whitePiecesCnt == 0 && blackPiecesCnt > 0)
                    return int.MinValue;
                piecesDifference = whitePiecesCnt - blackPiecesCnt;

            }
            else       //black player
            {
                if (evalPiecePosition)
                    piecesPositionVal += getPiecesPositionEvaluation(desk.getPlayerFields(GameVar.PLAYER_BLACK));
                if (whitePiecesCnt == 0 && blackPiecesCnt > 0)
                    return int.MaxValue;
                if (blackPiecesCnt == 0 && whitePiecesCnt > 0)
                    return int.MinValue;
                piecesDifference = blackPiecesCnt - whitePiecesCnt;
            }
            return piecesDifference * piecesDifferenceWeight + piecesPositionVal * piecesPositionWeight;
        }

        public int[] canJump(int[,] fields, int x, int y, int xIncrement, int yIncrement, int currentPlayer)
        {
            int xStart = x + xIncrement, yStart = y + yIncrement;
            int xTarget, yTarget;

            //inspect direction to the edge of the desk
            while (xStart >= 0 && xStart < deskSize && yStart >= 0 && yStart < deskSize)
            {
                //break if not valid field, or my field
                if (!GameVar.isValidField(xStart, yStart, deskSize) || fields[xStart, yStart] == currentPlayer)     //field invalid or current_player's field
                    break;
                if (fields[xStart, yStart] == GameVar.FIELD_EMPTY)        //field empty, continue
                {
                    xStart += xIncrement;
                    yStart += yIncrement;
                    continue;
                }

                //opposite player's field found, set jump target coords - coords right after the jumped field
                xTarget = xStart + xIncrement;
                yTarget = yStart + yIncrement;

                //is target field for jump landing valid and empty
                if (!GameVar.isValidField(xTarget, yTarget, deskSize) || fields[xTarget, yTarget] != GameVar.FIELD_EMPTY)
                    break;
                return new int[] { xTarget, yTarget };        //jump possible, return jump target coords
            }
            return null;
        }

        public ArrayList getPossibleJumps(Desk desk, int x, int y, short currentPlayer)
        {
            ArrayList possibleJumps = new ArrayList();
            ArrayList jumpsFound = new ArrayList();
            Move newMove;
            int[,] fields = desk.getFields();
            int xIncrement = 0;
            int yIncrement = 0;
            int[] targetCoords;
            short opposite_player = getOppositePlayer(currentPlayer);

            //loop all possible diretions for jump
            for (int i = 0; i < directionsJump.Length; i++)
            {
                if (directionsJump[i] == GameVar.DIR_UP_LEFT)
                {
                    xIncrement = -1;
                    yIncrement = 1;
                }
                else if (directionsJump[i] == GameVar.DIR_UP)
                {
                    xIncrement = 0;
                    yIncrement = 1;
                }
                else if (directionsJump[i] == GameVar.DIR_UP_RIGHT)
                {
                    xIncrement = 1;
                    yIncrement = 1;
                }
                else if (directionsJump[i] == GameVar.DIR_RIGHT)
                {
                    xIncrement = 1;
                    yIncrement = 0;
                }
                else if (directionsJump[i] == GameVar.DIR_LEFT)
                {
                    xIncrement = -1;
                    yIncrement = 0;
                }
                else if (directionsJump[i] == GameVar.DIR_DOWN_LEFT)
                {
                    xIncrement = -1;
                    yIncrement = -1;
                }
                else if (directionsJump[i] == GameVar.DIR_DOWN)
                {
                    xIncrement = 0;
                    yIncrement = -1;
                }
                else if (directionsJump[i] == GameVar.DIR_DOWN_RIGHT)
                {
                    xIncrement = 1;
                    yIncrement = -1;
                }

                //get target coords of possible jump
                targetCoords = canJump(fields, x, y, xIncrement, yIncrement, currentPlayer);
                if (targetCoords == null)      //no jump possible
                {
                    continue;
                }
                int targetCoordsX = targetCoords[0];
                int targetCoordsY = targetCoords[1];

                //create new (master) move, make it on desk and inspect again from new position - in case multiple jump
                newMove = new Move(x, y, targetCoordsX, targetCoordsY);
                newMove.addRemoveField(targetCoordsX - xIncrement, targetCoordsY - yIncrement);
                desk.makeMove(newMove);
                jumpsFound = getPossibleJumps(desk, targetCoordsX, targetCoordsY, currentPlayer);
                desk.undoMove(newMove);

                //multiple jump found
                if (jumpsFound.Count > 0)
                {
                    foreach (Move jump in jumpsFound)      //loop multiple jump fractals, add for master jump
                    {
                        jump.addOverField(jump.getFrom()[0], jump.getFrom()[1]);
                        jump.addRemoveField(jump.getFrom()[0] - xIncrement, jump.getFrom()[1] - yIncrement);
                        jump.setFrom(x, y);
                        possibleJumps.Add(jump);
                    }
                }
                else
                {
                    possibleJumps.Add(newMove);       //no (more) multijumps, add master jump to results
                }
            }
            return possibleJumps;
        }

        public ArrayList getPossibleMoves(Desk desk, short currentPlayer, bool firstMoveOnly = false)
        {
            int[,] fields = desk.getFields();
            int x, y, size = desk.getSize();
            ArrayList possibleMoves = new ArrayList();
            bool forcedMoves = false;
            short opositePlayer = getOppositePlayer(currentPlayer);

            ArrayList playerFields = null;
            ArrayList playerFieldsCopy = new ArrayList();

            //get current player fields
            if (currentPlayer == GameVar.PLAYER_WHITE)
            {
                playerFields = desk.getPlayerFields(GameVar.PLAYER_WHITE);
            }
            else if (currentPlayer == GameVar.PLAYER_BLACK)
            {
                playerFields = desk.getPlayerFields(GameVar.PLAYER_BLACK);
            }

            //make player_fields_copy, because while move inspected player_fields change
            foreach (var field in playerFields)
            {
                playerFieldsCopy.Add(field);
            }

            int playerFieldsCnt = playerFieldsCopy.Count;
            for (int i = 0; i < playerFieldsCnt; i++)           //loop player fields
            {
                x = (int)(playerFieldsCopy[i] as Array).GetValue(0);
                y = (int)(playerFieldsCopy[i] as Array).GetValue(1);

                //get possible jumps
                ArrayList possible_jumps = getPossibleJumps(desk, x, y, currentPlayer);
                if (possible_jumps.Count > 0)
                {
                    if (!forcedMoves)      //forced jump found, do not inspect normal moves anymore
                    {
                        possibleMoves.Clear();
                        forcedMoves = true;
                    }
                    foreach (Move jump in possible_jumps)
                    {
                        addMove(possibleMoves, jump);      //add jump move to results
                    }
                    if (firstMoveOnly)
                    {
                        return possibleMoves;
                    }
                }

                if (!forcedMoves)      //inspect normal moves only when no forced jump found
                {
                    int newX = 0;
                    int newY = 0;

                    //loop normal moves directions
                    for (int k = 0; k < directionsNormal[currentPlayer].Length; k++)
                    {
                        if (directionsNormal[currentPlayer][k] == GameVar.DIR_UP)
                        {
                            newX = x;
                            newY = y + 1;
                        }
                        else if (directionsNormal[currentPlayer][k] == GameVar.DIR_UP_LEFT)
                        {
                            newX = x - 1;
                            newY = y + 1;
                        }
                        else if (directionsNormal[currentPlayer][k] == GameVar.DIR_UP_RIGHT)
                        {
                            newX = x + 1;
                            newY = y + 1;
                        }
                        else if (directionsNormal[currentPlayer][k] == GameVar.DIR_DOWN)
                        {
                            newX = x;
                            newY = y - 1;
                        }
                        else if (directionsNormal[currentPlayer][k] == GameVar.DIR_DOWN_LEFT)
                        {
                            newX = x - 1;
                            newY = y - 1;
                        }
                        else if (directionsNormal[currentPlayer][k] == GameVar.DIR_DOWN_RIGHT)
                        {
                            newX = x + 1;
                            newY = y - 1;
                        }
                        if (GameVar.isValidField(newX, newY, deskSize) && fields[newX, newY] == GameVar.FIELD_EMPTY)
                        {
                            addMove(possibleMoves, x, y, newX, newY);      //add normal move to results

                            if (firstMoveOnly)
                            {
                                return possibleMoves;
                            }
                        }
                    }
                }
            }
            return possibleMoves;
        }
    }
}
