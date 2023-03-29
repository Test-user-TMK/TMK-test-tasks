using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order
{
    public class Update : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Update(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Data.Entities.Order OrderToUpdate { get; set; }

        public List<Data.Entities.Manufacturer> Manufacturers { get; set; }
        public List<Data.Entities.State> States { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Manufacturers = await _applicationDbContext.Manufacturers.ToListAsync();
            States = await _applicationDbContext.States.ToListAsync();

            OrderToUpdate = await _applicationDbContext.Orders.Where(_ => _.Id == id)
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State).FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _applicationDbContext.Orders.Update(OrderToUpdate);
            await _applicationDbContext.SaveChangesAsync();
            return Redirect("index");
        }
    }
}
