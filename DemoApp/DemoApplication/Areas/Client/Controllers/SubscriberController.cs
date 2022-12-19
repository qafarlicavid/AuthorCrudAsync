using DemoApplication.Areas.Client.ViewModels.Subscriber;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.Controllers
{

    [Area("client")]
    [Route("subscriber")]
    public class SubscriberController : Controller
    {
        private readonly DataContext _dataContext;

        public SubscriberController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Add

        [HttpPost("add", Name = "client-subscriber-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _dataContext.Subscribers.AddAsync(new Subscriber
            {
                Email = model.Email,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
