using System;

namespace FilmesApi.Data.DTOs
{
    public class FilmeResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public DateTime dataConsulta { get; set; }
    }
}