using Microsoft.AspNetCore.Mvc;
using OilTricksAPI.Data;
using OilTricksAPI.Requests.Data;

namespace OilTricksAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TanksSettingsController : ControllerBase
{
    private readonly TanksSettings _settings;
    
    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="settings">Актуальные настройки</param>
    public TanksSettingsController(TanksSettings settings)
    {
        _settings = settings;
    }
    
    /// <summary>
    /// Возвращает текущие настройки
    /// </summary>
    /// <returns></returns>
    [HttpGet("ActualSettings")]
    public IActionResult Get()
    {
        return Ok(_settings);
    }
    
    /// <summary>
    /// Изменить настройки
    /// </summary>
    /// <param name="settings">Новые настройки</param>
    /// <returns></returns>
    [HttpPost("SetSettings")]
    public IActionResult UpdateSettings([FromBody] SetTankSettingsRequestData settings)
    {
        IActionResult validateResult = ValidateSettingsData(settings);

        if (validateResult != Ok())
            return validateResult;
        
        _settings.FirstTankCapacity = settings.FirstTankCapacity;
        _settings.SecondTankCapacity = settings.SecondTankCapacity;

        return Ok(_settings);
    }

    /// <summary>
    /// Валидирует данные при изменении настроек
    /// </summary>
    /// <param name="settings">Настройки</param>
    /// <returns></returns>
    private IActionResult ValidateSettingsData(SetTankSettingsRequestData settings)
    {
        float firstTank = settings.FirstTankCapacity;
        float secondTank = settings.SecondTankCapacity;
        
        if (secondTank >= firstTank)
            return BadRequest("Объём второго резервуара должен быть меньше первого");

        float difference = 100 - GetTanksCapacityDifference(firstTank, secondTank);

        float maxDifference = _settings.MaximumCapacityDifferenceInPercents;
        float minDifference = _settings.MinimumCapacityDifferenceInPercents;

        if (difference > maxDifference || difference < minDifference)
            return BadRequest(
                $"Объём второго резервуара должен быть в диапазоне от {firstTank.PercentageOfNumber(minDifference)} до {firstTank.PercentageOfNumber(maxDifference)}");

        return Ok();
    }
    
    /// <summary>
    /// Считает разницу в процентах
    /// </summary>
    /// <param name="first">Первое число</param>
    /// <param name="second">Второе число</param>
    /// <returns></returns>
    private float GetTanksCapacityDifference(float first, float second)
    {
        float result = (second - first) / first * 100f;
        return Math.Abs(result);
    }
}