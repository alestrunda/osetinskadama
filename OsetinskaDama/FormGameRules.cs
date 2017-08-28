﻿using System;
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
    public partial class FormGameRules : Form
    {
        public FormGameRules()
        {
            InitializeComponent();
        }

        private void FormGameRules_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FormGameRules_Load(object sender, EventArgs e)
        {
            if (Owner != null)      // set window in the center of its parent
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
    }
}
