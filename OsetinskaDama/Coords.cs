using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    static class Coords
    {
        public static int[] getPieceCoordsFromName(String name)
        {
            int x, y;
            String[] coords = name.Replace("piece", "").Split('-');
            Int32.TryParse(coords[0], out x);
            Int32.TryParse(coords[1], out y);
            return new int[2] { x, y };
        }

        public static String getCoordsStr(PictureBox piece)
        {
            int[] coords = getPieceCoordsFromName(piece.Name);
            return getCoordsStr(coords[0], coords[1]);
        }

        public static String getCoordsStr(Move move, bool compactOutput = false)
        {
            String output = getCoordsStr(move.getFrom()[0], move.getFrom()[1]);
            if (!compactOutput)
            {
                ArrayList fieldsOver = move.getOverFields();
                int fieldsOverLen = fieldsOver.Count;
                for (int i = 0; i < fieldsOverLen; i++)
                {
                    output += " " + getCoordsStr((int)(fieldsOver[i] as Array).GetValue(0), (int)(fieldsOver[i] as Array).GetValue(1));
                }
            }
            return output + " " + getCoordsStr(move.getTo()[0], move.getTo()[1]);
        }

        public static String getCoordsStr(int x, int y)
        {
            return (char)((int)GameVar.LetterXStart + x) + (y + 1).ToString();
        }

    }
}
