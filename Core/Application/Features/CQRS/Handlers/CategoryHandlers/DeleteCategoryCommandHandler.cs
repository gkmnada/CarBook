using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCategoryCommand deleteCategoryCommand)
        {
            var values = await _repository.GetAsync(deleteCategoryCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
