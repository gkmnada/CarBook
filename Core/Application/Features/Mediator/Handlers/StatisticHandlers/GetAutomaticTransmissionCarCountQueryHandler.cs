using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAutomaticTransmissionCarCountQueryHandler : IRequestHandler<GetAutomaticTransmissionCarCountQuery, GetAutomaticTransmissionCarCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAutomaticTransmissionCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAutomaticTransmissionCarCountQueryResult> Handle(GetAutomaticTransmissionCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetAutomaticTransmissionCarCountAsync();
            return new GetAutomaticTransmissionCarCountQueryResult
            {
                AutomaticTransmissionCarCount = value
            };
        }
    }
}
