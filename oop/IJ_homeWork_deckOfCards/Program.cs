namespace IJ_homeWork_deckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            string userInput = string.Empty;
            string defaultInput = "5";
            int cardsCount;

            while (int.TryParse(userInput, out cardsCount) == false)
            {
                Console.Clear();
                Console.Write($"Введите количество карт, которые хотите взять, или оставте поле пустым, чтобы взять {defaultInput} карт: ");
                userInput = Console.ReadLine();

                if (userInput == string.Empty)
                {
                    userInput = defaultInput;
                }
            }
            
            for (int i = 0; i < cardsCount; i++)
            {
                player.GetCard(deck.TakeCard());
            }

            player.WriteCards();
            Console.ReadKey();
        }
    }

    class Deck
    {
        private static Random _random = new Random();

        private Stack<Card> _cards = new Stack<Card>();

        public Deck()
        {
            CreateCards();
            ShuffleCards();
        }

        public Card TakeCard()
        {
            if (_cards.Count == 0)
            {
                return null;
            }
            else
            {
                return _cards.Pop();
            }
        }

        private void CreateCards()
        {
            Array Suits = Enum.GetValues(typeof(CardSuit));

            foreach (CardSuit Suit in Suits)
            {
                for (int i = Card.MinRank; i <= Card.MaxRank; i++)
                {
                    _cards.Push(new Card(Suit, i));
                }
            }
        }

        private void ShuffleCards()
        {
            List<Card> cards = new List<Card>();

            for (int i = _cards.Count; i > 0; i--)
            {
                cards.Add(_cards.Pop());
            }

            for (int i = 0; i < cards.Count; i++)
            {
                Swap(cards, i, _random.Next(0, cards.Count));
            }

            for (int i = 0; i < cards.Count; i++)
            {
                _cards.Push(cards[i]);
            }
        }

        private void Swap(List<Card> cardsList, int firstIndex, int secondIndex)
        {
            Card temp = cardsList[firstIndex];
            cardsList[firstIndex] = cardsList[secondIndex];
            cardsList[secondIndex] = temp;
        }
    }

    class Card
    {
        private static int _minRank = 2;
        private static int _maxRank = 10;

        private int _rank;

        public Card(CardSuit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public CardSuit Suit { get; private set; }

        public static int MinRank
        {
            get
            {
                return _minRank;
            }
            private set { }
        }

        public static int MaxRank
        {
            get
            {
                return _maxRank;
            }
            private set { }
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
            private set
            {
                if (value < MinRank)
                {
                    _rank = MinRank;
                }
                else if (value > MaxRank)
                {
                    _rank = MaxRank;
                }
                else
                {
                    _rank = value;
                }
            }
        }

        public void WriteInfo()
        {
            Console.WriteLine($"Масть: {Suit} ранг: {Rank}");
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public void GetCard(Card card)
        {
            if (card != null)
            {
                _cards.Add(card);
            }
        }

        public void WriteCards()
        {
            foreach (var card in _cards)
            {
                card.WriteInfo();
            }
        }
    }

    enum CardSuit
    {
        Diamonds,
        Hearts,
        Clubs,
        Spades
    }
}