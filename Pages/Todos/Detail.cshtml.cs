using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Pages.Todos
{
    public class DetailModel : PageModel
    {
        private readonly AppDbContext context;

        public DetailModel(AppDbContext context)
        {
            this.context = context;
        }

        public Todo.Models.Todos Todos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return RedirectToPage("./Index");
            }

            var todos = await context.Todos.FirstOrDefaultAsync(e => e.Id == id);

            if(todos == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Todos = todos;
                return Page();
            }
        }
    }
}
