using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic_Game__Admin_.Models
{
    [Table("GameSettings")]
    public class GameSettings
    {
        public int GameSettingsID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Starting Amount")]
        public decimal StartingAmount { get; set; }

        [Display(Name = "Round 1 X")]
        public int? Round1Multiplier { get; set; }
        [Display(Name = "Round 2 X")]
        public int? Round2Multiplier { get; set; }
        [Display(Name = "Round 3 X")]
        public int? Round3Multiplier { get; set; }
        [Display(Name = "Round 4 X")]
        public int? Round4Multiplier { get; set; }

        [Display(Name = "Round 1 Return %")]
        public decimal? Round1ReturnPercentage { get; set; }
        [Display(Name = "Round 2 Return %")]
        public decimal? Round2ReturnPercentage { get; set; }
        [Display(Name = "Round 3 Return %")]
        public decimal? Round3ReturnPercentage { get; set; }
        [Display(Name = "Round 4 Return %")]
        public decimal? Round4ReturnPercentage { get; set; }

        [Display(Name = "Default")]
        public bool? SelectedSettings { get; set; }
    }
}
