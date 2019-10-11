using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class PasswordVc : ViewComponent
    {
        public IViewComponentResult Invoke(AccountViewModel vm)
        {
            var passAcc = new AccountViewModel();

            return View(vm);
        }
    }
}
