using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order
{
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Index(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Data.Entities.Order> AllOrders { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            AllOrders = await _applicationDbContext.Orders
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State).ToListAsync();

            return Page();
        }
    }
}
