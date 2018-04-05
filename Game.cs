using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Game
    {
        public Deck deck {get;set;}
        public Dealer dealer {get;set;}
        public Player player {get;set;}
        public Game(){
            deck = new Deck();
            deck.blackJackVals();
            deck.shuffle();
            dealer = new Dealer();
            System.Console.WriteLine("Input Your Name");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
        } 
        public void PlayHand(){
            if(deck.cards.Count < 18)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("The deck needs to be reshuffled. Hold on bro...");
                System.Console.WriteLine("/\\/\\/\\/\\/\\/\\  Shuffle Shuffle  /\\/\\/\\/\\/\\/\\/\\");
                Console.ResetColor();
                deck.reset();
                deck.blackJackVals();
                deck.shuffle();
            }

            while(dealer.hand.Count<2){
                player.draw(deck);
                dealer.draw(deck);
            }
            System.Console.WriteLine("The Dealer is Showing: "+ dealer.hand[0]);
            ShowHand(player);
            player.findTotal();
            dealer.findTotal();
            if(player.handtotal == 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine($"You won {player.name}! The dealer had {dealer.handtotal} and you had {player.handtotal}");
                Console.ResetColor();
                NewHand();
            }
            else if(dealer.handtotal == 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine($"You lost {player.name}! The dealer had {dealer.handtotal} and you had {player.handtotal}");
                Console.ResetColor();
                NewHand();
            }
            System.Console.WriteLine("Do you want to Hit [y/n]");  
            string answer = Console.ReadLine().ToLower();
            while(answer=="y"){
                player.draw(deck);              
                player.findTotal();            
                ShowHand(player);
                if (CheckBust(player) == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine($"The player busted the player total is {player.handtotal}");
                    Console.ResetColor();
                    NewHand();
                }
                System.Console.WriteLine("Do you want to Hit [y/n]");  
                answer = Console.ReadLine().ToLower();  
            }

            dealer.findTotal();

            System.Console.WriteLine("The Dealer's Hand Is:");
            foreach(Card card in dealer.hand)
            {
                card.printcard();
            }
            
            while(dealer.hitStay())
            {
                Card newcard = dealer.draw(deck);
                System.Console.WriteLine($"The dealer drew a {newcard}");


                if(CheckBust(dealer))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    System.Console.WriteLine($"Congratulations {player.name}! The dealer busted! Damn you! The dealer had {dealer.handtotal} and you had {player.handtotal}");
                    Console.ResetColor();
                    NewHand();
                }                
            }



            if(dealer.handtotal > player.handtotal)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine($"You lost {player.name}! The dealer had {dealer.handtotal} and you had {player.handtotal}");
                Console.ResetColor();
                NewHand();
            }
            if(player.handtotal >= dealer.handtotal)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine($"You won {player.name}! The dealer had {dealer.handtotal} and you had {player.handtotal}");
                Console.ResetColor();
                NewHand();
            }


            
        }
        public void ShowHand(Player player){
            System.Console.WriteLine(player.name+"'s Hand Is:");
            for(int i=0;i<player.hand.Count;i++){
                (player.hand[i]).printcard();
            }
        }
        public bool CheckBust(Player player){
            player.findTotal();
            if(player.handtotal > 21){
                return true;
            }
            return false;
        }

        public void NewHand()
        {
            System.Console.WriteLine("Would you like to play another hand? [y/n]");
            string newhand = Console.ReadLine().ToLower();
            if (newhand == "y"){
                dealer.clearHand();
                player.clearHand();
                System.Console.WriteLine("---------------------------------------------------------------------");
                PlayHand();
            }
            System.Console.WriteLine("Thanks for playing!");
        }
    }
}