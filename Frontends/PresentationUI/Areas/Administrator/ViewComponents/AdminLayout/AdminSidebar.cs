﻿using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.ViewComponents.AdminLayout
{
    public class AdminSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
