using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venkos.Domain.Model
{
    public class Book
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
    }
}
