using GraphQL;
using GraphqlTest.Graphql;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddGraphQL(options => {
    options.AddSystemTextJson();
    options.AddSchema<AppSchema>();
    options.AddGraphTypes();
});

var app = builder.Build();


app.UseGraphQL<AppSchema>("/graphql");
app.UseGraphQLPlayground("/ui/playground");

app.Run();