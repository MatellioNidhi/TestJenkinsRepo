using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using Operation = Swashbuckle.AspNetCore.Swagger.Operation;

namespace VehicleMaintenceService.API.Helpers.Filters
{
    internal class NumericExample : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var buffer = new byte[125];
            var randomizer = new Random();
            var successResponse = operation.Responses["200"];
            randomizer.NextBytes(buffer);
            successResponse.Examples = new Dictionary<string, object>()
            {
                { "text/plain", 12345 }
            };
        }
    }
}
