using System;


namespace Laba
{
    public class Class1
    {
        public class Block
        {
            char[] Letters;

            public Block(string letters)
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
}
