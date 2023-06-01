namespace LibreriaAPI.Models.Dto
{
    public class UpdateDocumento
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public int AnnoDiRilascio { get; set; }
        public string Icona { get; set; }

        public Guid CategoriaId { get; set; }
        public Guid MarchioId { get; set; }
        public Guid StatoId { get; set; }
        public Guid TipologiaId { get; set; }
        public Guid Tipologia { get; internal set; }
    }
}
