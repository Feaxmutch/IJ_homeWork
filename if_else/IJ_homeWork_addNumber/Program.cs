using System.ComponentModel;
using System.Xml;

namespace IJ_homeWork_addNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int appendValue = 7;
            int maxNumber = 96;

            for (int i = startNumber; i <= maxNumber; i += appendValue)
            {
                Console.Write($"{i} ");
            }

            Console.ReadKey();
        }
        
    }
}