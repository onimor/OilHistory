using System.Timers;
using OilHistory.Web.Business;

namespace OilHistory.Business
{
    public class BackgroundExecutorService : IHostedService, IDisposable
    {
        private ILogger<BackgroundExecutorService> _logger;
        private OilService _oilService;
        private System.Timers.Timer _timer;
        private DateTime? _lastGetDate;
        private bool _inProcess;

        public BackgroundExecutorService(
            ILogger<BackgroundExecutorService> logger,
            OilService oilService
            )
        {
            _logger = logger;
            _oilService = oilService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"запущен!");
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private async void _timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (_inProcess)
            {
                return;
            }
            _inProcess = true;
            try
            {
                if (_lastGetDate != null)
                {
                    if ((DateTime.Now - _lastGetDate.Value).TotalSeconds < 3600)
                    {
                        return;
                    }
                }
                var success = await _oilService.GetData();
                if (success)
                {
                    _lastGetDate = DateTime.Now;
                }
            }
            finally
            {
                _inProcess = false;
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Stop();
            _logger.LogInformation($"остановлен!");
        }

        public void Dispose()
        {
        }
    }
}
