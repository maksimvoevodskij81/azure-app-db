using System.ComponentModel.DataAnnotations;

namespace db_app.Models
{
    public class ExpenseType
    {
        public int ID { get; set; }

        [Display(Name = "Expense Type")]
        public string Name { get; set; }

    }
}
