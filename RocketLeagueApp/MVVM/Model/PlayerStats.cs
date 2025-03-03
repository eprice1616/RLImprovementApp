using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueApp.Model
{


    public class PlayerStats
    {
        public string? Rank { get; set; }
        public double ShootingPercentage { get; set; }
        public double ShotsPerGame { get; set; }
        public double SavePercentage { get; set; }
        public double SavesPerGame { get; set; }
        public double GoalPerMatch { get; set; }
    }

}
