﻿namespace FortesAlimentacaoApi.Util.WorkSevice;

using FortesAlimentacaoApi.Util.AbrirAgenda;

public class Work : BackgroundService
{
    private ILogger<Work> _logger;
    private readonly AberturaAgenda _abrirAgenda;
    private readonly ConferirControleData _conferirControleData;
    private readonly RegistrarMonitoramento _registrarMonitoramento;
    private readonly FinalizarMonitoramento _finalizarMonitoramento;

    public Work(ILogger<Work> logger, AberturaAgenda abrirAgenda,
        ConferirControleData conferirControleData, RegistrarMonitoramento registrarMonitoramento,
        FinalizarMonitoramento finalizarMonitoramento)
    {
        _logger = logger;
        _abrirAgenda = abrirAgenda;
        _conferirControleData = conferirControleData;
        _registrarMonitoramento = registrarMonitoramento;
        _finalizarMonitoramento = finalizarMonitoramento;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Data e Hora não permitem a abertura da agenda.");

            var horaAgora = DateTime.Now;
            DayOfWeek dataHoje = horaAgora.DayOfWeek;
            var horario = new TimeSpan(0,0, 0);
            TimeSpan ff = horaAgora.TimeOfDay;

            if (dataHoje == DayOfWeek.Thursday
                && ff.Hours == horario.Hours
                && ff.Minutes == horario.Minutes
                && ff.Seconds == horario.Seconds)
            {
                await _registrarMonitoramento.Registrar();
                await _conferirControleData.ConferirControleDatas();
                await _abrirAgenda.AbrirAgenda();
                await _finalizarMonitoramento.Finalizar();
                Console.WriteLine("Foi");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
