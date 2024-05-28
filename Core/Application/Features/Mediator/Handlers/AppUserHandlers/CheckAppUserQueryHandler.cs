using Application.Features.Mediator.Queries.AppUserQueries;
using Application.Features.Mediator.Results.AppUserResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CheckAppUserQueryHandler : IRequestHandler<CheckAppUserQuery, CheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public CheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<CheckAppUserQueryResult> Handle(CheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new CheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = user.Username;
                values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleID == user.AppRoleID)).RoleName;
                values.AppUserID = user.AppUserID;
            }
            return values;
        }
    }
}
