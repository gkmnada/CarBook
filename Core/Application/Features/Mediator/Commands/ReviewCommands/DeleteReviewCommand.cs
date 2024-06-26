using MediatR;

namespace Application.Features.Mediator.Commands.ReviewCommands
{
    public class DeleteReviewCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteReviewCommand(string id)
        {
            Id = id;
        }
    }
}
