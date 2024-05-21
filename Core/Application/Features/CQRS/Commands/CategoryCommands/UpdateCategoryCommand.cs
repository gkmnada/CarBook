namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
