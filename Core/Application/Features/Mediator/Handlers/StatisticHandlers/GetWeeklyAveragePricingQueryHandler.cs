using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetWeeklyAveragePricingQueryHandler : IRequestHandler<GetWeeklyAveragePricingQuery, GetWeeklyAveragePricingQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetWeeklyAveragePricingQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetWeeklyAveragePricingQueryResult> Handle(GetWeeklyAveragePricingQuery request, CancellationToken cancellationToken)
        {
            var weeklyAveragePricing = await _statisticRepository.GetWeeklyAveragePricingAsync();
            return new GetWeeklyAveragePricingQueryResult
            {
                WeeklyAveragePricing = weeklyAveragePricing
            };
        }
    }
}
