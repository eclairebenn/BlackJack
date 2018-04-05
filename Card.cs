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

        public void printcard()
        {
            if(this.suit == "Heart" || this.suit == "Diamond")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                System.Console.WriteLine(this);
                Console.ResetColor();                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                System.Console.WriteLine(this);
                Console.ResetColor();     
            }

        }
    }
}