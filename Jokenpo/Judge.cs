using System;
using System.Collections.Generic;

namespace Jokenpo
{
    public class Judge
    {
        public Player Player2 { get; set; }
        public Player Player1 { get; set; }
        public Winer Winer { get; set; }

        private readonly HashSet<Tuple<Hand, Hand>> _winerMatrix = new HashSet<Tuple<Hand, Hand>>
        {
            new Tuple<Hand, Hand>(Hand.Scisor, Hand.Paper),
            new Tuple<Hand, Hand>(Hand.Stone, Hand.Scisor),
            new Tuple<Hand, Hand>(Hand.Scisor, Hand.Paper),
            new Tuple<Hand, Hand>(Hand.Paper, Hand.Stone),
        };

        public void ShowYourHands()
        {
            if (Player1 == null && Player2 == null) throw new InvalidOperationException("Sorry. We can't play without any players.");
            if (Player1 == null) throw new InvalidOperationException("Sorry. We can't play with only the Player2.");
            if (Player2 == null) throw new InvalidOperationException("Sorry. We can't play with only the Player1.");

            var hand1VersusHand2 = new Tuple<Hand, Hand>(Player1.Hand, Player2.Hand);
            var hand2VersusHand1 = new Tuple<Hand, Hand>(Player2.Hand, Player1.Hand);
            if (_winerMatrix.Contains(hand1VersusHand2))
                Winer = Winer.Player1;
            else if (_winerMatrix.Contains(hand2VersusHand1))
                Winer = Winer.Player2;
            else if (Player1.Hand == Player2.Hand)
                Winer = Winer.Draw;
        }
    }
}