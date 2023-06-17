﻿using BasketService.Models;
using Redis.OM;

namespace BasketService.Services
{
    public class IndexCreationService : IHostedService
    {
        private readonly RedisConnectionProvider _provider;

        public IndexCreationService(RedisConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _provider.Connection.CreateIndexAsync(typeof(ShoppingCart));
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
