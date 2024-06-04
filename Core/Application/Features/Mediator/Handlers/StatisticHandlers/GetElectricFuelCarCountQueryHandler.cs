using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetElectricFuelCarCountQueryHandler : IRequestHandler<GetElectricFuelCarCountQuery, GetElectricFuelCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetElectricFuelCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetElectricFuelCarCountQueryResult> Handle(GetElectricFuelCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetElectricFuelCarCountAsync();
            return new GetElectricFuelCarCountQueryResult
            {
                ElectricFuelCarCount = value
            };
        }
    }
}
