using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.CarDetail
{
    public class CarReview : ViewComponent
    {
        public IViewComponentResult Invoke(string id)
        {
            return View();
        }
    }
}
