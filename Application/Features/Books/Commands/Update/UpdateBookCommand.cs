using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Update;

public class UpdateBookCommand : IRequest<UpdatedBookResponse>, ICacheRemoverRequest 
{
    public Guid Id { get; set; }
  
    public string BookBarrowNameSurname { get; set; }
    public DateTime BookReturnDate { get; set; }
    public DateTime BookLendDate { get; set; }
    public int BookStatus { get; set; }

  

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBooks";

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdatedBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await _bookRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            book = _mapper.Map(request, book);

            await _bookRepository.UpdateAsync(book);

            UpdatedBookResponse response = _mapper.Map<UpdatedBookResponse>(book);

            return response;
        }
    }
}
