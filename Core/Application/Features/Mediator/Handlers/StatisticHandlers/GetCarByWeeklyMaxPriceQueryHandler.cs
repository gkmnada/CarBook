using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarByWeeklyMaxPriceQueryHandler : IRequestHandler<GetCarByWeeklyMaxPriceQuery, GetCarByWeeklyMaxPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarByWeeklyMaxPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarByWeeklyMaxPriceQueryResult> Handle(GetCarByWeeklyMaxPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarByWeeklyMaxPriceAsync();
            return new GetCarByWeeklyMaxPriceQueryResult
            {
                CarName = value
            };
        }
    }
}
