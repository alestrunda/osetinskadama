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
    public partial class FormGameOver : Form
    {
        public FormGameOver()
        {
            InitializeComponent();
        }

        public void setGameDetails(String text)
        {
            labelGameDetails.Text = text;
        }

        public void setLabelWinner(String text)
        {
            labelWinner.Text = text;
        }

        public void setLabelHead(String text)
        {
            labelHead.Text = text;
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
