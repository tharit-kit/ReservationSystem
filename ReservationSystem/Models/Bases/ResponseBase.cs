using Microsoft.AspNetCore.Mvc;
using ReservationSystem.API.Utils;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.API.Models.Bases
{
    public abstract class ResponseBase
    {
        public string Code { get; set; }
        public string Description { get; set; }

        protected ResponseBase(string code)
        {
            Code = code;
            Description = ResponseCodes.GetDescription(code);
        }

        /*public static T Create<T>(string code) where T : ResponseBase, new()
        {
            var response = new T
            {
                Code = code,
                Description = ResponseCodes.GetDescription(code)
            };
            response.Value = response; // Set Value to the instance itself
            return response;
        }*/
    }
}
