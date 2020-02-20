using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Program
  {
    public static void DisplayHand(List<Card> hand, string who)
    {
      Console.WriteLine($"the {who} hand contains");
      Console.WriteLine("---------");

      for (int i = 0; i < hand.Count; i++)
      {
        Console.WriteLine($"{hand[i].DisplayCard()}");

      }
      Console.WriteLine();
    }

    static void Main(string[] args)
    {

      // display card method

      //create deck
      var suits = new List<string>() { "clubs", "spades", "hearts", "diamonds" };
      var ranks = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };
      var deck = new List<Card>();

      for (int i = 0; i < suits.Count; i++)
      {
        for (int j = 0; j < ranks.Count; j++)
        {
          var card = new Card();
          card.Rank = ranks[j];
          card.Suit = suits[i];
          if (card.Suit == "diamonds" || card.Suit == "hearts")
          {
            card.ColorOfTheCard = "red";
          }
          else
          {
            card.ColorOfTheCard = "black";
          }
          deck.Add(card);
        }
      }
      for (int i = deck.Count - 1; i >= 1; i--)
      {
        // shuffle
        var j = new Random().Next(i);
        var temp = deck[j];
        deck[j] = deck[i];
        deck[i] = temp;
      }

      var playerHand = new List<Card>();
      var dealerHand = new List<Card>();


      //dealer hand
      dealerHand.Add(deck[0]);
      deck.RemoveAt(0);

      dealerHand.Add(deck[0]);
      deck.RemoveAt(0);

      // deal player hand & remove it from the the deck

      // 1st card
      // display card meth will replace this
      Console.WriteLine("Your cards are:");
      Console.WriteLine($"{deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
      playerHand.Add(deck[0]);
      deck.RemoveAt(0);

      // display card meth will replace this
      // 2nd card
      Console.WriteLine($"{deck[0].DisplayCard()} ");
      playerHand.Add(deck[0]);
      deck.RemoveAt(0);

      string input = "";

      Console.WriteLine($"The player has {playerHand.Count} cards");
      var total = 0;
      var pTotal = 0;
      var dTotal = 0;

      //total cards for first 2 cards dealt to player
      for (int i = 0; i < playerHand.Count; i++)
      {
        total += playerHand[i].GetCardValue();
      }
      Console.WriteLine($"Your total hand is: {total}");

      // player hit or stand
      var isRunning = true;
      //while (input == "hit" && pTotal <= 21)
      while (isRunning)
      {
        Console.WriteLine("Hit or Stand?");
        input = Console.ReadLine().ToLower();
        if (input == "hit")
        {
          // draw next card
          Console.WriteLine($"The next card is {deck[0].DisplayCard()}  has a value of {deck[0].GetCardValue()}");
          //DisplayHand(playerHand, "player");
          playerHand.Add(deck[0]);
          deck.RemoveAt(0);
          total = 0;
          Console.WriteLine("You hit");
          //total cards again
          for (int i = 0; i < playerHand.Count; i++)
          {
            total += playerHand[i].GetCardValue();
            if (total > 21)
            {
              pTotal = total;
              isRunning = false;
              //Console.WriteLine("You Lost!!!");
            }
            else
            {
              isRunning = true;
            }
          }
          Console.WriteLine($"Your new total hand is: {total}");
        }
        else
        {
          pTotal = total;
          Console.WriteLine("dealers hand is:");
          isRunning = false;
          // break;
        }
      }

      // player busting
      var pBust = true;
      if (pTotal > 21)
      {
        pBust = true;
        Console.WriteLine("you bust");
      }
      else
      {
        pBust = false;
      }

      // deal dealer hand
      var dealerNotBust = true;
      dTotal = dealerHand[0].GetCardValue() + dealerHand[1].GetCardValue();
      if (dTotal > 21)
      {
        dealerNotBust = false;
      }
      else
      {
        dealerNotBust = true;
      }

      while (pBust == true && deck.Count > 0)
      {
        if (dealerNotBust == true)
        {
          //Console.WriteLine($"{deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
          // Console.WriteLine($"{deck[0].DisplayCard()} ");
          for (int i = 0; i < dealerHand.Count; i++)
          {
            total += dealerHand[i].GetCardValue();
            Console.WriteLine($"dealer total is {total}");
            if (pBust == true && total <= 21)
            {
              Console.WriteLine("dealer wins");
              dealerNotBust = false;
            }
            else if (total <= 16)
            {
              // automatically hit dealer again 
              Console.WriteLine($"{deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
              dealerHand.Add(deck[0]);
              deck.RemoveAt(0);
              //dealerBust = false;
            }
            else
            {
              Console.WriteLine("deal bust");
              //dealerBust = false;
              break;
            }
          }
        }
        else
        {
          dealerNotBust = false;
          //break;
          if (pTotal <= 21)

          {
            Console.WriteLine("dealer bust you won");
          }
        }



      }
      //Console.WriteLine("out");
    }
  }
  //Console.WriteLine("out");
}







// dealer hand
// var dealerHand = new List<Card>();
// Console.WriteLine("this works");
// 1st card
// dealerHand.Add(deck[0]);
// deck.RemoveAt(0);
// 2nd card
// dealerHand.Add(deck[1]);
// dealerHand.RemoveAt(1);

//if (total > 21)
// {
//   Console.WriteLine("You Lose");
// }