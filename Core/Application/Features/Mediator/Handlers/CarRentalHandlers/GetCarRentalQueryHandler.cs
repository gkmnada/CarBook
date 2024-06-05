using Application.Features.Mediator.Queries.CarRentalQueries;
using Application.Features.Mediator.Results.CarRentalResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarRentalHandlers
{
    public class GetCarRentalQueryHandler : IRequestHandler<GetCarRentalQuery, List<GetCarRentalQueryResult>>
    {
        private readonly ICarRentalRepository _carRentalRepository;

        public GetCarRentalQueryHandler(ICarRentalRepository carRentalRepository)
        {
            _carRentalRepository = carRentalRepository;
        }

        public async Task<List<GetCarRentalQueryResult>> Handle(GetCarRentalQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRentalRepository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
            return values.Select(x => new GetCarRentalQueryResult
            {
                CarID = x.CarID,
                BrandName = x.Car.Brand.BrandName,
                Model = x.Car.Model,
                Image = x.Car.Image
            }).ToList();
        }
    }
}
