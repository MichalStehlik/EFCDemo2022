using EFCDemo2022.Data;

var db = new ApplicationDbContext(@"Data Source=myGamesDatabase.sqlite");
foreach(var c in db.Companies.ToList())
{
    Console.WriteLine(c.Name);
}