using Microsoft.AspNetCore.Mvc;

namespace TrademarkRegistrar.Controllers;

[ApiController]
[Route("[controller]")]
public class TrademarkController : ControllerBase
{
    private static readonly HashSet<string> NormalizedTrademarks = new();

    private static string RemoveWhiteSpaces(string input)
    {
        return input
            .Replace(" ", "")
            .Replace("\t", "")
            .Replace("\n", "");
    }
    
    [HttpGet]
    public IActionResult Register(string name)
    {
        string registrant = RemoveWhiteSpaces(name).ToLower();
        if(NormalizedTrademarks.Add(registrant))
        {
            return Ok(new { message = "Everything is okay!" });    
        }
        return BadRequest(new { message = "Error" });
    }   
}