using System;

namespace Weather.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public double TemperatureMin { get; set; }

        public double Temperature { get; set; }

        public double TemperatureMax { get; set; }

        public string Description { get; set; }

        public Icons Icon { get; set; }
    }
}
