using RefactoringLab;

var shippingCarriers = new IShippingCarrier[]
{
    new AramexShippingCarrier(),
    new FedExShippingCarrier(),
    new DhlShippingCarrier(),
    new BostaShippingCarrier()
};

var shipping = new ShippingCostCalculator(shippingCarriers);
Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"Bosta 2kg  → {shipping.Calculate("Bosta", 2)}");
Console.WriteLine();

var processor = new OrderProcessor(
    new SqlOrderRepository(),
    new SmtpEmailSender());

processor.Process(1001, "customer@example.com");
Console.WriteLine();

var sendAt = DateTime.Today.AddHours(18);

var email = new EmailNotificationChannel();
var sms = new SmsNotificationChannel();
var push = new PushNotificationChannel();

new NotificationSender(new UrgentNotificationDecorator(email))
    .Send("customer@example.com", "Your order is ready");

new NotificationSender(new ScheduledNotificationDecorator(sms, sendAt))
    .Send("+201000000000", "Your delivery is scheduled");

new NotificationSender(
        new ScheduledNotificationDecorator(
            new UrgentNotificationDecorator(push),
            sendAt))
    .Send("customer@example.com", "Your package is on the way");

new NotificationSender(email)
    .Send("customer@example.com", "Simple email");

new NotificationSender(
        new ScheduledNotificationDecorator(
            new UrgentNotificationDecorator(sms),
            sendAt))
    .Send("+201000000000", "Urgent OTP");

new NotificationSender(new UrgentNotificationDecorator(push))
    .Send("customer@example.com", "Push alert");
