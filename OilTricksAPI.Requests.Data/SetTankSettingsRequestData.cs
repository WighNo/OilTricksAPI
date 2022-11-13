namespace OilTricksAPI.Requests.Data;

/// <summary>
/// Данные для изменения настроек
/// </summary>
public class SetTankSettingsRequestData
{
    /// <summary>
    /// Объём первого РВС
    /// </summary>
    public float FirstTankCapacity { get; set; }
    
    /// <summary>
    /// Объём второго РВС
    /// </summary>
    public float SecondTankCapacity { get; set; }
}