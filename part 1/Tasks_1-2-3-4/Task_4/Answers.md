# Task 1.4 — Blocked Users & Students

## BlockedUsers

* Time complexity before: `O(n * m)` where `n` is the number of requests and `m` is the number of blocked IDs.

* Time (ms) before: `186 ms`

* What did you change?

  * Converted `blockedIds` to a `HashSet<int>` once inside `CountBlocked`.
  * Replaced `List.Contains` with `HashSet.Contains`.
  * The found count stays unchanged.

* Time complexity after: `O(n + m)` because building the set is `O(m)` and each lookup is approximately `O(1)` on average.

* Time (ms) after: `2 ms`

The after-time is clearly lower than the before-time on the same machine.

## Students

* What was the problem?

  * `GetAllStudents()` created a list containing 1,000,000 students before the caller printed only the first three.
  * This caused unnecessary object creation and memory usage.

* What did you change?

  * Changed `GetAllStudents()` to return `IEnumerable<Student>` and use `yield return`.
  * Students are now created lazily, so stopping after three students creates only the first three.
