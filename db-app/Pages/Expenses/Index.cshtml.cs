using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using db_app.Data;
using db_app.Models;

namespace db_app.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _context;

        public IndexModel(ProjectContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Expenses != null)
            {
                Expense = await _context.Expenses
                .Include(e => e.ExpenseType).ToListAsync();
            }
        }
    }
}
