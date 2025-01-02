using GraphQL;
using GraphQL.Types;
using GraphqlDBTest.Context;
using GraphqlDBTest.Graphql;
using GraphqlDBTest.Graphql.Query;
using GraphqlDBTest.Graphql.Type;
using GraphqlDBTest.Repositories;

var builder = WebApplication.CreateBuilder(args);

LoadEnv(".env");

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISchema, GraphqlSchema>();

// builder.Services.AddGraphQL(ql => ql.AddAutoSchema<ISchema>().AddSystemTextJson());
builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson();
    options.AddAutoSchema<ISchema>();
    options.AddGraphTypes();
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseGraphQL<ISchema>("/graphql");
app.UseGraphQLPlayground("/ui/playground");

app.Run();

void LoadEnv(string filePath)
{
    // .env dosyasını oku
    if (!File.Exists(filePath))
    {
        Console.WriteLine(".env file not found!");
        return;
    }

    foreach (var line in File.ReadLines(filePath))
    {
        // Yalnızca boş olmayan satırları ve '=' içeren satırları al
        if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
        {
            var parts = line.Split('=', 2);
            var key = parts[0].Trim();
            var value = parts[1].Trim();

            // Çevresel değişken olarak ayarla
            Environment.SetEnvironmentVariable(key, value);
        }
    }
}