namespace PS.Template.API.Controllers
{
    public class MyUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
    }
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}