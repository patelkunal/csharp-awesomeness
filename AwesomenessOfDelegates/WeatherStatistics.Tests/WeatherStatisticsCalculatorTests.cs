using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dataframe;
using System.Collections.Generic;
using System;

namespace WeatherStatistics.Tests
{
    [TestClass]
    public class WeatherStatisticsCalculatorTests
    {
        [TestMethod]
        public void ColdestDayTest()
        {
            Dictionary<DateTime, float> temperatureData = PrepareTemperatureData(10f, 30f);
            Tuple<DateTime, float> coldestDay = WeatherStatisticsCalculator.ColdestDay(temperatureData);
            Assert.AreEqual(10f, coldestDay.Item2);
        }

        [TestMethod]
        public void HotestDayTest()
        {
            Dictionary<DateTime, float> temperatureData = PrepareTemperatureData(10f, 30f);
            Tuple<DateTime, float> hotestDay = WeatherStatisticsCalculator.HotestDay(temperatureData);
            Assert.AreEqual(30f, hotestDay.Item2);
        }

        [TestMethod]
        public void AverageTemperatureTest()
        {
            Dictionary<DateTime, float> temperatureData = PrepareTemperatureData(10f, 30f);
            float avg = WeatherStatisticsCalculator.AvgTemperature(temperatureData);
            Assert.AreEqual(20f, avg);
        }

        private static Dictionary<DateTime, float> PrepareTemperatureData(params float[] temperatures)
        {
            Dictionary<DateTime, float> temperatureData = new Dictionary<DateTime, float>();
            for (int i = 0; i < temperatures.Length; i++)
                temperatureData.Add(DateTime.Today.AddDays(-i), temperatures[i]);
            return temperatureData;
        }
    }
}