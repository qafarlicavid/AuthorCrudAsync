using DemoApplication.Areas.Admin.ViewModels.Subscriber;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Admin.Controllers
{
    //[Area("admin")]
    //[Route("admin/subscriber")]
    //public class SubscriberController : Controller
    //{
    //    private readonly DataContext _dataContext;

    //    public SubscriberController(DataContext dataContext)
    //    {
    //        _dataContext = dataContext;
    //    }

    //    #region List

    //    [HttpGet("list", Name = "admin-subscriber-list")]
    //    public async Task<IActionResult> ListAsync()
    //    {
    //        var model = await _dataContext.Subscribers.Select(b => new ListViewModel(b.Id, b.Email, b.CreatedAt, b.UpdatedAt));
                        

    //        return View(model);
    //    }

    //    #endregion
    //}
}
