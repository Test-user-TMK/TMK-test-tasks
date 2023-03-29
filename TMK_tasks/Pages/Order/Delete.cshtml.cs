using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order
{
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Delete(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Data.Entities.Order OrderToDelete { get; set; }

        public List<Data.Entities.Manufacturer> Manufacturers { get; set; }
        public List<Data.Entities.State> States { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Manufacturers = await _applicationDbContext.Manufacturers.ToListAsync();
            States = await _applicationDbContext.States.ToListAsync();

            OrderToDelete = await _applicationDbContext.Orders.Where(_ => _.Id == id)
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State).FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var orderToDelete = await _applicationDbContext.Orders.Where(_ => _.Id == id)
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State).FirstOrDefaultAsync();

            _applicationDbContext.Orders.Remove(orderToDelete);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToPage("index");
        }
    }
}
