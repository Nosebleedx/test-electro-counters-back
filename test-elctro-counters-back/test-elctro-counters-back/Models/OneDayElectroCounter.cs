namespace test_elctro_counters_back.Models
{
    public class OneDayElectroCounter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DailyMeasures ActiveInput { get; set; }
        public DailyMeasures ActiveOutput { get; set; }
        public DailyMeasures ReactiveInput { get; set; }
        public DailyMeasures ReactiveOutput { get; set; }

        public OneDayElectroCounter(int _id, string _name,
            DailyMeasures _actin, DailyMeasures _actout, DailyMeasures _reactin, DailyMeasures _reactout)
        {
            Id = _id;
            Name = _name;
            ActiveInput = _actin;
            ActiveOutput = _actout;
            ReactiveInput = _reactin;
            ReactiveOutput = _reactout;
        }
    }
}
