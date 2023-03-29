using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order.Position
{
    public class Update : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Update(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Data.Entities.Position PositionToUpdate { get; set; }

        public Data.Entities.Order Order { get; set; }
        public List<Data.Entities.SteelType> SteelTypes { get; set; }
        public List<Data.Entities.State> States { get; set; }

        [BindProperty]
        public int OriginalId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SteelTypes = await _applicationDbContext.SteelTypes.ToListAsync();
            States = await _applicationDbContext.States.ToListAsync();

            PositionToUpdate = await _applicationDbContext.Positions.Where(_ => _.Id == id)
                .Include(_ => _.SteelType)
                .Include(_ => _.State).FirstOrDefaultAsync();

            Order = await _applicationDbContext.Orders
                .Where(_ => _.Id == PositionToUpdate.OrderId)
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State)
                .FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _applicationDbContext.Positions.Update(PositionToUpdate);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToPage("index", new { id = OriginalId.ToString() });
        }
    }
}
