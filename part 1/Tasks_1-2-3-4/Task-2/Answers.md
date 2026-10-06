# Part 02 — answers

---

## Reports

- What was the problem?
  - The three exporters repeated the same `Load`, `Validate`, and `Save` steps, including the same order of execution. This makes the code harder to maintain and can cause the implementations to drift apart.

- What did you change?
  - Created the abstract `ReportExporter` base class.
  - Moved the common workflow into one `Export` method.
  - Kept only the formatting logic in `CsvReportExporter`, `JsonReportExporter`, and `TextReportExporter`.

- Why did you choose that approach?
  - Template Method is a good fit because the algorithm is the same for all exporters while one step (`Format`) changes.
  - An abstract class is better than an interface here because the subclasses need shared implementation and protected helper methods, not only a shared contract.

---

## Enrollment

- What was the problem?
  - The Enrollment code was not part of the Reports task described in this section, so no refactoring was applied to it.

- What did you change?
  - Nothing. The original Enrollment code is kept so the supplied project still behaves as provided.

- Why did you choose that approach?
  - The instructions provided for Task 1.2 specifically require refactoring the three report exporters using Template Method. Changing unrelated code would add unnecessary scope and could change the original behavior.
