using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Series
    {
        Linear[] linears;
        List<Solution> squares;

        public Series(int Liner_Letgth, int Square_Length)
        {
            linears = new Linear[Liner_Letgth];
            for (int i = 0; i < Liner_Letgth; i++)
                linears[i] = new Linear();

            squares = new List<Solution>();
            for (int i = 0; i < Square_Length; i++)
                squares.Add(new Square());
            Print(linears);
            Print(squares);
        }
        public Series(Linear[] newLinear, List<Solution> newSqares)
        {
            linears = newLinear; squares = newSqares;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != typeof(Series))
                return false;

            Series newObj = (Series)obj;
            return (this.GetHashCode() == newObj.GetHashCode());
        }

        public static bool operator ==(Series obj1, Series obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Series obj1, Series obj2)
        {
            return !obj1.Equals(obj2);
        }

        public Series DeepCopy()
        {
            Linear[] newLinears = new Linear[this.linears.Length];
            for (int i = 0; i < this.linears.Length; i++)
                newLinears[i] = this.linears[i];
            List<Solution> newSquares = new List<Solution>();
            foreach (Solution sol in this.squares)
                newSquares.Add(sol);
            return new Series(newLinears, newSquares);
        }

        public override int GetHashCode()
        {
            int hash = 1;
            foreach (Linear lin in linears)
                hash *= lin.GetHashCode();
            foreach (Square sqr in squares)
                hash *= sqr.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            string linears = "";
            for (int i = 0; i < this.linears.Length; i++)
                linears += $"{this.linears[i].ToString()}";
            string squares = "";
            foreach (Solution sol in this.squares)
                squares += $"{sol.ToString()}";
            string str = "{ " + $"\n    LINEARS: [{linears}], \n    SQUARES: [{squares}]" + " }";
            return str;
        }

        void Print(Solution[] solutions)
        {
            foreach (Solution solution in solutions)
                solution.Decide();
        }
        void Print(List<Solution> solutions)
        {
            foreach (Solution solution in solutions)
                solution.Decide();
        }

        public static void Start()
        { 
            Linear[] linears = { new Linear(1, 2), new Linear(1, 2), new Linear(3, 4) };
            List<Solution> squares = new List<Solution>();
            squares.Add(new Square(2, 2, 3));
            squares.Add(new Square(4, 5, 6));
            Series series1 = new Series(linears, squares);
            Series series2 = series1.DeepCopy();
            Console.Write($"SERIES_1: {series1.ToString()}\n");
            Console.Write($"SERIES_2: {series2.ToString()}\n");
            Console.Write($"SERIES_1 == SERIES_2 -> {series1 == series2}\n");
            Console.Write($"{linears[0].ToString()} == {linears[1].ToString()} -> {linears[0] == linears[1]}\n");
            Console.Write($"{linears[1].ToString()} != {linears[2].ToString()} -> {linears[1] != linears[2]}\n");
            Console.Write($"{linears[0].ToString()} === {linears[2].ToString()} -> {linears[0].Equals(linears[2])}\n");
            Console.Write($"{squares[0].ToString()} == {squares[1].ToString()} -> {squares[0] == squares[1]}\n");
            Console.Write($"{squares[0].ToString()} != {squares[1].ToString()} -> {squares[0] != squares[1]}\n");
            Console.Write($"{squares[0].ToString()} === {squares[1].ToString()} -> {squares[0].Equals(squares[1])}\n");
            Console.Write("=======================================================\n");
        }
    }
}
