using Microsoft.AspNetCore.Mvc;

namespace bankingAssignment.controllers
{
    public class currentBalance : Controller
    {
        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult index()
        {
            object accountNumberObj;
            if (HttpContext.Request.RouteValues.TryGetValue("accountNumber", out accountNumberObj) && accountNumberObj is string accountNumber)
            {
                if (string.IsNullOrEmpty(accountNumber))
                {
                    return NotFound("Account Number should be supplied");
                }

                if (int.TryParse(accountNumber, out int accountNumberInt))
                {
                    var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

                    if (accountNumberInt == 1001)
                    {
                        return Content(bankAccount.currentBalance.ToString());
                    }
                    else
                    {
                        return BadRequest("Account Number should be 1001");
                    }
                }
                else
                {
                    return BadRequest("Invalid Account Number format");
                }
            }
            else
            {
                return NotFound("Account Number should be supplied");
            }
        }
    }
}
