namespace SelectAllRowsInGroup.Data {
    public class WeatherForecastService {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] CloudCovers = new[] {
            "Sunny", "Partly cloudy", "Cloudy", "Storm"
        };
        public Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate) {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 30).Select(index => new WeatherForecast {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                CloudCover = CloudCovers[rng.Next(CloudCovers.Length)]
            }).ToList());
        }
    }
}
