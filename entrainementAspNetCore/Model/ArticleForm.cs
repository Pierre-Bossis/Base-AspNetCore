namespace entrainementAspNetCore.Model
{
    public class ArticleForm
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
        public decimal Poids { get; set; }
        public decimal? Taille { get; set; }
        public string Provenance { get; set; }
        public string Fournisseur { get; set; }
        public string MotsCles { get; set; }

    }
}
