using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Game
    {
        public Deck deck {get;set;}
        public Player dealer {get;set;}
        public Player player {get;set;}
        public Game(){
            deck = new Deck();
            deck.shuffle();
            dealer = new Player("Dealer");
            System.Console.WriteLine("Input Your Name");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
        } 
        public void PlayHand(){
            
            while(dealer.hand.Count<2){
                player.draw(deck);
                dealer.draw(deck);
            }
            System.Console.WriteLine("Dealer First Card: "+dealer.hand[0]);
            ShowHand(player);
            System.Console.WriteLine("Do you want to Hit [y/n]");  
            string answer = Console.ReadLine().ToLower();
            while(answer=="y"){
                player.draw(deck);
                ShowHand(player);
                if (CheckBust(player) == true){
                    dealer.hand.Clear();
                    player.hand.Clear();
                    System.Console.WriteLine("Would you like to play another hand? [y/n]");
                    string newhand = Console.ReadLine().ToLower();
                    if (newhand == "y"){
                        PlayHand();
                    }
                    System.Console.WriteLine("Thanks for playing!");
                }  
            }
            
        }
        public void ShowHand(Player player){
            System.Console.WriteLine(player.name+"'s Hand Is:");
            for(int i=0;i<player.hand.Count;i++){
                System.Console.WriteLine(player.hand[i]);
            }
        }
        public bool CheckBust(Player player){
            int sum = 0;
            foreach(Card c in player.hand){
                sum += c.val;
            }
            if(sum > 21){
                System.Console.WriteLine("Bust");
                return true;
            }
            return false;
        }
    }
}