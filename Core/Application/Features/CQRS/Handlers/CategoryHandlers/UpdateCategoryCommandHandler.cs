using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var values = await _repository.GetAsync(updateCategoryCommand.CategoryID);
            values.CategoryName = updateCategoryCommand.CategoryName;

            await _repository.UpdateAsync(values);
        }
    }
}
