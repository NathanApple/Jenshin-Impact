using System;
using System.Reflection;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Jenshin.Impack.API.Model;
using Jenshin.Impack.API.Output;

using Binus.WS.Pattern.Output;
using Binus.WS.Pattern.Service;
using Jenshin.Impack.API.Model.Request;

namespace Jenshin.Impack.API.Services
{
    [ApiController]
    [Route("purchase")]
    public class PurchaseService : BaseService
    {
        public PurchaseService(ILogger<BaseService> logger) : base(logger)
        {
        }

        /// <summary>
        /// Purchase Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /purchase
        ///
        /// </remarks>
        /// <returns>Success</returns>
        /// <response code="200">Returns success if item is successfully purchased</response>
        /// 
        /// SOAL NOMOR 6 - Purchase Item
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ItemOutput), StatusCodes.Status200OK)]
        public IActionResult PurchaseItem([FromBody] PurchaseRequestDTO data)
        {
            try
            {
                // -- MODIFY THIS TO YOUR OWN STUDENT ID (NIM) !! -- //
                var authorization = Request.Headers["authorization"];
                var NIM = "2540120521";
                if (authorization != "Basic " + NIM)
                {
                    return StatusCode(500, new OutputBase(new Exception("Invalid Credential")));
                }

                var objJSON = new TopUpOutput();
                objJSON.Message = Helper.PurchaseHelper.PurchaseItem(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }
    }
}