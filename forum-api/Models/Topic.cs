using System;
using System.Collections.Generic;

namespace forum_api.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
