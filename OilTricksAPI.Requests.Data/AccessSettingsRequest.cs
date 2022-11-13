using System.ComponentModel.DataAnnotations;

namespace OilTricksAPI.Requests.Data;

public class AccessSettingsRequest
{
    [Required]
    public string Key { get; set; }
}