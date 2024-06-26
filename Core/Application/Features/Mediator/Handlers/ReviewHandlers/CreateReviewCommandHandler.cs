using Application.Features.Mediator.Commands.ReviewCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                Name = request.Name,
                Image = request.Image,
                Comment = request.Comment,
                Rating = request.Rating,
                CreatedAt = DateTime.Now,
                CarID = request.CarID
            });

            return Unit.Value;
        }
    }
}
