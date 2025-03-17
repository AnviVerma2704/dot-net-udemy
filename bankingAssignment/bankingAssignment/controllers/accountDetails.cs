using Microsoft.AspNetCore.Mvc;

namespace bankingAssignment.controllers
{
    public class accountDetails : Controller
    {
        [Route("account-details")]
        public IActionResult Index()
        {
            return Content("{\r\n    \"accountNumber\": 1001,\r\n    \"accountHolderName\": \"Example Name\",\r\n    \"currentBalance\": 5000\r\n }");
        }
    }
}
