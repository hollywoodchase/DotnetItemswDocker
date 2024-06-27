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
        public string ItemName { get; set; }
        public IList<Item> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await _context.Items.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(ItemName))
            {
                var newItem = new Item { Name = ItemName };
                _context.Items.Add(newItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
