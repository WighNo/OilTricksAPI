using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using OilTricksAPI.Data;
using OilTricksAPI.Requests.Data;

namespace OilTricksAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccessSettingsController : ControllerBase
{
    /// <summary>
    /// Настройки доступа
    /// </summary>
    private readonly AccessSettings _accessSettings;

    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="accessSettings">Актуальные настройки доступа</param>
    public AccessSettingsController(AccessSettings accessSettings)
    {
        _accessSettings = accessSettings;
    }

    /// <summary>
    /// Получить текущие настройки
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ActualSettings()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        
        return Ok(_accessSettings);
    }

    /// <summary>
    /// Проверка кода доступа
    /// </summary>
    /// <param name="code">Сравниваемый код</param>
    /// <returns></returns>
    [HttpGet("{code}")]
    public async Task<IActionResult> CheckingAccessCode(string code)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));

        if (code != _accessSettings.Key)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Обновление настроек
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UpdateSettings([FromBody] AccessSettingsRequest settings)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));

        _accessSettings.Key = settings.Key;
        return Ok(_accessSettings);
    }
}