using Application.Features.Books.Commands.Create;
//using Application.Features.Books.Commands.Delete;
using Application.Features.Books.Commands.Update;
//using Application.Features.Books.Queries.GetById;
using Application.Features.Books.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Book, CreateBookCommand>().ReverseMap();
        CreateMap<Book, CreatedBookResponse>().ReverseMap();

        CreateMap<Book, UpdateBookCommand>().ReverseMap();
        CreateMap<Book, UpdatedBookResponse>().ReverseMap();

        //CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        //CreateMap<Brand, DeletedBrandResponse>().ReverseMap();

        CreateMap<Book, GetListBookListItemDto>().ReverseMap();
        //CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
        CreateMap<Paginate<Book>, GetListResponse<GetListBookListItemDto>>().ReverseMap();
    }
}
