using AutoMapper;
using LibreriaAPI.Models.Domain;
using LibreriaAPI.Models.Dto;
using LibreriaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDocumentoRepository documentoRepository;

        public DocumentoController(IMapper mapper, IDocumentoRepository documentoRepository)
        {
            this.mapper = mapper;
            this.documentoRepository = documentoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDocumento addDocumento)
        {
            var documentoDomain = mapper.Map<Documento>(addDocumento);
            await documentoRepository.CreateAsync(documentoDomain);
            return Ok(mapper.Map<DocumentoDto>(documentoDomain));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentoDomain = await documentoRepository.GetAllAsync();
            return Ok(mapper.Map<List<DocumentoDto>>(documentoDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var documentoDomain = await documentoRepository.GetByIdAsync(id);
            if (documentoDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DocumentoDto>(documentoDomain));
        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var documentoDomain = await documentoRepository.GetByIdAsync(id);
            if (documentoDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DocumentoDto>(documentoDomain));
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDocumento updateDocumento)
        {
            var documentoDomain = await documentoRepository.GetByIdAsync(id);
            if (documentoDomain == null)
            {
                return NotFound();
            }

            documentoDomain.AnnoDiRilascio = updateDocumento.AnnoDiRilascio;
            documentoDomain.StatoId = updateDocumento.StatoId;
            documentoDomain.MarchioId = updateDocumento.MarchioId;
            documentoDomain.CategoriaId = updateDocumento.CategoriaId;
            documentoDomain.Title = updateDocumento.Title;
            documentoDomain.Link = updateDocumento.Link;
            documentoDomain.Icona = updateDocumento.Icona;
            documentoDomain.TipologiaId = updateDocumento.Tipologia;

            return Ok(mapper.Map<DocumentoDto>(documentoDomain));
        }

    }
}
