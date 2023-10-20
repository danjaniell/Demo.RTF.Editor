using Application.Models;
using Application.Services.Interface;
using HandlebarsDotNet;

namespace Application.Services;

public class TemplateBuilder : ITemplateBuilder
{
    public string GenerateTemplate(string source, BillingDataModel model)
    {
        var template = Handlebars.Compile(source);
        var result = template(model);

        return result;
    }
}
