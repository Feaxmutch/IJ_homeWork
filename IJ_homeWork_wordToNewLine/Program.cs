namespace IJ_homeWork_wordToNewLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char separationChar = ' ';
            string fontPangram = "Съешь ещё этих мягких французских булок, да выпей чаю.";
            string[] words = fontPangram.Split(separationChar);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}