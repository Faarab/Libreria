using AutoMapper;
using LibreriaAPI.Models.Domain;
using LibreriaAPI.Models.Dto.Marchio;
using LibreriaAPI.Repositories.MarchioRep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarchiController : ControllerBase
    {
        
        private readonly IMarchioRepository marchioRepository;
        private readonly IMapper mapper;

        public MarchiController(IMarchioRepository marchioRepository, IMapper mapper)
        {
            this.marchioRepository = marchioRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marchiDomain = await marchioRepository.GetAllAsync();
           
            return Ok(mapper.Map<List<MarchioDto>>(marchiDomain));

        }
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var marchioDomain = await marchioRepository.GetByIdAsync(id);

            if (marchioDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MarchioDto>(marchioDomain));
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddMarchioDto addMarchioDto)
        {
            var marchioDomain = mapper.Map<Marchio>(addMarchioDto);

            marchioDomain= await marchioRepository.CreateAsync(marchioDomain);
            
            var marchiDto  = mapper.Map<MarchioDto>(marchioDomain);


            // return 201 -> 
            return CreatedAtAction(nameof(GetById), new { id = marchioDomain.Id }, marchiDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateMarchioDto updateMarchioDto)
        {
            var marchioDomain = new Marchio
            {
                Name = updateMarchioDto.Name,
                Code = updateMarchioDto.Code,
            };
            marchioDomain = await marchioRepository.UpdateAsync(id, marchioDomain);

            if (marchioDomain == null)
            {
                return NotFound();
            }

            marchioDomain.Name = updateMarchioDto.Name;
            marchioDomain.Code = updateMarchioDto.Code;

            return Ok(mapper.Map<MarchioDto>(marchioDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {

            var marchioDomain = await marchioRepository.DeleteAsync(id);

            if (marchioDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MarchioDto>(marchioDomain));


        }

    }

}

