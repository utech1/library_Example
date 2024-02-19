using Application.Features.Books.Rules;

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Commands.Create;

public class CreateBookCommand:IRequest<CreatedBookResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string BookName { get; set; }
    public string BookAuthor { get; set; }
    public DateTime PublishDate { get; set; }
    public string BookImage { get; set; }
    public string BookTitle { get; set; }
    public string BookDescription { get; set; }
    public string PublishHouse { get; set; }
    public int BookStatus { get; set; } = 1;
    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBooks";

   public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreatedBookResponse>
    {
        private readonly IBookRepository _booksRepository;
        private readonly IMapper _mapper;
        private readonly BookBusinessRules _bookBusinessRules;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules bookBusinessRules)
        {
            _booksRepository = bookRepository;
            _mapper = mapper;
            _bookBusinessRules = bookBusinessRules;
        }

        public async Task<CreatedBookResponse>? Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            await _bookBusinessRules.BookNameCannotBeDuplicatedWhenInserted(request.BookName);

            Book book = _mapper.Map<Book>(request);
            book.Id = Guid.NewGuid();            

            await _booksRepository.AddAsync(book);          

            CreatedBookResponse createdBrandResponse = _mapper.Map<CreatedBookResponse>(book);
            return createdBrandResponse;
        }
    }
}
