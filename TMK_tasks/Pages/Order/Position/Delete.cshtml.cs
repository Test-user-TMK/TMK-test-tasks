using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order.Position
{
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Delete(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Data.Entities.Position PositionToDelete { get; set; }

        public Data.Entities.Order Order { get; set; }
        public List<Data.Entities.SteelType> SteelTypes { get; set; }
        public List<Data.Entities.State> States { get; set; }

        [BindProperty]
        public int OriginalId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SteelTypes = await _applicationDbContext.SteelTypes.ToListAsync();
            States = await _applicationDbContext.States.ToListAsync();

            PositionToDelete = await _applicationDbContext.Positions.Where(_ => _.Id == id)
                .Include(_ => _.SteelType)
                .Include(_ => _.State).FirstOrDefaultAsync();

            Order = await _applicationDbContext.Orders
                .Where(_ => _.Id == PositionToDelete.OrderId)
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State)
                .FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var positionToDelete = await _applicationDbContext.Positions.Where(_ => _.Id == id)
                .Include(_ => _.SteelType)
                .Include(_ => _.State).FirstOrDefaultAsync();

            _applicationDbContext.Positions.Remove(positionToDelete);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToPage("index", new { id = OriginalId.ToString() });
        }
    }
}
