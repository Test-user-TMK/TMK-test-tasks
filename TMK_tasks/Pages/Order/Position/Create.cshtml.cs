using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data;

namespace TMK_tasks.Pages.Order.Position
{
    public class Create : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public Create(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [BindProperty]
        public Data.Entities.Position NewPosition { get; set; }

        public Data.Entities.Order Order { get; set; }
        public List<Data.Entities.SteelType> SteelTypes { get; set; }
        public List<Data.Entities.State> States { get; set; }

        [BindProperty]
        public int OriginalId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SteelTypes = await _applicationDbContext.SteelTypes.ToListAsync();
            States = await _applicationDbContext.States.ToListAsync();

            Order = await _applicationDbContext.Orders
                .Where(_ => _.Id == id)
                .Include(_ => _.Manufacturer)
                .Include(_ => _.State)
                .FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _applicationDbContext.Positions.Add(NewPosition);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToPage("index", new { id = OriginalId.ToString()});
        }
    }
}
