using System;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataframe = new Dataframe.Simple.WeatherDataframe();
            Dataframe.Simple.WeatherDataframePopulator.Populate(dataframe, 3);
            Console.WriteLine(dataframe);

            dataframe.DoWeatherStatistics();
        }
    }
}
