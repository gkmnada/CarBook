using MediatR;

namespace Application.Features.Mediator.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string CarID { get; set; }
    }
}
