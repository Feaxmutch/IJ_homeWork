namespace IJ_homeWork_parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parentheses = "(()(()))";
            char leftParenthesis = '(';
            char rightParenthesis = ')';
            int currentDepth = 0;       
            int maxDepth = 0;
            bool isCorrect = true;

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == leftParenthesis)
                {
                    currentDepth++;
                }

                if (parentheses[i] == rightParenthesis)
                {
                    currentDepth--;
                }

                if (currentDepth < 0)
                {
                    isCorrect = false;
                    break;
                }

                if (maxDepth < currentDepth)
                {
                    maxDepth = currentDepth;
                }
            }

            if (currentDepth != 0)
            {
                isCorrect = false;
            }

            if (isCorrect)
            {
                Console.WriteLine("Строка коректная.");
                Console.WriteLine($"Максимальная вложеность: {maxDepth}");
            }
            else
            {
                Console.WriteLine("Строка не коректная.");
            }

            Console.ReadKey();
        }
    }
}