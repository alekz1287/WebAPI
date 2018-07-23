using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using AutoMapper;
using HillmanGroup.API.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace HillmanGroup.API.Controllers
{
    //[Authorize]
    [Route("api/cities/")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        private Services.IMailService _mailService;
        private Services.ICityInfoRepository _cityInfoRepository;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, Services.IMailService mailService, Services.ICityInfoRepository cityInfoRepository)
        {
            _logger = logger;
            _mailService = mailService;
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {

                if (!_cityInfoRepository.CityExists(cityId))
                {
                    _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
                    return NotFound();
                }

                var pointsOfInterest = _cityInfoRepository.GetPointsOfInterestForCity(cityId);
                var poiResults = Mapper.Map<IEnumerable<Models.PointOfInterestDTO>>(pointsOfInterest);

                return Ok(poiResults);
            }
            catch (Exception ex) 
            {
                _logger.LogCritical($"Exception while getting poi for city {cityId}", ex);

                return StatusCode(500, "A problem happened while handling your request.");//Do not expose implementation details (stack trace etc).
            }
            
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var poi = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if(poi == null)
            {
                return NotFound();
            }

            var result = Mapper.Map<Models.PointOfInterestDTO>(poi);

            return Ok(result);
        }


        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] Models.PointOfInterestForCreationDTO pointOfInterest)
        {
            //The user's input cannot be serialized
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            PointOfInterestForCreationDTO_Validator validator = new PointOfInterestForCreationDTO_Validator();
            ValidationResult result = validator.Validate(pointOfInterest);
            //The users' input violates the validation rules on the Model
            if (!result.IsValid)
            {
                return BadRequest(result.ToString());
            }

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound($"cityId: {cityId} does not exist.");
            }


            var newPointOfInterest = Mapper.Map<Entities.PointOfInterest>(pointOfInterest);
            _cityInfoRepository.AddPointOfInterestForCity(cityId, newPointOfInterest);

            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "Cannot Save");
            }

            var createdPointOfInterestToReturn = Mapper.Map<Models.PointOfInterestDTO>(newPointOfInterest);

            //201 - Create, returns uri at which the new object can be found
            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = newPointOfInterest.Id }, createdPointOfInterestToReturn); 
        }

        /// <summary>
        /// PUT should fully update the resource, meaning it must provide values for each field of the resource
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="id"></param>
        /// <param name="pointOfInterest"></param>
        /// <returns></returns>
        [HttpPut("{cityId}/pointsofinterest/{id}")] 
        public IActionResult UpdatePointOfInterest(int cityId, int id, 
            [FromBody] Models.PointOfInterestForUpdateDTO pointOfInterest)
        {
            if(pointOfInterest == null)
            {
                return BadRequest();
            }
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The name and description must be different");
            }

            //The users' input violates the validation rules on the Model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            if(!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);
            if(pointOfInterestEntity == null)
            {
                return NotFound();
            }

            //Automapper will update our db-connected entity. Then EF just needs to SAVE()
            Mapper.Map(pointOfInterest, pointOfInterestEntity); //1st Param is used overwrite the values in the 2nd Param

            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "Cannot Save");
            }


            return NoContent(); //204 - Request Completed successfully. No need to return any data as the client already has all of the information
        }

        /// <summary>
        /// 
        /// JSON Patch (RFC 6902)
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="id"></param>
        /// <param name="patchDoc">
        /// JSON Patch (RFC 6902) 
        /// Describes a sequence of operation to apply to a JSON document
        /// </param>
        /// <returns></returns>
        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<Models.PointOfInterestForUpdateDTO> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = Mapper.Map<Models.PointOfInterestForUpdateDTO>(pointOfInterestEntity);

            //Use the JSONPatch document to update the new DTO object
            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The name and description must be different");
            }

            TryValidateModel(pointOfInterestToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //The DTO is validated and updated
            //Now copy the values into the EF entity and save it
            Mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);

            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "Cannot Save");
            }

            return NoContent(); //204 - Request Completed successfully. No need to return any data as the client already has all of the information
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);

            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "Cannot Save");
            }

            _mailService.Send("Point of interest deleted", $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");

            return NoContent();
        }
    }
}
