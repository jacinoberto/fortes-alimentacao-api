using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services;
using FortesAlimentacaoApi.Util.AbrirAgenda;
using FortesAlimentacaoApi.Util.DataObra;
using FortesAlimentacaoApi.Util.Filtro;
using FortesAlimentacaoApi.Util.Validacao;
using FortesAlimentacaoApi.Util.Validacao.ConferirRefeicao;
using FortesAlimentacaoApi.Util.ValidarDatas;
using FortesAlimentacaoApi.Util.VerificarDias.Dias;
using FortesAlimentacaoApi.Util.WorkSevice;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<SelectService>();
builder.Services.AddScoped<ObraSelecionada>();
builder.Services.AddScoped<TodasObras>();
builder.Services.AddScoped<DataObraService>();
builder.Services.AddScoped<RelatorioService>();
builder.Services.AddSingleton<IFiltrarDia, FiltrarDiaAtipico>();
builder.Services.AddSingleton<IFiltrarDia, FiltrarDiaNaoAtipico>();
builder.Services.AddSingleton<IValidarDia, ValidarDiaAtipico>();
builder.Services.AddSingleton<IValidarDia, ValidarDiaNaoAtipico>();
builder.Services.AddSingleton<IConferirRefeicao, Cafe>();
builder.Services.AddSingleton<IConferirRefeicao, Almoco>();
builder.Services.AddSingleton<IConferirRefeicao, Jantar>();
builder.Services.AddSingleton<RefeicaoPermitida>();
builder.Services.AddScoped<AtualizarRefeicoes>();
builder.Services.AddHostedService<Work>();
builder.Services.AddSingleton<AberturaAgenda>();
builder.Services.AddSingleton<ConferirControleData>();
builder.Services.AddSingleton<RegistrarMonitoramento>();
builder.Services.AddSingleton<FinalizarMonitoramento>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Segunda>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Terca>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Quarta>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Quinta>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Sexta>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Sabado>();
builder.Services.AddSingleton<IDiaSemanaStrategy, Domingo>();

builder.Services.AddControllers();

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
