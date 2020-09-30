using System;

namespace handnotes.Contacts.v1.Requests
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}