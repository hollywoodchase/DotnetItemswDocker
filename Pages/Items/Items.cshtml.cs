using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesApp.Pages.Items
{
    public class ItemsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ItemsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string NewItem { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public void OnGet()
        {
            Items = _context.Items.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(NewItem))
            {
                var item = new Item { Name = NewItem };
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
