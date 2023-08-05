namespace IJ_homeWork_combineCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbersCollection1 = new string[] {"1", "2", "1" };
            string[] numbersCollection2 = new string[] {"3", "2" };
            List<string> combinedCollection = CombineCollections(numbersCollection1, numbersCollection2);

            for (int i = 0; i < combinedCollection.Count; i++)
            {
                Console.Write(combinedCollection[i] + " ");
            }

            Console.ReadKey();
        }

        static List<string> CombineCollections(string[] сollection1, string[] сollection2)
        {
            List<string> newCollection = new List<string>();
            string[][] collectionsForCombine = new string[][] { сollection1, сollection2 };

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