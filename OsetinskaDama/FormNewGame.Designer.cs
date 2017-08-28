namespace OsetinskaDama
{
    partial class formNewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formNewGame));
            this.label1 = new System.Windows.Forms.Label();
            this.playerWhiteName = new System.Windows.Forms.TextBox();
            this.playerWhiteAI = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.playerBlackHuman = new System.Windows.Forms.RadioButton();
            this.playerBlackAI = new System.Windows.Forms.RadioButton();
            this.playerBlackName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerWhiteHuman = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player White";
            // 
            // playerWhiteName
            // 
            this.playerWhiteName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerWhiteName.Location = new System.Drawing.Point(11, 37);
            this.playerWhiteName.Margin = new System.Windows.Forms.Padding(6, 3, 10, 3);
            this.playerWhiteName.Name = "playerWhiteName";
            this.playerWhiteName.Size = new System.Drawing.Size(119, 20);
            this.playerWhiteName.TabIndex = 1;
            this.playerWhiteName.Text = "White";
            // 
            // playerWhiteAI
            // 
            this.playerWhiteAI.AutoSize = true;
            this.playerWhiteAI.Location = new System.Drawing.Point(8, 22);
            this.playerWhiteAI.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.playerWhiteAI.Name = "playerWhiteAI";
            this.playerWhiteAI.Size = new System.Drawing.Size(70, 17);
            this.playerWhiteAI.TabIndex = 3;
            this.playerWhiteAI.Text = "Computer";
            this.playerWhiteAI.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.playerBlackName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.playerWhiteName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 112);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.playerBlackHuman);
            this.panel2.Controls.Add(this.playerBlackAI);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(143, 65);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(129, 44);
            this.panel2.TabIndex = 10;
            // 
            // playerBlackHuman
            // 
            this.playerBlackHuman.AutoSize = true;
            this.playerBlackHuman.Checked = true;
            this.playerBlackHuman.Location = new System.Drawing.Point(8, 3);
            this.playerBlackHuman.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.playerBlackHuman.Name = "playerBlackHuman";
            this.playerBlackHuman.Size = new System.Drawing.Size(59, 17);
            this.playerBlackHuman.TabIndex = 11;
            this.playerBlackHuman.TabStop = true;
            this.playerBlackHuman.Text = "Human";
            this.playerBlackHuman.UseVisualStyleBackColor = true;
            // 
            // playerBlackAI
            // 
            this.playerBlackAI.AutoSize = true;
            this.playerBlackAI.Location = new System.Drawing.Point(8, 22);
            this.playerBlackAI.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.playerBlackAI.Name = "playerBlackAI";
            this.playerBlackAI.Size = new System.Drawing.Size(70, 17);
            this.playerBlackAI.TabIndex = 3;
            this.playerBlackAI.Text = "Computer";
            this.playerBlackAI.UseVisualStyleBackColor = true;
            // 
            // playerBlackName
            // 
            this.playerBlackName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerBlackName.Location = new System.Drawing.Point(146, 37);
            this.playerBlackName.Margin = new System.Windows.Forms.Padding(6, 3, 10, 3);
            this.playerBlackName.Name = "playerBlackName";
            this.playerBlackName.Size = new System.Drawing.Size(119, 20);
            this.playerBlackName.TabIndex = 6;
            this.playerBlackName.Text = "Black";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(143, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player Black";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playerWhiteHuman);
            this.panel1.Controls.Add(this.playerWhiteAI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 65);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(129, 44);
            this.panel1.TabIndex = 9;
            // 
            // playerWhiteHuman
            // 
            this.playerWhiteHuman.AutoSize = true;
            this.playerWhiteHuman.Checked = true;
            this.playerWhiteHuman.Location = new System.Drawing.Point(8, 3);
            this.playerWhiteHuman.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.playerWhiteHuman.Name = "playerWhiteHuman";
            this.playerWhiteHuman.Size = new System.Drawing.Size(59, 17);
            this.playerWhiteHuman.TabIndex = 11;
            this.playerWhiteHuman.TabStop = true;
            this.playerWhiteHuman.Text = "Human";
            this.playerWhiteHuman.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(59, 130);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(170, 35);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // formNewGame
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 177);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formNewGame_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerWhiteName;
        private System.Windows.Forms.RadioButton playerWhiteAI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton playerBlackHuman;
        private System.Windows.Forms.RadioButton playerBlackAI;
        private System.Windows.Forms.TextBox playerBlackName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton playerWhiteHuman;
        private System.Windows.Forms.Button buttonStart;
    }
}