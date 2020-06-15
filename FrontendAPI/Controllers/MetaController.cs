﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrontendAPI.Controllers
{
    
    [Route("api/meta")]
    public class MetaController : Controller
    {
        private ILogger<MetaController> Logger { get; }

        public MetaController(ILogger<MetaController> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Unprotected API for readyness checks
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     GET /ready 
        /// </remarks>
        /// <response code="200">Nothing more</response>
        [HttpGet]
        [Route("ready")]
        public IActionResult IsReady()
        {
            try
            {
                Logger.LogDebug("IsReady invoked");

                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { exception.Message, exception.StackTrace });
            }
        }

        /// <summary>
        /// Unprotected API for health checks
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     GET /healthy 
        /// </remarks>
        /// <response code="200">Nothing more</response>
        [HttpGet]
        [Route("healthy")]
        public IActionResult IsHealthy()
        {
            try
            {
                Logger.LogDebug("IsHealthy invoked");
                return Ok();
            }
            catch (Exception exception)
            {
                return StatusCode(500, new { exception.Message, exception.StackTrace });
            }
        }
    }
}