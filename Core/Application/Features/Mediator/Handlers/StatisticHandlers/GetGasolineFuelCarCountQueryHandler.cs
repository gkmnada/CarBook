using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetGasolineFuelCarCountQueryHandler : IRequestHandler<GetGasolineFuelCarCountQuery, GetGasolineFuelCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetGasolineFuelCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetGasolineFuelCarCountQueryResult> Handle(GetGasolineFuelCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetGasolineFuelCarCountAsync();
            return new GetGasolineFuelCarCountQueryResult
            {
                GasolineFuelCarCount = value
            };
        }
    }
}
