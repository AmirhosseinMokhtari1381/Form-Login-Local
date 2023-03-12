using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using Contactus1.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    //Logic
    var url = context.Request.Path.ToString();

    context.Items.Add("Test", "First Use");
    //if (url.ToLower() == "/home/index")
    //{
    //    //in miyad yek header dorsot mikone 
    //    //context.Response.Headers.Add("customHeader", "Amirhossein");
    //    //vagti az in estefade mishe dige be middleware dige nmire 
    //    //await context.Response.WriteAsync("dige tamom shod be middleware badi nemire ");
    //}
    await next();
    //MoreLogic 

});

//app.Run(async (context) =>
//{

//    var item = context.Items["Test"]?.ToString(); 
//    await context.Response.WriteAsync($"<h1>Amirhossein Mokhtari - {item}</h1>");

//});


//app.MapWhen(contex=>shart,method)

//app.MapWhen(context =>context.Request.Query.ContainsKey("test") , MapWhenMehod);

//app.Map("/home", Test);



app.UseTestM();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void MapWhenMehod(IApplicationBuilder app)
{
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("MapWhen");

    });
}


static void Test(IApplicationBuilder app)
{
    app.Map("/index", config2 =>
    {
        config2.Run(async (context) =>
        {
            await context.Response.WriteAsync("Run Index Page");
        });
    });

    app.Use(async (contex, next) =>
    {
        contex.Response.Headers.Add("Test", "Hello");
        await next();
    });
    app.Run(async (contex) =>
    {
        var text = contex.Response.Headers["Test"].ToString();
        if (text == "Hello")
        {
            await contex.Response.WriteAsync(text);
        }
        else
        {
            contex.Response.Redirect("/");
        }

    });
}
