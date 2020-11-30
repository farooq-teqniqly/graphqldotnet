using System.Collections.Generic;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Types
{
    public sealed class MenuSummaryType : ObjectGraphType<IMenu>
    {
        public MenuSummaryType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.Image);
        }
    }
}
