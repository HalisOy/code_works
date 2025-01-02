using GraphQL.Types;
using GraphqlDBTest.Models;

namespace GraphqlDBTest.Graphql.Type;

public class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Field<StringGraphType>("name");
    }
}