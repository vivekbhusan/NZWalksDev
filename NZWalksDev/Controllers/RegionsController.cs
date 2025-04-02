using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksDev.Data;
using NZWalksDev.Models.Domain;
using NZWalksDev.Models.DTO;

namespace NZWalksDev.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly NZWalksDBContext dbContext;
        public RegionsController(NZWalksDBContext _dbContext) { 
            this.dbContext = _dbContext;
        }
     
        [HttpGet]
        public IActionResult GetAll()
        {
            var regionsDomain = dbContext.Regions.ToList();

            //Map Domain Models to Dtos

            var regionDtos = new List<RegionDto>();
            foreach (var region in regionsDomain)
            {
                regionDtos.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

           // return Dtos

            return Ok(regionDtos);
        }
        [HttpGet]
        [Route("{Id:guid}")]
        public IActionResult GetRegionById([FromRoute] Guid Id)
        {
           // var regions = dbContext.Regions.Find(Id);

            var regionsDomain = dbContext.Regions.FirstOrDefault(r => r.Id == Id);
            if(regionsDomain == null)
            {
                return NotFound();
            }
            //Map Domain Model to Dtos
            var regionDtos = new RegionDto
            {
                Id = regionsDomain.Id,
                Name = regionsDomain.Name,
                Code = regionsDomain.Code,
                RegionImageUrl = regionsDomain.RegionImageUrl
            };
            
            return Ok(regionsDomain);
        }
        //This will be a POST to Create a new Region

        [HttpPost]
        public IActionResult CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert DTO to DOmain Model

            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //use Domain model to create Region

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionDtos = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDtos.Id }, regionDtos);
        }
    }
}
