using System;
using System.Collections;
using OsetinskaDama;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OsetinskaDamaTest
{
    [TestClass]
    public class OsetinskaDamaTests
    {
        [TestMethod]
        public void DefaultFieldsShouldBe21()
        {
            /*
             * o - white
             * x - black
             * 
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            //Act
            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);

            //Assert
            Assert.AreEqual(21, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(21, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void DefaultFieldsPositionTest()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            //Act
            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);

            //Assert
            int[,] fields = desk.getFields();
            Assert.AreEqual(fields[6, 6], GameVar.FIELD_BLACK);
            Assert.AreEqual(fields[3, 4], GameVar.FIELD_BLACK);
            Assert.AreEqual(fields[0, 5], GameVar.FIELD_BLACK);

            Assert.AreEqual(fields[0, 0], GameVar.FIELD_WHITE);
            Assert.AreEqual(fields[6, 1], GameVar.FIELD_WHITE);
            Assert.AreEqual(fields[2, 2], GameVar.FIELD_WHITE);

            Assert.AreEqual(fields[0, 3], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[6, 3], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 3], GameVar.FIELD_EMPTY);
        }

        [TestMethod]
        public void MakingMoveShouldKeepFieldsCount()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             *    
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 |o| | | | | | |
             *   ---------------
             * 2 | |o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Move move = new Move(0, 2, 0, 3);

            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);
            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);

            //Act
            desk.makeMove(move);

            //Assert
            Assert.AreEqual(21, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(21, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void MakingMoveShouldChangeFieldPosition()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             *    
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | |o| | | |
             *   ---------------
             * 2 |o|o|o|o| |o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            int x1 = 4;
            int y1 = 2;
            int x2 = 3;
            int y2 = 3;
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Move move = new Move(x1, y1, x2, y2);

            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);

            //Act
            desk.makeMove(move);

            //Assert
            Assert.AreEqual(desk.getFields()[x1, y1], GameVar.FIELD_EMPTY);
            Assert.AreEqual(desk.getFields()[x2, y2], GameVar.FIELD_WHITE);
        }

        [TestMethod]
        public void MakingJumpShouldRemoveJumpedField()
        {
            /*
             *   ---------------
             * 6 |x| | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | |x| | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             *    
             *   ---------------
             * 6 |x| | | | | | |
             *   ---------------
             * 5 | | | |o| | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(3, 4, GameVar.PLAYER_BLACK);
            desk.setField(0, 6, GameVar.PLAYER_BLACK);

            Move move = new Move(3, 2, 3, 5);
            move.addRemoveField(3, 4);

            //Act
            desk.makeMove(move);

            //Assert
            Assert.AreEqual(21, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);

            int[,] fields = desk.getFields();
            Assert.AreEqual(fields[3, 2], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 4], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 5], GameVar.FIELD_WHITE);
            Assert.AreEqual(fields[0, 6], GameVar.FIELD_BLACK);
        }

        [TestMethod]
        public void MakingDoubleJumpShouldRemoveJumpedFields()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | |x| | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | |x| | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | |o| | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             *    
             *   ---------------
             * 6 | | | |o| | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(3, 0, GameVar.PLAYER_WHITE);
            desk.setField(3, 3, GameVar.PLAYER_BLACK);
            desk.setField(3, 5, GameVar.PLAYER_BLACK);

            Move move = new Move(3, 0, 3, 6);
            move.addRemoveField(3, 3);
            move.addRemoveField(3, 5);

            //Act
            desk.makeMove(move);

            //Assert
            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(0, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);

            int[,] fields = desk.getFields();
            Assert.AreEqual(fields[3, 0], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 3], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 4], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 5], GameVar.FIELD_EMPTY);
            Assert.AreEqual(fields[3, 6], GameVar.FIELD_WHITE);
        }

        [TestMethod]
        public void ShouldFind19PossibleMovesFromStartPosition()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);

            //Act
            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            ArrayList possible_moves_white = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_BLACK);
            ArrayList possible_moves_black = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            //Assert
            Assert.AreEqual(19, possible_moves_white.Count);
            Assert.AreEqual(19, possible_moves_black.Count);
        }

        [TestMethod]
        public void ShouldFind17White1BlackPossibleMoves()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | |o| | | |
             *   ---------------
             * 2 |o|o|o| |o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);

            //Act
            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            Move move = new Move(3, 2, 3, 3);
            desk.makeMove(move);
            ArrayList possible_moves_white = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_BLACK);
            ArrayList possible_moves_black = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            //Assert
            Assert.AreEqual(17, possible_moves_white.Count);
            Assert.AreEqual(1, possible_moves_black.Count);

            Move the_move = (Move)possible_moves_black[0];
            Assert.AreEqual(3, the_move.getFrom()[0]);
            Assert.AreEqual(4, the_move.getFrom()[1]);
            Assert.AreEqual(3, the_move.getTo()[0]);
            Assert.AreEqual(2, the_move.getTo()[1]);
        }

        [TestMethod]
        public void ShouldFindSimpleJump()
        {
            /*
             *   ---------------
             * 6 | |x| |x|x|x|x|
             *   ---------------
             * 5 | |x| | | | | |
             *   ---------------
             * 4 | | | |x| | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | |o| | | |
             *   ---------------
             * 1 |o| | | | | |o|
             *   ---------------
             * 0 |o| |o|o| | |o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setField(0, 0, GameVar.PLAYER_WHITE);
            desk.setField(0, 1, GameVar.PLAYER_WHITE);
            desk.setField(2, 0, GameVar.PLAYER_WHITE);
            desk.setField(3, 0, GameVar.PLAYER_WHITE);
            desk.setField(3, 2, GameVar.PLAYER_WHITE);
            desk.setField(6, 0, GameVar.PLAYER_WHITE);
            desk.setField(6, 1, GameVar.PLAYER_WHITE);
            desk.setField(1, 6, GameVar.PLAYER_BLACK);
            desk.setField(1, 5, GameVar.PLAYER_BLACK);
            desk.setField(3, 6, GameVar.PLAYER_BLACK);
            desk.setField(3, 4, GameVar.PLAYER_BLACK);
            desk.setField(4, 6, GameVar.PLAYER_BLACK);
            desk.setField(5, 6, GameVar.PLAYER_BLACK);
            desk.setField(6, 6, GameVar.PLAYER_BLACK);
            desk.setCurrentPlayer(GameVar.PLAYER_BLACK);

            //Act
            ArrayList possible_moves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            //Assert
            Assert.AreEqual(1, possible_moves.Count);

            Move the_move = (Move)possible_moves[0];
            Assert.AreEqual(3, the_move.getFrom()[0]);
            Assert.AreEqual(4, the_move.getFrom()[1]);
            Assert.AreEqual(3, the_move.getTo()[0]);
            Assert.AreEqual(1, the_move.getTo()[1]);
            Assert.AreEqual(1, the_move.getRemoveFields().Count);
        }

        [TestMethod]
        public void ShouldFindMultipleJump()
        {
            /*
             *   ---------------
             * 6 | | | |x| | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | |x| | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o| | |o| | | |
             *   ---------------
             * 1 | |o| | | | |o|
             *   ---------------
             * 0 |o| | |o| | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setField(0, 0, GameVar.PLAYER_WHITE);
            desk.setField(0, 2, GameVar.PLAYER_WHITE);
            desk.setField(1, 1, GameVar.PLAYER_WHITE);
            desk.setField(3, 0, GameVar.PLAYER_WHITE);
            desk.setField(3, 2, GameVar.PLAYER_WHITE);
            desk.setField(6, 1, GameVar.PLAYER_WHITE);
            desk.setField(3, 6, GameVar.PLAYER_BLACK);
            desk.setField(3, 4, GameVar.PLAYER_BLACK);
            desk.setCurrentPlayer(GameVar.PLAYER_BLACK);

            //Act
            ArrayList possible_moves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            //Assert
            Assert.AreEqual(1, possible_moves.Count);

            Move the_move = (Move)possible_moves[0];
            Assert.AreEqual(3, the_move.getFrom()[0]);
            Assert.AreEqual(4, the_move.getFrom()[1]);
            Assert.AreEqual(0, the_move.getTo()[0]);
            Assert.AreEqual(3, the_move.getTo()[1]);
            Assert.AreEqual(3, the_move.getRemoveFields().Count);
        }

        [TestMethod]
        public void ShouldFindTwoMultipleCircularJumps()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | |x| |x| | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | |x| |x| | |
             *   ---------------
             * 2 | | | |o| | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setField(3, 2, GameVar.PLAYER_WHITE);
            desk.setField(2, 3, GameVar.PLAYER_BLACK);
            desk.setField(2, 5, GameVar.PLAYER_BLACK);
            desk.setField(4, 3, GameVar.PLAYER_BLACK);
            desk.setField(4, 5, GameVar.PLAYER_BLACK);
            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);

            //Act
            ArrayList possible_moves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            //Assert
            Assert.AreEqual(2, possible_moves.Count);

            Move the_move = (Move)possible_moves[0];
            Assert.AreEqual(3, the_move.getFrom()[0]);
            Assert.AreEqual(2, the_move.getFrom()[1]);
            Assert.AreEqual(3, the_move.getTo()[0]);
            Assert.AreEqual(2, the_move.getTo()[1]);
            Assert.AreEqual(4, the_move.getRemoveFields().Count);

            the_move = (Move)possible_moves[1];
            Assert.AreEqual(3, the_move.getFrom()[0]);
            Assert.AreEqual(2, the_move.getFrom()[1]);
            Assert.AreEqual(3, the_move.getTo()[0]);
            Assert.AreEqual(2, the_move.getTo()[1]);
            Assert.AreEqual(4, the_move.getRemoveFields().Count);
        }

        [TestMethod]
        public void ShouldFind3PossibleJumps()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | |x| | |
             *   ---------------
             * 3 | | | |x|x| | |
             *   ---------------
             * 2 | | | |o| | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(3, 2, GameVar.PLAYER_WHITE);
            desk.setField(3, 3, GameVar.PLAYER_BLACK);
            desk.setField(4, 3, GameVar.PLAYER_BLACK);
            desk.setField(4, 4, GameVar.PLAYER_BLACK);

            //Act
            ArrayList possible_moves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            //Assert
            Assert.AreEqual(3, possible_moves.Count);
        }

        [TestMethod]
        public void AIShouldFindBetterJumpAmongTwoPossibleJumps()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | |x| |
             *   ---------------
             * 3 | |x| | | | | |
             *   ---------------
             * 2 | | |x| | | | |
             *   ---------------
             * 1 | | |o| | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             *    
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | |x| |
             *   ---------------
             * 3 |o| | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(2, 1, GameVar.PLAYER_WHITE);
            desk.setField(2, 2, GameVar.PLAYER_BLACK);
            desk.setField(1, 3, GameVar.PLAYER_BLACK);
            desk.setField(5, 4, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);
            desk.makeMove(ai_move);

            //Assert
            Assert.AreEqual(0, ai_move.getTo()[0]);
            Assert.AreEqual(3, ai_move.getTo()[1]);

            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void AIShouldAvoidToGetJumped()
        {
            /*
             *   ---------------
             * 6 |x|x| | | | | |
             *   ---------------
             * 5 | | | | | |o| |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(5, 5, GameVar.PLAYER_WHITE);
            desk.setField(0, 6, GameVar.PLAYER_BLACK);
            desk.setField(1, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);
            desk.makeMove(ai_move);

            //Assert
            Assert.AreEqual(6, ai_move.getTo()[0]);
            Assert.AreEqual(6, ai_move.getTo()[1]);

            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(2, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void AIShouldAvoidToGetJumped2()
        {
            /*
             *   ---------------
             * 6 | | |x|x| | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | |o| | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(2, 2, GameVar.PLAYER_WHITE);
            desk.setField(2, 6, GameVar.PLAYER_BLACK);
            desk.setField(3, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);
            desk.makeMove(ai_move);

            //Assert
            Assert.AreEqual(1, ai_move.getTo()[0]);
            Assert.AreEqual(3, ai_move.getTo()[1]);

            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(2, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void AIShouldNotAvoidToGetJumpedButSacrificeFigureToWin()
        {
            /*
             *   ---------------
             * 6 | |x|x| | | | |
             *   ---------------
             * 5 | | | | | |o| |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | |o| | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(2);     //ai must inspect at least 3 steps forward to see the sacrifice

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(1, 2, GameVar.PLAYER_WHITE);
            desk.setField(5, 5, GameVar.PLAYER_WHITE);
            desk.setField(1, 6, GameVar.PLAYER_BLACK);
            desk.setField(2, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);
            desk.makeMove(ai_move);

            //Assert
            Assert.AreEqual(6, ai_move.getTo()[0]);
            Assert.AreEqual(6, ai_move.getTo()[1]);

            Assert.AreEqual(2, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(2, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void AIShouldFindTheShortestWayToWin()
        {
            /*
             *   ---------------
             * 6 | | |x| | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | |o| |
             *   ---------------
             * 3 | | | | | | |o|
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 |o| | | | | | |
             *   ---------------
             * 0 |o| | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(2);     //ai must inspect at least 3 steps forward to see the win

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 0, GameVar.PLAYER_WHITE);
            desk.setField(0, 1, GameVar.PLAYER_WHITE);
            desk.setField(6, 3, GameVar.PLAYER_WHITE);
            desk.setField(5, 4, GameVar.PLAYER_WHITE);
            desk.setField(2, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);
            desk.makeMove(ai_move);

            //Assert
            bool correct_x_found = false;
            if (ai_move.getTo()[0] == 4 || ai_move.getTo()[0] == 5 || ai_move.getTo()[0] == 6)
                correct_x_found = true;

            Assert.AreEqual(true, correct_x_found);
            Assert.AreEqual(5, ai_move.getTo()[1]);

            Assert.AreEqual(4, desk.getPlayerFields(GameVar.PLAYER_WHITE).Count);
            Assert.AreEqual(1, desk.getPlayerFields(GameVar.PLAYER_BLACK).Count);
        }

        [TestMethod]
        public void AIShouldPreferPositionOnTheEdgeOfTheDesk()
        {
            /*
             *   ---------------
             * 6 | | | | | |x|x|
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | |o| | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(0);
            engine.setRandomMoveSelection(false);
            rules.setEvalPiecePosition(true);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(1, 4, GameVar.PLAYER_WHITE);
            desk.setField(5, 6, GameVar.PLAYER_BLACK);
            desk.setField(6, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);

            //Assert
            Assert.AreEqual(0, ai_move.getTo()[0]);
            Assert.AreEqual(5, ai_move.getTo()[1]);
        }

        [TestMethod]
        public void AIShouldPreferPositionOnTheEdgeOfTheDesk2()
        {
            /*
             *   ---------------
             * 6 | | | |x| | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | |o| | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | |o| | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(0);
            engine.setRandomMoveSelection(false);
            rules.setEvalPiecePosition(true);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(1, 0, GameVar.PLAYER_WHITE);
            desk.setField(1, 2, GameVar.PLAYER_WHITE);
            desk.setField(3, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);

            //Assert
            Assert.AreEqual(0, ai_move.getTo()[0]);
            Assert.AreEqual(3, ai_move.getTo()[1]);
        }

        [TestMethod]
        public void AIShouldPreferPositionOnTheEdgeOfTheDesk3()
        {
            /*
             *   ---------------
             * 6 | | | |x| | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o| | | | | | |
             *   ---------------
             * 1 | | | | | |x| |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(0);
            engine.setRandomMoveSelection(false);
            rules.setEvalPiecePosition(true);

            desk.setCurrentPlayer(GameVar.PLAYER_BLACK);
            desk.setField(0, 2, GameVar.PLAYER_WHITE);
            desk.setField(3, 6, GameVar.PLAYER_BLACK);
            desk.setField(5, 1, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);

            //Assert
            Assert.AreEqual(4, ai_move.getTo()[0]);
            Assert.AreEqual(0, ai_move.getTo()[1]);
        }

        [TestMethod]
        public void AIShouldPreferPositionOnTheEdgeOfTheDesk4()
        {
            /*
             *   ---------------
             * 6 |x| | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o| | | | |o| |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(0);
            engine.setRandomMoveSelection(false);
            rules.setEvalPiecePosition(true);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 2, GameVar.PLAYER_WHITE);
            desk.setField(5, 2, GameVar.PLAYER_WHITE);
            desk.setField(0, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);

            //Assert
            Assert.AreEqual(6, ai_move.getTo()[0]);
            Assert.AreEqual(3, ai_move.getTo()[1]);
        }

        [TestMethod]
        public void AIShouldPreferPositionOnTheEdgeOfTheDesk5()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(0);
            rules.setEvalPiecePosition(true);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);

            //Assert
            Assert.IsTrue(ai_move.getTo()[0] == 0 || ai_move.getTo()[0] == 6);
            Assert.AreEqual(3, ai_move.getTo()[1]);
        }

        [TestMethod]
        public void AIShouldNotPreferPositionOnTheEdgeOfTheDesk()
        {
            /*
             *   ---------------
             * 6 |x| | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o| | | | |o| |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(1);
            rules.setEvalPiecePosition(true);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 2, GameVar.PLAYER_WHITE);
            desk.setField(5, 2, GameVar.PLAYER_WHITE);
            desk.setField(0, 6, GameVar.PLAYER_BLACK);

            //Act
            Move ai_move = engine.getBestMove(desk, rules);

            //Assert
            Assert.AreEqual(1, ai_move.getTo()[0]);
            Assert.AreEqual(3, ai_move.getTo()[1]);
        }

        [TestMethod]
        public void EngineShouldStopAfterEightMovesInspected()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 |o| | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | |x| | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(10);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 5, GameVar.PLAYER_WHITE);
            desk.setField(3, 1, GameVar.PLAYER_BLACK);

            //Act
            Move move = engine.getBestMove(desk, rules);
            int game_end = engine.getMovesInspectedCnt();

            //Assert
            Assert.AreEqual(game_end, 8);
        }

        [TestMethod]
        public void EngineShouldStopAfterFourMovesInspected()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 |o| | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 |x| | | | |x| |
             *   ---------------
             * 0 |x|x| | |x| |x|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();
            engine.setDepth(10);

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 5, GameVar.PLAYER_WHITE);
            desk.setField(0, 0, GameVar.PLAYER_BLACK);
            desk.setField(0, 1, GameVar.PLAYER_BLACK);
            desk.setField(1, 0, GameVar.PLAYER_BLACK);
            desk.setField(4, 0, GameVar.PLAYER_BLACK);
            desk.setField(5, 1, GameVar.PLAYER_BLACK);
            desk.setField(6, 0, GameVar.PLAYER_BLACK);

            //Act
            Move move = engine.getBestMove(desk, rules);
            int game_end = engine.getMovesInspectedCnt();

            //Assert
            Assert.AreEqual(game_end, 4);
        }


        [TestMethod]
        public void ShouldNotBeGameEnd()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | |o| | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | |x| |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(3, 5, GameVar.PLAYER_WHITE);
            desk.setField(5, 0, GameVar.PLAYER_BLACK);

            //Act
            bool game_end = rules.isGameEnd(desk);

            //Assert
            Assert.AreEqual(false, game_end);
        }

        [TestMethod]
        public void ShouldNotBeGameEnd2()
        {
            /*
             *   ---------------
             * 6 | | | |o| | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | |x| |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(3, 6, GameVar.PLAYER_WHITE);
            desk.setField(5, 1, GameVar.PLAYER_BLACK);

            //Act
            bool game_end = rules.isGameEnd(desk);

            //Assert
            Assert.AreEqual(false, game_end);
        }

        [TestMethod]
        public void ShouldBeGameEndNoMoveWhiteWins()
        {
            /*
             *   ---------------
             * 6 | | |o|o|o| | |
             *   ---------------
             * 5 | | | |o| | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | |x|x|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(3, 5, GameVar.PLAYER_WHITE);
            desk.setField(2, 6, GameVar.PLAYER_WHITE);
            desk.setField(3, 6, GameVar.PLAYER_WHITE);
            desk.setField(4, 6, GameVar.PLAYER_WHITE);
            desk.setField(5, 0, GameVar.PLAYER_BLACK);
            desk.setField(6, 0, GameVar.PLAYER_BLACK);

            //Act
            bool game_end = rules.isGameEnd(desk);
            short game_result = rules.decideGameResult(desk);

            //Assert
            Assert.AreEqual(true, game_end);
            Assert.AreEqual(GameVar.PLAYER_WHITE, game_result);
        }

        [TestMethod]
        public void ShouldBeGameEndNoMoveDraw()
        {
            /*
             *   ---------------
             * 6 | | |o| |o| | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 |x| | | | |x| |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(2, 6, GameVar.PLAYER_WHITE);
            desk.setField(4, 6, GameVar.PLAYER_WHITE);
            desk.setField(0, 0, GameVar.PLAYER_BLACK);
            desk.setField(5, 0, GameVar.PLAYER_BLACK);

            //Act
            bool game_end = rules.isGameEnd(desk);
            short game_result = rules.decideGameResult(desk);

            //Assert
            Assert.AreEqual(true, game_end);
            Assert.AreEqual(0, game_result);
        }

        [TestMethod]
        public void ShouldBeGameEndWhiteHasNoFigures()
        {
            /*
             *   ---------------
             * 6 |x| | | | | | |
             *   ---------------
             * 5 | | | | | | | |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | |x| |x| | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | | | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 6, GameVar.PLAYER_BLACK);
            desk.setField(2, 2, GameVar.PLAYER_BLACK);
            desk.setField(4, 2, GameVar.PLAYER_BLACK);

            //Act
            bool game_end = rules.isGameEnd(desk);
            short game_result = rules.decideGameResult(desk);

            //Assert
            Assert.AreEqual(true, game_end);
            Assert.AreEqual(GameVar.PLAYER_BLACK, game_result);
        }

        [TestMethod]
        public void ShouldBeGameEndBlackHasNoFigures()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | | | |o| |
             *   ---------------
             * 4 | | | | | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | |o| | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 |o| | | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(0, 0, GameVar.PLAYER_WHITE);
            desk.setField(4, 2, GameVar.PLAYER_WHITE);
            desk.setField(5, 5, GameVar.PLAYER_WHITE);

            //Act
            bool game_end = rules.isGameEnd(desk);
            short game_result = rules.decideGameResult(desk);

            //Assert
            Assert.AreEqual(true, game_end);
            Assert.AreEqual(GameVar.PLAYER_WHITE, game_result);
        }


        [TestMethod]
        public void ShouldSwitchCurrentPlayerToBlack()
        {
            /*
             *   ---------------
             * 6 |x|x|x|x|x|x|x|
             *   ---------------
             * 5 |x|x|x|x|x|x|x|
             *   ---------------
             * 4 |x|x|x|x|x|x|x|
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 |o|o|o|o|o|o|o|
             *   ---------------
             * 1 |o|o|o|o|o|o|o|
             *   ---------------
             * 0 |o|o|o|o|o|o|o|
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);

            //Act
            short player = rules.getNextPlayer(desk);

            //Assert
            Assert.AreEqual(GameVar.PLAYER_BLACK, player);
        }

        [TestMethod]
        public void ShouldLetWhitePlayAgain()
        {
            /*
             *   ---------------
             * 6 | | | | | | | |
             *   ---------------
             * 5 | | | | |o| | |
             *   ---------------
             * 4 | | |o| | | | |
             *   ---------------
             * 3 | | | | | | | |
             *   ---------------
             * 2 | | | | | | | |
             *   ---------------
             * 1 | | | | | | | |
             *   ---------------
             * 0 | |x| | | | | |
             *   ---------------
             *    0 1 2 3 4 5 6
             */

            //Arrange
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());

            desk.setCurrentPlayer(GameVar.PLAYER_WHITE);
            desk.setField(2, 4, GameVar.PLAYER_WHITE);
            desk.setField(4, 5, GameVar.PLAYER_WHITE);
            desk.setField(1, 0, GameVar.PLAYER_BLACK);

            //Act
            short player = rules.getNextPlayer(desk);

            //Assert
            Assert.AreEqual(GameVar.PLAYER_WHITE, player);
        }

        [TestMethod]
        public void MovesShouldBeEqual()
        {
            Move move1 = new Move(0, 1, 0, 1);
            Move move2 = new Move(0, 1, 0, 1);

            //Assert
            Assert.AreEqual(move1.isEqual(move2), true);
        }

        [TestMethod]
        public void MovesShouldBeEqual2()
        {
            Move move1 = new Move(0, 1, 0, 1);
            Move move2 = new Move(0, 1, 0, 1);

            move1.addOverField(3, 3);
            move2.addOverField(3, 3);
            move1.addOverField(0, 0);
            move2.addOverField(0, 0);

            //Assert
            Assert.AreEqual(move1.isEqual(move2), true);
        }

        [TestMethod]
        public void MovesShouldBeEqual3()
        {
            Move move1 = new Move(0, 1, 0, 1);
            Move move2 = new Move(0, 1, 0, 1);

            move1.addOverField(3, 4);
            move2.addOverField(3, 4);

            move1.addRemoveField(2, 2);
            move2.addRemoveField(2, 2);
            move1.addRemoveField(1, 5);
            move2.addRemoveField(1, 5);

            //Assert
            Assert.AreEqual(move1.isEqual(move2), true);
        }

        [TestMethod]
        public void MovesShouldNotBeEqual()
        {
            Move move1 = new Move(0, 1, 2, 3);
            Move move2 = new Move(0, 1, 0, 1);

            //Assert
            Assert.AreEqual(move1.isEqual(move2), false);
        }

        [TestMethod]
        public void MovesShouldNotBeEqual2()
        {
            Move move1 = new Move(0, 1, 0, 1);
            Move move2 = new Move(0, 1, 0, 1);

            move1.addOverField(3, 4);
            move2.addOverField(5, 2);

            //Assert
            Assert.AreEqual(move1.isEqual(move2), false);
        }

        [TestMethod]
        public void MovesShouldNotBeEqual3()
        {
            Move move1 = new Move(0, 1, 0, 1);
            Move move2 = new Move(0, 1, 0, 1);

            move1.addRemoveField(1, 0);
            move2.addRemoveField(0, 1);

            //Assert
            Assert.AreEqual(move1.isEqual(move2), false);
        }
    }
}
