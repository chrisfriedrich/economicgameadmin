using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic_Game__Admin_.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string PlayerName { get; set; }
        public string AmazonID { get; set; }
        [Display(Name = "Starting Amount")]
        public decimal? StartingAmount { get; set; }
        public int? CurrentRound { get; set; }

        [Display(Name ="Round 1 X")]
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

        [Display(Name = "Round 1 Investment")]
        public decimal? Round1Investment { get; set; }
        [Display(Name = "Round 1 Kept")]
        public decimal? Round1Kept { get; set; }
        [Display(Name = "Round 1 Returned")]
        public decimal? Round1Returned { get; set; }

        [Display(Name = "Round 2 Investment")]
        public decimal? Round2Investment { get; set; }
        [Display(Name = "Round 2 Kept")]
        public decimal? Round2Kept { get; set; }
        [Display(Name = "Round 2 Returned")]
        public decimal? Round2Returned { get; set; }

        [Display(Name = "Round 3 Investment")]
        public decimal? Round3Investment { get; set; }
        [Display(Name = "Round 3 Kept")]
        public decimal? Round3Kept { get; set; }
        [Display(Name = "Round 3 Returned")]
        public decimal? Round3Returned { get; set; }

        [Display(Name = "Round 4 Investment")]
        public decimal? Round4Investment { get; set; }
        [Display(Name = "Round 4 Kept")]
        public decimal? Round4Kept { get; set; }
        [Display(Name = "Round 4 Returned")]
        public decimal? Round4Returned { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(Name ="Player Total")]
        public decimal? PlayerTotal { get; set; }
        [Display(Name = "Computer Total")]
        public decimal? ComputerTotal { get; set; }

        [Display(Name = "Persuasion")]
        public string ComputerPersuasion { get; set; }
        [Display(Name = "Apology")]
        public string ComputerApology { get; set; }


        public int? GameSettingsID { get; set; }

        public Game()
        {
            this.CurrentRound = 1;
        }
    }

}
