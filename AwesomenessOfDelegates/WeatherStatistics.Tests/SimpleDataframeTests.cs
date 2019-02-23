using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dataframe.Simple;
using System;
using System.Collections.Generic;

namespace WeatherStatistics.Tests
{
    [TestClass]
    public class SimpleDataframeTests
    {
        [TestMethod]
        public void AddAndGetTemperatureTest()
        {
            WeatherDataframe dataframe = new WeatherDataframe();
            dataframe.AddTemperature(DateTime.Today, 10f);
            Assert.AreEqual(10f, dataframe.GetTemperature(DateTime.Today));

            Assert.ThrowsException<KeyNotFoundException>(() => dataframe.GetTemperature(DateTime.Today.AddDays(-2)));
        }
    }
}
