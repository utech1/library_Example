using Application.Features.Books.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries.GetList;

public class GetListBookQuery : IRequest<GetListResponse<GetListBookListItemDto>>, ICachableRequest, ILoggableRequest
{

    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListBookQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool BypassCache { get; }
    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetBooks";

    public class GetListBookQueryHandler : IRequestHandler<GetListBookQuery, GetListResponse<GetListBookListItemDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetListBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBookListItemDto>> Handle(GetListBookQuery request, CancellationToken cancellationToken)
        {
            Paginate<Book> books = await _bookRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
                );

            GetListResponse<GetListBookListItemDto> response = _mapper.Map<GetListResponse<GetListBookListItemDto>>(books);
            return response;

        }
    }
}
