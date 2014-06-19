using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain {
    public class Player {
        private readonly List<Bet> bets = new List<Bet>();

        public IList<Bet> Bets {
            get { return bets.AsReadOnly(); }
        }

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
            bets.Add(new Bet(chips, score));
        }

        public void Lose() {
            bets.Clear();
        }

        public void Win(int chips) {
            Chips += chips;
            bets.Clear();
        }
    }
}