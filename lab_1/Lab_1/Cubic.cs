using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class Cubic
    {
        char[] Letters;

        public Cubic(string letters)
        {
            Letters = letters.ToCharArray();
        }

        public bool IsLetterExist(char c)
        {
            for (int i = 0; i < Letters.Length; i++)
            {
                if (c == Letters[i])
                    return true;
            }
            return false;
        }
    }
}
