using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Enums;

namespace GerenciadorDeLivraria.Helper
{
    public static class ApiResponseHelper
    {
        public static ApiResponse<T> CreateResponse<T>(T? data, StatusCode statusCode, string message = null)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Success = (int)statusCode>= 200 && (int)statusCode < 300,
                StatusCode = (int)statusCode,
                Message = message
            };
        }

        public static ApiResponse<T> CreateErrorResponse<T>(List<string> errors, StatusCode statusCode)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = (int)statusCode,
                Errors = errors
            };
        }

        internal static ApiResponse CreateResponse<T>(ApiResponse apiResponse, StatusCode created)
        {
            throw new NotImplementedException();
        }
    }
}
