#region Usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace Web.Models {
    public class RollDiceGameViewModel {
        [Required]
        [Display(Name = "On score:")]
        public int Score { get; set; }

        [Display(Name = "Bet amount:")]
        public int Chips { get; set; }
    }
}