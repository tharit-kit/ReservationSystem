using System.ComponentModel;

namespace ReservationSystem.API.Utils
{
    public static class ResponseCodes
    {
        private static readonly Dictionary<string, string> Codes = new()
        {
            // S-type Code => Success
            { "S01", "Success" },
            // I-type Code => Information
            { "I01", "Email already registered" },
            { "I02", "User not found" },
            // W-type Code => Warning
            // E-type Code => Error
            { "E01", "System Error" },
        };

        public static string GetDescription(string code)
        {
            return Codes.TryGetValue(code, out var description) ? description : "Unknown code";
        }
    }
}
