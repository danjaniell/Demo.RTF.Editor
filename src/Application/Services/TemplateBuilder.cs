using Application.Services.Interface;
using HandlebarsDotNet;

namespace Application.Services
{
    public class TemplateBuilder<TModel> : ITemplateBuilder<TModel>
    {
        public string GenerateTemplate(TModel model, string source)
        {
            var template = Handlebars.Compile(source);
            var result = template(model);
            return result;
        }
    }
}
