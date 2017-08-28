namespace OsetinskaDama
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showBestMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableGame = new System.Windows.Forms.TableLayoutPanel();
            this.panelGameInfo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.gameMovesHistory = new System.Windows.Forms.ListBox();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupGame = new System.Windows.Forms.GroupBox();
            this.buttonContinueAI = new System.Windows.Forms.Button();
            this.buttonStopAI = new System.Windows.Forms.Button();
            this.labelStepsValue = new System.Windows.Forms.Label();
            this.labelSteps = new System.Windows.Forms.Label();
            this.labelTimerValue = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.groupPlayers = new System.Windows.Forms.GroupBox();
            this.playerBlackName = new System.Windows.Forms.Label();
            this.playerWhiteName = new System.Windows.Forms.Label();
            this.playerBlackPcsCnt = new System.Windows.Forms.Label();
            this.playerWhitePcsCnt = new System.Windows.Forms.Label();
            this.playerBlackImage = new System.Windows.Forms.PictureBox();
            this.playerWhiteImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableDeskWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.tableDeskBarVertical = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.tableDeskContainer = new System.Windows.Forms.Panel();
            this.tableDesk = new System.Windows.Forms.TableLayoutPanel();
            this.tableDeskBarHorizontal = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.tableGame.SuspendLayout();
            this.panelGameInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupGame.SuspendLayout();
            this.groupPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBlackImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerWhiteImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableDeskWrapper.SuspendLayout();
            this.tableDeskBarVertical.SuspendLayout();
            this.tableDeskContainer.SuspendLayout();
            this.tableDeskBarHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(803, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator1,
            this.showBestMoveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.ShowShortcutKeys = false;
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // showBestMoveToolStripMenuItem
            // 
            this.showBestMoveToolStripMenuItem.Name = "showBestMoveToolStripMenuItem";
            this.showBestMoveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.showBestMoveToolStripMenuItem.ShowShortcutKeys = false;
            this.showBestMoveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.showBestMoveToolStripMenuItem.Text = "Show &best move";
            this.showBestMoveToolStripMenuItem.Click += new System.EventHandler(this.showBestMoveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.ShowShortcutKeys = false;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Se&ttings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameRulesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gameRulesToolStripMenuItem
            // 
            this.gameRulesToolStripMenuItem.Name = "gameRulesToolStripMenuItem";
            this.gameRulesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.gameRulesToolStripMenuItem.ShowShortcutKeys = false;
            this.gameRulesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.gameRulesToolStripMenuItem.Text = "Game &Rules";
            this.gameRulesToolStripMenuItem.Click += new System.EventHandler(this.gameRulesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.ShowShortcutKeys = false;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableGame
            // 
            this.tableGame.AutoScroll = true;
            this.tableGame.AutoSize = true;
            this.tableGame.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableGame.ColumnCount = 2;
            this.tableGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 296F));
            this.tableGame.Controls.Add(this.panelGameInfo, 1, 0);
            this.tableGame.Controls.Add(this.panel1, 0, 0);
            this.tableGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableGame.Location = new System.Drawing.Point(0, 24);
            this.tableGame.Margin = new System.Windows.Forms.Padding(0);
            this.tableGame.Name = "tableGame";
            this.tableGame.RowCount = 1;
            this.tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 508F));
            this.tableGame.Size = new System.Drawing.Size(803, 508);
            this.tableGame.TabIndex = 1;
            // 
            // panelGameInfo
            // 
            this.panelGameInfo.Controls.Add(this.label3);
            this.panelGameInfo.Controls.Add(this.statusBar);
            this.panelGameInfo.Controls.Add(this.groupBox1);
            this.panelGameInfo.Controls.Add(this.groupGame);
            this.panelGameInfo.Controls.Add(this.groupPlayers);
            this.panelGameInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGameInfo.Location = new System.Drawing.Point(510, 3);
            this.panelGameInfo.Name = "panelGameInfo";
            this.panelGameInfo.Size = new System.Drawing.Size(290, 408);
            this.panelGameInfo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Status bar";
            // 
            // statusBar
            // 
            this.statusBar.FormattingEnabled = true;
            this.statusBar.Location = new System.Drawing.Point(7, 358);
            this.statusBar.Name = "statusBar";
            this.statusBar.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.statusBar.Size = new System.Drawing.Size(276, 43);
            this.statusBar.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRedo);
            this.groupBox1.Controls.Add(this.gameMovesHistory);
            this.groupBox1.Controls.Add(this.buttonUndo);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            // 
            // buttonRedo
            // 
            this.buttonRedo.Location = new System.Drawing.Point(91, 19);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(75, 23);
            this.buttonRedo.TabIndex = 8;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // gameMovesHistory
            // 
            this.gameMovesHistory.FormattingEnabled = true;
            this.gameMovesHistory.Location = new System.Drawing.Point(10, 48);
            this.gameMovesHistory.Name = "gameMovesHistory";
            this.gameMovesHistory.Size = new System.Drawing.Size(254, 43);
            this.gameMovesHistory.TabIndex = 6;
            this.gameMovesHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gameMovesHistory_MouseDoubleClick);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(10, 19);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 7;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "dghj",
            "dghj",
            "dghj",
            "dghj",
            "dghj",
            "dghk",
            "djk",
            "dghk",
            "d"});
            this.listBox1.Location = new System.Drawing.Point(13, 106);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(276, 43);
            this.listBox1.TabIndex = 6;
            // 
            // groupGame
            // 
            this.groupGame.Controls.Add(this.buttonContinueAI);
            this.groupGame.Controls.Add(this.buttonStopAI);
            this.groupGame.Controls.Add(this.labelStepsValue);
            this.groupGame.Controls.Add(this.labelSteps);
            this.groupGame.Controls.Add(this.labelTimerValue);
            this.groupGame.Controls.Add(this.labelTimer);
            this.groupGame.Location = new System.Drawing.Point(7, 148);
            this.groupGame.Name = "groupGame";
            this.groupGame.Size = new System.Drawing.Size(276, 86);
            this.groupGame.TabIndex = 2;
            this.groupGame.TabStop = false;
            this.groupGame.Text = "Game";
            // 
            // buttonContinueAI
            // 
            this.buttonContinueAI.Location = new System.Drawing.Point(91, 56);
            this.buttonContinueAI.Name = "buttonContinueAI";
            this.buttonContinueAI.Size = new System.Drawing.Size(75, 23);
            this.buttonContinueAI.TabIndex = 5;
            this.buttonContinueAI.Text = "Continue AI";
            this.buttonContinueAI.UseVisualStyleBackColor = true;
            this.buttonContinueAI.Click += new System.EventHandler(this.buttonContinueAI_Click);
            // 
            // buttonStopAI
            // 
            this.buttonStopAI.Location = new System.Drawing.Point(10, 56);
            this.buttonStopAI.Name = "buttonStopAI";
            this.buttonStopAI.Size = new System.Drawing.Size(75, 23);
            this.buttonStopAI.TabIndex = 4;
            this.buttonStopAI.Text = "Stop AI";
            this.buttonStopAI.UseVisualStyleBackColor = true;
            this.buttonStopAI.Click += new System.EventHandler(this.buttonStopAI_Click);
            // 
            // labelStepsValue
            // 
            this.labelStepsValue.AutoSize = true;
            this.labelStepsValue.Location = new System.Drawing.Point(61, 37);
            this.labelStepsValue.Name = "labelStepsValue";
            this.labelStepsValue.Size = new System.Drawing.Size(10, 13);
            this.labelStepsValue.TabIndex = 3;
            this.labelStepsValue.Text = " ";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(7, 37);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(37, 13);
            this.labelSteps.TabIndex = 2;
            this.labelSteps.Text = "Steps:";
            // 
            // labelTimerValue
            // 
            this.labelTimerValue.AutoSize = true;
            this.labelTimerValue.Location = new System.Drawing.Point(61, 20);
            this.labelTimerValue.Name = "labelTimerValue";
            this.labelTimerValue.Size = new System.Drawing.Size(10, 13);
            this.labelTimerValue.TabIndex = 1;
            this.labelTimerValue.Text = " ";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(7, 20);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(33, 13);
            this.labelTimer.TabIndex = 0;
            this.labelTimer.Text = "Time:";
            // 
            // groupPlayers
            // 
            this.groupPlayers.Controls.Add(this.playerBlackName);
            this.groupPlayers.Controls.Add(this.playerWhiteName);
            this.groupPlayers.Controls.Add(this.playerBlackPcsCnt);
            this.groupPlayers.Controls.Add(this.playerWhitePcsCnt);
            this.groupPlayers.Controls.Add(this.playerBlackImage);
            this.groupPlayers.Controls.Add(this.playerWhiteImage);
            this.groupPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupPlayers.Location = new System.Drawing.Point(7, 3);
            this.groupPlayers.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.groupPlayers.Name = "groupPlayers";
            this.groupPlayers.Size = new System.Drawing.Size(276, 139);
            this.groupPlayers.TabIndex = 1;
            this.groupPlayers.TabStop = false;
            this.groupPlayers.Text = "Players";
            // 
            // playerBlackName
            // 
            this.playerBlackName.AutoSize = true;
            this.playerBlackName.Location = new System.Drawing.Point(164, 25);
            this.playerBlackName.Name = "playerBlackName";
            this.playerBlackName.Size = new System.Drawing.Size(34, 13);
            this.playerBlackName.TabIndex = 7;
            this.playerBlackName.Text = "Black";
            // 
            // playerWhiteName
            // 
            this.playerWhiteName.AutoSize = true;
            this.playerWhiteName.Location = new System.Drawing.Point(25, 25);
            this.playerWhiteName.Name = "playerWhiteName";
            this.playerWhiteName.Size = new System.Drawing.Size(35, 13);
            this.playerWhiteName.TabIndex = 6;
            this.playerWhiteName.Text = "White";
            // 
            // playerBlackPcsCnt
            // 
            this.playerBlackPcsCnt.AutoSize = true;
            this.playerBlackPcsCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerBlackPcsCnt.Location = new System.Drawing.Point(164, 112);
            this.playerBlackPcsCnt.MinimumSize = new System.Drawing.Size(100, 0);
            this.playerBlackPcsCnt.Name = "playerBlackPcsCnt";
            this.playerBlackPcsCnt.Size = new System.Drawing.Size(100, 13);
            this.playerBlackPcsCnt.TabIndex = 5;
            this.playerBlackPcsCnt.Text = " ";
            this.playerBlackPcsCnt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playerWhitePcsCnt
            // 
            this.playerWhitePcsCnt.AutoSize = true;
            this.playerWhitePcsCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.playerWhitePcsCnt.Location = new System.Drawing.Point(25, 112);
            this.playerWhitePcsCnt.MinimumSize = new System.Drawing.Size(100, 0);
            this.playerWhitePcsCnt.Name = "playerWhitePcsCnt";
            this.playerWhitePcsCnt.Size = new System.Drawing.Size(100, 13);
            this.playerWhitePcsCnt.TabIndex = 4;
            this.playerWhitePcsCnt.Text = " ";
            this.playerWhitePcsCnt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playerBlackImage
            // 
            this.playerBlackImage.BackColor = System.Drawing.Color.Transparent;
            this.playerBlackImage.BackgroundImage = global::OsetinskaDama.Properties.Resources.piece_black;
            this.playerBlackImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerBlackImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerBlackImage.InitialImage = null;
            this.playerBlackImage.Location = new System.Drawing.Point(190, 50);
            this.playerBlackImage.Name = "playerBlackImage";
            this.playerBlackImage.Size = new System.Drawing.Size(50, 50);
            this.playerBlackImage.TabIndex = 3;
            this.playerBlackImage.TabStop = false;
            // 
            // playerWhiteImage
            // 
            this.playerWhiteImage.BackColor = System.Drawing.Color.Transparent;
            this.playerWhiteImage.BackgroundImage = global::OsetinskaDama.Properties.Resources.piece_white;
            this.playerWhiteImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerWhiteImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerWhiteImage.InitialImage = null;
            this.playerWhiteImage.Location = new System.Drawing.Point(45, 50);
            this.playerWhiteImage.Name = "playerWhiteImage";
            this.playerWhiteImage.Size = new System.Drawing.Size(50, 50);
            this.playerWhiteImage.TabIndex = 2;
            this.playerWhiteImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tableDeskWrapper);
            this.panel1.Controls.Add(this.tableDeskBarHorizontal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 508);
            this.panel1.TabIndex = 3;
            // 
            // tableDeskWrapper
            // 
            this.tableDeskWrapper.AutoSize = true;
            this.tableDeskWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableDeskWrapper.ColumnCount = 2;
            this.tableDeskWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableDeskWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableDeskWrapper.Controls.Add(this.tableDeskBarVertical, 0, 0);
            this.tableDeskWrapper.Controls.Add(this.tableDeskContainer, 1, 0);
            this.tableDeskWrapper.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDeskWrapper.Location = new System.Drawing.Point(0, 0);
            this.tableDeskWrapper.Name = "tableDeskWrapper";
            this.tableDeskWrapper.RowCount = 1;
            this.tableDeskWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDeskWrapper.Size = new System.Drawing.Size(507, 491);
            this.tableDeskWrapper.TabIndex = 5;
            // 
            // tableDeskBarVertical
            // 
            this.tableDeskBarVertical.AutoSize = true;
            this.tableDeskBarVertical.ColumnCount = 1;
            this.tableDeskBarVertical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDeskBarVertical.Controls.Add(this.label7, 0, 6);
            this.tableDeskBarVertical.Controls.Add(this.label6, 0, 5);
            this.tableDeskBarVertical.Controls.Add(this.label5, 0, 4);
            this.tableDeskBarVertical.Controls.Add(this.label4, 0, 3);
            this.tableDeskBarVertical.Controls.Add(this.label2, 0, 2);
            this.tableDeskBarVertical.Controls.Add(this.label1, 0, 1);
            this.tableDeskBarVertical.Controls.Add(this.a, 0, 0);
            this.tableDeskBarVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDeskBarVertical.Location = new System.Drawing.Point(0, 0);
            this.tableDeskBarVertical.Margin = new System.Windows.Forms.Padding(0);
            this.tableDeskBarVertical.Name = "tableDeskBarVertical";
            this.tableDeskBarVertical.RowCount = 7;
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDeskBarVertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableDeskBarVertical.Size = new System.Drawing.Size(17, 491);
            this.tableDeskBarVertical.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 71);
            this.label7.TabIndex = 8;
            this.label7.Text = "1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 70);
            this.label6.TabIndex = 7;
            this.label6.Text = "2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 70);
            this.label5.TabIndex = 6;
            this.label5.Text = "3";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 70);
            this.label4.TabIndex = 5;
            this.label4.Text = "4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 70);
            this.label2.TabIndex = 4;
            this.label2.Text = "5";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 70);
            this.label1.TabIndex = 3;
            this.label1.Text = "6";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a.Location = new System.Drawing.Point(3, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(11, 70);
            this.a.TabIndex = 2;
            this.a.Text = "7";
            this.a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableDeskContainer
            // 
            this.tableDeskContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableDeskContainer.Controls.Add(this.tableDesk);
            this.tableDeskContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDeskContainer.Location = new System.Drawing.Point(17, 0);
            this.tableDeskContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableDeskContainer.Name = "tableDeskContainer";
            this.tableDeskContainer.Size = new System.Drawing.Size(490, 491);
            this.tableDeskContainer.TabIndex = 7;
            // 
            // tableDesk
            // 
            this.tableDesk.BackColor = System.Drawing.Color.Transparent;
            this.tableDesk.BackgroundImage = global::OsetinskaDama.Properties.Resources.board;
            this.tableDesk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableDesk.ColumnCount = 7;
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.08163F));
            this.tableDesk.Location = new System.Drawing.Point(0, 0);
            this.tableDesk.Margin = new System.Windows.Forms.Padding(0);
            this.tableDesk.Name = "tableDesk";
            this.tableDesk.RowCount = 7;
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.46029F));
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.25662F));
            this.tableDesk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.05295F));
            this.tableDesk.Size = new System.Drawing.Size(490, 491);
            this.tableDesk.TabIndex = 5;
            // 
            // tableDeskBarHorizontal
            // 
            this.tableDeskBarHorizontal.ColumnCount = 8;
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31516F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31516F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31516F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31516F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31516F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.31516F));
            this.tableDeskBarHorizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.10903F));
            this.tableDeskBarHorizontal.Controls.Add(this.label14, 7, 0);
            this.tableDeskBarHorizontal.Controls.Add(this.label13, 6, 0);
            this.tableDeskBarHorizontal.Controls.Add(this.label12, 5, 0);
            this.tableDeskBarHorizontal.Controls.Add(this.label11, 4, 0);
            this.tableDeskBarHorizontal.Controls.Add(this.label10, 3, 0);
            this.tableDeskBarHorizontal.Controls.Add(this.label9, 2, 0);
            this.tableDeskBarHorizontal.Controls.Add(this.label8, 1, 0);
            this.tableDeskBarHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableDeskBarHorizontal.Location = new System.Drawing.Point(0, 491);
            this.tableDeskBarHorizontal.Name = "tableDeskBarHorizontal";
            this.tableDeskBarHorizontal.RowCount = 1;
            this.tableDeskBarHorizontal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDeskBarHorizontal.Size = new System.Drawing.Size(507, 17);
            this.tableDeskBarHorizontal.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(437, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "G";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(367, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "F";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(297, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "E";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(227, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 17);
            this.label11.TabIndex = 3;
            this.label11.Text = "D";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(157, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "C";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(87, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "B";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(17, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "A";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(803, 533);
            this.Controls.Add(this.tableGame);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "FormMain";
            this.Text = "Osetinská dáma";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.FormMain_HelpRequested);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tableGame.ResumeLayout(false);
            this.tableGame.PerformLayout();
            this.panelGameInfo.ResumeLayout(false);
            this.panelGameInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupGame.ResumeLayout(false);
            this.groupGame.PerformLayout();
            this.groupPlayers.ResumeLayout(false);
            this.groupPlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerBlackImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerWhiteImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableDeskWrapper.ResumeLayout(false);
            this.tableDeskWrapper.PerformLayout();
            this.tableDeskBarVertical.ResumeLayout(false);
            this.tableDeskBarVertical.PerformLayout();
            this.tableDeskContainer.ResumeLayout(false);
            this.tableDeskBarHorizontal.ResumeLayout(false);
            this.tableDeskBarHorizontal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableGame;
        private System.Windows.Forms.ToolStripMenuItem gameRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel panelGameInfo;
        private System.Windows.Forms.GroupBox groupGame;
        private System.Windows.Forms.GroupBox groupPlayers;
        private System.Windows.Forms.Label playerBlackPcsCnt;
        private System.Windows.Forms.Label playerWhitePcsCnt;
        private System.Windows.Forms.PictureBox playerBlackImage;
        private System.Windows.Forms.PictureBox playerWhiteImage;
        private System.Windows.Forms.Label labelTimerValue;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label playerBlackName;
        private System.Windows.Forms.Label playerWhiteName;
        private System.Windows.Forms.Label labelStepsValue;
        private System.Windows.Forms.Label labelSteps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox statusBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.ListBox gameMovesHistory;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableDeskBarHorizontal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem showBestMoveToolStripMenuItem;
        private System.Windows.Forms.Button buttonContinueAI;
        private System.Windows.Forms.Button buttonStopAI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableDeskWrapper;
        private System.Windows.Forms.TableLayoutPanel tableDeskBarVertical;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Panel tableDeskContainer;
        private System.Windows.Forms.TableLayoutPanel tableDesk;
    }
}

