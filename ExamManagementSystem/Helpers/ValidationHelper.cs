using System;
using System.Text.RegularExpressions;

namespace ExamManagementSystem.Helpers
{
    public static class ValidationHelper
    {
        // Check if a string is a positive number
        public static bool IsPositiveNumber(string input)
        {
            return double.TryParse(input, out double value) && value > 0;
        }

        // Check if input is alphabetic (allows spaces optionally)
        public static bool IsAlphabetic(string input, bool allowSpaces = true)
        {
            string pattern = allowSpaces ? @"^[a-zA-Z\s]+$" : @"^[a-zA-Z]+$";
            return Regex.IsMatch(input, pattern);
        }

        // Validate password strength (min 8 chars, 1 upper, 1 lower, 1 digit, 1 special char)
        public static bool IsValidPassword(string input)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(input, pattern);
        }

        // Validate login username (only alphanumeric, no spaces)
        public static bool IsValidUsername(string input)
        {
            string pattern = @"^[a-zA-Z0-9]{4,20}$";
            return Regex.IsMatch(input, pattern);
        }

        // Validate CNIC (13 digits)
        public static bool IsValidCNIC(string input)
        {
            return Regex.IsMatch(input, @"^\d{13}$");
        }

        // Check if field is required (non-null and non-empty)
        public static bool IsRequired(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Check if string has only digits (alternative to IsNumeric for strict digit check)
        public static bool IsDigitsOnly(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        public static bool IsValidTime12Hour(string input)
        {
            return DateTime.TryParseExact(
                input,
                new[] { "h:mm tt", "hh:mm tt", "h:mmtt", "hh:mmtt" },
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
        }
    }
}
