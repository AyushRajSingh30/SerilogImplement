using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApplication1.Model.Entity;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Auth : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LogModel request)
        {
            Log.Information("Login attempt for user: {Username}", request.Username);

            if (request.Username == "admin" && request.Password == "12345678")
            {
                Log.Information("User {Username} logged in successfully", request.Username);
                return Ok(new { message = "Login successful" });
            }
            else
            {
                Log.Warning("Failed login attempt for user: {Username}", request.Username);
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }
    }
}


//Log.Verbose("This is a Verbose log."); 	Most detailed logs, useful for debugging everything.
//Log.Debug("This is a Debug log.");        Debugging information, useful during development.
//Log.Information("This is an Information log.");  General application flow, used for normal events.
//Log.Warning("This is a Warning log.");           Something unexpected happened but the app continues.
//Log.Error("This is an Error log.");             Errors that cause functionality issues but not crashes.
//Log.Fatal("This is a Fatal log.");            Critical errors causing system failure.
