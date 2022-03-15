using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Domain.Abstract
{
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
        public string TenantId { get; set; }
    }
}
