using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
   
    class PhoneBook
    {
        private Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        public void Add(string name, string phone)
        {
            if (!phoneBook.ContainsKey(name))
            {
                phoneBook[name] = phone;
                Console.WriteLine("Contactt added.");
            }
            else
            {
                Console.WriteLine("A contact with that name already exists.");
            }
        }

        public void Update(string name, string newPhone)
        {
            if (phoneBook.ContainsKey(name))
            {
                phoneBook[name] = newPhone;
                Console.WriteLine("The contact has been updated.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void Search(string name)
        {
            if (phoneBook.TryGetValue(name, out string phone))
            {
                Console.WriteLine($"Name: {name}, Phone: {phone}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void Delete(string name)
        {
            if (phoneBook.Remove(name))
            {
                Console.WriteLine("Contact deleted.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }

    


    class DeckOfCards
    {
        private Queue<string> deck;

        public DeckOfCards()
        {
            ResetDeck();
        }

        public void ResetDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            var cards = suits.SelectMany(suit => ranks.Select(rank => $"{rank} of {suit}"));
            deck = new Queue<string>(cards);
            Shuffle();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            deck = new Queue<string>(deck.OrderBy(_ => rnd.Next()));
            Console.WriteLine("The deck is shuffled.");
        }

        public string DrawCard()
        {
            if (deck.Count > 0)
            {
                return deck.Dequeue();
            }
            else
            {
                Console.WriteLine("The deck is empty.");
                return null;
            }
        }

        public List<string> DealCards(int count)
        {
            List<string> hand = new List<string>();

            for (int i = 0; i < count; i++)
            {
                if (deck.Count > 0)
                    hand.Add(DrawCard());
                else
                    break;
            }

            return hand;
        }
    }

    
    static void Main(string[] args)
    {
        List<string> words = new List<string> { "cake", "think", "sharp", "basketball", "computer" };

        string maxWord = words
            .Where(w => w.Length == words.Max(x => x.Length))
            .OrderBy(w => w)
            .First();

        Console.WriteLine($"Max word: {maxWord}");
       


        PhoneBook phoneBook = new PhoneBook();
        phoneBook.Add("Alex", "098756480");
        phoneBook.Add("Mary", "09568438");
        phoneBook.Search("Alex");
        phoneBook.Update("Alex", "067950463");
        phoneBook.Delete("Mary");

     

        DeckOfCards deck = new DeckOfCards();

        Console.WriteLine("We mix the log...");
        deck.Shuffle();

        Console.WriteLine("We deal 6 cards:");
        List<string> hand = deck.DealCards(6);
        hand.ForEach(card => Console.WriteLine(card));

        Console.WriteLine("We take one card:");
        Console.WriteLine(deck.DrawCard());

      
    }
}
