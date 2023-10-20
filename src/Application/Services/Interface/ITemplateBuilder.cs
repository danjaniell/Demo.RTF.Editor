using Application.Models;

namespace Application.Services.Interface;

public interface ITemplateBuilder
{
    string GenerateTemplate(string source, BillingDataModel model);
}
