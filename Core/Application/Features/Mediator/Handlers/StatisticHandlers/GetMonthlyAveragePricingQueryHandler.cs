using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetMonthlyAveragePricingQueryHandler : IRequestHandler<GetMonthlyAveragePricingQuery, GetMonthlyAveragePricingQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetMonthlyAveragePricingQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetMonthlyAveragePricingQueryResult> Handle(GetMonthlyAveragePricingQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetMonthlyAveragePricingAsync();
            return new GetMonthlyAveragePricingQueryResult
            {
                MonthlyAveragePricing = value
            };
        }
    }
}
