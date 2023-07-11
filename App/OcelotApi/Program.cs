using Flurl.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile($"ocelot.json", false, true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var AuthenticationProviderKey = JwtBearerDefaults.AuthenticationScheme;
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(AuthenticationProviderKey, cfg =>
            {
                cfg.RequireHttpsMetadata = true;
                //cfg.SaveToken = true;
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                        builder.Configuration["Secret"]
                        ?? throw new Exception("Secret key was not found"))),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = true
                };
            });

//builder.Services.AddTransient<JwtMiddleware, JwtMiddleware>();

//var configuration = new OcelotPipelineConfiguration
//{
//    PreAuthenticationMiddleware = async (ctx, next) =>
//    {
//        var token = ctx.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
//        //var id = ctx.Request.Qer
//        if (token != null)
//        {
//            await next.Invoke();
//        }

//        else
//        {
//            var newtoken = await $"https://localhost:53757/account/auth/13220F00-E8B4-4FC2-91B0-13663CB3FD7F".GetJsonAsync();
//            var tokenstr = newtoken.token;
//            ctx.Request.Headers.Add("Authorization", $"Bearer {tokenstr}");
//            await next.Invoke();
//        }
//    }
//};

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseCors("CorsPolicy");


//app.UseMiddleware<JwtMiddleware>();



app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();




