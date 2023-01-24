using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme2.Model
{
    public class Words
    {
        [Key]
        public int ID { get; set; } = 0;
        public string? Word { get; set; } = string.Empty;
  

    }
}
