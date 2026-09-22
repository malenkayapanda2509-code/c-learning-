namespace StyleErrors
{
    class Program
    {
        static int A;
        static int upperBound;

        static void Main()
        {
            upperBound = 100;
            Do();
        }

        static void Do()
        {
            A = 0;
            for (int theNumberToSquareAndSum = 0; theNumberToSquareAndSum < upperBound; theNumberToSquareAndSum++)
                A = A + theNumberToSquareAndSum * theNumberToSquareAndSum;
            Console.WriteLine("Sum = " + A.ToString());
            return;
        }
    }
}