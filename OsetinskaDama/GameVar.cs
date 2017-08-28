using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsetinskaDama
{
    public static class GameVar
    {
        public const short FIELD_EMPTY = 0;
        public const short FIELD_WHITE = 1;
        public const short FIELD_BLACK = 2;

        public const short PLAYER_WHITE = 1;
        public const short PLAYER_BLACK = 2;
        public const short PLAYER_HUMAN = 1;
        public const short PLAYER_COMPUTER = 2;

        public const short DIR_UP = 1;
        public const short DIR_RIGHT = 2;
        public const short DIR_DOWN = 3;
        public const short DIR_LEFT = 4;
        public const short DIR_UP_LEFT = 5;
        public const short DIR_UP_RIGHT = 6;
        public const short DIR_DOWN_RIGHT = 7;
        public const short DIR_DOWN_LEFT = 8;

        public const char LetterXStart = 'A';

        public static bool isValidField(int x, int y, int deskSize)
        {
            if (x < 0 || x > deskSize - 1 || y < 0 || y > deskSize - 1)
                return false;
            return true;
        }
    }
}
