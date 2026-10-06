using Collections;

Console.WriteLine("=== Egyptian Phone Validation ===");

Console.WriteLine($"01012345678 -> {"01012345678".IsValidEgyptianPhone()}");
Console.WriteLine($"+201512345678 -> {"+201512345678".IsValidEgyptianPhone()}");
Console.WriteLine($"01312345678 -> {"01312345678".IsValidEgyptianPhone()}");
Console.WriteLine($"0101234567 -> {"0101234567".IsValidEgyptianPhone()}");
Console.WriteLine($"0101234567a -> {"0101234567a".IsValidEgyptianPhone()}");

Console.WriteLine();
Console.WriteLine("=== Egyptian National ID Validation ===");

Console.WriteLine($"29901011234567 -> {"29901011234567".IsValidEgyptianNationalId()}");
Console.WriteLine($"19901011234567 -> {"19901011234567".IsValidEgyptianNationalId()}");
Console.WriteLine($"2990101123456 -> {"2990101123456".IsValidEgyptianNationalId()}");

Console.WriteLine();
Console.WriteLine("=== Null / Empty / Spaces ===");

Console.WriteLine($"null phone -> {((string?)null).IsValidEgyptianPhone()}");
Console.WriteLine($"empty phone -> {"".IsValidEgyptianPhone()}");
Console.WriteLine($"spaces phone -> {"   ".IsValidEgyptianPhone()}");

Console.WriteLine($"null national ID -> {((string?)null).IsValidEgyptianNationalId()}");
Console.WriteLine($"empty national ID -> {"".IsValidEgyptianNationalId()}");
Console.WriteLine($"spaces national ID -> {"   ".IsValidEgyptianNationalId()}");
