using Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationByIdQuery : IRequest<GetReservationByIdQueryResult>
    {
        public string Id { get; set; }

        public GetReservationByIdQuery(string id)
        {
            Id = id;
        }
    }
}
