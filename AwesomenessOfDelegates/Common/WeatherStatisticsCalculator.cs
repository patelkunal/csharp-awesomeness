using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dataframe
{
    public class WeatherStatisticsCalculator
    {
        public static Tuple<DateTime, float> ColdestDay(Dictionary<DateTime, float> temperatureData)
        {
            return FindByValue(temperatureData, temperatureData.Values.Min());
        }

        public static Tuple<DateTime, float> HotestDay(Dictionary<DateTime, float> temperatureData)
        {
            return FindByValue(temperatureData, temperatureData.Values.Max());
        }

        private static Tuple<DateTime, float> FindByValue(Dictionary<DateTime, float> temperatureData, float value)
        {
            return temperatureData
                        .Where(kvp => kvp.Value == value)
                        .Select(kvp => Tuple.Create(kvp.Key, kvp.Value))
                        .First();
        }

        public static float AvgTemperature(Dictionary<DateTime, float> temperatureData)
        {
            return temperatureData.Values.Average();
        }
    }
}