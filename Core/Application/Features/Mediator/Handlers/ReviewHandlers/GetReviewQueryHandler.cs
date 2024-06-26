using Application.Features.Mediator.Queries.ReviewQueries;
using Application.Features.Mediator.Results.ReviewResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, List<GetReviewQueryResult>>
    {
        private readonly IRepository<Review> _repository;

        public GetReviewQueryHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewQueryResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListByFilterAsync(x => x.CarID == request.Id);

            return values.Select(x => new GetReviewQueryResult
            {
                ReviewID = x.ReviewID,
                Name = x.Name,
                Image = x.Image,
                Comment = x.Comment,
                Rating = x.Rating,
                CreatedAt = x.CreatedAt,
                CarID = x.CarID
            }).ToList();
        }
    }
}
