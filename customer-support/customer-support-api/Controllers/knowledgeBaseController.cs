using customer_support_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace customer_support_api.Controllers
{
    public class knowledgeBaseController : Controller
    {
        public IActionResult Index(AppDbContext context)
        {
            return View();
        }
        
    }
}
