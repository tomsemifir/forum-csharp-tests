using System;
using System.Collections.Generic;

namespace forum_api.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int TopicId { get; set; }
    }
}
