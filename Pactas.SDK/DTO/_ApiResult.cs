using System;

namespace Pactas.SDK.DTO
{
    public class ApiResult
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Additional, optional complex object
        /// </summary>
        public object Details { get; set; }
    }
}
