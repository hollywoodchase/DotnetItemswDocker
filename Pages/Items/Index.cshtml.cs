// Pages/Items/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPagesApp.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item NewItem { get; set; }

        public IList<Item> Items { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            Items = await _context.Items.ToListAsync();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(NewItem);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
