using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{


    public class Card
    {//Array voor de rank van de kaarten en de symbolen ervan
		public static readonly String[] Rank = { "*", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Boer", "Vrouw", "Koning", "Aas" };
		private static readonly String[] Suit = { "*", "Harten", "Ruiten", "Koning", "Schoppen" };
		private byte cardSuit;
		private byte cardRank;
		public Card(int suit, int rank)
		{
			if (rank == 1)
				cardRank = 14;
			else
			cardRank = (byte)rank;
			cardSuit = (byte)suit;
		}

		public int suit()
		{
			return (cardSuit);
		}

		public int rank()
		{
			return (cardRank);
		}
		//Geeft aan hoe de kaarten worden weergegven (bvb Harten 5)
		public String toString()
		{
			return (Suit[cardSuit]+" "+ Rank[cardRank]);
		}
	}

}
      



