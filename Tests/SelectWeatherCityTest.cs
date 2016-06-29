using System;
using demo.framework;
using demo.framework.Forms;
using demo.Framework.Forms;
using NUnit.Framework;

namespace demo.Tests
{
    class SelectWeatherCityTest:BaseTest
    {
        private readonly String _weatherCity = RunConfigurator.GetValue("weather_city");
        
        [Test]
        public void RunTest()
        {
            MainForm mainForm=new MainForm();
            Log.Step(1);
            mainForm.ClickWeatherMenu();

            Log.Step(2);
            WeatherForm weatherPage=new WeatherForm();

            Log.Step(3);
            weatherPage.OpenWeatherCityList();
            weatherPage.SelectCity(_weatherCity);

            Log.Step(4, "The city is selected in the list of cities");
            weatherPage.AssertCity(_weatherCity);
        }



    }
}
