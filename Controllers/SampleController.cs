using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching","test"
        };

        public int publicVariable;
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/SecurityIssueOnUseRandom")]
        public IEnumerable<SampleModel> GetSecurityIssueOnUseRandom()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new SampleModel
            {
                Date = DateTime.Now.AddDays(index),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/BugOnNullPath")]
        public SampleModel GetBugOnNullPath()
        {
            SampleModel sampleModel = null;
            sampleModel.Date = DateTime.Now;
            return sampleModel;
        }

        [HttpGet("/BugOnAlwaysEvaluateToFalse")]
        public IActionResult GetBugOnAlwaysEvaluateToFalse()
        {
            var alwaysFalse = false;

            if (alwaysFalse)
                alwaysFalse = true;

            return Ok();
        }
    }
}
