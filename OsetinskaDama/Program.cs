using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //set up game and desk
            GameRules rules = new GameRules();
            Desk desk = new Desk(rules.getDeskSize(), rules.getPiecesPerPlayer());
            Engine engine = new Engine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(rules, desk, engine));
        }
    }
}
