using MediatR;

namespace Application.Features.Mediator.Commands.ReservationCommands
{
    public class DeleteReservationCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteReservationCommand(string id)
        {
            Id = id;
        }
    }
}
