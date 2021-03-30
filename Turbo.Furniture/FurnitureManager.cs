﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Turbo.Core.Game.Furniture;
using Turbo.Core.Game.Furniture.Definition;
using Turbo.Core.Storage;
using Turbo.Database.Entities.Furniture;
using Turbo.Database.Queue;
using Turbo.Database.Repositories.Furniture;
using Turbo.Furniture.Definition;

namespace Turbo.Furniture
{
    public class FurnitureManager : IFurnitureManager
    {
        private readonly ILogger<FurnitureManager> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IStorageQueue _storageQueue;

        private IDictionary<int, IFurnitureDefinition> _furnitureDefinitions;

        public FurnitureManager(
            ILogger<FurnitureManager> logger,
            IStorageQueue storageQueue,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _storageQueue = storageQueue;
            _serviceScopeFactory = scopeFactory;

            _furnitureDefinitions = new Dictionary<int, IFurnitureDefinition>();
        }

        public async ValueTask InitAsync()
        {
            await LoadDefinitions();
        }

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }

        public IFurnitureDefinition GetFurnitureDefinition(int id)
        {
            if(_furnitureDefinitions.TryGetValue(id, out IFurnitureDefinition furnitureDefinition))
            {
                return furnitureDefinition;
            }

            return null;
        }

        private async ValueTask LoadDefinitions()
        {
            // when definitions are reloaded
            // we need all furniture to reload their definitions

            _furnitureDefinitions.Clear();

            List<FurnitureDefinitionEntity> entities;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var furnitureDefinitionRepository = scope.ServiceProvider.GetService<IFurnitureDefinitionRepository>();
                entities = await furnitureDefinitionRepository.FindAllAsync();
            }

            entities.ForEach(entity =>
            {
                IFurnitureDefinition definition = new FurnitureDefinition(entity);

                _furnitureDefinitions.Add(definition.Id, definition);
            });

            _logger.LogInformation("Loaded {0} furniture definitions", _furnitureDefinitions.Count);
        }

        public IStorageQueue StorageQueue => _storageQueue;
    }
}
