using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Pages.Todos
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;

        public EditModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Todos.Update(Todos);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
