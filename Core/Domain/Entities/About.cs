﻿namespace Domain.Entities
{
    public class About
    {
        public string AboutID { get; } = Guid.NewGuid().ToString("D");
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
