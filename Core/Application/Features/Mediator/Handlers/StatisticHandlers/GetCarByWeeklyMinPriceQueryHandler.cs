using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarByWeeklyMinPriceQueryHandler : IRequestHandler<GetCarByWeeklyMinPriceQuery, GetCarByWeeklyMinPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarByWeeklyMinPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarByWeeklyMinPriceQueryResult> Handle(GetCarByWeeklyMinPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarByWeeklyMinPriceAsync();
            return new GetCarByWeeklyMinPriceQueryResult
            {
                CarName = value
            };
        }
    }
}
