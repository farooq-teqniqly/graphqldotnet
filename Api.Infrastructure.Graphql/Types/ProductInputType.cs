using GraphQL.Types;

namespace Teqniqly.Samples.Graphql.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<DecimalGraphType>("price");
        }
        
    }
}
