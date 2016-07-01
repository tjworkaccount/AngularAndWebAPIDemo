using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public abstract class BaseClass
    {
        [Key]
        public int Id { get; set; }
    }
}