using AutoMapper;
using LibreriaAPI.CustomActionFilters;
using LibreriaAPI.Models.Domain;
using LibreriaAPI.Models.Dto.Categorie;
using LibreriaAPI.Models.Dto.Marchio;
using LibreriaAPI.Repositories;
using LibreriaAPI.Repositories.MarchioRep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IMapper mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            this.categoriaRepository = categoriaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorieDomain = await categoriaRepository.GetAllAsync();

            return Ok(mapper.Map<List<CategoriaDto>>(categorieDomain));

        }
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var categorieDomain = await categoriaRepository.GetByIdAsync(id);

            if (categorieDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CategoriaDto>(categorieDomain));
        }

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> Create([FromBody] AddCategoria addCategoria)
        {
            
            var categorieDomain = mapper.Map<Categoria>(addCategoria);

            categorieDomain = await categoriaRepository.CreateAsync(categorieDomain);

            var marchiDto = mapper.Map<CategoriaDto>(categorieDomain);


            // return 201 -> 
            return CreatedAtAction(nameof(GetById), new { id = categorieDomain.Id }, marchiDto);
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]  UpdateCategoria updateCategoria)
        {
            var categorieDomain = new Categoria
            {
                Name = updateCategoria.Name,
                Code = updateCategoria.Code,
            };
            categorieDomain = await categoriaRepository.UpdateAsync(id, categorieDomain);

            if (categorieDomain == null)
            {
                return NotFound();
            }

            categorieDomain.Name = updateCategoria.Name;
            categorieDomain.Code = updateCategoria.Code;

            return Ok(mapper.Map<CategoriaDto>(categorieDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var categorieDomain = await categoriaRepository.DeleteAsync(id);

            if (categorieDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CategoriaDto>(categorieDomain));


        }

    }
}
