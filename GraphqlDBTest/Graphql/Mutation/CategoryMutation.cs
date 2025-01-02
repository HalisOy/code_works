using GraphQL;
using GraphQL.Types;
using GraphqlDBTest.Graphql.Type;
using GraphqlDBTest.Models;
using GraphqlDBTest.Repositories;

namespace GraphqlDBTest.Graphql.Mutation;

public sealed class CategoryMutation : ObjectGraphType
{
    public CategoryMutation(ICategoryRepository categoryRepository)
    {
        Field<StringGraphType>("createCategory")
            .Arguments(
                new QueryArgument<CategoryInputType> { Name = "category" })
            .ResolveAsync(async context =>
            {
                try
                {
                    await categoryRepository.AddCategoryAsync(context.GetArgument<Category>("category"));
                    return "Başarıyla eklendi.";
                }
                catch (Exception ex)
                {
                    return "Hata: " + ex.Message;
                }
            });

        Field<StringGraphType>("updateCategory")
            .Arguments(
                new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "categoryId" },
                    new QueryArgument<CategoryInputType> { Name = "category" }))
            .ResolveAsync(async context =>
            {
                try
                {
                    var menu = context.GetArgument<Category>("category");
                    menu.Id = context.GetArgument<int>("categoryId");
                    await categoryRepository.UpdateCategoryAsync(menu);
                    return "Başarıyla güncellendi.";
                }
                catch (Exception ex)
                {
                    return "Hata: " + ex.Message;
                }
            });

        Field<StringGraphType>("deleteCategory")
            .Arguments(
                new QueryArgument<IntGraphType> { Name = "categoryId" })
            .ResolveAsync(async context =>
            {
                try
                {
                    await categoryRepository.DeleteCategoryAsync(context.GetArgument<int>("categoryId"));
                    return "Kullanıcı silindi.";
                }
                catch (Exception ex)
                {
                    return "Hata: " + ex.Message;
                }
            });
    }
}