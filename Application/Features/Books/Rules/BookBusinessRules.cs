using Application.Features.Books.Constants;

using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Rules;

public class BookBusinessRules:BaseBusinessRules
{
    private readonly IBookRepository _bookRepository;

    public BookBusinessRules(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task BookNameCannotBeDuplicatedWhenInserted(string name)
    {
        Book? result = await _bookRepository.GetAsync(predicate: b=>b.BookName.ToLower()==name.ToLower());

        if (result!=null)
        {
            throw new BusinessException(BooksMessages.BooksNameExists);
        }
    }
}
