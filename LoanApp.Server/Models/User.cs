namespace LoanApp.Server.Models;

public class User
{
    private static int _idCounter = 0;

    public User()
    {
        Id = Interlocked.Increment(ref _idCounter);
    }

    public int Id { get; } 
    public int Age { get; set; }
    public string Name { get; set; }
}