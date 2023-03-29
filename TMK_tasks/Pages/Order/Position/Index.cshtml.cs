using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order.Position
{
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Index(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Data.Entities.Order ParentOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ParentOrder = await _applicationDbContext.Orders
                .Where(_ => _.Id == id)
                .Include(_ => _.Positions)
                .ThenInclude(_ => _.SteelType)
                .Include(_ => _.Positions)
                .ThenInclude(_ => _.State).FirstOrDefaultAsync();

            return Page();
        }
    }
}
