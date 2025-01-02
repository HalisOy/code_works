using GraphQL.Types;
using GraphqlDBTest.Models;

namespace GraphqlDBTest.Graphql.Type;

public class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x=>x.Price);
        Field(x => x.Quantity);
    }
}