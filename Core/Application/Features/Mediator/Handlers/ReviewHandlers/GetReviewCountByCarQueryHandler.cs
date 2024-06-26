using Application.Features.Mediator.Queries.ReviewQueries;
using Application.Features.Mediator.Results.ReviewResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewCountByCarQueryHandler : IRequestHandler<GetReviewCountByCarQuery, GetReviewCountByCarQueryResult>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewCountByCarQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<GetReviewCountByCarQueryResult> Handle(GetReviewCountByCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _reviewRepository.GetReviewCountByCarAsync(request.Id);

            return new GetReviewCountByCarQueryResult
            {
                ReviewCount = values
            };
        }
    }
}
