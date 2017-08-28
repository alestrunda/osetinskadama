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
    public partial class formSettings : Form
    {
        public event EventHandler buttonSave_Clicked;
        public String playerWhiteNameValue;
        public String playerBlackNameValue;
        public int playerWhiteControls;
        public int playerBlackControls;
        public bool showPossibleMoves;
        public int computerPlayTimeValue;
        public int computerWhiteLevelValue;
        public int computerBlackLevelValue;

        public formSettings()
        {
            InitializeComponent();
        }

        public void setPlayerControls(int playerControls, int playerColor)
        {
            var playerHuman = playerColor == GameVar.PLAYER_WHITE ? playerWhiteHuman : playerBlackHuman;
            var playerComputer = playerColor == GameVar.PLAYER_WHITE ? playerWhiteComputer : playerBlackComputer;
            if (playerControls == GameVar.PLAYER_HUMAN)
            {
                playerHuman.Checked = true;
                playerComputer.Checked = false;
            }
            else
            {
                playerHuman.Checked = false;
                playerComputer.Checked = true;
            }
        }

        public void setComputerLevel(int val, int player)
        {
            (player == GameVar.PLAYER_WHITE ? computerWhiteLevel : computerBlackLevel).Value = val;
        }

        public void setComputerPlayTime(int val)
        {
            computerPlayTime.Text = val.ToString();
        }

        public void setPlayerName(String name, int player)
        {
            (player == GameVar.PLAYER_WHITE ? playerWhiteName : playerBlackName).Text = name;
        }

        public void setComputerLevelActive(bool levelActive, int player)
        {
            (player == GameVar.PLAYER_WHITE ? computerWhiteLevel : computerBlackLevel).Enabled = levelActive;
        }

        private void checkWhiteControls_Changed(object sender, EventArgs e)
        {
            setComputerLevelActive(playerWhiteComputer.Checked, GameVar.PLAYER_WHITE);
        }

        private void checkBlackControls_Changed(object sender, EventArgs e)
        {
            setComputerLevelActive(playerBlackComputer.Checked, GameVar.PLAYER_BLACK);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            playerWhiteControls = playerWhiteHuman.Checked ? GameVar.PLAYER_HUMAN : GameVar.PLAYER_COMPUTER;
            playerBlackControls = playerBlackHuman.Checked ? GameVar.PLAYER_HUMAN : GameVar.PLAYER_COMPUTER;
            playerWhiteNameValue = playerWhiteName.Text;
            playerBlackNameValue = playerBlackName.Text;
            showPossibleMoves = checkPossibleMoves.Checked;
            computerWhiteLevelValue = computerWhiteLevel.Value;
            computerBlackLevelValue = computerBlackLevel.Value;
            if (!Int32.TryParse(computerPlayTime.Text, out computerPlayTimeValue))
            {
                System.Windows.Forms.MessageBox.Show("\"Minimal computer play time\" field is not a valid number");
                return;
            }
            if (computerPlayTimeValue < 1)
            {
                System.Windows.Forms.MessageBox.Show("Minimal computer play time is 1ms");
                return;
            }
            Close();
            buttonSave_Clicked(sender, e);
        }

        private void formSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
