namespace IJ_homeWork_image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfImages = 52;
            int imagesInLine = 3;
            int numberOfFilledLines = numberOfImages / imagesInLine;
            int numberOfImagesInLastLine = numberOfImages % imagesInLine;
            Console.WriteLine($"У вас {numberOfImages} картинок(ка), которые образуют {numberOfFilledLines} заполненых рядов, и {numberOfImagesInLastLine} картинки(ку) в последнем ряду.");
            Console.ReadKey();
        }
    }
}