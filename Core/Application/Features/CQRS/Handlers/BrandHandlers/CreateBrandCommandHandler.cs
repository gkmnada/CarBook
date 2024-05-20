using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand createBrandCommand)
        {
            await _repository.CreateAsnyc(new Brand
            {
                BrandName = createBrandCommand.BrandName
            });
        }
    }
}
