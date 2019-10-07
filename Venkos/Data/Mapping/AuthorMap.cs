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
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Table("AUTHOR");

            Id(x => x.Id).Column("ID").GeneratedBy.Identity();

            Map(b => b.Name).Column("NAME").Length(50).Not.Nullable();
        }
    }
}
