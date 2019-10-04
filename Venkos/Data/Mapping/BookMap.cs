using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Venkos.Domain.Model;

namespace Venkos.Data.Mapping
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("BOOK");

            Id(x => x.Id).Column("ID").GeneratedBy.Guid();

            Map(b => b.Title).Column("TITLE").Length(50).Not.Nullable();
        }
    }
}
