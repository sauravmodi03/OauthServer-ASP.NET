using Microsoft.EntityFrameworkCore;
using ResourceServer;
using ResourceServer.Repository;
using ResourceServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<DbContext, DataContext>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<TodoRepository>();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(c =>
{
    c.AddPolicy(name: "CORSOpenPolicy", options => {
        options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        options.WithOrigins("http://localhost:4200/**").AllowAnyHeader().AllowAnyMethod();
        options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


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
app.UseCors("CORSOpenPolicy");
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

