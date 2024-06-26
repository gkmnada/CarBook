using Application.Features.Mediator.Queries.ReviewQueries;
using Application.Features.Mediator.Results.ReviewResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQueryResult>
    {
        private readonly IRepository<Review> _repository;

        public GetReviewByIdQueryHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<GetReviewByIdQueryResult> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetReviewByIdQueryResult
            {
                ReviewID = values.ReviewID,
                Name = values.Name,
                Image = values.Image,
                Comment = values.Comment,
                Rating = values.Rating,
                CreatedAt = values.CreatedAt,
                CarID = values.CarID
            };
        }
    }
}
