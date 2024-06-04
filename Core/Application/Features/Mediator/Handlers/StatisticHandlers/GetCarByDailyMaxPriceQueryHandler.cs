using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarByDailyMaxPriceQueryHandler : IRequestHandler<GetCarByDailyMaxPriceQuery, GetCarByDailyMaxPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarByDailyMaxPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarByDailyMaxPriceQueryResult> Handle(GetCarByDailyMaxPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarByDailyMaxPriceAsync();
            return new GetCarByDailyMaxPriceQueryResult
            {
                CarName = value
            };
        }
    }
}
