using System.ComponentModel;

namespace ReservationSystem.Utils
{
    public static class ResponseCodes
    {
        private static readonly Dictionary<string, string> Codes = new()
        {
            // S-type Code => Success
            { "S01", "Success" },
            { "I01", "Email already registered" },
            { "I02", "User not found" },
            { "E01", "System Error" },
            // Add more codes and descriptions as needed
            // I-type Code => Information
            // W-type Code => Warning
            // E-type Code => Error
        };

        public static string GetDescription(string code)
        {
            return Codes.TryGetValue(code, out var description) ? description : "Unknown code";
        }
    }
}
