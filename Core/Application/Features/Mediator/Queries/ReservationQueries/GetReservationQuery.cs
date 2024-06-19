using Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery : IRequest<List<GetReservationQueryResult>>
    {
    }
}
