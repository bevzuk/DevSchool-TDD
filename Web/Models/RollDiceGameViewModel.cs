using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models {
    public class RollDiceGameViewModel {
        [Required]
        [Display(Name = "Make your bet on")]
        public int Score { get; set; }

        [Display(Name = "Your balance:")]
        public int Chips { get; set; }
    }
}