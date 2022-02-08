using System.Collections.Generic;
using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeRequest, Filme>();
            CreateMap<Filme, FilmeResponse>();
            CreateMap<IList<Filme>, IList<FilmeResponse>>();
        }
    }
}