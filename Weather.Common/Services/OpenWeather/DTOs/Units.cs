using System.Runtime.Serialization;

namespace Weather.Services.OpenWeather.DTOs
{
    public enum Units
    {
        [EnumMember(Value = "imperial")]
        Imperial,
        [EnumMember(Value = "metric")]
        Metric
    }
}
