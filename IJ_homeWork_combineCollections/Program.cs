namespace IJ_homeWork_combineCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstNumbers = new string[] {"1", "2", "1" };
            string[] secondNumbers = new string[] {"3", "2" };
            List<string> combinedNumbers = CombineCollections(firstNumbers, secondNumbers);

            for (int i = 0; i < combinedNumbers.Count; i++)
            {
                Console.Write(combinedNumbers[i] + " ");
            }

            Console.ReadKey();
        }

        static List<string> CombineCollections(string[] firstCollection, string[] secondCollection)
        {
            List<string> newCollection = new List<string>();
            string[][] collectionsForCombine = new string[][] { firstCollection, secondCollection };

            for (int i = 0; i < collectionsForCombine.Length; i++)
            {
                for (int j = 0; j < collectionsForCombine[i].Length; j++)
                {
                    if (newCollection.Contains(collectionsForCombine[i][j]) == false)
                    {
                        newCollection.Add(collectionsForCombine[i][j]);
                    }
                }
            }
            
            return newCollection;
        }
    }
}