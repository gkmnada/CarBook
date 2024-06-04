using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;
using MediatR.Pipeline;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarByMonthlyMinPriceQueryHandler : IRequestHandler<GetCarByMonthlyMinPriceQuery, GetCarByMonthlyMinPriceQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarByMonthlyMinPriceQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarByMonthlyMinPriceQueryResult> Handle(GetCarByMonthlyMinPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetCarByMonthlyMinPriceAsync();
            return new GetCarByMonthlyMinPriceQueryResult
            {
                CarName = value
            };
        }
    }
}
