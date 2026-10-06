namespace RefactoringLab;

public class PushNotificationChannel : INotificationChannel
{
    public void Send(NotificationRequest request)
    {
        var prefix = request.SendAt.HasValue
            ? $"[push scheduled {request.SendAt:g}]"
            : "[push]";

        Console.WriteLine($"{prefix} {request.To}: {request.Message}");
    }
}
