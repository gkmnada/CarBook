using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutQueryResult> Handle(GetAboutQuery query)
        {
            var values = await _repository.GetAsync(query.Id);
            return new GetAboutQueryResult
            {
                AboutID = values.AboutID,
                Title = values.Title,
                Description = values.Description,
                Image = values.Image
            };
        }
    }
}
