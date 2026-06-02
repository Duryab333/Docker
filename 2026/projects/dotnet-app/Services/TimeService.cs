namespace SimpleApp.Services;

public class TimeService
{
    public string GetUtcTime()
    {
        return DateTime.UtcNow.ToString("O");
    }
}
