using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithPeriodQueryHandler : IRequestHandler<GetCarPricingWithPeriodQuery, List<GetCarPricingWithPeriodQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithPeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithPeriodQueryResult>> Handle(GetCarPricingWithPeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.ListCarPricingWithPeriodAsync();

            return values.Select(x => new GetCarPricingWithPeriodQueryResult
            {
                CarID = x.CarID,
                Model = x.Model,
                Image = x.Image,
                DailyAmount = x.DailyAmount,
                WeeklyAmount = x.WeeklyAmount,
                MonthlyAmount = x.MonthlyAmount
            }).ToList();
        }
    }
}
