using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;
using TMK_tasks.Data.Entities;

namespace TMK_tasks.Pages.Order
{
    public class Create : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Create(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Data.Entities.Order NewOrder { get; set; }

        public List<Data.Entities.Manufacturer> Manufacturers { get; set; }
        public List<Data.Entities.State> States { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Manufacturers = await _applicationDbContext.Manufacturers.ToListAsync();
            States = await _applicationDbContext.States.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _applicationDbContext.Orders.Add(NewOrder);
            await _applicationDbContext.SaveChangesAsync();
            return Redirect("index");
        }
    }
}
