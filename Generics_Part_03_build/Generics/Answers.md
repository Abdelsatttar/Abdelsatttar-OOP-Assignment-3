# Part 03 — Generics

## Step 2 — StudentStore vs CourseStore

### What is the same?

Both stores keep objects in a `List<T>` and expose the same four operations: `Add`, `GetById`, `GetAll`, and `Remove`.

### What is different?

`StudentStore` works only with `Student` objects, while `CourseStore` works only with `Course` objects. The `Student` class has `Id` and `Name`; the `Course` class has `Id`, `Title`, and `Price`.

---

## Step 3 — Why GetById does not compile

In Step 3, the stores were replaced by one generic class `Store<T>`. `T` represents an unknown type, so the compiler cannot assume that an object of type `T` has an `Id` property.

A typical compiler error is:

```text
'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)
```

In simple words, the compiler is saying: **you told me that T can be any type, but you are using an Id property that may not exist on every type.**

---

## Step 7 — Proof

The program creates one `Store<Student>` with 5 students and one `Store<Course>` with 3 courses. It retrieves one student and one course by Id.

It then tries to add another student with an Id that already exists. `Store<T>` throws an `InvalidOperationException`, and `Main` catches it and prints the clear message.

The program prints page 2 with a page size of 2. With five students, page 2 contains students 3 and 4.

It also calls `FindById` on a normal `List<Course>` to show that the generic extension method works with any `IEnumerable<T>` where `T` implements `IHasId`.

This line is intentionally commented out:

```csharp
// var strings = new Store<string>(); // must NOT compile
```

It must not compile because `Store<T>` has the constraint `where T : IHasId`, while `string` does not implement `IHasId`.

---

## Last question — Common name

The common name for the kind of class built in Steps 4 and 5 is a **Generic Repository** (using the Repository pattern). A repository provides collection-like operations over domain objects, and a generic repository can serve multiple entity types through one reusable class. Microsoft documents generic repository types as a way to reduce the number of concrete repository classes that need to be maintained. citeturn125091search0turn125091search5
