namespace IJ_homeWork_wordToNewLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separator = ' ';
            string PangramForFonts = "Съешь ещё этих мягких французских булок, да выпей чаю.";
            string[] words = PangramForFonts.Split(separator);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}