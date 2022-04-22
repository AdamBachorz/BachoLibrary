using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Mapping;
using BachorzLibrary.DAL;

namespace BachorzLibrary.NHibernate.Extensions
{
    public static class IdentityGenerationStrategyBuilderExtensions
    {
        public static IdentityPart Strategy(this IdentityGenerationStrategyBuilder<IdentityPart> identityGenerationStrategyBuilder, IdentityStrategy identityStrategy, string tablename)
        {
            string sequenceName = tablename + "_seq";
            return identityStrategy switch
            {
                IdentityStrategy.Sequance => identityGenerationStrategyBuilder.Sequence(sequenceName),
                IdentityStrategy.Guid => identityGenerationStrategyBuilder.Guid(),
                _ => identityGenerationStrategyBuilder.Sequence(sequenceName),
            };
        }
    }
}
