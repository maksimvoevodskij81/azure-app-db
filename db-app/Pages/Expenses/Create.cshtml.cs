using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using db_app.Models;

namespace db_app.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly db_app.Data.ProjectContext _context;

        public CreateModel(db_app.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExpenseTypeID"] = new SelectList(_context.ExpenseTypes, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Expense.ExpenseType");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
