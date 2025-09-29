using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text.Json.Serialization;

public class LightsPlugin
{
    private readonly List<LightModel> lights = new()
    {
        new LightModel { Id=1, Name = "Table Lamp", IsOn = false },
        new LightModel { Id = 2, Name = "Porch Light", IsOn = false},
        new LightModel { Id = 3, Name = "Chandelier", IsOn = true},
        new LightModel { Id = 4, Name = "Kitchen Light", IsOn = false},
        new LightModel { Id = 5, Name = "Desk light", IsOn = true}
    };

    [KernelFunction("get_lights")]
    [Description("Gets a list of lights and their current state")]

    public async Task<List<LightModel>> GetLightsAsync()
    {
        return lights;
    }

    [KernelFunction("change_state")]
    [Description("Changes the state of the lights")]
    //change the state of one of the lights
    public async Task<LightModel?> ChangeStateAsync(int id, bool isOn)
    {
        //query light base on Id 
        var light = lights.FirstOrDefault(light => light.Id == id);

        if (light == null)
        {
            return null;
        }
        //update light with new state
        light.IsOn = isOn;
        return light;
    }

    public class LightModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("is_on")]
        public bool? IsOn { get; set; }
    }
}