using EFCDemo2022.Data;
using EFCDemo2022.Models;
using Microsoft.EntityFrameworkCore;

var db = new ApplicationDbContext(@"Data Source=myGamesDatabase.sqlite");

foreach(var c in db.Companies.ToList())
{
    Console.WriteLine(c.Name);
}
foreach (var g in db.Games.Include(g => g.Developer).ToList())
{
    Console.WriteLine(g.Name + " - " + g.Developer?.Name);
}

foreach (var c in db.Companies
    .Include(c => c.Games)
    .Select(c => new CompanyListIM{ CompanyId = c.CompanyId, Name = c.Name, GameCount = c.Games.Count}).ToList())
{
    Console.WriteLine(c.Name + " - " + c.GameCount);
}

IQueryable<Game> games = db.Games;
games = games.Where(g => g.DeveloperId == 1);
games = games.OrderBy(g => g.Name);
games.ToList();
foreach(Game g in games)
{
    Console.WriteLine(g.Name);
}

Game game = db.Games.FirstOrDefault(g => g.GameId == 1);
if (game != null)
{
    db.Entry(game).Reference(g => g.Developer).Load();
    Console.WriteLine(game.Name + " - " + game.Developer?.Name);
}

Company company = db.Companies.SingleOrDefault(c => c.CompanyId == 1);
if (company != null)
{
    db.Entry(company).Collection(c => c.Games)
        .Query().Where(g => g.Name.Length > 5)
        .ToList();
    Console.WriteLine(company.Name);
}