namespace IJ_homeWork_frame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string horizontalSide = "";
            Console.WriteLine("Я могу поместить ваше имя в рамку из символов.");
            Console.Write("Напишите своё имя: ");
            string name = Console.ReadLine();
            Console.Write("Нажмите клавишу с символом будующей рамки: ");
            char frameChar = Console.ReadKey().KeyChar;
            string centerSide = $"{frameChar}{name}{frameChar}";
            Console.WriteLine();
            
            for (int i = 0; i < centerSide.Length; i++)
            {
                horizontalSide += frameChar;
            }

            Console.WriteLine(horizontalSide);
            Console.WriteLine(centerSide);
            Console.WriteLine(horizontalSide);
            Console.ReadKey(true);
        }
    }
}