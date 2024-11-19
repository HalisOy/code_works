using GraphQL.Types;

namespace GraphqlTest.Graphql;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<UserQuery>();
    }
}