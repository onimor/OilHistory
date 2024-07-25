using OilHistory.Web.Business.Services.Oil;

namespace OilHistory.Web.Business.BackgroundServices
{
    public class BackgroundExecutorService : IHostedService, IDisposable
    {
        private ILogger<BackgroundExecutorService> _logger;
        private IOilService _oilService; 
        private DateTime? _lastGetDate;
        private CancellationTokenSource? _cancellationTokenSource;

        public BackgroundExecutorService(
            ILogger<BackgroundExecutorService> logger,
            IOilService oilService
            )
        {
            _logger = logger;
            _oilService = oilService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        { 
            _cancellationTokenSource = new CancellationTokenSource();
            _ = Task.Factory.StartNew(() => DoWork(_cancellationTokenSource.Token), TaskCreationOptions.LongRunning);
            return Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"запущен!");
            while (cancellationToken.IsCancellationRequested == false)
            {
                try
                { 
                    if (_lastGetDate is null || (DateTime.Now - _lastGetDate.Value).TotalSeconds > 3600)
                        await _oilService.GetData(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    _lastGetDate = DateTime.Now;
                    await Task.Delay(1000);
                }
            }
            _logger.LogInformation($"остановлен!");
        } 
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource?.Cancel();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
            _lastGetDate = default;
            GC.SuppressFinalize(this);
        }
    }
}
