using GeoCRON.Data;
using GeoCRON.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace GeoCRON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParserController : Controller
    {
        private readonly GeoDbContext _geoDbContext;

        public ParserController(GeoDbContext geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

       [HttpGet("GetGeoInfo/{ipAddress}")]
        public async Task<IActionResult> GetGeoInfo(string ipAddress)
        {
            try
            {
                // единственный IP
                bool isIpUnique = await _geoDbContext.GeoInfos
                    .AllAsync(g => g.Ip != ipAddress);

                if (!isIpUnique)
                {
                    return BadRequest("Same IP address, not saved.");
                }

                // Get данные по IP
                string apiUrl = $"https://ipinfo.io/{ipAddress}/geo";
                using (HttpClient client = new HttpClient())
                {
                    string jsonResponse = await client.GetStringAsync(apiUrl);
                    JObject data = JObject.Parse(jsonResponse);

                    GeoInfo geoData = new GeoInfo
                    {
                        IpLocal = Guid.NewGuid(),
                        Ip = ipAddress,
                        City = (string)data["city"],
                        Region = (string)data["region"],
                        Country = (string)data["country"],
                        Location = (string)data["loc"],
                        Organization = (string)data["org"],
                        Postal = (string)data["postal"],
                        Timezone = (string)data["timezone"],
                        Readme = (string)data["readme"]
                    };

                    // Save
                    _geoDbContext.GeoInfos.Add(geoData);
                    await _geoDbContext.SaveChangesAsync();

                    return Ok(geoData);
                }
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}