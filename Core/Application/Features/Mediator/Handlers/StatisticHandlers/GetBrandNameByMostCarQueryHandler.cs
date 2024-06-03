using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBrandNameByMostCarQueryHandler : IRequestHandler<GetBrandNameByMostCarQuery, GetBrandNameByMostCarQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBrandNameByMostCarQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBrandNameByMostCarQueryResult> Handle(GetBrandNameByMostCarQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticRepository.GetBrandNameByMostCarAsync();
            return new GetBrandNameByMostCarQueryResult
            {
                BrandName = value
            };
        }
    }
}
