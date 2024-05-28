namespace Application.Features.Mediator.Results.AppUserResults
{
    public class CheckAppUserQueryResult
    {
        public int AppUserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
