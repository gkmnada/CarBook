using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetDailyAveragePricingQueryHandler : IRequestHandler<GetDailyAveragePricingQuery, GetDailyAveragePricingQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetDailyAveragePricingQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetDailyAveragePricingQueryResult> Handle(GetDailyAveragePricingQuery request, CancellationToken cancellationToken)
        {
            var dailyAveragePricing = await _statisticRepository.GetDailyAveragePricingAsync();
            return new GetDailyAveragePricingQueryResult
            {
                DailyAveragePricing = dailyAveragePricing
            };
        }
    }
}
