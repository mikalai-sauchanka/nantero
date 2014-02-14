using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pactas.SDK.DTO
{
    public enum SignupType
    {
        Trial = 0,
        Active = 1,
        Churn = 2,
        TrialExpired = 3,
        Other = 4
    }

    public class PlanStatisticsDTO
    {
        public SignupType SignupType { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }

        public int RunningMonth { get; set; }
    }

    public class StatsDatasetDTO
    {
        public StatsDatasetDTO() { data = new List<double> { 0, 0, 0, 0, 0, 0, 0 }; }

        public string label { get; set; }

        public string fillColor { get; set; }

        public string strokeColor { get; set; }

        public string pointColor { get; set; }

        public string pointStrokeColor { get; set; }

        public List<double> data { get; set; }
    }

    public class StatsDTO
    {
        //[DataMember(Name = "labels")]
        public List<string> labels { get; set; }
        //[DataMember(Name = "datasets")]
        public List<StatsDatasetDTO> datasets { get; set; }
    }

    public class DashboarSignupStatsDTO
    {
        public DashboarSignupStatsDTO()
        {
            //TrialSignups = new int[6];
            //PaidSignups = new int[6];
            //Churns = new int[6];
            stats = new int[3, 6];
        }

        //public int[] TrialSignups { get; set; }
        //public int[] PaidSignups { get; set; }
        //public int[] Churns { get; set; }
        public int[,] stats { get; set; }
    }

}
