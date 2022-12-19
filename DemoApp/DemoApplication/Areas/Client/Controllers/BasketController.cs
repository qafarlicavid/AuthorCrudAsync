using DemoApplication.Areas.Client.ViewComponents;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    public class BasketController : Controller
    {
        private readonly DataContext _dataContext;

        public BasketController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region AddBasket
        [HttpGet("add/{id}", Name = "client-basket-add")]
        public async Task<IActionResult> AddAsync([FromRoute] int id)
        {
            var product = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (product is null)
            {
                return NotFound();
            }


            var productsCookieViewModel = new List<AddBasketViewModel>();
            var productCookieValue = HttpContext.Request.Cookies["products"];

            if (productCookieValue is null)
            {
                productsCookieViewModel = new List<AddBasketViewModel>()
                {
                    new AddBasketViewModel(product.Id, product.Title, string.Empty, 1, product.Price, product.Price)
                };
                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));
            }
            else
            {
                productsCookieViewModel = JsonSerializer.Deserialize<List<AddBasketViewModel>>(productCookieValue);

                var productCookieViewModel = productsCookieViewModel!.FirstOrDefault(avm => avm.Id == id);

                if (productCookieViewModel is null)
                {
                    productsCookieViewModel!.Add(new AddBasketViewModel(product.Id, product.Title, string.Empty, 1, product.Price, product.Price));

                }
                else
                {
                    productCookieViewModel.Quantity += 1;
                    productCookieViewModel.Total = productCookieViewModel.Quantity * productCookieViewModel.Price;

                }
                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));


            }

            return ViewComponent(nameof(ShopCart), productsCookieViewModel);


        }
        #endregion

        #region Remove
        [Area("client")]
        [HttpGet("delete/{id}", Name = "client-basket-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            var product = await _dataContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (product is null)
            {
                return NotFound();
            }
            var productsCookieViewModel = new List<AddBasketViewModel>();
            var productCookieValue = HttpContext.Request.Cookies["products"];
            if (productCookieValue is null)
            {
                return NotFound();
            }

             productsCookieViewModel = JsonSerializer.Deserialize<List<AddBasketViewModel>>(productCookieValue);
            
            var cookieViewModel = productsCookieViewModel!.FirstOrDefault(b => b.Id == id);
            if (cookieViewModel.Quantity > 1)
            {
                cookieViewModel.Quantity -= 1;
                cookieViewModel.Total = cookieViewModel.Quantity * cookieViewModel.Price;
            }
            else
            {
                productsCookieViewModel.RemoveAll(pcvm => pcvm.Id == id);

            }

            HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(productsCookieViewModel));

            return ViewComponent(nameof(ShopCart), productsCookieViewModel);

        }

        #endregion
    }
}
