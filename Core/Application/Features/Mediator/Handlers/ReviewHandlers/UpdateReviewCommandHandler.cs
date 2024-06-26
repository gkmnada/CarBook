using Application.Features.Mediator.Commands.ReviewCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.ReviewID);
            values.Name = request.Name;
            values.Image = request.Image;
            values.Comment = request.Comment;
            values.Rating = request.Rating;
            values.CarID = request.CarID;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
