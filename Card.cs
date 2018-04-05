using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Card 
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card()
        {
            
        }  
        public Card(string suit, string stringVal,int val)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }
        public override string ToString(){
            return $"{stringVal} of {suit}";
        }
    }
}