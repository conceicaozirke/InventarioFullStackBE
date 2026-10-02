using InventarioWebBE_FullStack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

//frontend- conexão com localhost / 5506 -VERIFICAR SE É 5506 OU 3306 
builder.Services.AddCors(Options =>
{
    Options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:5506")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });



});

//adc controllers
builder.Services.AddControllers();


//Coisa do Swachbucker- buckler- buker?
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//DBContext no MYSQL - password e loguinho abaixo
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Port5506;Database=Db_Inv;User=root;Password=RootRoot;";

var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

var app = builder.Build();


app.UseCors("AllowAll");


//Swachbuckershitshow / Ativar a ingerface do Mick Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
// usar HTTPS redirect
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();





app.Run();


/* Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();*/



/* Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run(); */
