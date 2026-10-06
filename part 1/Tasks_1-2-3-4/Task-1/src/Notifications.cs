namespace RefactoringLab;

public record NotificationRequest(string To, string Message, DateTime? SendAt = null);

public interface INotificationChannel
{
    void Send(NotificationRequest request);
}

public class EmailNotificationChannel : INotificationChannel
{
    public void Send(NotificationRequest request)
    {
        var prefix = request.SendAt.HasValue
            ? $"[email scheduled {request.SendAt:g}]"
            : "[email]";

        Console.WriteLine($"{prefix} {request.To}: {request.Message}");
    }
}

public class SmsNotificationChannel : INotificationChannel
{
    public void Send(NotificationRequest request)
    {
        var prefix = request.SendAt.HasValue
            ? $"[sms scheduled {request.SendAt:g}]"
            : "[sms]";

        Console.WriteLine($"{prefix} {request.To}: {request.Message}");
    }
}

public class UrgentNotificationDecorator : INotificationChannel
{
    private readonly INotificationChannel _inner;

    public UrgentNotificationDecorator(INotificationChannel inner)
    {
        _inner = inner;
    }

    public void Send(NotificationRequest request)
    {
        var urgentRequest = request with
        {
            Message = $"[URGENT] {request.Message}"
        };

        _inner.Send(urgentRequest);
    }
}

public class ScheduledNotificationDecorator : INotificationChannel
{
    private readonly INotificationChannel _inner;
    private readonly DateTime _sendAt;

    public ScheduledNotificationDecorator(INotificationChannel inner, DateTime sendAt)
    {
        _inner = inner;
        _sendAt = sendAt;
    }

    public void Send(NotificationRequest request)
    {
        var scheduledRequest = request with
        {
            SendAt = _sendAt
        };

        _inner.Send(scheduledRequest);
    }
}

public class NotificationSender
{
    private readonly INotificationChannel _channel;

    public NotificationSender(INotificationChannel channel)
    {
        _channel = channel;
    }

    public void Send(string to, string message)
    {
        _channel.Send(new NotificationRequest(to, message));
    }
}
