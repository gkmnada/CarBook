using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Results.FeatureResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class ListFeatureQueryHandler : IRequestHandler<ListFeatureQuery, List<ListFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public ListFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<ListFeatureQueryResult>> Handle(ListFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();
            return values.Select(x => new ListFeatureQueryResult
            {
                FeatureID = x.FeatureID,
                FeatureName = x.FeatureName
            }).ToList();
        }
    }
}
