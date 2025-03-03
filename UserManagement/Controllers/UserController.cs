using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.User;
using UserManagement.Domain.ViewModels;
using UserManagement.Infrastructure.Data;

namespace UserManagement.web.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel viewModel)
        {
            var user = new User
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                ContactNumber = viewModel.ContactNumber,
            };
            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var user = await DbContext.Users.ToListAsync();
            return View(user);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await DbContext.Users.FindAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddUserViewModel viewmodel)
        {
            var user = await DbContext.Users.FindAsync(viewmodel.Id);
            if (user == null)
            {
                user.FirstName = viewmodel.FirstName;
                user.LastName = viewmodel.LastName;
                user.Email = viewmodel.Email;
                user.ContactNumber = viewmodel.ContactNumber;

                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "User");
        }
    }
}