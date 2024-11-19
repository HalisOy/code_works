using GraphQL.Types;
using GraphqlTest.Model;

namespace GraphqlTest.Graphql;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Field(x => x.Id).Description("The ID of the user");
        Field(x => x.Name).Description("The name of the user");
        Field(x => x.Email).Description("The email of the user");
    }
}