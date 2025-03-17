using Microsoft.AspNetCore.Mvc;

namespace bankingAssignment.controllers
{
    public class accountStatement : Controller
    {
        //[Route("account-statement")]
        public IActionResult Index()
        {
            return File("~/statement.pdf", "application/pdf");
        }
    }
}
