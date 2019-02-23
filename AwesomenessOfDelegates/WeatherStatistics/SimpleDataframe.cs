using System;
using System.Linq;
using System.Collections.Generic;


namespace Dataframe.Simple
{
    public class WeatherDataframe
    {
        public Tuple<float, float> Location { get; private set; }


        /// _temperatureData should be concealed inside Dataframe because its complex/internal data representation
        /// which should not be exposed to others or other should not know how data is stored internally.
        ///
        /// That means, WeatherDataframe itself should operate data on its own rather than exposing data structure to
        /// operators/algorithms. 
        /// 
        /// Two approaches to solve this -
        /// 1.  WIRE all required operators/algorithms with Dataframe as its dependency but 
        ///     this way you will have to send data to these dependencies.
        /// 2.  Have all operations in same class which leads this class to big monolith class

        private Dictionary<DateTime, float> _temperatureData = new Dictionary<DateTime, float>();

        public void AddTemperature(DateTime when, float temperature) => _temperatureData.Add(when, temperature);

        public float GetTemperature(DateTime dateTime) => _temperatureData.ContainsKey(dateTime)
                                                                ? _temperatureData[dateTime]
                                                                : throw new KeyNotFoundException($"temperature is not recorded for date = {dateTime.ToShortDateString()}");


        /// Solution through 1st approach - where this will send data to WeatherStatisticsCalculator
        /// 
        /// Pros - Simple
        /// 
        /// Cons - Breaking changes in WeatherStatisticsCalculator will break this class as well.
        public void DoWeatherStatistics()
        {
            Tuple<DateTime, float> coldestday = WeatherStatisticsCalculator.ColdestDay(_temperatureData);
            Console.WriteLine($"Coldest day was {coldestday.Item1.ToShortDateString()} with {coldestday.Item2} temperature !!>");

            Tuple<DateTime, float> hotestday = WeatherStatisticsCalculator.HotestDay(_temperatureData);
            Console.WriteLine($"Hotestday day was {hotestday.Item1.ToShortDateString()} with {hotestday.Item2} temperature !!>");

            float avgTemperature = WeatherStatisticsCalculator.AvgTemperature(_temperatureData);
            Console.WriteLine($"Average temperature was {avgTemperature:f2}");
        }

        public override string ToString() => string.Join("; ", _temperatureData.Select(kvp => $"{kvp.Key.ToShortDateString()} -> {kvp.Value}"));
    }

    public class WeatherDataframePopulator
    {
        private static readonly Random _random = new Random();

        public static void Populate(WeatherDataframe dataframe, int days)
        {
            for (int i = 0; i < days; i++)
            {
                dataframe.AddTemperature(DateTime.Now.AddDays(-i).Date, _random.Next(-30, 50));
            }
        }
    }
}