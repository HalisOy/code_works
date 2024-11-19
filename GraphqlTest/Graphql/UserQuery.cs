using GraphQL;
using GraphQL.Types;
using GraphqlTest.Model;

namespace GraphqlTest.Graphql;

public class UserQuery : ObjectGraphType
{
    private readonly List<User> _users;

    public UserQuery()
    {
        _users = new List<User>
        {
            new User { Id = 1, Name = "Halis", Email = "halis@example.com" },
            new User { Id = 2, Name = "Tugce", Email = "tugce@example.com" },
            new User { Id = 3, Name = "tugcem", Email = "tugcem@example.com" },
        };
        Field<ListGraphType<UserType>>("users")
            .Arguments(new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "name" }, // name parametresi ekliyoruz
                new QueryArgument<StringGraphType> { Name = "email" } // email parametresi ekliyoruz
            ))
            .Resolve(context =>
            {
                var nameFilter = context.GetArgument<string>("name");
                var emailFilter = context.GetArgument<string>("email");

                var filteredUsers = _users.AsQueryable();

                if (!string.IsNullOrEmpty(nameFilter))
                {
                    filteredUsers = filteredUsers.Where(u =>
                        string.Equals(u.Name, nameFilter, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(emailFilter))
                {
                    filteredUsers = filteredUsers.Where(u => u.Email.Contains(emailFilter));
                }

                return filteredUsers.ToList();
            });
    }
}