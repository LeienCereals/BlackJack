using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BlackJack
{
    class Table
    {
        public int aantalSpeler;
		private const int NCARDS = 52;
		private Card[] deckOfCards;
		private int currentCard;
		private Random randNum;
		private int aantalKaarten;
		public Table()
		{//Maakt het Deck aan van 52 kaarten
			deckOfCards = new Card[NCARDS];
			int i = 0;
			for (int suit = 1; suit <= 4; suit++)
				for (int rank = 1; rank <= 13; rank++)
					deckOfCards[i++] = new Card(suit, rank);
			currentCard = 0;
		}
		///Gaat de kaarten schudden int n is hoe vaak geschud wordt
		public void shuffle(int n)
		{
			int i, j;
			randNum = new Random();
			for (int k = 0; k < n; k++)
			{
				i = (int)(randNum.Next(NCARDS));
				j = (int)(randNum.Next(NCARDS));
				Card tmp = deckOfCards[i];
				deckOfCards[i] = deckOfCards[j];
				deckOfCards[j] = tmp;
			}

			currentCard = 0;
		}
		//Dealt de kaarten uit 
		public Card deal()
		{
			if (currentCard < NCARDS)
				return (deckOfCards[currentCard++]);
			else
				return (null);
		}
		//Start het spel en je moet het aantal spelers en hoeveel kaarten je wilt aangeven
		public void StartGame()
        {

            Console.WriteLine("Geef het aantal spelers:", aantalSpeler);
			aantalSpeler = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Geef het aantal gewenste kaarten:", aantalKaarten);
			aantalKaarten = Convert.ToInt32(Console.ReadLine());


		}
		//Dealt de gewenste kaarten uit aan de gewenste speler en het wordt gesorteerd op waarde. 
		public void Deal()
		{
			Table deck;
			deck = new Table();
			deck.shuffle(100);
			List<string>[] Speler = new List<string>[aantalSpeler];
			for (int h = 0; h < aantalSpeler; h++)
				Speler[h] = new List<string>();
			for (int i = 0; i < aantalKaarten; i++)
				for (int j = 0; j < aantalSpeler; j++)
					Speler[j].Add(deck.deal().toString());
			for (int k = 0; k < aantalSpeler; k++)
			{
				List<string> sortedList = Speler[k].OrderBy(x => PadNumbers(x)).OrderBy(g => FaceValue(g)).ToList();
				Console.WriteLine("Player #" + (k + 1) + ": " + string.Join("-", sortedList));
			}
		}
		//Gaat de value van 1 tot 9 van string veranderen naar het getal
		public static string PadNumbers(string input)
		{
			return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(2, '0'));
		}
		//Verandert de plaatjes naar een getal
		public static int FaceValue(string input)
		{
			return input.Substring(0, 1) == "A" ? 14 : input.Substring(0, 1) == "K" ? 13 : input.Substring(0, 1) == "Q" ? 12 : input.Substring(0, 1) == "J" ? 11 : 0;
		}



	}
}
