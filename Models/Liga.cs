namespace equipas_mvc.Models
{
    public class Liga
    {
        public int Id { get; set; }
        public string? Equipa { get; set; }
        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public string? Cidade { get; set; }
    }
}
