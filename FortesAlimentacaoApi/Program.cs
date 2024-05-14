using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services;
using FortesAlimentacaoApi.Services.WorkSevice;
using FortesAlimentacaoApi.Util;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<AberturaAgendaService>();
builder.Services.AddHostedService<Work>();

builder.Services.AddControllers();

// Add cors
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200");
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
    policy.AllowCredentials();
    policy.SetIsOriginAllowed(_ => true);
}));

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
builder.Services.AddScoped<AbrirAgenda>();
builder.Services.AddScoped<ValidarAtualizacao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
