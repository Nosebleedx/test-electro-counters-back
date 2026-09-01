using System;
using System.Diagnostics.Contracts;

namespace test_elctro_counters_back.Models
{
    public class ElectroCounter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<DailyMeasures> ActiveInput {  get; set; }
        public List<DailyMeasures> ActiveOutput {  get; set; }
        public List<DailyMeasures> ReactiveInput {  get; set; }
        public List<DailyMeasures> ReactiveOutput {  get; set; }

        public ElectroCounter(int _id, string _name, int _year, int _month)
        {
            Id = _id;
            Name = _name;
            Year = _year;
            Month = _month;
            ActiveInput = DailyMeasures.GenerateRandomMeasures(_year, _month);
            ActiveOutput = DailyMeasures.GenerateRandomMeasures(_year, _month);
            ReactiveInput = DailyMeasures.GenerateRandomMeasures(_year, _month);
            ReactiveOutput = DailyMeasures.GenerateRandomMeasures(_year, _month);
        }
    }
}
