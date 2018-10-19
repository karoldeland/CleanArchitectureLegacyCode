using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Domain.Services
{
    public class BacklogItemIdGenerator
    {
        public Guid GetUniqueId()
        {
            return Guid.NewGuid();
        }
    }
}
