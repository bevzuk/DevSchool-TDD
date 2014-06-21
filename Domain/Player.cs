#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace Domain {
    public class Player {
        public Bet CurrentBet { get; private set; }

        public void BuyChips(int chips) {
            if (chips < 0) {
                throw new ArgumentException("Are you cheating?");
            }
            Chips += chips;
        }

        public int Chips { get; private set; }

        public void Bet(int chips, int score) {
            if (Chips < chips) {
                throw new ArgumentException("Have you spend all your money already?");
            }

            Chips -= chips;
            CurrentBet = new Bet(chips, score);
        }

        public void Lose() {
            CurrentBet = null;
        }

        public void Win(int chips) {
            Chips += chips;
            CurrentBet = null;
        }

        public void Join(RollDiceGame game) {
            game.Player = this;
        }
    }
}