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

namespace Jenshin.Impack.API.Services
{
    [ApiController]
    [Route("item")]
    public class ItemService : BaseService
    {
        public ItemService(ILogger<BaseService> logger) : base(logger)
        {
        }

        /// <summary>
        /// Add New Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /item
        ///
        /// </remarks>
        /// <returns>Success</returns>
        /// <response code="200">Returns success if item is successfully added</response>
        /// 
        /// SOAL NOMOR 3 - Add New Item
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ItemOutput), StatusCodes.Status200OK)]
        public IActionResult AddNewItem([FromBody] MsShopItem data)
        {
            try
            {
                var objJSON = new ItemOutput();
                objJSON.Success = Helper.ItemHelper.AddNewItem(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }

        /// <summary>
        /// Update Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /item
        ///
        /// </remarks>
        /// <returns>Success</returns>
        /// <response code="200">Returns success if item is successfully updated</response>
        /// 
        /// SOAL NOMOR 4 - Update Item
        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ItemOutput), StatusCodes.Status200OK)]
        public IActionResult UpdateItem([FromBody] MsShopItem data)
        {
            try
            {
                var objJSON = new ItemOutput();
                objJSON.Success = Helper.ItemHelper.UpdateItem(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                if (ex.Message == "EmptyArgument")
                {
                    return StatusCode(404, new OutputBaseWithMessage(404, new Exception("ID Must be provided")));
                }
                return StatusCode(500, new OutputBase(ex));
            }
        }
    }
}