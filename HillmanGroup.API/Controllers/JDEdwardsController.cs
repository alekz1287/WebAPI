﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HillmanGroup.API.Controllers
{
    
    [Route("api/cities")]
    public class JDEdwardsController : Controller
    {
        private Services.ICityInfoRepository _cityRepository;

        public JDEdwardsController(Services.ICityInfoRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }


        [HttpGet("/F0101")]
        public IActionResult GetF0101(int numberOfRows = 2)
        {
            try
            {
                HillmanGroup.API.HillpyEntities.HILLPYContext repo = new HillmanGroup.API.HillpyEntities.HILLPYContext();
                var list = repo.F0101.Take(numberOfRows).ToList();

                return Ok(list);
            }catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        //[Authorize]
        //[HttpGet()]
        //public IActionResult GetCities()
        //{
        //    var cityEntities = _cityRepository.GetCities();            
        //    var results = Mapper.Map<IEnumerable<Models.CityWithoutPointsOfInterestDTO>>(cityEntities);//Tell Automapper to map each parameter to the matching DTO


        //    return Ok(results);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        //{
        //    var cityEntity = _cityRepository.GetCity(id, includePointsOfInterest);
        //    if(cityEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    if (includePointsOfInterest)
        //    {
        //        var cityResult = Mapper.Map<Models.CityDTO>(cityEntity);
        //        return Ok(cityResult);
        //    }
        //    else
        //    {
        //        var cityResult = Mapper.Map<Models.CityWithoutPointsOfInterestDTO>(cityEntity);
        //        return Ok(cityResult);
        //    }            
        //}
    }
}

