using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    public class Move
    {
        private int[] from;
        private int[] to;
        private ArrayList over = new ArrayList();
        private ArrayList remove = new ArrayList();

        public Move(int xFrom, int yFrom, int xTo, int yTo)
        {
            from = new int[] { xFrom, yFrom };
            to = new int[] { xTo, yTo };
        }

        public void addOverField(int x, int y)
        {
            over.Insert(0, new int[] { x, y });
        }

        public void addRemoveField(int x, int y)
        {
            remove.Insert(0, new int[] { x, y });
        }

        public int[] getFrom()
        {
            return from;
        }

        public int[] getTo()
        {
            return to;
        }

        public ArrayList getOverFields()
        {
            return over;
        }

        public ArrayList getRemoveFields()
        {
            return remove;
        }

        public bool isEqual(Move move)
        {
            if (from[0] != move.getFrom()[0] || from[1] != move.getFrom()[1])
                return false;
            if (to[0] != move.getTo()[0] || to[1] != move.getTo()[1])
                return false;

            ArrayList moveFields = move.getOverFields();
            int fieldsCnt = over.Count;
            if (fieldsCnt != moveFields.Count)
                return false;
            for(int i=0; i< fieldsCnt; i++)
            {
                if (((int[])over[i])[0] != ((int[])moveFields[i])[0] || ((int[])over[i])[1] != ((int[])moveFields[i])[1])
                    return false;
            }

            moveFields = move.getRemoveFields();
            fieldsCnt = remove.Count;
            if (fieldsCnt != moveFields.Count)
                return false;
            for (int i = 0; i < fieldsCnt; i++)
            {
                if (((int[])remove[i])[0] != ((int[])moveFields[i])[0] || ((int[])remove[i])[1] != ((int[])moveFields[i])[1])
                    return false;
            }
            return true;
        }

        public void setFrom(int x, int y)
        {
            from[0] = x;
            from[1] = y;
        }

        public void setTo(int x, int y)
        {
            to[0] = x;
            to[1] = y;
        }
    };
}
