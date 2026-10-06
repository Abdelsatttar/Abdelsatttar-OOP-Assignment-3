# Part 01 — answers

---

## ShippingCostCalculator

- What was the problem?
  - The calculator used a switch statement and had to be edited every time a new carrier was added. This violates the Open/Closed Principle.

- What did you change?
  - Added the `IShippingCarrier` abstraction and created one class per carrier.
  - `ShippingCostCalculator` now depends on the abstraction and receives the available carriers.
  - Added `BostaShippingCarrier` as a new carrier without changing the calculator or the other carrier classes.

---

## OrderProcessor

- What was the problem?
  - `OrderProcessor` created `SqlOrderRepository` and `SmtpEmailSender` directly, so it was tightly coupled to concrete implementations. This violates the Dependency Inversion Principle and makes testing harder.

- What did you change?
  - Added `IOrderRepository` and `IEmailSender` abstractions.
  - Injected both dependencies through the constructor.
  - `SqlOrderRepository` and `SmtpEmailSender` now implement those abstractions.

---

## Notifications

- What was the problem?
  - The original design used inheritance for combinations such as urgent email and urgent scheduled SMS. This causes class explosion and makes adding new combinations or channels harder.

- What did you change?
  - Replaced the inheritance hierarchy with composition.
  - Added `INotificationChannel` and separate channel classes for email, SMS, and push.
  - Added `UrgentNotificationDecorator` and `ScheduledNotificationDecorator` so behaviors can be combined without creating a separate class for every combination.

---

## Proof

- New carrier file(s): `src/BostaShippingCarrier.cs`
- New notification channel file(s): `src/PushNotificationChannel.cs`
- Existing classes left unchanged? no — the original classes were refactored as required by R1–R3. However, after the refactoring, adding the Bosta carrier and Push channel did not require editing any existing class; only `Program.cs` was changed to wire them in.
