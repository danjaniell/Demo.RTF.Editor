using System.Reflection;
using Application.Services;
using Application.Services.Interface;
using Application.Services.Strategies;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using PuppeteerSharp;
using Radzen;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons()
    .AddBlazoriseRichTextEdit();

InitPuppeteer();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<WkHtmlToPdfConversionStrategy>();
builder.Services.AddScoped<PhantomJsPdfConversionStrategy>();
builder.Services.AddScoped<WeasyPrintPdfConversionStrategy>();
builder.Services.AddScoped<PuppeteerSharpPdfConversionStrategy>();
builder.Services.AddScoped<JsPdfConversionStrategy>();
builder.Services.AddScoped(typeof(PdfConverter<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

static void InitPuppeteer()
{
    var bfOptions = new BrowserFetcherOptions
    {
        Path = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)
    };
    var bf = new BrowserFetcher(bfOptions);
    bf.DownloadAsync().Wait();
}
