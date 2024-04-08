using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ServicosRestFull.Models;
using ServicosRestFull.Services;
using ServicosRestFull.Services.Helpers;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Configura a conex�o com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<MeuBanco>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    // Adiciona o filtro de autentica��o JWT ao Swagger
    c.OperationFilter<AuthenticationRequirementOperationFilter>();

    // Adiciona o esquema de seguran�a JWT ao Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    // Adiciona o requisito de autoriza��o JWT ao Swagger
    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    };
    c.AddSecurityRequirement(securityRequirement);

    // Adiciona um exemplo para o modelo de login
    c.MapType<UsuariosSistema>(() => new OpenApiSchema
    {
        Type = "object",
        Properties = new Dictionary<string, OpenApiSchema>
        {
             { "login", new OpenApiSchema { Type = "string", Example = new OpenApiString("usuario") } },
             { "senha", new OpenApiSchema { Type = "string", Example = new OpenApiString("senha") } }
        }
    });
});

// Adiciona a autentica��o JWT
var key = Encoding.ASCII.GetBytes("ChaveSecretaParaCriptografiaDoTokenJWT");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adm", policy =>
    {
        policy.RequireRole("adm");
    });
});

// Cria uma inst�ncia da classe UsuariosSistemaAutenticacao
builder.Services.AddSingleton<UsuariosSistemaAutenticacao>();

var app = builder.Build();

// Middleware de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.DefaultModelsExpandDepth(-1); // Isso impede que todos os modelos sejam expandidos por padr�o
    });
}

app.UseHttpsRedirection();

// Adiciona o middleware de autentica��o JWT
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Endpoint para autenticar usu�rios
app.MapPost("/login", async (UsuariosSistema model, UsuariosSistemaAutenticacao auth, MeuBanco dbContext) =>
{
    // Suponha que voc� tenha o login e senha no corpo da solicita��o
    string login = model.Login; // Preencher com o login da solicita��o
    string senha = model.Senha; // Preencher com a senha da solicita��o    

    // Buscar os dados de login e senha do banco de dados
    var usuario = dbContext.UsuarioSistema
        .Include(u => u.Roles)
        .ThenInclude(ur => ur.Role)
        .FirstOrDefault(u => u.Login == login);

    if (usuario != null && usuario.Senha == senha)
    {
        // Se o usu�rio � v�lido, obt�m as fun��es do usu�rio
        var roles = usuario.Roles.Select(ur => ur.Role.Nome).ToArray();
        // Se o usu�rio � v�lido, gera um token JWT
        // Gera um token JWT com as fun��es do usu�rio
        var token = JwtTokenGenerator.GenerateToken("ChaveSecretaParaCriptografiaDoTokenJWT", login, senha, roles);

        // Retorna o token JWT
        return Results.Ok(new { Token = token });
    }
    else
    {
        return Results.Unauthorized(); // Retorna um status 401 Unauthorized se a autentica��o falhar
    }
});

// Endpoint para obter os vinhos, acess�vel apenas para usu�rios com fun��o "adm"
app.MapGet("/vinho", async (HttpContext httpContext, MeuBanco dbContext, IAuthorizationService authorizationService) =>
{
    // Verifica se o usu�rio est� autenticado
    if (!httpContext.User.Identity.IsAuthenticated)
    {
        return Results.Unauthorized(); // Retorna um status 401 Unauthorized se o usu�rio n�o estiver autenticado
    }

    // L�gica para obter os vinhos aqui...
    var vinhos = await dbContext.Vinho.ToListAsync();
    return Results.Ok(vinhos);
});

// Endpoint DELETE protegido pela pol�tica de autoriza��o "adm"
//app.MapDelete("/resource/{id}", async (HttpContext httpContext, MeuBanco dbContext, IAuthorizationService authorizationService, int id) =>
//{
//    // Verifica a autoriza��o do usu�rio
//    var authorizationResult = await authorizationService.AuthorizeAsync(httpContext.User, null, "adm");

//    if (!authorizationResult.Succeeded)
//    {
//        return Results.Forbid(); // Retorna um status 403 Forbidden se o usu�rio n�o tiver a fun��o "adm"
//    }

//    // L�gica para exclus�o do recurso aqui...

//    return Results.Ok(); // Retorna um status 200 OK ou outro resultado apropriado ap�s a exclus�o do recurso
//});


app.Run();
