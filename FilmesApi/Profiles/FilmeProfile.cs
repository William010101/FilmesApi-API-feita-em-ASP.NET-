﻿namespace FilmesApi.Profiles;
using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
    }
}
