using MediatR;

namespace Application.Features.Mediator.Commands.TestimonialCommands
{
    public class DeleteTestimonialCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteTestimonialCommand(string id)
        {
            Id = id;
        }
    }
}
