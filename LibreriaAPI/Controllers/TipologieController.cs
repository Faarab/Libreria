using AutoMapper;
using LibreriaAPI.Models.Domain;
using LibreriaAPI.Models.Dto.Marchio;
using LibreriaAPI.Models.Dto.Tipologia;
using LibreriaAPI.Repositories;
using LibreriaAPI.Repositories.MarchioRep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipologieController : ControllerBase
    {
        private readonly ITipologiaRepository tipologiaRepository;
        private readonly IMapper mapper;

        public TipologieController(ITipologiaRepository tipologiaRepository, IMapper mapper)
        {
            this.tipologiaRepository = tipologiaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipologieDomain = await tipologiaRepository.GetAllAsync();

            return Ok(mapper.Map<List<TipologiaDto>>(tipologieDomain));

        }
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var tipologieDomain = await tipologiaRepository.GetByIdAsync(id);

            if (tipologieDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MarchioDto>(tipologieDomain));
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddTipologia addTipologia)
        {
            var tipologieDomain = mapper.Map<Tipologia>(addTipologia);

            tipologieDomain = await tipologiaRepository.CreateAsync(tipologieDomain);

            var tipologieDto = mapper.Map<TipologiaDto>(tipologieDomain);


            // return 201 -> 
            return CreatedAtAction(nameof(GetById), new { id = tipologieDomain.Id }, tipologieDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMarchioDto updateMarchioDto)
        {
            var tipologieDomain = new Tipologia
            {
                Name = updateMarchioDto.Name,
                Code = updateMarchioDto.Code,
            };
            tipologieDomain = await tipologiaRepository.UpdateAsync(id, tipologieDomain);

            if (tipologieDomain == null)
            {
                return NotFound();
            }

            tipologieDomain.Name = updateMarchioDto.Name;
            tipologieDomain.Code = updateMarchioDto.Code;

            return Ok(mapper.Map<TipologiaDto>(tipologieDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var tipologieDomain = await tipologiaRepository.DeleteAsync(id);

            if (tipologieDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TipologiaDto>(tipologieDomain));


        }
    }
}
