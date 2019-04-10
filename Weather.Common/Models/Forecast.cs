using System.Collections.Generic;

namespace Weather.Models
{
    public class Forecast
    {
        public IEnumerable<Weather> Days { get; set; }
    }
}
