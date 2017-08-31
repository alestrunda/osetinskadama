using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace OsetinskaDama
{
    internal partial class FormMain : Form
    {
        private GameRules rules;
        private Desk desk;
        private Engine engine;
        private formNewGame formNewGame;
        private formSettings formSettings;
        private PictureBox[,] pieces;
        private PictureBox pieceFocused;
        private ArrayList piecesSelected = new ArrayList();
        private ArrayList movesDone = new ArrayList();
        private ArrayList movesUndone = new ArrayList();
        private Move aiMove;
        private bool aiMoveComputingDone;
        private bool aiMoveTimerElapsed;
        private int playerWhiteControls;
        private int playerBlackControls;
        private uint gameTimerValue = 0;
        private uint gameSteps = 0;
        private bool gameRunning = false;
        private bool isPieceSelected = false;
        private bool isPieceSelectError = false;
        private bool pieceClickListening = false;
        private bool showPossibleMoves = false;
        private int minComputerPlayTime = 1000;
        private int computerWhiteLevel = 2;
        private int computerBlackLevel = 2;
        private int bestMoveAILevelDefault = 5;
        private int evalPiecePositionMinLevel = 3;
        private System.Windows.Forms.Timer gameTimer;
        private System.Timers.Timer aiTimer;
        private BackgroundWorker aiWorker;
        static readonly object _locker = new object();

        public FormMain(GameRules rules, Desk desk, Engine engine)
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            this.rules = rules;
            this.desk = desk;
            this.engine = engine;

            pieces = new PictureBox[rules.getDeskSize(), rules.getDeskSize()];
            playerWhiteControls = GameVar.PLAYER_HUMAN;
            playerBlackControls = GameVar.PLAYER_HUMAN;

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += new EventHandler(gameTimer_Tick);

            formNewGame = new formNewGame();
            formNewGame.buttonStart_Invoked += buttonNewGame_Click;
            formSettings = new formSettings();
            formSettings.buttonSave_Clicked += buttonSettingsSave_Click;

            InitializeComponent();
            setUpPieces();
            resetGameInfo();
            resetGameTimer();
            aiButtonsDisable();
        }

        private void setPlayerPieces(int player, ArrayList fields)
        {
            int fieldsLen = fields.Count;
            Bitmap pieceBg = player == GameVar.PLAYER_WHITE ? Properties.Resources.piece_white : Properties.Resources.piece_black;
            for (int i = 0; i < fieldsLen; i++)
            {
                pieces[(int)(fields[i] as Array).GetValue(0), (int)(fields[i] as Array).GetValue(1)].BackgroundImage = pieceBg;
            }
        }

        private void setUpPieces()
        {
            int piecesCnt = rules.getDeskSize();
            for (int x = 0; x < piecesCnt; x++)
            {
                for (int y = 0; y < piecesCnt; y++)
                {
                    pieces[x, y] = makePiece("piece" + x + '-' + y);
                    tableDesk.Controls.Add(pieces[x, y], x, piecesCnt - 1 - y);
                }
            }
        }

        private PictureBox makePiece(string name)
        {
            PictureBox piece = new PictureBox();
            piece.BackgroundImageLayout = ImageLayout.Stretch;
            piece.Dock = DockStyle.Fill;
            piece.Location = new Point(0, 0);
            piece.Margin = new Padding(0);
            piece.Name = name;
            piece.BackColor = Color.Transparent;
            piece.Click += new EventHandler(handlePieceClick);
            return piece;
        }

        private void setActivePlayerBox(int player)
        {
            PictureBox currentPlayerImage = player == GameVar.PLAYER_WHITE ? playerWhiteImage : playerBlackImage;
            groupPlayers.Refresh();
            drawPictureBoxControl(currentPlayerImage, Properties.Resources.piece_control_select);
        }

        private void setActivePlayer(int player, bool autorunAI = true, bool refreshPlayerControl = true)
        {
            addGameNotice((player == GameVar.PLAYER_WHITE ? playerWhiteName.Text : playerBlackName.Text) + " on turn");

            if (refreshPlayerControl)       //refresh pieces signalizing which player is on turn
            {
                setActivePlayerBox(player);
            }

            if (!isComputerOnTurn())
            {
                aiButtonsDisable();
                pieceClickListening = true;
            }
            else
            {
                aiButtonsEnableContinue();
                if (autorunAI)
                    makeAIMove();
            }
        }

        private void aiButtonsDisable()
        {
            buttonStopAI.Enabled = false;
            buttonContinueAI.Enabled = false;
        }

        private void aiButtonsEnableStop()
        {
            buttonStopAI.Enabled = true;
            buttonContinueAI.Enabled = false;
        }

        private void aiButtonsEnableContinue()
        {
            buttonStopAI.Enabled = false;
            buttonContinueAI.Enabled = true;
        }

        private void startAIComputing(object sender, DoWorkEventArgs e)
        {
            aiMove = engine.getBestMove(desk, rules, desk.getCurrentPlayer());
        }

        private void aiComputingFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isComputerOnTurn())
            {
                lock (_locker)      // main UI thread and aiTimer thread use these variables
                {
                    if (aiMoveTimerElapsed)
                        aiMoveReady();
                    else
                        aiMoveComputingDone = true;
                }
            }
            else
            {
                aiHelpMoveReady();
            }
        }

        private void cancelAIComputing(bool handleAIButtons = true)
        {
            if (aiTimer != null)
                aiTimer.Stop();
            if (aiWorker != null)
            {
                aiWorker.RunWorkerCompleted -= aiComputingFinished;
                aiWorker.Dispose();
            }
            if (handleAIButtons)
            {
                if (!isComputerOnTurn())
                    aiButtonsDisable();
                else
                    aiButtonsEnableContinue();
            }
        }

        private void setupAIComputing()
        {
            aiWorker = new BackgroundWorker();
            aiWorker.DoWork += startAIComputing;
            aiWorker.RunWorkerCompleted += aiComputingFinished;
            aiWorker.RunWorkerAsync();
        }

        private void setAILevel(int level)
        {
            rules.setEvalPiecePosition(level >= evalPiecePositionMinLevel);
            engine.setDepth(level);
        }

        private void makeAIMove()
        {
            aiButtonsEnableStop();

            aiMove = null;
            aiMoveComputingDone = false;
            aiMoveTimerElapsed = false;
            int aiLevel = desk.getCurrentPlayer() == GameVar.PLAYER_WHITE ? computerWhiteLevel : computerBlackLevel;
            setAILevel(aiLevel);
            setupAIComputing();

            // "AI minimal play time" timer
            aiTimer = new System.Timers.Timer();
            aiTimer.Elapsed += new ElapsedEventHandler(onAITimerElapsed);
            aiTimer.Interval = minComputerPlayTime;
            aiTimer.Enabled = true;
        }

        private void onAITimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (_locker)      // main UI thread and aiTimer thread use these variables
            {
                aiTimer.Stop();
                if (aiMoveComputingDone)
                {
                    this.Invoke(new Action(aiMoveReady));       // switch to UI thread
                }
                else
                {
                    aiMoveTimerElapsed = true;
                }
            }
        }

        private void aiMoveReady()
        {
            if (aiMove == null)     // no possible move found
            {
                addGameNotice("Computer move failed");
                aiButtonsEnableContinue();
                return;
            }
            aiButtonsDisable();
            performMove(aiMove);
        }

        private void aiHelpMoveReady()
        {
            if (aiMove == null)     // no possible move found
            {
                addGameNotice("AI move failed");
                return;
            }
            highlightMove(aiMove);
            addGameNotice("suggested best move " + getMoveCoordsString(aiMove));
        }

        private void handlePieceClick(Object sender, EventArgs e)
        {
            if (!pieceClickListening)
                return;

            bool setAIButtons = false;
            cancelAIComputing(setAIButtons);    // AI computing "show best move" could be in progress

            PictureBox pieceClicked = (PictureBox)sender;
            int[] coords = getPieceCoords(pieceClicked.Name);

            if (isPieceSelectError)
            {
                tableDesk.Refresh();
                isPieceSelected = false;
                isPieceSelectError = false;
            }

            if (wasClickedOnOwnPiece(desk.getCurrentPlayer(), coords))      // start piece of move
            {
                // clean previously highlighted pieces
                tableDesk.Refresh();
                piecesSelected.Clear();

                pieceFocused = pieceClicked;
                isPieceSelected = true;
                if (showPossibleMoves)
                    highlightPossibleMovesFromPiece(pieceFocused, piecesSelected);
                else
                    drawPictureBoxControl(pieceClicked, Properties.Resources.piece_control_select);
            }
            else if (isPieceSelected)       // following pieces of move
            {
                if (isPartialMove(pieceFocused, pieceClicked, piecesSelected))      // move cannot be made yet, clicked piece is not end piece
                {
                    piecesSelected.Add(pieceClicked);
                    if (showPossibleMoves)
                        highlightPossibleMovesFromPiece(pieceFocused, piecesSelected);
                    else
                        drawPictureBoxControl(pieceClicked, Properties.Resources.piece_control_select);
                    return;
                }
                try
                {
                    makeHumanMove(pieceFocused, pieceClicked, piecesSelected);
                }
                catch       // selected move isn't possible
                {
                    drawPictureBoxControl(pieceClicked, Properties.Resources.piece_control_error);
                    addGameNotice("move " + getPieceCoordsString(pieceFocused) + " " + getPieceCoordsString(pieceClicked) + " is not possible");
                }
                isPieceSelectError = true;
            }
            else    // clicked on some piece without possibility of making move
            {
                tableDesk.Refresh();
                isPieceSelected = false;
            }
        }

        private bool wasClickedOnOwnPiece(int player, int[] coords)
        {
            ArrayList currentPlayerFields = player == GameVar.PLAYER_WHITE ? desk.getWhiteFields() : desk.getBlackFields();
            int fieldsLen = currentPlayerFields.Count;
            for (int i = 0; i < fieldsLen; i++)
            {
                if ((int)(currentPlayerFields[i] as Array).GetValue(0) == coords[0] && (int)(currentPlayerFields[i] as Array).GetValue(1) == coords[1])
                    return true;
            }
            return false;
        }

        private void highlightMove(Move move)
        {
            ArrayList overFields = move.getOverFields();
            ArrayList removeFields = move.getRemoveFields();
            String pieceEndStr = null;
            int overFieldsLen = overFields.Count;
            int removeFieldsLen = removeFields.Count;
            int i;

            drawPictureBoxControl(pieces[move.getFrom()[0], move.getFrom()[1]], Properties.Resources.piece_control_select);     // start piece
            for (i = 0; i < overFieldsLen; i++)          // pieces jumped over in multi-jump
            {
                drawPictureBoxControl(pieces[(int)(overFields[i] as Array).GetValue(0), (int)(overFields[i] as Array).GetValue(1)], Properties.Resources.piece_control_select, (i+1).ToString());
            }
            for (i = 0; i < removeFieldsLen; i++)          // pieces removed
            {
                drawPictureBoxControl(pieces[(int)(removeFields[i] as Array).GetValue(0), (int)(removeFields[i] as Array).GetValue(1)], Properties.Resources.piece_control_error);
            }
            if (overFieldsLen > 0)      // add number for end piece if multi-jump
            {
                pieceEndStr = i.ToString();
            }
            drawPictureBoxControl(pieces[move.getTo()[0], move.getTo()[1]], Properties.Resources.piece_control_select, pieceEndStr);     // end piece
        }

        private void highlightPossibleMovesFromPiece(PictureBox pieceStart, ArrayList piecesOver)
        {
            ArrayList possibleMoves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());
            ArrayList fieldsOver;
            int[] coordsStart = getPieceCoords(pieceStart.Name);
            int[] coordsLast = { };

            tableDesk.Refresh();        // clean previously highlighted pieces

            // hightlight start piece and all pieces already selected
            drawPictureBoxControl(pieceStart, Properties.Resources.piece_control_select);
            if (piecesOver.Count > 0)
            {
                coordsLast = getPieceCoords(((PictureBox)piecesOver[piecesOver.Count - 1]).Name);
                foreach (PictureBox piece in piecesOver)
                {
                    drawPictureBoxControl(piece, Properties.Resources.piece_control_select);
                }
            }

            foreach (Move move in possibleMoves)
            {
                if (move.getFrom()[0] != coordsStart[0] || move.getFrom()[1] != coordsStart[1])
                {
                    continue;
                }
                fieldsOver = move.getOverFields();
                if (fieldsOver.Count == 0)          // no over fields, hightlight only the end piece
                {
                    drawPictureBoxControl(move.getTo()[0], move.getTo()[1], Properties.Resources.piece_control_select);
                    continue;
                }
                if (piecesOver.Count == 0)          // no selected pieces, hightlight the first over field
                {
                    drawPictureBoxControl((int)(fieldsOver[0] as Array).GetValue(0), (int)(fieldsOver[0] as Array).GetValue(1), Properties.Resources.piece_control_select);
                    continue;
                }
                if (fieldsOver.Count < piecesOver.Count)
                {
                    continue;
                }
                if ((int)(fieldsOver[piecesOver.Count - 1] as Array).GetValue(0) == coordsLast[0] && (int)(fieldsOver[piecesOver.Count - 1] as Array).GetValue(1) == coordsLast[1])
                {
                    // highlight next over field after last selected piece
                    if (piecesOver.Count < fieldsOver.Count)
                        drawPictureBoxControl((int)(fieldsOver[piecesOver.Count] as Array).GetValue(0), (int)(fieldsOver[piecesOver.Count] as Array).GetValue(1), Properties.Resources.piece_control_select);
                    else
                        drawPictureBoxControl(move.getTo()[0], move.getTo()[1], Properties.Resources.piece_control_select);
                }
            }
        }

        private bool isPartialMove(PictureBox pieceStart, PictureBox pieceEnd, ArrayList piecesOver)
        {
            ArrayList fieldsOver;
            ArrayList possibleMoves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());
            int[] coordsStart = getPieceCoords(pieceStart.Name);
            int[] coordsEnd = getPieceCoords(pieceEnd.Name);
            foreach (Move move in possibleMoves)
            {
                fieldsOver = move.getOverFields();
                if (move.getFrom()[0] != coordsStart[0] || move.getFrom()[1] != coordsStart[1])
                    continue;
                if (fieldsOver.Count == 0 || fieldsOver.Count - 1 < piecesOver.Count)
                    continue;
                if ((int)(fieldsOver[piecesOver.Count] as Array).GetValue(0) == coordsEnd[0] && (int)(fieldsOver[piecesOver.Count] as Array).GetValue(1) == coordsEnd[1])
                    return true;
            }
            return false;
        }

        private void makeHumanMove(PictureBox pieceStart, PictureBox pieceEnd, ArrayList piecesOver)
        {
            int[] coordsStart = getPieceCoords(pieceStart.Name);
            int[] coordsEnd = getPieceCoords(pieceEnd.Name);
            int[] coordsOver;
            int fieldsOverCnt;
            ArrayList fieldsOver;
            ArrayList possibleMoves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());

            foreach (Move move in possibleMoves)
            {
                if (move.getFrom()[0] != coordsStart[0] || move.getFrom()[1] != coordsStart[1] || move.getTo()[0] != coordsEnd[0] || move.getTo()[1] != coordsEnd[1])
                    continue;
                fieldsOver = move.getOverFields();
                fieldsOverCnt = fieldsOver.Count;
                if (piecesOver.Count != fieldsOverCnt)
                    continue;
                for (int i = 0; i < fieldsOverCnt; i++)
                {
                    coordsOver = getPieceCoords(((PictureBox)piecesOver[i]).Name);
                    if ((int)(fieldsOver[i] as Array).GetValue(0) != coordsOver[0] || (int)(fieldsOver[i] as Array).GetValue(1) != coordsOver[1])
                        continue;
                }
                pieceClickListening = false;
                performMove(move);
                return;
            }
            throw new Exception("No possible move with these pieces");
        }

        private void performMove(Move move, bool newMovePath = true, bool refreshDesk = true, bool autorunAI = true)
        {
            if (newMovePath)
            {
                // in case some undo moves were made, clear this history
                int movesUndoneCnt = movesUndone.Count;
                while (movesUndoneCnt > 0)
                {
                    gameMovesHistory.Items.RemoveAt(0);
                    movesUndoneCnt--;
                }
                movesUndone.Clear();
            }

            movesDone.Add(move);
            boardMakeMove(move);
            desk.makeMove(move);
            if (refreshDesk)
                tableDesk.Refresh();
            incrementGameSteps();
            updatePlayerPiecesCnt(rules.getOppositePlayer(desk.getCurrentPlayer()));
            if (newMovePath)
                addGameHistoryMove(move);
            if (rules.isGameEnd(desk))
            {
                gameFinished();
                return;
            }
            desk.setCurrentPlayer(rules.getNextPlayer(desk));
            setActivePlayer(desk.getCurrentPlayer(), autorunAI, refreshDesk);
        }

        private bool isComputerOnTurn()
        {
            return (desk.getCurrentPlayer() == GameVar.PLAYER_WHITE ? playerWhiteControls : playerBlackControls) == GameVar.PLAYER_COMPUTER;
        }

        private void redoMove(Move move, bool refreshDesk = true)
        {
            bool cleanDesk = false;
            bool setAIButtons = false;
            stopPlayers(cleanDesk, setAIButtons);

            int movesUndoneCount = movesUndone.Count;
            bool cleanUndoMoves = false;
            bool autorunAI = false;
            if (movesUndoneCount <= 0)
                throw new Exception("No moves to redo.");
            movesUndone.RemoveAt(movesUndoneCount - 1);
            movesUndoneCount = movesUndone.Count;
            if (movesUndoneCount == 0)
                clearMovesHistorySelectedIndex();
            else
                setMovesHistorySelectedIndex(movesUndoneCount - 1);
            addGameNotice("move redo");
            performMove(move, cleanUndoMoves, refreshDesk, autorunAI);
            if (!gameRunning)
                return;
            if (isComputerOnTurn())
                aiButtonsEnableContinue();
            else
                aiButtonsDisable();
        }

        private void undoMove(Move move, bool refreshDesk = true)
        {
            bool setAIButtons = false;
            stopPlayers(refreshDesk, setAIButtons);

            int movesDoneCount = movesDone.Count;
            bool autorunAI = false;
            if (movesDoneCount <= 0)
                throw new Exception("No moves to undo.");
            addGameNotice("move undo");
            movesDone.RemoveAt(movesDoneCount - 1);
            movesUndone.Add(move);
            boardUnmakeMove(move);
            decrementGameSteps();
            setMovesHistorySelectedIndex(movesUndone.Count - 1);
            desk.undoMove(move);
            desk.setCurrentPlayer((short)desk.getPieceOwnership(move.getFrom()[0], move.getFrom()[1]));
            updatePlayerPiecesCnt(rules.getOppositePlayer(desk.getCurrentPlayer()));
            if (isComputerOnTurn())
                aiButtonsEnableContinue();
            else
                aiButtonsDisable();
            if (!gameRunning)
                reactivateFinishedGame();
            setActivePlayer(desk.getCurrentPlayer(), autorunAI, refreshDesk);
        }

        private void setMovesHistorySelectedIndex(int index)
        {
            if (index < 0 || gameMovesHistory.Items.Count <= index)
                throw new Exception("wrong index value");
            gameMovesHistory.SelectedIndex = index;
        }

        private void clearMovesHistorySelectedIndex()
        {
            gameMovesHistory.ClearSelected();
        }

        private void gameFinished()
        {
            bool cleanDesk = false;
            bool handleAIButtons = false;
            stopGameTimer();
            stopPlayers(cleanDesk, handleAIButtons);
            aiButtonsDisable();
            groupPlayers.Refresh();     // remove image boxes signalizing who's on turn
            gameRunning = false;

            String labelWinner, labelHead;
            String labelGameDetails = "finished in " + gameTimerValue + "s, " + gameSteps + " steps";
            int gameResult = rules.decideGameResult(desk);
            FormGameOver form = new FormGameOver();
            if (gameResult != 0)      // player won
            {
                labelHead = "Congratulations";
                labelWinner = (gameResult == GameVar.PLAYER_WHITE ? playerWhiteName.Text : playerBlackName.Text) + " won!";
                labelGameDetails += ", " + Math.Abs(desk.getBlackFields().Count - desk.getWhiteFields().Count) + " piece(s) left";
            }
            else      // draw
            {
                labelHead = "Game Ended";
                labelWinner = "Draw";
            }
            form.setLabelHead(labelHead);
            form.setLabelWinner(labelWinner);
            form.setGameDetails(labelGameDetails);
            form.ShowDialog(this);
            addGameNotice("Game ended");
        }

        private void reactivateFinishedGame()
        {
            gameRunning = true;
            addGameNotice("Game continues");
            runGameTimer();
        }

        private void boardMakeMove(Move move)
        {
            PictureBox piece_start = pieces[move.getFrom()[0], move.getFrom()[1]];
            PictureBox piece_end = pieces[move.getTo()[0], move.getTo()[1]];
            int player = desk.getPieceOwnership(move.getFrom()[0], move.getFrom()[1]);

            piece_end.BackgroundImage = piece_start.BackgroundImage;
            piece_start.BackgroundImage = null;
            changePlayerPieces(move.getRemoveFields(), rules.getOppositePlayer((short)player));
            addGameNotice((player == GameVar.PLAYER_WHITE ? playerWhiteName.Text : playerBlackName.Text) + " moves " + getMoveCoordsString(move));
        }

        private void boardUnmakeMove(Move move)
        {
            PictureBox piece_start = pieces[move.getFrom()[0], move.getFrom()[1]];
            PictureBox piece_end = pieces[move.getTo()[0], move.getTo()[1]];
            bool restoreOriginalBg = true;
            int player = desk.getPieceOwnership(move.getTo()[0], move.getTo()[1]);

            piece_start.BackgroundImage = piece_end.BackgroundImage;
            piece_end.BackgroundImage = null;
            changePlayerPieces(move.getRemoveFields(), rules.getOppositePlayer((short)player), restoreOriginalBg);
            addGameNotice("move canceled " + getMoveCoordsString(move) + " by " + (player == GameVar.PLAYER_WHITE ? playerWhiteName.Text : playerBlackName.Text));
        }

        private void changePlayerPieces(ArrayList fields, int player, bool restoreBg = false)
        {
            Image newBg = null;
            if (fields == null)
                return;
            if (restoreBg)
                newBg = player == GameVar.PLAYER_WHITE ? Properties.Resources.piece_white : Properties.Resources.piece_black;
            for (int i = 0; i < fields.Count; i++)
                pieces[(int)(fields[i] as Array).GetValue(0), (int)(fields[i] as Array).GetValue(1)].BackgroundImage = newBg;
        }

        private void stopPlayers(bool cleanDesk = true, bool setAIButtons = true)
        {
            cancelAIComputing(setAIButtons);
            pieceClickListening = false;
            isPieceSelected = false;
            if (cleanDesk)
                cleanDeskPieceSelections();
        }

        private void updatePlayerPiecesCnt(int player)
        {
            int fieldsCnt = player == GameVar.PLAYER_WHITE ? desk.getWhiteFields().Count : desk.getBlackFields().Count;
            setPlayerPcsCnt(player, fieldsCnt);
        }

        private void decrementGameSteps()
        {
            gameSteps--;
            printGameSteps();
        }

        private void incrementGameSteps()
        {
            gameSteps++;
            printGameSteps();
        }

        private void printGameSteps()
        {
            labelStepsValue.Text = gameSteps.ToString();
        }

        private void drawPictureBoxControl(int x, int y, Bitmap pieceControl)
        {
            PictureBox pictureBox = pieces[x, y];
            Graphics g = pictureBox.CreateGraphics();
            g.DrawImage(pieceControl, new Rectangle(new Point(0, 0), new Size(pictureBox.Width, pictureBox.Height)));
        }

        private void drawPictureBoxControl(PictureBox pictureBox, Bitmap pieceControl, String pieceStr = null)
        {
            Graphics g = pictureBox.CreateGraphics();
            if (pieceStr != null)
            {
                // text drawing position
                int textBoxSize = 15;
                int textOffsetX = 3;
                int textOffsetY = 1;
                int textSize = 8;

                g.FillRectangle(new SolidBrush(Color.White), 0, 0, textBoxSize, textBoxSize);
                g.DrawString(pieceStr, new Font("Arial", textSize), new SolidBrush(Color.Black), new Point(textOffsetX, textOffsetY));
            }
            g.DrawImage(pieceControl, new Rectangle(new Point(0, 0), new Size(pictureBox.Width, pictureBox.Height)));
        }

        private int[] getPieceCoords(String name)
        {
            String[] coords = name.Replace("piece", "").Split('-');
            Int32.TryParse(coords[0], out int x);
            Int32.TryParse(coords[1], out int y);
            return new int[2] { x, y };
        }

        private String getPieceCoordsString(PictureBox piece)
        {
            int[] coords = getPieceCoords(piece.Name);
            return getCoordsString(coords[0], coords[1]);
        }

        private String getMoveCoordsString(Move move)
        {
            return getCoordsString(move.getFrom()[0], move.getFrom()[1]) + " " + getCoordsString(move.getTo()[0], move.getTo()[1]);
        }

        private String getCoordsString(int x, int y)
        {
            return (char)((int)GameVar.LetterXStart + x) + (y + 1).ToString();
        }

        private void resetPiecesBg()
        {
            int piecesCnt = rules.getDeskSize();
            for (int x = 0; x < piecesCnt; x++)
            {
                for (int y = 0; y < piecesCnt; y++)
                {
                    pieces[x, y].BackgroundImage = null;
                }
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            setNewGame();
            setNewGameFormData();
            startGame();
        }

        private void setNewGame()
        {
            resetGame();
            desk.setPlayerPieces(rules.getInitPiecesWhite(), GameVar.PLAYER_WHITE);
            desk.setPlayerPieces(rules.getInitPiecesBlack(), GameVar.PLAYER_BLACK);
            desk.setCurrentPlayer(rules.getStartingPlayer());
            setPlayerPieces(GameVar.PLAYER_WHITE, desk.getWhiteFields());
            setPlayerPieces(GameVar.PLAYER_BLACK, desk.getBlackFields());
            setPlayerPcsCnt(GameVar.PLAYER_WHITE, desk.getWhiteFields().Count);
            setPlayerPcsCnt(GameVar.PLAYER_BLACK, desk.getBlackFields().Count);
        }

        private void setNewGameFormData()
        {
            playerWhiteName.Text = formNewGame.playerWhiteNameValue;
            playerBlackName.Text = formNewGame.playerBlackNameValue;
            playerWhiteControls = formNewGame.playerWhiteControls;
            playerBlackControls = formNewGame.playerBlackControls;
        }

        private void resetGame()
        {
            bool cleanDesk = true;
            bool setAIButtons = false;
            gameRunning = false;
            tableDesk.Refresh();
            resetPiecesBg();
            desk.reset();
            resetGameInfo();
            resetGameTimer();
            aiButtonsDisable();
            stopPlayers(cleanDesk, setAIButtons);
        }

        private void startGame(bool autorunAI = true)
        {
            gameRunning = true;
            addGameNotice("game started");
            setActivePlayer(desk.getCurrentPlayer(), autorunAI);
            resetGameTimer();
            runGameTimer();
        }

        private void runGameTimer()
        {
            gameTimer.Start();
        }

        private void resetGameTimer()
        {
            gameTimer.Stop();
            gameTimerValue = 0;
            printGameTimer();
        }

        private void stopGameTimer()
        {
            gameTimer.Stop();
            printGameTimer();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                gameTimerValue++;
            }
            catch
            {
                gameTimerValue = 0;
            }
            printGameTimer();
        }

        private void printGameTimer()
        {
            labelTimerValue.Text = gameTimerValue + "s";
        }

        public void addGameNotice(String notice)
        {
            statusBar.Items.Insert(0, "- " + notice);
        }

        private void addGameHistoryMove(Move move)
        {
            gameMovesHistory.Items.Insert(0, movesDone.Count + ". " + getCoordsString(move.getFrom()[0], move.getFrom()[1]) + " " + getCoordsString(move.getTo()[0], move.getTo()[1]) + " " + (desk.getCurrentPlayer() == GameVar.PLAYER_WHITE ? playerWhiteName.Text : playerBlackName.Text));
        }

        private void clearGameListBoxes()
        {
            statusBar.Items.Clear();
            gameMovesHistory.Items.Clear();
        }

        private void resetGameInfo()
        {
            setPlayerPcsCnt(GameVar.PLAYER_WHITE, 0);
            setPlayerPcsCnt(GameVar.PLAYER_BLACK, 0);
            gameSteps = 0;
            printGameSteps();
            printGameTimer();
            movesDone.Clear();
            movesUndone.Clear();
            clearGameListBoxes();
        }

        private void FormMain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            showGameRulesForm();
        }

        private void setPlayerPcsCnt(int player, int cnt)
        {
            System.Windows.Forms.Label target = player == GameVar.PLAYER_WHITE ? playerWhitePcsCnt : playerBlackPcsCnt;
            target.Text = $"{cnt.ToString()} piece(s)";
        }

        private void showGameRulesForm()
        {
            FormGameRules form = new FormGameRules();
            form.Show(this);
        }

        private void cleanDeskPieceSelections()
        {
            tableDesk.Refresh();
            piecesSelected.Clear();
            pieceFocused = null;
            isPieceSelected = false;
        }

        private void loadXML(String filename)
        {
            ArrayList movesLoaded;
            XMLHandler xmlHandler = new XMLHandler();
            try
            {
                xmlHandler.loadXML(filename);
                playerWhiteName.Text = xmlHandler.getPlayerName(GameVar.PLAYER_WHITE);
                playerBlackName.Text = xmlHandler.getPlayerName(GameVar.PLAYER_BLACK);
                playerWhiteControls = xmlHandler.getPlayerControls(GameVar.PLAYER_WHITE);
                playerBlackControls = xmlHandler.getPlayerControls(GameVar.PLAYER_BLACK);
                movesLoaded = xmlHandler.getXMLMoves();
            }
            catch
            {
                MessageBox.Show("Error, file is corrupted.", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addGameNotice("loading game from file failed");
                return;
            }
            startLoadedGameFromFile(movesLoaded);
        }

        private void startLoadedGameFromFile(ArrayList movesLoaded)
        {
            int movesLoadedCnt = movesLoaded.Count;
            int i = 0;
            bool refreshDesk = false;
            bool newMovePath = true;
            bool movePossible = false;
            bool autorunAI = false;
            ArrayList possibleMoves = new ArrayList();
            setNewGame();
            gameRunning = true;
            try
            {
                foreach (Move move in movesLoaded)
                {
                    possibleMoves = rules.getPossibleMoves(desk, desk.getCurrentPlayer());
                    foreach (Move possibleMove in possibleMoves)
                    {
                        if (move.isEqual(possibleMove))
                            movePossible = true;
                    }
                    if (!movePossible)
                        throw new Exception("Move not possible");
                    if (i - 1 == movesLoadedCnt)
                        refreshDesk = true;
                    performMove(move, newMovePath, refreshDesk, autorunAI);
                    i++;
                    movePossible = false;
                }
            }
            catch
            {
                MessageBox.Show("Error, file is corrupted.", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addGameNotice("loading game from file failed");
                resetGame();
                return;
            }
            addGameNotice("loaded game from file");
            if (gameRunning)
                startGame(autorunAI);
        }

        private void saveXML(String fileName, ArrayList moves)
        {
            XMLHandler xmlHandler = new XMLHandler();
            try
            {
                xmlHandler.saveXML(moves, playerWhiteName.Text, playerBlackName.Text, playerWhiteControls, playerBlackControls, fileName);
                MessageBox.Show("File successfully saved.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addGameNotice("game saved");
            }
            catch
            {
                MessageBox.Show("Error, cannot write the file.", "File not saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addGameNotice("saving game failed");
            }
        }

        private void buttonSettingsSave_Click(object sender, EventArgs e)
        {
            playerWhiteControls = formSettings.playerWhiteControls;
            playerBlackControls = formSettings.playerBlackControls;
            playerWhiteName.Text = formSettings.playerWhiteNameValue;
            playerBlackName.Text = formSettings.playerBlackNameValue;
            showPossibleMoves = formSettings.showPossibleMoves;
            minComputerPlayTime = formSettings.computerPlayTimeValue;
            computerWhiteLevel = formSettings.computerWhiteLevelValue;
            computerBlackLevel = formSettings.computerBlackLevelValue;

            if (isComputerOnTurn())
            {
                tableDesk.Refresh();        // remove possible piece selections left from human
            }
            if (gameRunning)
            {
                setActivePlayer(desk.getCurrentPlayer());
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            int movesCnt = movesDone.Count;
            if (movesCnt <= 0)
                return;
            try
            {
                undoMove((Move)movesDone[movesCnt - 1]);
            }
            catch
            {
                addGameNotice("Undo move failed");
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            int movesCnt = movesUndone.Count;
            if (movesCnt <= 0)
                return;
            try
            {
                redoMove((Move)movesUndone[movesCnt - 1]);
            }
            catch
            {
                addGameNotice("Redo move failed");
            }
        }

        private void gameMovesHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gameMovesHistory.SelectedItem == null)
                return;

            int movesUndoneCnt = movesUndone.Count;
            int selectedItemIndex = gameMovesHistory.SelectedIndex;
            int i = 0;
            bool isLastItem = false;
            if (selectedItemIndex >= movesUndoneCnt)
            {
                int movesDoneCnt = movesDone.Count;
                while (i <= selectedItemIndex - movesUndoneCnt)
                {
                    if (i == selectedItemIndex)
                        isLastItem = true;
                    try
                    {
                        undoMove((Move)movesDone[movesDoneCnt - 1 - i], isLastItem);
                    }
                    catch
                    {
                        addGameNotice("Undo move failed");
                    }
                    i++;
                }
            }
            else
            {
                while (i <= movesUndoneCnt - 1 - selectedItemIndex)
                {
                    if (i == movesUndoneCnt - 1)
                        isLastItem = true;
                    try
                    {
                        redoMove((Move)movesUndone[movesUndoneCnt - 1 - i], isLastItem);
                    }
                    catch
                    {
                        addGameNotice("Redo move failed");
                    }
                    i++;
                }
            }
        }

        private void buttonStopAI_Click(object sender, EventArgs e)
        {
            if (!gameRunning)
            {
                aiButtonsDisable();
                return;
            }
            cancelAIComputing();
        }

        private void buttonContinueAI_Click(object sender, EventArgs e)
        {
            if (!gameRunning)
            {
                aiButtonsDisable();
                return;
            }
            makeAIMove();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //make sure all threads are stopped before exit
            cancelAIComputing();
            gameTimer.Dispose();
        }

        // Main menu item "About"
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool setAIButtons = gameRunning;
            cancelAIComputing(setAIButtons);

            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }

        // Main menu item "Save"
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (movesDone.Count == 0)
            {
                MessageBox.Show("Nothing to save", "Save file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool setAIButtons = gameRunning;
            bool autorunAI = false;
            bool cleanDesk = false;
            stopPlayers(cleanDesk, setAIButtons);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "new_game.xml";
            savefile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
                saveXML(savefile.FileName, movesDone);
            if (gameRunning)
                setActivePlayer(desk.getCurrentPlayer(), autorunAI);
        }

        // Main menu item "Load"
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool setAIButtons = gameRunning;
            bool autorunAI = false;
            bool cleanDesk = false;
            stopPlayers(cleanDesk, setAIButtons);

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select file";
            theDialog.Filter = "XML files|*.xml";
            if (theDialog.ShowDialog() == DialogResult.OK)
                loadXML(theDialog.FileName);
            else if (gameRunning)
                setActivePlayer(desk.getCurrentPlayer(), autorunAI);
        }

        // Main menu item "Exit"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Main menu item "New Game"
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool setAIButtons = gameRunning;
            cancelAIComputing(setAIButtons);

            formNewGame.setupFormData(playerWhiteControls, playerBlackControls, playerWhiteName.Text, playerBlackName.Text);
            formNewGame.ShowDialog(this);
        }

        // Main menu item "Settings"
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool setAIButtons = gameRunning;
            cancelAIComputing(setAIButtons);

            formSettings.setPlayerControls(playerWhiteControls, GameVar.PLAYER_WHITE);
            formSettings.setPlayerControls(playerBlackControls, GameVar.PLAYER_BLACK);
            formSettings.setPlayerName(playerWhiteName.Text, GameVar.PLAYER_WHITE);
            formSettings.setPlayerName(playerBlackName.Text, GameVar.PLAYER_BLACK);
            formSettings.setComputerPlayTime(minComputerPlayTime);
            formSettings.setComputerLevel(computerWhiteLevel, GameVar.PLAYER_WHITE);
            formSettings.setComputerLevel(computerBlackLevel, GameVar.PLAYER_BLACK);
            formSettings.setComputerLevelActive(playerWhiteControls == GameVar.PLAYER_COMPUTER, GameVar.PLAYER_WHITE);
            formSettings.setComputerLevelActive(playerBlackControls == GameVar.PLAYER_COMPUTER, GameVar.PLAYER_BLACK);
            formSettings.ShowDialog(this);
        }

        // Main menu item "Game rules"
        private void gameRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool setAIButtons = gameRunning;
            cancelAIComputing(setAIButtons);

            showGameRulesForm();
        }

        // Main menu item "Show best move"
        private void showBestMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameRunning || isComputerOnTurn())
            {
                MessageBox.Show("Make sure the game is running and human is on turn to get this functionality.", "Best move suggestion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cleanDeskPieceSelections();     // clean possible pieces selections from human move

            int aiLevel = Math.Max(Math.Max(computerWhiteLevel, computerBlackLevel), bestMoveAILevelDefault);
            setAILevel(aiLevel);
            setupAIComputing();
        }

        // FormMain resizeEnd event
        private void formMain_ResizeEnd(object sender, EventArgs e)
        {
            // resizing main window removes all drawing
            if (!gameRunning)
                return;
            isPieceSelected = false;        // force human make move from the beginning
            setActivePlayerBox(desk.getCurrentPlayer());        // redraw active player box
        }

        // tableDesk paint event
        private void tableDesk_Paint(object sender, PaintEventArgs e)
        {
            OnResize(EventArgs.Empty);
        }

        // Desk's horizontal bar resize event
        private void tableDeskBarHorizontal_Resize(object sender, EventArgs e)
        {
            int width = tableDeskBarHorizontal.Size.Width - tableDeskBarHorizontal.Size.Height;
            if (tableDeskContainer.Width == width)
                return;
            Size newSize = new Size(width, width);
            tableDeskContainer.Size = newSize;
            tableDesk.Size = newSize;
        }
    }
}