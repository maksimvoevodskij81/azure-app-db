using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using db_app.Data;
using db_app.Models;

namespace db_app.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly db_app.Data.ProjectContext _context;

        public DetailsModel(db_app.Data.ProjectContext context)
        {
            _context = context;
        }

      public Expense Expense { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FirstOrDefaultAsync(m => m.ID == id);
            if (expense == null)
            {
                return NotFound();
            }
            else 
            {
                Expense = expense;
            }
            return Page();
        }
    }
}
