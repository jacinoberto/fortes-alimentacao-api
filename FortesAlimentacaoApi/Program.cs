using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services;
using FortesAlimentacaoApi.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add cors
var Origem = "_origem";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Origem,
        policy =>
        {
            policy.WithOrigins("http://localhost:4000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add context
builder.Services.AddDbContext<FortesAlimentacaoDbContext>();

// Add mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add service
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<OperarioService>();
builder.Services.AddScoped<EncarregadoService>();
builder.Services.AddScoped<ObraService>();
builder.Services.AddScoped<GestaoEquipeService>();
builder.Services.AddScoped<EquipeService>();
builder.Services.AddScoped<ControleDataService>();
builder.Services.AddScoped<RefeicaoService>();
builder.Services.AddScoped<Validacao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
