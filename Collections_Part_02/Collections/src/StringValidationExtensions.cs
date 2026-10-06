using System.Text.RegularExpressions;

namespace Collections;

public static class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string? phone)
    {
        const string pattern = @"^(?:01[0125]\d{8}|\+20(?:10|11|12|15)\d{8})$";

        if (string.IsNullOrWhiteSpace(phone))
            return false;

        return Regex.IsMatch(phone, pattern);
    }

    public static bool IsValidEgyptianNationalId(this string? nationalId)
    {
        const string pattern = @"^[23]\d{13}$";

        if (string.IsNullOrWhiteSpace(nationalId))
            return false;

        return Regex.IsMatch(nationalId, pattern);
    }
}
