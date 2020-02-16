using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Program
  {
    static void Main(string[] args)
    {
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

      // display player hand
      var playerHand = new List<Card>();

      //remove it from the the deck
      Console.WriteLine("Your cards are:");
      Console.WriteLine($"{deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
      playerHand.Add(deck[0]);
      deck.RemoveAt(0);

      Console.WriteLine($"{deck[0].DisplayCard()} ");
      playerHand.Add(deck[0]);
      deck.RemoveAt(0);

      string input = "";
      while (input == "" && deck.Count > 0)
      {
        Console.WriteLine($"The player has {playerHand.Count} cards");
        var total = 0;
        //total cards for first 2 cards dealt to player
        for (int i = 0; i < playerHand.Count; i++)
        {
          total += playerHand[i].GetCardValue();
        }
        Console.WriteLine($"Your total hand is: {total}");

        // player hit or stand
        var isRunning = true;
        while (isRunning)
        {
          Console.WriteLine("Hit or Stand?");
          input = Console.ReadLine().ToLower();
          if (input == "hit")
          {
            Console.WriteLine($"The next card is {deck[0].DisplayCard()}  has a value of {deck[0].GetCardValue()}");
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            total = 0;
            //total cards again
            for (int i = 0; i < playerHand.Count; i++)
            {
              total += playerHand[i].GetCardValue();
              if (total > 21)
              {
                Console.WriteLine("You Lost!!!");
              }
            }
            //if statement for <21
            Console.WriteLine($"Your new total hand is: {total}");

          }
          else if (input == "stand")
          {
            Console.WriteLine("dealers hand is:")
            //isRunning = false;
          }
        }
      }
    }
  }
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