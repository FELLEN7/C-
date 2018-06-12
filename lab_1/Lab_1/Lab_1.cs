using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class MainClass
    {
        static Cubic[] Cubics;
        static string Name;
        static void Input()
        {
            Cubics = new Cubic[InputNumberBoxes()];
            Name = InputName();
            InputAllBlocks();
            BuildName();
        }

        static void BuildName()
        {
            Letter(0, new List<int>());
        }

        static void Letter(int index, List<int> blockInUse)
        {
            List<int> newBlockInUse = blockInUse;

            for (int i = 0; i < Cubics.Length; i++)
            {
                if (!newBlockInUse.Contains(i) && Cubics[i].IsLetterExist(Name[index]))
                {
                    newBlockInUse.Add(i);
                    if (index == Name.Length - 1)
                    {
                        PrintAnswer(blockInUse);
                    }
                    else
                    {
                        Letter(index + 1, newBlockInUse);
                    }
                    newBlockInUse.Remove(i);
                }
            }
        }

        static void PrintAnswer(List<int> blockInUse)
        {
            foreach (int block in blockInUse)
            {
                Console.Write(block + " ");
            }
            Console.WriteLine();
        }

        static int InputNumberBoxes()
        {
            Console.WriteLine("INPUT NUMBER BOXES (< 100)");
            int count = 0;
            string input = Console.ReadLine();

            try
            {
                count = int.Parse(input);

                if (count > 0 && count < 100)
                {
                    return count;
                }
                else
                {
                    Console.WriteLine("ERROR!");
                    return InputNumberBoxes();
                }
            }
            catch
            {
                Console.WriteLine("Wrong input!");
                return InputNumberBoxes();
            }
        }

        static Cubic InputBlock()
        {
            Console.WriteLine("INPUT LETTERS FOR BOX (6)");
            string newLetters = Console.ReadLine();

            if (IsAllUpper(newLetters) && newLetters.Length == 6)
            {
                return new Cubic(newLetters);
            }
            else
            {
                Console.WriteLine("ERROR!");
                return InputBlock();
            }
        }

        static string InputName()
        {
            Console.WriteLine("(CAPS_LOCK) -> INPUT NAME SISTER: ");
            string newName = Console.ReadLine();

            if (IsAllUpper(newName) && newName.Length <= 100 && newName.Length > 0)
            {
                return newName;
            }
            else
            {
                Console.WriteLine("ERROR!");
                return InputName();
            }
        }
        static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
                if (!Char.IsUpper(input[i])) return false;

            return true;
        }

        static void InputAllBlocks()
        {
            for (int i = 0; i < Cubics.Length; i++)
                Cubics[i] = InputBlock();
        }
        public static void Main(string[] args)
        {
            Input();
            Console.ReadLine();
        }
    }
}
