using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryParameters
{
    public class QueryParameters
    {
        [FromQuery(Name = "userId")]
        public int? UserId { get; set; }
        [FromQuery(Name ="taskId")]
        public int? TaskId { get; set; }
    }
}
