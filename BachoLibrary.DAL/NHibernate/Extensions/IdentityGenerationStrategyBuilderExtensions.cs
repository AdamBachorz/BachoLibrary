using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Mapping;
using BachoLibrary.DAL;

namespace BachoLibrary.NHibernate.Extensions
{
    public static class IdentityGenerationStrategyBuilderExtensions
    {
        public static IdentityPart Strategy(this IdentityGenerationStrategyBuilder<IdentityPart> identityGenerationStrategyBuilder, IdentityStrategy identityStrategy, string tablename)
        {
            string sequenceName = tablename + "_seq";
            switch (identityStrategy)
            {
                case IdentityStrategy.Sequance:
                    return identityGenerationStrategyBuilder.Sequence(sequenceName);
                case IdentityStrategy.Guid:
                    return identityGenerationStrategyBuilder.Guid();
                default:
                    return identityGenerationStrategyBuilder.Sequence(sequenceName);
            }
        }
    }
}
