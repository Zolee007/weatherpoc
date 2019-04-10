using System.Runtime.Serialization;

namespace Weather.Services.OpenWeather.DTOs
{
    public enum Icons
    {
        [EnumMember(Value = "01d")]
        ClearSkyDay,
        [EnumMember(Value = "01n")]
        ClearSkyNight,
        [EnumMember(Value = "02d")]
        FewCloudsDay,
        [EnumMember(Value = "02n")]
        FewCloudsNight,
        [EnumMember(Value = "03d")]
        ScatteredCloudsDay,
        [EnumMember(Value = "03n")]
        ScatteredCloudsNight,
        [EnumMember(Value = "04d")]
        BrokenCloudsDay,
        [EnumMember(Value = "04n")]
        BrokenCloudsNight,
        [EnumMember(Value = "09d")]
        ShowerRainDay,
        [EnumMember(Value = "09n")]
        ShowerRainNight,
        [EnumMember(Value = "10d")]
        RainDay,
        [EnumMember(Value = "10n")]
        RainNight,
        [EnumMember(Value = "11d")]
        ThunderStormDay,
        [EnumMember(Value = "11n")]
        ThunderStormNight,
        [EnumMember(Value = "13d")]
        SnowDay,
        [EnumMember(Value = "13n")]
        SnowNight,
        [EnumMember(Value = "50d")]
        MistDay,
        [EnumMember(Value = "50n")]
        MistNight
    }
}
