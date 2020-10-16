using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PS.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "3XM6dzdfCzvz8IFpiz9FFyJVgnc262wfIfQnZ6qM",
            BasePath = "https://pstemplate.firebaseio.com/Users"
        };
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(MyUser user)
        {
            IFirebaseClient _client = new FirebaseClient(config);
            SetResponse response = await _client.SetAsync(user.UserName, user);
            MyUser result = response.ResultAs<MyUser>();
            return new JsonResult(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> login(Login user)
        {
            IFirebaseClient _client = new FirebaseClient(config);

            FirebaseResponse response = await _client.GetAsync(user.UserName);
            MyUser result = response.ResultAs<MyUser>();
            return new JsonResult(result);
        }
    }
}