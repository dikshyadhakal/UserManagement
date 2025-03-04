using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
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

        public ApplicationDbContext DbContext { get; set; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel viewModel)
        {
            var user = new User1
            {
                //Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                ContactNumber = viewModel.ContactNumber,
            };
            //userviewmodel instead of user 
            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            //chnaged Users to UserViewModels
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
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            var user = await DbContext.Users.FindAsync(viewModel.Id);
            if (user is not null)
            {
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;
                user.ContactNumber = viewModel.ContactNumber;

                await DbContext.SaveChangesAsync();
            }
            //returned UserViewModel which was viewmodel
            return RedirectToAction("List", "User");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User1 viewModel)
        {
            var user = await DbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (user is not null)
            {
                DbContext.Users.Remove(user);
                await DbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "User");
        }
    }
}
