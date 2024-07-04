using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesApp.Pages.ScoreReporting
{
    public class ScoreReportingModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ScoreReportingModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList PlayersSelectList { get; set; }
        public SelectList CourtsSelectList { get; set; }

        [BindProperty]
        public string SelectedPlayer1 { get; set; }

        [BindProperty]
        public string SelectedPlayer2 { get; set; }

        [BindProperty]
        public string SelectedCourt { get; set; }

        [BindProperty]
        public string MatchScore { get; set; }  // Updated property name

        public IList<Score> ScoreList { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            var players = new[] { "Danny", "Bobby", "Nadal", "Medvedev", "Alcaraz", "Agassi", "Sampras" };
            var courts = new[] { "Strawberry Mansion", "Chaminoux", "FDR", "Poplar", "Temple", "Drexel", "PENN", "Legacy" };

            PlayersSelectList = new SelectList(players);
            CourtsSelectList = new SelectList(courts);

            ScoreList = await _context.Scores.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var players = new[] { "Danny", "Bobby", "Nadal", "Medvedev", "Alcaraz", "Agassi", "Sampras" };
                var courts = new[] { "Strawberry Mansion", "Chaminoux", "FDR", "Poplar", "Temple", "Drexel", "PENN", "Legacy" };

                PlayersSelectList = new SelectList(players);
                CourtsSelectList = new SelectList(courts);

                return Page();
            }

            var score = new Score
            {
                Player1 = SelectedPlayer1,
                Player2 = SelectedPlayer2,
                CourtName = SelectedCourt,
                MatchScore = MatchScore
            };

            _context.Scores.Add(score);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ScoreReporting");
        }
    }
}
