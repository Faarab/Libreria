using AutoMapper;
using LibreriaAPI.Models.Domain;
using LibreriaAPI.Models.Dto.Stato;
using LibreriaAPI.Repositories;
using LibreriaAPI.Repositories.StatoRep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatiController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IStatoRepository statoRepository;

        public StatiController(IMapper mapper, IStatoRepository statoRepository) {
            this.mapper = mapper;
            this.statoRepository = statoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statiDomain = await statoRepository.GetAllAsync();

            return Ok(mapper.Map<List<StatoDto>>(statiDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var statoDomain = await statoRepository.GetByIdAsync(id);

            if (statoDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StatoDto>(statoDomain));
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddStato addStato)
        {
            var statoDomain = mapper.Map<Stato>(addStato);

            statoDomain = await statoRepository.CreateAsync(statoDomain);

            var marchiDto = mapper.Map<StatoDto>(statoDomain);


            // return 201 -> 
            return CreatedAtAction(nameof(GetById), new { id = statoDomain.Id }, marchiDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStato updateStato)
        {
            var statoDomain = new Stato
            {
                Descrizione = updateStato.Descrizione,
                Code = updateStato.Code,
            };
            statoDomain = await statoRepository.UpdateAsync(id, statoDomain);

            if (statoDomain == null)
            {
                return NotFound();
            }

            statoDomain.Descrizione = updateStato.Descrizione;
            statoDomain.Code = updateStato.Code;

            return Ok(mapper.Map<StatoDto>(statoDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var statoDomain = await statoRepository.DeleteAsync(id);

            if (statoDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StatoDto>(statoDomain));


        }
    }
}
