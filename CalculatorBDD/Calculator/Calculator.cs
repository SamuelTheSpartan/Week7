namespace CalculatorLib
{
    public class Calculator
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public List<int> Numbers { get; set; }
        public int Add()
        {
            return Num1 + Num2;
        }

        public int Divide()
        {
            if (Num2 == 0)
            {
                throw new DivideByZeroException();
            }

            return Num1 / Num2;

        }

        public int Multiply()
        {
            return Num1 * Num2;

        }

        public int Subtract()
        {
            return Num1 - Num2;
        }

        public int Sum()
        {
            return Numbers.Sum(x => x % 2 == 0 ? x : 0);
        }
    }
}