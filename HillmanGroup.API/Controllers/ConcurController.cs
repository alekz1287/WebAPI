using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanGroup.API.Models.Concur;
using HillmanGroup.API.Models.Concur.FTP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HillmanGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcurController : ControllerBase
    {
        private Services.IConcurRepository _concurRepository;

        public ConcurController(Services.IConcurRepository concurRepository)
        {
            _concurRepository = concurRepository;
        }

        /// <summary>
        /// Create or Update a user in Concur using the Concur API
        /// </summary>
        /// <returns></returns>
        [HttpPost("Employees")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult ImportEmployees([FromBody]ConcurImportDataFile ftpFile)
        {
            try
            {
                _concurRepository.SendFtpFileToOutgoingDirectory(ftpFile);
                return NoContent(); //204 - Request Completed successfully. No need to return any data as the client already has all of the information
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns a collection of standard accounting extracts that are currently available in the INBOUND FTP folder
        /// </summary>
        /// <returns></returns>
        [HttpGet("StandardAccountingExtracts")]
        [ProducesResponseType(typeof(List<StandardAccountingExtract>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetStandardAccountingExtracts()
        {
            try
            {
                return Ok(_concurRepository.GetStandardAccountingExtracts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        


        /// <summary>
        /// Retrieves the "Edition Type" from Concur which is useful for determining what actions are available to us
        /// See: https://developer.concur.com/api-guides/expense/1create-a-user.html
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEditionType")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetEditionType()
        {
            try
            {
                return Ok(_concurRepository.GetEditionType());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
       
    }
}