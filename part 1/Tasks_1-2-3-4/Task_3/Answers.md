# Task 1.3 — Enrollment: Facade

## Enrollment

- What was the problem?
  - Program.cs knew about four different services and also had to know the correct order of the enrollment steps.
  - This made the caller tightly coupled to the internal enrollment process.

- What did you change?
  - Added an `EnrollmentFacade` that owns the enrollment workflow.
  - The facade calls PaymentGateway, SeatInventory, InvoiceGenerator, and EmailService in the required order.
  - Program.cs now makes one call: `enrollment.Enroll(studentId, courseId, amount);`
  - The four existing services in `Services.cs` were kept unchanged.

- What problem does the Facade solve?
  - It provides one simple entry point for a complex group of related operations.
  - The caller no longer needs to create or coordinate the individual services.

- What does the caller no longer need to know?
  - It no longer needs to know which services are involved, how they are created, or the order in which they must be called.
