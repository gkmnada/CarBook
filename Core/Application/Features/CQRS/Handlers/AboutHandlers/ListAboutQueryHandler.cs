using Application.Features.CQRS.Results.AboutResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class ListAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public ListAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<ListAboutQueryResult>> Handle()
        {

            var values = await _repository.ListAsync();
            return values.Select(x => new ListAboutQueryResult
            {
                AboutID = x.AboutID,
                Title = x.Title,
                Description = x.Description,
                Image = x.Image,
            }).ToList();
        }
    }
}
