using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moisi_Olivia_Debora_Lab8.Models
{
    public class Publisher
    {
        public int ID { get; set; }

        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }

        // navigation property
        public ICollection<Book> Books { get; set; }
    }
}
