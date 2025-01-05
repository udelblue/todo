using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Pages.Todos
{


    public class IndexModel : PageModel
    {


        private readonly AppDbContext context;
        public IndexModel(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Models.Todos> Todos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Todos = await context.Todos.ToListAsync();
        }
    }
}




