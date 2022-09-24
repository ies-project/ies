using ICT.MM.DAL.DB;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();




builder.Services.AddDbContext<ICTDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        //options.ExpireTimeSpan = TimeSpan.FromSeconds(60);
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Forbidden";
    });


//Criar policies para serem usadas através da autorização com claims
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedIn", policy =>
                policy.RequireClaim("Role"));
    options.AddPolicy("Root", policy =>
                policy.RequireClaim("Role","Root"));
    options.AddPolicy("Admin", policy =>
                policy.RequireClaim("Role","Admin", "Root"));
}


);
builder.Services.AddControllersWithViews();


var app = builder.Build();

//Permitir requests para o API vindos da app em React.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

//Redirecionar para a página Error em caso de erro.
app.UseExceptionHandler("/Home/Error");
app.UseStatusCodePagesWithReExecute("/Home/Error");
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
//Utilizar autenticação(cookies) e autorização(claims)
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
