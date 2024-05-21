﻿using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetAsync(query.Id);

            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Email = values.Email,
                Subject = values.Subject,
                Message = values.Message,
                CreatedAt = values.CreatedAt
            };
        }
    }
}
