using DtoLayer.ContactDto;
using DtoLayer.FooterDto;

namespace PresentationUI.Models
{
    public class ContactViewModel
    {
        public List<ResultFooterDto> ResultFooterDto { get; set; }
        public CreateContactDto CreateContactDto { get; set; }
    }
}
