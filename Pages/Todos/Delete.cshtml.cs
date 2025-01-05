using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Pages.Todos
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext context;

        public DeleteModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id==null)
            {
                return Page();
            }

            var todos = await context.Todos.FindAsync(id);

            if(todos == null)
            {
                return Page();
            }
            else
            {
                Todos = todos;
                context.Todos.Remove(Todos);
                await context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
    }
}
