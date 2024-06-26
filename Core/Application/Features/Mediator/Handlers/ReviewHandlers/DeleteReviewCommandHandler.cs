using Application.Features.Mediator.Commands.ReviewCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public DeleteReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAsync(request.Id);
            await _repository.DeleteAsync(value);
            return Unit.Value;
        }
    }
}
