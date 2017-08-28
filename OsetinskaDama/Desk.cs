using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    public class Desk
    {
        private int piecesCnt;
        private int size;
        private int[,] fields;
        private ArrayList fieldsWhite;
        private ArrayList fieldsBlack;
        private int piecesPerPlayer;
        private short currentPlayer;

        public Desk(int size, int piecesPerPlayer)
        {
            this.size = size;
            this.piecesPerPlayer = piecesPerPlayer;
            piecesCnt = size * size;
            fields = new int[size, size];
            reset();
        }

        public void reset()
        {
            currentPlayer = -1;
            fieldsWhite = new ArrayList();
            fieldsBlack = new ArrayList();

            //set up desk fields
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    fields[i, j] = GameVar.FIELD_EMPTY;
                }
            }
        }

        public short getCurrentPlayer()
        {
            return currentPlayer;
        }

        public void setCurrentPlayer(short player)
        {
            currentPlayer = player;
        }

        public int[,] getFields()
        {
            return fields;
        }

        public ArrayList getWhiteFields()
        {
            return fieldsWhite;
        }

        public ArrayList getBlackFields()
        {
            return fieldsBlack;
        }

        public int getSize()
        {
            return size;
        }

        public int getPicesCnt()
        {
            return piecesCnt;
        }

        public int getPieceOwnership(int x, int y)
        {
            return fields[x, y];
        }

        public void makeMove(Move move)
        {
            int xFrom = move.getFrom()[0];
            int yFrom = move.getFrom()[1];
            int xTo = move.getTo()[0];
            int yTo = move.getTo()[1];
            short player = -1;

            //get current player
            if (fields[xFrom, yFrom] == GameVar.FIELD_WHITE)
            {
                player = GameVar.PLAYER_WHITE;
            }
            else if (fields[xFrom, yFrom] == GameVar.FIELD_BLACK)
            {
                player = GameVar.PLAYER_BLACK;
            }
            else
            {
                throw new Exception("Making move from empty field");
            }

            //check remove fields
            ArrayList removeFields = move.getRemoveFields();
            if (removeFields == null)
            {
                return;
            }

            //remove fields - fields that were jumped
            int x = 0;
            int y = 0;
            int removeFieldsCnt = removeFields.Count;
            for (int i = 0; i < removeFieldsCnt; i++)
            {
                x = (int)(removeFields[i] as Array).GetValue(0);
                y = (int)(removeFields[i] as Array).GetValue(1);
                if (fields[x, y] == GameVar.FIELD_WHITE && player == GameVar.PLAYER_BLACK)
                {
                    removePlayerField(x, y, GameVar.PLAYER_WHITE);
                }
                else if (fields[x, y] == GameVar.FIELD_BLACK && player == GameVar.PLAYER_WHITE)
                {
                    removePlayerField(x, y, GameVar.PLAYER_BLACK);
                }
                if (x != xTo || y != yTo)         //make sure field where jump landed is not removed
                {
                    fields[x, y] = GameVar.FIELD_EMPTY;
                }
            }

            //switch from/to fields of current player
            removePlayerField(xFrom, yFrom, player);
            addPlayerField(xTo, yTo, player);

            //switch from/to fields on desk
            if (xFrom != xTo || yFrom != yTo)       //do not swith in case circular jumps
            {
                fields[move.getTo()[0], move.getTo()[1]] = fields[move.getFrom()[0], move.getFrom()[1]];
                fields[move.getFrom()[0], move.getFrom()[1]] = GameVar.FIELD_EMPTY;
            }
        }

        public void undoMove(Move move)
        {
            int xFrom = move.getFrom()[0];
            int yFrom = move.getFrom()[1];
            int xTo = move.getTo()[0];
            int yTo = move.getTo()[1];
            short player = -1;

            //get current player
            if (fields[xTo, yTo] == GameVar.FIELD_WHITE)
            {
                player = GameVar.PLAYER_WHITE;
            }
            else if (fields[xTo, yTo] == GameVar.FIELD_BLACK)
            {
                player = GameVar.PLAYER_BLACK;
            }

            //swith from/to fields
            if (xFrom != xTo || yFrom != yTo)       //do not swith if jump is cycle
            {
                fields[xFrom, yFrom] = fields[xTo, yTo];
                fields[xTo, yTo] = GameVar.FIELD_EMPTY;
            }

            if (player != -1)
            {
                removePlayerField(xTo, yTo, player);
                addPlayerField(xFrom, yFrom, player);

                //undo fields removed
                ArrayList fieldsRemoved = move.getRemoveFields();
                if (fieldsRemoved != null)
                {
                    int x = 0;
                    int y = 0;
                    for (int i = 0; i < fieldsRemoved.Count; i++)
                    {
                        x = (int)(fieldsRemoved[i] as Array).GetValue(0);
                        y = (int)(fieldsRemoved[i] as Array).GetValue(1);
                        if (player == GameVar.PLAYER_WHITE)
                        {
                            addPlayerField(x, y, GameVar.PLAYER_BLACK);
                            fields[x, y] = GameVar.PLAYER_BLACK;
                        }
                        else if (player == GameVar.PLAYER_BLACK)
                        {
                            addPlayerField(x, y, GameVar.PLAYER_WHITE);
                            fields[x, y] = GameVar.PLAYER_WHITE;
                        }
                    }
                }
            }
        }

        public void setField(int x, int y, short fieldValue)
        {
            if (!GameVar.isValidField(x, y, size))
                throw new Exception("Not valid field " + x + " " + y + " for size" + size);

            short player = 0;
            if (fieldValue == GameVar.FIELD_WHITE)
            {
                player = GameVar.PLAYER_WHITE;
            }
            else if (fieldValue == GameVar.FIELD_BLACK)
            {
                player = GameVar.PLAYER_BLACK;
            }
            else
            {
                throw new Exception("Player not recognized");
            }

            //set desk field
            fields[x, y] = fieldValue;
            addPlayerField(x, y, player);
        }

        public void setPlayerPieces(int[,] pieces, short player)
        {
            int piecesCnt = pieces.GetLength(0);
            int field = player == GameVar.PLAYER_WHITE ? GameVar.FIELD_WHITE : GameVar.FIELD_BLACK;
            for (int i = 0; i < piecesCnt; i++)
            {
                fields[pieces[i, 0], pieces[i, 1]] = field;
                addPlayerField(pieces[i, 0], pieces[i, 1], player);
            }

        }

        public void removePlayerField(int x, int y, short player)
        {
            int fieldsCnt, fieldsCntBack;
            ArrayList fields = null;

            //get player fields
            if (player == GameVar.PLAYER_WHITE)
            {
                fields = fieldsWhite;
            }
            else if (player == GameVar.PLAYER_BLACK)
            {
                fields = fieldsBlack;
            }
            else
            {
                throw new Exception("Player not recognized");
            }

            fieldsCnt = fields.Count;
            fieldsCntBack = fieldsCnt;

            //loop player fields, remove seleted field
            for (int i = 0; i < fieldsCnt; i++)
            {
                if ((int)(fields[i] as Array).GetValue(0) == x && (int)(fields[i] as Array).GetValue(1) == y)
                {
                    fields.RemoveAt(i);
                    break;
                }
            }
            if (fieldsCntBack == fields.Count)
                throw new Exception("field " + x + " " + y + " belonging to " + player + " not removed");
        }

        public void addPlayerField(int x, int y, short player)
        {
            int fieldsCnt;
            ArrayList fields = null;

            //get player fields
            if (player == GameVar.PLAYER_WHITE)
            {
                fields = fieldsWhite;
            }
            else if (player == GameVar.PLAYER_BLACK)
            {
                fields = fieldsBlack;
            }
            else
            {
                throw new Exception("Player not recognized");
            }

            fieldsCnt = fields.Count;

            if (fieldsCnt == piecesPerPlayer)     //adding more fields than player's max fields count
                throw new Exception("filed " + x + " " + y + " for player " + player + " out of max player fields count");
            fields.Add(new int[] { x, y });
        }
    }
}