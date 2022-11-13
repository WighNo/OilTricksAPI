namespace OilTricksAPI.Data;

/// <summary>
/// Настройки РВС
/// </summary>
public class TanksSettings
{
    /// <summary>
    /// Объём первого РВС
    /// </summary>
    public float FirstTankCapacity { get; set; }
    
    /// <summary>
    /// Объём второго РВС
    /// </summary>
    public  float SecondTankCapacity { get; set; }
    
    /// <summary>
    /// Максимальная разница между РВС в процентах
    /// </summary>
    public float MaximumCapacityDifferenceInPercents { get; set; }
    
    /// <summary>
    /// Минимальная разница между РВС в процентах
    /// </summary>
    public float MinimumCapacityDifferenceInPercents { get; set; }
}