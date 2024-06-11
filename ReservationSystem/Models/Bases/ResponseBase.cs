using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Utils;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Models.Bases
{
    public abstract class ResponseBase : ObjectResult
    {
        public string Code { get; set; }
        public string Description { get; set; }

        protected ResponseBase(string code) : base(null)
        {
            Code = code;
            Description = ResponseCodes.GetDescription(code);
            Value = new { Code = code, Description = Description };
        }

        public static T Create<T>(string code) where T : ResponseBase, new()
        {
            return new T { Code = code, Description = ResponseCodes.GetDescription(code), Value = new { Code = code, Description = ResponseCodes.GetDescription(code) } };
        }
    }
}
