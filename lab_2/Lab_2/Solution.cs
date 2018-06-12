using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public abstract class Solution
    {
        public abstract void Decide();
        public abstract void Print();

        protected virtual double Input(string Variable, bool CanNull)
        {
            Console.WriteLine("INPUT " + Variable);
            if (!CanNull) Console.WriteLine("!= 0");

            double variable = 0;
            string str = Console.ReadLine();
            try
            {
                variable = double.Parse(str);

                if (!CanNull && variable == 0)
                {
                    Console.WriteLine("ERROR!");
                    return Input(Variable, CanNull);
                }
                else
                {
                    return variable;
                }
            }
            catch
            {
                Console.WriteLine("ERROR!");
                return Input(Variable, CanNull);
            }
        }
    }

    public class Linear : Solution
    {
        double a;
        double b;
        public Linear()
        {
            a = Input("a", false);
            b = Input("b", true);
        }
        public Linear(double newA, double newB)
        {
            a = newA; b = newB;
        }

        public override void Decide()
        {
            Print();
            double x = -b / a;
            PrintAnsver(x);
        }

        public override void Print()
        {
            Console.WriteLine($"{a}*x + {b} = 0");
        }

        private void PrintAnsver(double x)
        {
            Console.WriteLine($"x = {x}");
            Console.WriteLine( a + "*" + x + "+" + b + "= 0");
        }

        protected override double Input(string Variable, bool CanNull)
        {
            return base.Input(Variable, CanNull);
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != typeof(Linear))
                return false;
            Linear newObj = (Linear)obj;
            return (this.GetHashCode() == newObj.GetHashCode());
        }

        public static bool operator == (Linear obj1, Linear obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator != (Linear obj1, Linear obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override int GetHashCode()
        {
            int hash = 10;
            hash = (hash / 2) + this.a.GetHashCode();
            hash = (hash * 20) + this.b.GetHashCode();
            return hash;
        }

        public Linear DeepCopy(Linear obj)
        {
            Linear newObj = new Linear(obj.a, obj.b);
            return newObj;
        }

        public override string ToString()
        {
            string str = "{ " + $"a: {this.a}, b: {this.b}" + " }";
            return str;
        }
    }

    public class Square : Solution
    {
        double A;
        double B;
        double C;
        public Square()
        {
            A = Input("a", false);
            B = Input("b", true);
            C = Input("c", true);
        }
        public Square(double newA, double newB, double newC)
        {
            A = newA; B = newB; C = newC;
        }
        public override void Decide()
        {
            Print();
            double D = Math.Pow(B, 2) - 4 * A * C;
            if (D.Equals(0))
            {
                double x = -B / 2 * A;
                ShowAnswer(x);
            }
            else if (D > 0)
            {
                double x1 = (-B + Math.Sqrt(D)) / 2 * A;
                ShowAnswer(x1);
                double x2 = (-B - Math.Sqrt(D)) / 2 * A;
                ShowAnswer(x2);
            }
            else
            {
                Console.WriteLine("NO SOLUTIONS");
            }
        }

        private void ShowAnswer(double x)
        {
            Console.Write($"x = {x}\n");
            Console.Write($"{A}*{x} + {B} = 0\n");
        }

        protected override double Input(string VariableName, bool CanNull)
        {
            return base.Input(VariableName, CanNull);
        }

        public override void Print()
        {
            Console.Write($"{A}*x^2 + {B}*x + {C} = 0\n");
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != typeof(Square))
                return false;

            Square new_obj = (Square)obj;
            return (this.GetHashCode() == new_obj.GetHashCode());
        }

        public static bool operator ==(Square obj1, Square obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Square obj_1, Square obj_2)
        {
            return !obj_1.Equals(obj_2);
        }

        public override int GetHashCode()
        {
            int code = 10;
            code = (code / 2) + this.A.GetHashCode();
            code = (code * 20) + this.B.GetHashCode();
            code = (code - 200) + this.C.GetHashCode();
            return code;
        }

        public Square DeepCopy()
        {
            Square Obj = new Square(this.A, this.B, this.C);
            return Obj;
        }

        public override string ToString()
        {
            string str = "{ " + $"a: {this.A}, b: {this.B}, c: {this.C}" + " }";
            return str;
        }
    }
}
