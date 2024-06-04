using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarByDailyMinPriceQueryHandler : IRequestHandler<GetCarByDailyMinPriceQuery, GetCarByDailyMinPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarByDailyMinPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarByDailyMinPriceQueryResult> Handle(GetCarByDailyMinPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarByDailyMinPriceAsync();
            return new GetCarByDailyMinPriceQueryResult
            {
                CarName = value
            };
        }
    }
}
