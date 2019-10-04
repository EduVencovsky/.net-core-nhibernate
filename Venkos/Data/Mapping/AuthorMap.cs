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
    public class AuthorMap : ClassMap<Book>
    {
        public AuthorMap()
        {
            Table("AUTHOR");

            Id(x => x.Id).Column("ID").CustomType<long>()
                .GeneratedBy.Custom<global::NHibernate.Id.IdentityGenerator>()
                .UnsavedValue(null);

            Map(b => b.Title).Column("NAME").Length(50).Not.Nullable();
        }
    }
}
