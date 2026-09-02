namespace test_elctro_counters_back.Models
{
    public class DailyMeasures
    {
        public float[] Measures { get; set; } = new float[48];


        //public static List<DailyMeasures> GenerateRandomMeasures(int year, int month)
        //{
        //    var result = new List<DailyMeasures>();
        //    var days = DateTime.DaysInMonth(year, month);
        //    var rand = new Random();

        //    for (int i = 1; i <= days; i++)
        //    {
        //        var dailyMeasures = new DailyMeasures(i);
        //        for(int j = 0; j < 48;  j++)
        //        {
        //            dailyMeasures.Measures[j] = (float)rand.NextDouble() * 100;
        //        }
        //        result.Add(dailyMeasures);
        //    }
            
        //    return result;
        //}

        public static Dictionary<int, DailyMeasures> GenerateRandomMeasuresDict(int year, int month)
        {
            var result = new Dictionary<int, DailyMeasures>();
            var days = DateTime.DaysInMonth(year, month);
            var rand = new Random();

            for (int i = 1; i <= days; i++)
            {
                var dailyMeasures = new DailyMeasures();
                for (int j = 0; j < 48; j++)
                {
                    dailyMeasures.Measures[j] = (float)rand.NextDouble() * 100;
                }
                result.Add(i, dailyMeasures);
            }

            return result;
        }
    }
}
