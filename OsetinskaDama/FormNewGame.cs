using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    public partial class formNewGame : Form
    {
        public event EventHandler buttonStart_Invoked;
        public String playerWhiteNameValue;
        public String playerBlackNameValue;
        public int playerWhiteControls;
        public int playerBlackControls;

        public formNewGame()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            handleStartBtnPressed(sender, e);
        }

        private void handleStartBtnPressed(object sender, EventArgs e)
        {
            playerWhiteControls = playerWhiteHuman.Checked ? GameVar.PLAYER_HUMAN : GameVar.PLAYER_COMPUTER;
            playerBlackControls = playerBlackHuman.Checked ? GameVar.PLAYER_HUMAN : GameVar.PLAYER_COMPUTER;
            playerWhiteNameValue = playerWhiteName.Text;
            playerBlackNameValue = playerBlackName.Text;

            Close();
            buttonStart_Invoked(sender, e);
        }

        public void setupFormData(int playerWhiteControls, int playerBlackControls, String playerWhiteNameValue, String playerBlackNameValue)
        {
            if (playerWhiteControls == GameVar.PLAYER_HUMAN)
            {
                playerWhiteHuman.Checked = true;
                playerWhiteAI.Checked = false;
            }
            else
            {
                playerWhiteHuman.Checked = false;
                playerWhiteAI.Checked = true;
            }
            if (playerBlackControls == GameVar.PLAYER_HUMAN)
            {
                playerBlackHuman.Checked = true;
                playerBlackAI.Checked = false;
            }
            else
            {
                playerBlackHuman.Checked = false;
                playerBlackAI.Checked = true;
            }
            playerWhiteName.Text = playerWhiteNameValue;
            playerBlackName.Text = playerBlackNameValue;
        }

        private void formNewGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
