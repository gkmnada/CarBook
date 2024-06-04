using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetDieselFuelCarCountQueryHandler : IRequestHandler<GetDieselFuelCarCountQuery, GetDieselFuelCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetDieselFuelCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetDieselFuelCarCountQueryResult> Handle(GetDieselFuelCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetDieselFuelCarCountAsync();
            return new GetDieselFuelCarCountQueryResult
            {
                DieselFuelCarCount = value
            };
        }
    }
}
