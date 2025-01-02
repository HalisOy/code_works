using GraphQL.Types;
using GraphqlDBTest.Graphql.Mutation;
using GraphqlDBTest.Graphql.Query;

namespace GraphqlDBTest.Graphql;

public class GraphqlSchema : Schema
{
    public GraphqlSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<CategoryQuery>();
        Mutation = provider.GetRequiredService<CategoryMutation>();
    }
}