using GraphQL;
using GraphQL.Types;
using GraphqlDBTest.Graphql.Type;
using GraphqlDBTest.Models;
using GraphqlDBTest.Repositories;

namespace GraphqlDBTest.Graphql.Query;

public class CategoryQuery : ObjectGraphType
{
    public CategoryQuery(ICategoryRepository categoryRepository)
    {
        Field<ListGraphType<CategoryType>>("categories").ResolveAsync(async context =>
            await categoryRepository.GetAllCategoriesAsync());

        Field<CategoryType>("category")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }))
            .ResolveAsync(async context =>
                await categoryRepository.GetCategoryByIdAsync(context.GetArgument<int>("categoryId")));
    }
}