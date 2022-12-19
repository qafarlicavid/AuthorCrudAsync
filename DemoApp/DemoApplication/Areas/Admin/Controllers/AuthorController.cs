﻿using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/author")]
    public class AuthorController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("list", Name = "admin-author-list")]
        public IActionResult List()
        {
            var model = _dataContext.Authors
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();

            return View(model);
        }


        #region Add


        [HttpGet("add", Name = "admin-author-add")]
        public IActionResult GetBook()
        {
           

            return PartialView("~/Areas/Admin/Views/Shared/Partials/_AddAuthorModalPartial.cshtml");
        }


        [HttpPost("add", Name = "admin-author-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _dataContext.Authors.AddAsync(new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            await _dataContext.SaveChangesAsync();

            var author = new Author();

            var id = author.Id;

            return Created("admin-author-list", id);
            

        }

        #endregion


        #region Delete

        [HttpDelete("delete-author/{id}", Name = "delete-author")]
        public IActionResult DeleteAuthorAsync(int id)
        {
            var author = _dataContext.Authors.FirstOrDefault(a => a.Id == id);

            if (author is null)
            {
                return BadRequest();
            }

            _dataContext.Authors.Remove(author);

            _dataContext.SaveChanges();

            var model = _dataContext.Authors
               .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
               .ToList();

            return NoContent();

        } 
        #endregion
    }
}
