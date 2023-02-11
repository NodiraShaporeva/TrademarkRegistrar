using Microsoft.AspNetCore.Mvc;

namespace TrademarkRegistrar.Controllers;

[ApiController]
[Route("[controller]")]
public class TrademarkController : ControllerBase
{
    private static readonly List<string> TrademarksList = new ();
    private readonly ILogger<TrademarkController> _logger;

    public TrademarkController(ILogger<TrademarkController> logger)
    {
        _logger = logger;
    }

    private static string RemoveInPlaceCharArray(string input)
    {
        var len = input.Length;
        var src = input.ToCharArray();
        int dstIdx = 0;
        for (int i = 0; i < len; i++)
        {
            var ch = src[i];
            if (!Char.IsWhiteSpace(ch))
                src[dstIdx++] = ch;
        }
        return new string(src, 0, dstIdx);
    }
    
    [HttpGet]
    public async Task<IActionResult> Register(string name)
    {
        // if (TrademarksList.Exists(x => x.Replace(" ", "").ToLower() ==
        //                           name.Replace(" ", "").ToLower()))

        string sample = RemoveInPlaceCharArray(name);
        if(TrademarksList.Exists(
               x => String.Equals(RemoveInPlaceCharArray(x), sample, StringComparison.CurrentCultureIgnoreCase)
               )
           )
        {
            return BadRequest(new { message = "Error" });
        }
        TrademarksList.Add(name);
        return Ok(new { message = "Everything is okay!" });    
    }   
}