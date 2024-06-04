using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarByMonthlyMaxPriceQueryHandler : IRequestHandler<GetCarByMonthlyMaxPriceQuery, GetCarByMonthlyMaxPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarByMonthlyMaxPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarByMonthlyMaxPriceQueryResult> Handle(GetCarByMonthlyMaxPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarByMonthlyMaxPriceAsync();
            return new GetCarByMonthlyMaxPriceQueryResult
            {
                CarName = value
            };
        }
    }
}
