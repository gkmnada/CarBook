using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetManuelTransmissionCarCountQueryHandler : IRequestHandler<GetManuelTransmissionCarCountQuery, GetManuelTransmissionCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetManuelTransmissionCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetManuelTransmissionCarCountQueryResult> Handle(GetManuelTransmissionCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetManuelTransmissionCarCountAsync();
            return new GetManuelTransmissionCarCountQueryResult
            {
                ManuelTransmissionCarCount = value
            };
        }
    }
}
