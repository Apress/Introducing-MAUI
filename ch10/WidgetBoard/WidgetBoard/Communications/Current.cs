using System.Text.Json.Serialization;

namespace WidgetBoard.Communications;

public class Current
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    public int Sunrise { get; set; }

    public int Sunset { get; set; }

    public Weather[] Weather { get; set; }
}
