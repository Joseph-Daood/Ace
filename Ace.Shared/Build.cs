using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace.Shared
{
    public class Build : ObjectBase
    {
        [Key]
        public string BuildNumber { get; set; }
    }
}
