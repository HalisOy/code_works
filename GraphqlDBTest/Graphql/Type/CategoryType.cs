using GraphQL.Types;
using GraphqlDBTest.Models;

namespace GraphqlDBTest.Graphql.Type;

public sealed class CategoryType : ObjectGraphType<Category>
{
    public CategoryType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        
        Field<ListGraphType<ProductType>>("products")
            .Resolve(context => context.Source.Products);
    }
}