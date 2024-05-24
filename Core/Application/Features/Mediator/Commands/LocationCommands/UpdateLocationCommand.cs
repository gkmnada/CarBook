using MediatR;

namespace Application.Features.Mediator.Commands.LocationCommands
{
    public class UpdateLocationCommand : IRequest
    {
        public string LocationID { get; set; }
        public string Name { get; set; }
    }
}
