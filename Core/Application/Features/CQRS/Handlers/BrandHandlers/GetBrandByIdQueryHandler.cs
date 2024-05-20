using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetBrandByIdQueryResult
            {
                BrandID = values.BrandID,
                BrandName = values.BrandName
            };
        }
    }
}
