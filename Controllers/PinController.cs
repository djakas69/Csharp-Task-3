using Microsoft.AspNetCore.Mvc;

namespace Csharp_Task_3.Controllers;

[ApiController]
[Route("pin")]
public class PinController
{



    [HttpGet(Name = "GetPinSolution")]
    public IEnumerable<String> Get(String observed)
    {
        return new List<string>() { "a", "b" };
    }


}