using System;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck deck = new Deck();
            deck.blackJackVals();
            Player player1 = new Dealer();
            deck.shuffle();
            player1.draw(deck);
            player1.draw(deck);
            (player1 as Dealer).findTotal();
            (player1 as Dealer).hitStay();
            

            deck.reset();
            Console.WriteLine(player1.hand);
        }
    }
}
