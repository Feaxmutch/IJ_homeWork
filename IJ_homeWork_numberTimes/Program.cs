namespace IJ_homeWork_numberTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minNumber = 0;
            int maxNumber = 2;
            int[] numbers = new int[30];
            int repeatTimes = 1;
            int maxRepeatTimes = 1;
            int hightestRepeatingNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minNumber, maxNumber + 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    repeatTimes = 1;
                    hightestRepeatingNumber = numbers[i];
                }
                else
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        repeatTimes++;
                    }
                    else
                    {
                        repeatTimes = 1;
                    }
                }

                if (repeatTimes > maxRepeatTimes)
                {
                    maxRepeatTimes = repeatTimes;
                    hightestRepeatingNumber = numbers[i];
                }
            }

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            Console.WriteLine($"число {hightestRepeatingNumber} повторилось {maxRepeatTimes} раз, что является наибольшим числом повторений.");
        }
    }
}