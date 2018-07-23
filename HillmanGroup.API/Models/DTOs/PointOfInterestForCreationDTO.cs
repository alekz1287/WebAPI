using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace HillmanGroup.API.Models
{
    public class PointOfInterestForCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PointOfInterestForCreationDTO_Validator : AbstractValidator<PointOfInterestForCreationDTO>
    {
        public PointOfInterestForCreationDTO_Validator()
        {
            RuleFor(poi => poi.Name).NotNull().MaximumLength(50);
            RuleFor(poi => poi.Name).NotEqual(poi => poi.Description)
                .WithMessage(poi => $"Name: {poi.Name} and Description: {poi.Description} must be different");
            RuleFor(poi => poi.Description).MaximumLength(200);

        }
    }
}
