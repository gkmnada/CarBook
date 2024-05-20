using Application.Features.CQRS.Results.BrandResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                BrandName = x.BrandName,
            }).ToList();
        }
    }
}
