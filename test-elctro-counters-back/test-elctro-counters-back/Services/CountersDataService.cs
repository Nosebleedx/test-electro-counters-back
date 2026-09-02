using test_elctro_counters_back.Models;

namespace test_elctro_counters_back.Services
{

    public class CountersDataService
    {
        private static readonly List<ElectroCounter> electroCounters = new List<ElectroCounter> {
                new (1, "ПС Восточная, Фидер 1", 2026, 5),
                new (2, "ПС Западная, Фидер 1", 2026, 5),
                new (3, "ПС Северная, Фидер 1", 2026, 5),
                new (4, "ПС Южная, Фидер 1", 2026, 5),
                new (5, "ПС Восточная, Фидер 2", 2026, 5),
                new (6, "ПС Западная, Фидер 2", 2026, 5),
                new (7, "ПС Северная, Фидер 2", 2026, 5),
                new (8, "ПС Южная, Фидер 2", 2026, 5),
                new (1, "ПС Восточная, Фидер 1", 2026, 6),
                new (1, "ПС Восточная, Фидер 1", 2026, 7)

        };

        public Task<ElectroCounter> GetCounterByNameAndDateAsync(string name, int year, int month)
        {
            var counter = electroCounters.FirstOrDefault(c => c.Name == name && c.Year == year && c.Month == month);
            return Task.FromResult(counter);
        }
        
        public Task<OneDayElectroCounter> GetCounterByNameAndDateAndDayAsync(string name, int year, int month, int day)
        {
            var counter = electroCounters.FirstOrDefault(c => c.Name == name && c.Year == year && c.Month == month);
            var result = new OneDayElectroCounter(counter.Id, counter.Name, counter.ActiveInput[day],
                counter.ActiveOutput[day], counter.ReactiveInput[day], counter.ReactiveOutput[day]);
            return Task.FromResult(result);
        }

        public Task<List<string>> GetAllNamesAsync()
        {
            var uniqueNames = electroCounters
                .Select(c => c.Name)
                .Distinct()
                .ToList();
            return Task.FromResult(uniqueNames);
        }
    }
}
