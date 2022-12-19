using DemoApplication.Areas.Client.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Client.ViewComponents
{
    public class ShopCart : ViewComponent
    {
        public IViewComponentResult Invoke(List<AddBasketViewModel>? model = null)
        {
            if (model is not null)
            {
                return View(model);
            }

            var productCookieValue = HttpContext.Request.Cookies["products"];
            var productViewModel = new List<AddBasketViewModel>();

            if (productCookieValue is not null)
            {
                productViewModel = JsonSerializer.Deserialize<List<AddBasketViewModel>>(productCookieValue);
            }
          
            return View(productViewModel);
        }
    }
}
