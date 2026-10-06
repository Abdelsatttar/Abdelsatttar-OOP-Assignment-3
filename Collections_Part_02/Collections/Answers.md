# Part 02 — Collections

## Task 2.1 — Research: IReadOnlyDictionary & SortedDictionary

### IReadOnlyDictionary<TKey, TValue>

`IReadOnlyDictionary<TKey, TValue>` is an interface for reading key/value data. It lets the caller access values by key, check keys, read keys and values, and enumerate the entries, but it does not expose dictionary modification methods such as `Add`, `Remove`, or changing a value through the interface.

### IReadOnlyDictionary vs Dictionary

`Dictionary<TKey, TValue>` is a concrete collection that supports adding, updating, and removing items. `IReadOnlyDictionary<TKey, TValue>` exposes the read-only view needed by callers.

A public method can return `IReadOnlyDictionary` when the caller should only read the data. This hides modification operations from the public API and makes the intention of the method clearer.

### SortedDictionary<TKey, TValue>

`SortedDictionary<TKey, TValue>` is a dictionary that keeps its keys sorted according to its comparer. When the collection is enumerated, the entries appear in key order.

### SortedDictionary vs Dictionary

`Dictionary<TKey, TValue>` uses hashing and normally provides average `O(1)` lookup by key, but it is not intended to keep keys sorted.

`SortedDictionary<TKey, TValue>` keeps the keys ordered and provides `O(log n)` lookup. The extra ordering makes it useful when the application needs data to stay sorted while items are added or removed.

I would choose `Dictionary` when fast lookup is the main requirement. I would choose `SortedDictionary` when key order is part of the requirement, such as a timetable ordered by session start time.



## Task 2.2 — Pick the Collection

### S1 — Find a student by national ID — thousands of times a day

**Collection:** `Dictionary`

A `Dictionary` is the best choice because the national ID can be used as a key and lookup is normally very fast.

### S2 — Keep the tags of a course. The same tag must never be stored twice.

**Collection:** `HashSet`

A `HashSet` is the best choice because it stores unique values and does not allow the same tag to be stored twice.

### S3 — Keep a student's grades in the order they were entered. The same grade can appear more than once.

**Collection:** `List`

A `List` is the best choice because it keeps insertion order and allows duplicate values.

### S4 — A public method returns the course price list. Callers can read prices but must not add or change any.

**Collection:** `IReadOnlyDictionary`

`IReadOnlyDictionary` is the best choice because callers can read the prices by key without receiving the normal dictionary modification operations.

### S5 — A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.

**Collection:** `SortedDictionary`

A `SortedDictionary` is the best choice because the session start times remain sorted automatically, so enumeration prints them in time order.

### S6 — A method returns results that the caller only loops over once — and may stop early.

**Collection:** `IEnumerable`

`IEnumerable` is the best choice because the caller can iterate through the results and stop as soon as it has what it needs.

---

## Task 2.3 — Extension Methods With Regular Expressions

### `IsValidEgyptianPhone()`

The method accepts:

- `010`, `011`, `012`, or `015` followed by 8 digits.
- The same mobile number with `+20` instead of the leading `0`.
- Null, empty, and whitespace strings return `false`.

The method uses one regular expression and does not loop over characters.

### `IsValidEgyptianNationalId()`

The method accepts exactly 14 digits and requires the first digit to be `2` or `3`.

The method uses one regular expression and does not loop over characters.

### Expected output

```text
=== Egyptian Phone Validation ===
01012345678 -> True
+201512345678 -> True
01312345678 -> False
0101234567 -> False
0101234567a -> False

=== Egyptian National ID Validation ===
29901011234567 -> True
19901011234567 -> False
2990101123456 -> False

=== Null / Empty / Spaces ===
null phone -> False
empty phone -> False
spaces phone -> False
null national ID -> False
empty national ID -> False
spaces national ID -> False
```
