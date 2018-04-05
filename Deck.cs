using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Deck{
        public List<Card> cards = new List<Card>();

        public Deck()
        {
            generateDeck();
        }

        public Card deal()
        {
            Card temp = cards[0];
            cards.RemoveAt(0);
            return temp;
        }

        public void reset()
        {
            generateDeck();
        }
        
        public void generateDeck()
        {
            cards.Clear();
            string[] suits = {"Diamond","Spade","Club","Heart"};
            for(int i =0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Card card = new Card();
                    card.suit = suits[i];
                    card.val = j;
                    if(j == 11) {
                        card.stringVal = "Jack";
                    } else if(j == 12) {
                        card.stringVal = "Queen";
                    } else if (j == 13){
                        
                        card.stringVal = "King";
                    } else if (j == 1){
                        
                        card.stringVal = "Ace";
                       
                    } else {
                  
                        card.stringVal = ("" + j);
                       
                    }
                    cards.Add(card);
                }
            }
        }

        public void shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < 10; i ++)
            {
                for(int j = 0; j < cards.Count; j++)
                {
                    int randomIndex = rand.Next(1,52);
                    Card temp = cards[randomIndex];
                    cards[randomIndex] = cards[j];
                    cards[j] = temp;
                }
            }
            
        }

        public void displayDeck()
        {
            Console.WriteLine("There are " + cards.Count);
            foreach(Card card in cards)
            {
                Console.WriteLine(card.stringVal);
                Console.WriteLine(card.val);
                Console.WriteLine(card.suit);
                
            }
        }

        public void blackJackVals()
        {
            foreach(Card card in cards)
            {
                if(card.val > 10)
                {
                    card.val = 10;
                }

                if(card.val == 1)
                {
                    card.val = 11;
                }
            }
        }
    }
     
}