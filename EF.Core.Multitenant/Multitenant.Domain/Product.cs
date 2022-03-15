using Multitenant.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Domain
{
    public  class Product : BaseEntity
    {
        public string Description { get; set; }
    }
}
