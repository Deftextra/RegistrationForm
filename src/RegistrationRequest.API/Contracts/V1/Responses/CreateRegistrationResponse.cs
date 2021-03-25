﻿using RegistrationRequest.API.Contracts.V1.Common;
using RegistrationRequest.API.Domain.Models;

namespace RegistrationRequest.API.Contracts.V1.Responses
{
    public class CreateRegistrationResponse : BaseResponse
    {
        private CreateRegistrationResponse(bool success, string message, Registration registration) : base(success,
            message)
        {
            Registration = registration;
        }

        /// <summary>
        ///     Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CreateRegistrationResponse(Registration category) : this(true, string.Empty, category)
        {
        }

        /// <summary>
        ///     Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CreateRegistrationResponse(string message) : this(false, message, null)
        {
        }

        public Registration Registration { get; }
    }
}