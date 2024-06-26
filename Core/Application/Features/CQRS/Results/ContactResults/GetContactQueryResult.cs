﻿namespace Application.Features.CQRS.Results.ContactResults
{
    public class GetContactQueryResult
    {
        public string ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
