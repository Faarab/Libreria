namespace LibreriaAPI.Models.Domain
{
    public class Documento
    {
        public Guid Id { get; set; }
       
        public string Title { get; set;}
        public string Link { get; set;}

        public int AnnoDiRilascio { get; set; }
        public string Icona { get; set;}

        public Guid CategoriaId { get; set;}
        public Guid MarchioId { get; set; }
        public Guid StatoId { get; set; }
        public Guid TipologiaId { get; set; }

        public Categoria  Categoria { get; set; }

        public Marchio  Marchio { get; set; }
        public Stato Stato{ get; set; }

        public Tipologia Tipologia { get; set; }


    }
}
