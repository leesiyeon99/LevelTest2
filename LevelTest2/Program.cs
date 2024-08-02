namespace LevelTest2
/*. 
1. 두매개변수를서로교환하는함수를제작한다.
2. 함수는같은자료형의매개변수2개를요구한다.
3. 함수는매개변수로어떠한자료형이던대응할수있어야한다*/
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iLeft = 10;
            int iRight = 20;
            Util.Swap(ref iLeft, ref iRight);
            Console.WriteLine("int 자료형을 사용한 Swap 함수");
            Console.WriteLine($"{iLeft}, {iRight}");

            Console.WriteLine();

            double dLeft = 3.5;
            double dRight = 8.8;
            Util.Swap(ref dLeft, ref dRight);
            Console.WriteLine("double 자료형을 사용한 Swap 함수");
            Console.WriteLine($"{dLeft} {dRight}");
        }

        public static class Util
        {
            public static void Swap<T> (ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }
    }
}
