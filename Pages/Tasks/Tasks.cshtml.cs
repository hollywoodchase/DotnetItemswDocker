using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPagesApp.Pages.Tasks
{
    public class TasksModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TasksModel(ApplicationDbContext context)
        {
            Console.WriteLine("TEST1");
            _context = context;
        }

        public SelectList UsersSelectList { get; set; }

        [BindProperty]
        public string SelectedUser { get; set; }

        [BindProperty]
        public string TaskName { get; set; }

        public IList<RazorPagesApp.Models.Task> TaskList { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            UsersSelectList = new SelectList(new[]
            {
                "Danny", "Jessie", "Mom", "Dad", "Bobby", "Cooper", "Hazel"
            });

            TaskList = await _context.Tasks.ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("TEST2");
            if (!ModelState.IsValid)
            {
                // Handle validation errors if needed
                return Page();
            }

            // Process form submission logic here
            var taskItem = new RazorPagesApp.Models.Task
            {
                AssignedTo = SelectedUser,
                Name = TaskName
            };

            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Tasks");
        }

    }
}
