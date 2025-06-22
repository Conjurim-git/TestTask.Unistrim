namespace TestTask.Unistrim.Api
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0; 
        private readonly ILogger<TimedHostedService> _logger; 
        private Timer? _timer = null;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
           _logger.LogInformation("Hello Krasnoyarsk");
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
         _logger.LogInformation("Stop");
            return Task.CompletedTask;
        }

        //public Task ExecuteAsync()
        //{

        //}

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
