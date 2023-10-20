namespace Application.Services.Interface
{
    public interface ITemplateBuilder<TModel>
    {
        string GenerateTemplate(TModel model, string source);
    }
}
