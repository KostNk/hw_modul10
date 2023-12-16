namespace hw10
{
    public interface ILogger
    {
        void Error(string s);

        void Write(string s);        
    }
    public interface ICalculator
    {
        int Add(int a, int b);
    }
    public class Logger : ILogger
    {
        void ILogger.Error(string message)
        {
            Console.BackgroundColor=ConsoleColor.Red;
            Console.WriteLine("Произошло событие '{0}'", message);
            Console.BackgroundColor = ConsoleColor.White;
        }

        void ILogger.Write(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Произошло событие '{0}'", message);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }

    public class Calculator:ICalculator
    {
        public int Add(int s1, int s2)
        {
            return s1 + s2;
        }
    }

    public class Program
    {
        static ILogger Logger { get; set; }
        static void Main()
        {
            int a = 0, b = 0;
            string entervalue;
            Calculator calculator = new Calculator();
            Logger = new Logger();

            try
            {
                Console.WriteLine("Введите первоe число для сложения");
                entervalue = Console.ReadLine();
                Logger.Write("ввели первое число");
                a = Convert.ToInt32(entervalue);

                Console.WriteLine("Введите второе число для сложения");
                entervalue = Console.ReadLine();
                Logger.Write("ввели второе число");
                b = Convert.ToInt32(entervalue);

                Console.WriteLine("{0}+{1}={2}", a, b, calculator.Add(a, b));
                Logger.Write("успешно сложили");
            }
            catch
            {
                Logger.Error("введено неправильное число");
            }
            Console.ReadKey();
        }
    }
}
