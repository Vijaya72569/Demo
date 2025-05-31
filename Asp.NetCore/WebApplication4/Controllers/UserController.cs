using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        [Route("Display1/{id?}")]
        public string Display1(int id)
        {
            return "Value of id is:"+id;
        }
        [Route("Display2/{id:int}")]
        public string Display2(int id)
        {
            return "Value of id is:" + id;
        }
        [Route("Display3/{id:double}")]
        public string Display3(double id)
        {
            return "Value of id is:" + id;
        }
        [Route("Display4/{id:min(50)}")]
        public string Display4(int id)
        {
            return "Value of id is:" + id;
        }
        [Route("Display5/{id:max(200)}")]
        public string Display5(int id)
        {
            return "Value of id is:" + id;
        }
        [Route("Display6/{id:range(9,50)}")]
        public string Display6(int id)
        {
            return "Value of id is:" + id;
        }
        [Route("Display7/{name:length(10)}")]
        public string Display7(string name)
        {
            return "Name of the user is:" + name;
        }
        [Route("Display8/{name:length(5,10)}")]
        public string Display8(string name)
        {
            return "Name of the user is:" + name;
        }
        [Route("Display9/{name:minlength(5)}")]
        public string Display9(string name)
        {
            return "Name of the user is:" + name;
        }
        [Route("Display10/{name:maxlength(10)}")]
        public string Display10(string name)
        {
            return "Name of the user is:" + name;
        }
        [Route("Display11/{name:alpha}")]
        public string Display11(string name)
        {
            return "Name of the user is:" + name;
        }
        [Route("Display12/{f:bool}")]
        public string Display12(bool f)
        {
            if (f)
                return "Namaste India";
            else
                return "Namaste Ap";
        }
    }
}


