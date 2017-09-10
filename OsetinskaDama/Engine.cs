using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    public class Engine
    {
        private int depthMax = 2;
        private int movesInspected = 0;
        private bool randomMoveSelection = true;

        public void setDepth(int depth)
        {
            if (depth < 0)
                throw new Exception("Depth in Engine.setDepth not valid number");
            else
                depthMax = depth;
        }

        public int getMovesInspectedCnt()
        {
            return movesInspected;
        }

        public void setRandomMoveSelection(bool flag)
        {
            randomMoveSelection = flag;
        }

        public Move getBestMove(Desk desk, GameRules rules)
        {
            movesInspected = 0;
            int topMoveScore = int.MinValue;
            int currentScore = 0;
            short currentPlayer = desk.getCurrentPlayer();
            short oppositePlayer = rules.getOppositePlayer(currentPlayer);
            bool maximizingPlayer = false;
            ArrayList topMoves = new ArrayList();

            //check game end - both players have some fields and at least one can move
            if (rules.isGameEnd(desk))
                return null;

            ArrayList possiblePlayerMoves = rules.getPossibleMoves(desk, currentPlayer);

            if (possiblePlayerMoves.Count == 0)        //no possible moves for current player, switch to another player
            {
                possiblePlayerMoves = rules.getPossibleMoves(desk, oppositePlayer);
                oppositePlayer = currentPlayer;
                maximizingPlayer = !maximizingPlayer;
            }

            //loop possible moves
            foreach (Move move in possiblePlayerMoves)
            {
                //try the move and run minimax
                desk.makeMove(move);
                currentScore = minimax(desk, rules, depthMax, oppositePlayer, maximizingPlayer);
                desk.undoMove(move);

                if (currentScore > topMoveScore)     //new top move found
                {
                    topMoveScore = currentScore;
                    topMoves.Clear();
                    topMoves.Add(move);
                }
                else if (currentScore == topMoveScore)    //more moves with same value found
                {
                    topMoves.Add(move);
                }
            }

            if (!randomMoveSelection)
                return (Move)topMoves[0];

            //pick randomly one of the top moves
            Random r = new Random();
            return (Move)topMoves[r.Next(0, topMoves.Count)];
        }

        private int minimax(Desk desk, GameRules rules, int depth, short currentPlayer, bool maximizingPlayer)
        {
            movesInspected++;
            short oppositePlayer = rules.getOppositePlayer(currentPlayer);

            if (rules.isGameEnd(desk))      //check game end - both players have some fields and at least one can move
            {
                short nextPlayer = rules.getNextPlayer(desk);
                if (desk.getPlayerFields(GameVar.PLAYER_WHITE).Count != 0 && desk.getPlayerFields(GameVar.PLAYER_BLACK).Count != 0 && nextPlayer == -1)
                {
                    return 0;       //draw, neither of players can move
                }
                if (maximizingPlayer)
                    return int.MinValue + depthMax - depth;
                return int.MaxValue - depthMax + depth;
            }

            if (depth == 0)     //check depth level, return eval of current position
            {
                if (maximizingPlayer)
                    return -rules.getGameEvaluation(desk, oppositePlayer);
                return rules.getGameEvaluation(desk, oppositePlayer);
            }

            //get new possible moves, make the moves and call recursively minmax
            ArrayList possibleMoves = rules.getPossibleMoves(desk, currentPlayer);
            int bestVal = 0;
            int currentVal = 0;

            //current player has no possible moves, play "nothing" and call minimax
            if (possibleMoves.Count == 0)
            {
                if (maximizingPlayer)
                {
                    bestVal = int.MinValue;
                    currentVal = minimax(desk, rules, depth, oppositePlayer, false);
                    bestVal = Math.Max(bestVal, currentVal);
                }
                else
                {
                    bestVal = int.MaxValue;
                    currentVal = minimax(desk, rules, depth, oppositePlayer, true);
                    bestVal = Math.Min(bestVal, currentVal);
                }
                return bestVal;
            }

            if (maximizingPlayer)      //current player's best move, looking for the highest rating move
            {
                bestVal = int.MinValue;
                foreach (Move move in possibleMoves)
                {
                    desk.makeMove(move);
                    currentVal = minimax(desk, rules, depth - 1, oppositePlayer, false);
                    desk.undoMove(move);
                    bestVal = Math.Max(bestVal, currentVal);
                }
            }
            else                  //opposite player's best move - the worst move for current player, looking for the lowest rating move
            {
                bestVal = int.MaxValue;
                foreach (Move move in possibleMoves)
                {
                    desk.makeMove(move);
                    currentVal = minimax(desk, rules, depth - 1, oppositePlayer, true);
                    desk.undoMove(move);
                    bestVal = Math.Min(bestVal, currentVal);
                }
            }
            return bestVal;
        }
    }
}
