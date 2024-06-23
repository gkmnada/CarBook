using Application.Features.Mediator.Queries.CarFeatureQueries;
using Application.Features.Mediator.Results.CarFeatureResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carFeatureRepository.ListCarFeatureByCarIdAsync(request.Id);

            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature.FeatureName,
                Available = x.Available
            }).ToList();
        }
    }
}
