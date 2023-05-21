using Csharp_Task_3.Models;
using Csharp_Task_3.Models.Dto;
using Csharp_Task_3.Pins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csharp_Task_3.Controllers;

[ApiController]
[Route("api/pins")]
public class PinController : ControllerBase
{
    private readonly ILogger<PinController> _logger;
    public PinController(ILogger<PinController> logger)
    {
        _logger = logger;
        
    }

    [HttpGet("{pin}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<PinDTO> Get(string pin)
    {
        _logger.LogInformation("Get one pin ");
        if (pin.Length > 8)
        {
            _logger.LogError("Pin is out of scope");
            return NotFound();
        }
        PinDTO pins = new PinDTO();
        PinMatrix pmx = new PinMatrix();
        pins.CalulatedPins = pmx.pinVariations(pin);
        return Ok(pins);
      

    }

    private IEnumerable<String> getPINs(String inputString)
    {
        List<String> res = new List<String>();
        try
        {
            char[] chars = inputString.ToCharArray();
            for (int i = 0;i<chars.Length; i++)
            {
                res.Add(chars[i].ToString());
            }
            //return new List<String>() { inputString };
            //res.Add(inputString);
            return res;
        }
        catch (Exception ee)
        {

            return new List<String>() { ee.Message };
        }
        
    }

}