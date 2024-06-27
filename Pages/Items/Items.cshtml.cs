using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;

namespace RazorPagesApp.Pages
{
    public class ItemsModel : PageModel
    {
        [BindProperty]
        public string NewItem { get; set; }
        public List<string> Items { get; set; } = new List<string>();

        public void OnGet()
        {
            // Load items from session
            var itemsJson = HttpContext.Session.GetString("Items");
            if (!string.IsNullOrEmpty(itemsJson))
            {
                Items = JsonSerializer.Deserialize<List<string>>(itemsJson);
            }
        }

        public IActionResult OnPost()
        {
            // Load items from session
            var itemsJson = HttpContext.Session.GetString("Items");
            if (!string.IsNullOrEmpty(itemsJson))
            {
                Items = JsonSerializer.Deserialize<List<string>>(itemsJson);
            }

            // Add the new item
            if (!string.IsNullOrEmpty(NewItem))
            {
                Items.Add(NewItem);
                // Save the updated list back to session
                HttpContext.Session.SetString("Items", JsonSerializer.Serialize(Items));
            }

            // Redirect to GET to clear the form
            return RedirectToPage();
        }
    }
}
