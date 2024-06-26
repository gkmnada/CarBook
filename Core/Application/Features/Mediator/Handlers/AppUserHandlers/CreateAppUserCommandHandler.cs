using Application.Enums;
using Application.Features.Mediator.Commands.AppUserCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                AppRoleID = (int)RoleTypes.Member
            });

            return Unit.Value;
        }
    }
}
