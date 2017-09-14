namespace OsetinskaDama
{
    partial class formSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.playerBlackName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.playerBlackComputer = new System.Windows.Forms.RadioButton();
            this.playerBlackHuman = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.computerBlackLevel = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerWhiteName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.playerWhiteComputer = new System.Windows.Forms.RadioButton();
            this.playerWhiteHuman = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.computerWhiteLevel = new System.Windows.Forms.TrackBar();
            this.checkPossibleMoves = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.computerPlayTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computerBlackLevel)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computerWhiteLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 186);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.playerBlackName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.computerBlackLevel);
            this.panel3.Location = new System.Drawing.Point(165, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 180);
            this.panel3.TabIndex = 1;
            // 
            // playerBlackName
            // 
            this.playerBlackName.Location = new System.Drawing.Point(8, 83);
            this.playerBlackName.Name = "playerBlackName";
            this.playerBlackName.Size = new System.Drawing.Size(129, 20);
            this.playerBlackName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Computer level";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.playerBlackComputer);
            this.panel4.Controls.Add(this.playerBlackHuman);
            this.panel4.Location = new System.Drawing.Point(9, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 52);
            this.panel4.TabIndex = 8;
            // 
            // playerBlackComputer
            // 
            this.playerBlackComputer.AutoSize = true;
            this.playerBlackComputer.Location = new System.Drawing.Point(4, 27);
            this.playerBlackComputer.Name = "playerBlackComputer";
            this.playerBlackComputer.Size = new System.Drawing.Size(70, 17);
            this.playerBlackComputer.TabIndex = 1;
            this.playerBlackComputer.Text = "Computer";
            this.playerBlackComputer.UseVisualStyleBackColor = true;
            this.playerBlackComputer.CheckedChanged += new System.EventHandler(this.checkBlackControls_Changed);
            // 
            // playerBlackHuman
            // 
            this.playerBlackHuman.AutoSize = true;
            this.playerBlackHuman.Location = new System.Drawing.Point(4, 4);
            this.playerBlackHuman.Name = "playerBlackHuman";
            this.playerBlackHuman.Size = new System.Drawing.Size(59, 17);
            this.playerBlackHuman.TabIndex = 0;
            this.playerBlackHuman.Text = "Human";
            this.playerBlackHuman.UseVisualStyleBackColor = true;
            this.playerBlackHuman.CheckedChanged += new System.EventHandler(this.checkBlackControls_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Player black";
            // 
            // computerBlackLevel
            // 
            this.computerBlackLevel.Location = new System.Drawing.Point(9, 135);
            this.computerBlackLevel.Maximum = 5;
            this.computerBlackLevel.Name = "computerBlackLevel";
            this.computerBlackLevel.Size = new System.Drawing.Size(104, 45);
            this.computerBlackLevel.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playerWhiteName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.computerWhiteLevel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 180);
            this.panel1.TabIndex = 0;
            // 
            // playerWhiteName
            // 
            this.playerWhiteName.Location = new System.Drawing.Point(8, 83);
            this.playerWhiteName.Name = "playerWhiteName";
            this.playerWhiteName.Size = new System.Drawing.Size(129, 20);
            this.playerWhiteName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Computer level";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.playerWhiteComputer);
            this.panel2.Controls.Add(this.playerWhiteHuman);
            this.panel2.Location = new System.Drawing.Point(9, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 52);
            this.panel2.TabIndex = 8;
            // 
            // playerWhiteComputer
            // 
            this.playerWhiteComputer.AutoSize = true;
            this.playerWhiteComputer.Location = new System.Drawing.Point(4, 27);
            this.playerWhiteComputer.Name = "playerWhiteComputer";
            this.playerWhiteComputer.Size = new System.Drawing.Size(70, 17);
            this.playerWhiteComputer.TabIndex = 1;
            this.playerWhiteComputer.Text = "Computer";
            this.playerWhiteComputer.UseVisualStyleBackColor = true;
            this.playerWhiteComputer.CheckedChanged += new System.EventHandler(this.checkWhiteControls_Changed);
            // 
            // playerWhiteHuman
            // 
            this.playerWhiteHuman.AutoSize = true;
            this.playerWhiteHuman.Location = new System.Drawing.Point(4, 4);
            this.playerWhiteHuman.Name = "playerWhiteHuman";
            this.playerWhiteHuman.Size = new System.Drawing.Size(59, 17);
            this.playerWhiteHuman.TabIndex = 0;
            this.playerWhiteHuman.Text = "Human";
            this.playerWhiteHuman.UseVisualStyleBackColor = true;
            this.playerWhiteHuman.CheckedChanged += new System.EventHandler(this.checkWhiteControls_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player white";
            // 
            // computerWhiteLevel
            // 
            this.computerWhiteLevel.Location = new System.Drawing.Point(10, 135);
            this.computerWhiteLevel.Maximum = 5;
            this.computerWhiteLevel.Name = "computerWhiteLevel";
            this.computerWhiteLevel.Size = new System.Drawing.Size(104, 45);
            this.computerWhiteLevel.TabIndex = 6;
            // 
            // checkPossibleMoves
            // 
            this.checkPossibleMoves.AutoSize = true;
            this.checkPossibleMoves.Location = new System.Drawing.Point(11, 195);
            this.checkPossibleMoves.Name = "checkPossibleMoves";
            this.checkPossibleMoves.Size = new System.Drawing.Size(128, 17);
            this.checkPossibleMoves.TabIndex = 6;
            this.checkPossibleMoves.Text = "Show possible moves";
            this.checkPossibleMoves.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Minimal computer play time";
            // 
            // computerPlayTime
            // 
            this.computerPlayTime.Location = new System.Drawing.Point(148, 215);
            this.computerPlayTime.Name = "computerPlayTime";
            this.computerPlayTime.Size = new System.Drawing.Size(100, 20);
            this.computerPlayTime.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "ms";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.Location = new System.Drawing.Point(74, 254);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(170, 35);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // formSettings
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 301);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.computerPlayTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkPossibleMoves);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSettings_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computerBlackLevel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computerWhiteLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton playerBlackComputer;
        private System.Windows.Forms.RadioButton playerBlackHuman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar computerBlackLevel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton playerWhiteComputer;
        private System.Windows.Forms.RadioButton playerWhiteHuman;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar computerWhiteLevel;
        private System.Windows.Forms.CheckBox checkPossibleMoves;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox computerPlayTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox playerWhiteName;
        private System.Windows.Forms.TextBox playerBlackName;
    }
}