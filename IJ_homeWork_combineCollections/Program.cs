namespace IJ_homeWork_combineCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Collection1 = new string[] {"1", "2", "1" };
            string[] Collection2 = new string[] {"3", "2" };
            List<string> combinedCollection = CombineCollections(Collection1, Collection2);

            for (int i = 0; i < combinedCollection.Count; i++)
            {
                Console.Write(combinedCollection[i] + " ");
            }

            Console.ReadKey();
        }

        static List<string> CombineCollections(string[] Collection1, string[] Collection2)
        {
            List<string> newCollection = new List<string>();
            string[][] collections = new string[][] { Collection1, Collection2 };

            for (int i = 0; i < collections.Length; i++)
            {
                for (int j = 0; j < collections[i].Length; j++)
                {
                    if (newCollection.Contains(collections[i][j]) == false)
                    {
                        newCollection.Add(collections[i][j]);
                    }
                }
            }
            
            return newCollection;
        }
    }
}