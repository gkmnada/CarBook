using MediatR;
using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Results.FeatureResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.OrderBy(x => x.FeatureName).Select(x => new GetFeatureQueryResult
            {
                FeatureID = x.FeatureID,
                FeatureName = x.FeatureName
            }).ToList();
        }
    }
}
