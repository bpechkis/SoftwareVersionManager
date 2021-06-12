using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareVersionManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareVersionManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        public ActionResult<IEnumerable<SoftwareViewModel>> Get(string versionsOlderThan)
        {
            // Chose not to filter the list? Return them all
            if (String.IsNullOrEmpty(versionsOlderThan))
                return SoftwareManager.GetAllSoftware().Select(s => new SoftwareViewModel { Name = s.Name, Version = s.Version }).ToList();

            var versionToFilterBy = new SoftwareVersion(0, 0, 0);
            try
            {
                versionToFilterBy = new SoftwareVersion(versionsOlderThan);
            }
            catch (ArgumentException exp)
            {
                return BadRequest(exp.Message);
            }

            var softwaresToReturn = SoftwareManager
                                       .GetAllSoftware()
                                       .Where(s => s.ParsedVersion.IsGreaterThan(versionToFilterBy))
                                       .Select(s => new SoftwareViewModel { Name = s.Name, Version = s.Version });

            return Ok(softwaresToReturn);

        }
    }
}
