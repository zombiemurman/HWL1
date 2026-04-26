using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeatures;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.HPBar
{
    public class EntitiesHealthDisplayPresenter : IPresenter
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly EntitiesHealthDisplay _view;

        private readonly GameplayPresentersFactory _gameplayPresentersFactory;

        private readonly ViewsFactory _viewsFactory;

        private Dictionary<Entity, EntityHealthBarInfo> _entityToHealthBarInfo = new();

        public EntitiesHealthDisplayPresenter(
            EntitiesLifeContext entitiesLifeContext,
            EntitiesHealthDisplay view,
            ViewsFactory viewsFactory,
            GameplayPresentersFactory gameplayPresentersFactory)
        {
            _entitiesLifeContext = entitiesLifeContext;
            _view = view;
            _viewsFactory = viewsFactory;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
            _entitiesLifeContext.Released += OnEntityReleased;

            foreach (Entity entity in _entitiesLifeContext.Entities)
                OnEntityAdded(entity);
        }
        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (EntityHealthBarInfo info in _entityToHealthBarInfo.Values)
                DisposeFor(info);

            _entityToHealthBarInfo.Clear();
        }

        private void OnEntityReleased(Entity entity)
        {
            if (_entityToHealthBarInfo.ContainsKey(entity))
                RemoveHealthBarFor(entity);
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.TryGetHealthBarPoint(out Transform healthBarPoint))
            {
                BarWithText healthBarView = null;

                if (entity.HasComponent<IsMainHero>())
                    healthBarView = _viewsFactory.Create<BarWithText>(ViewIDs.MainHeroHealthBar);
                else
                    healthBarView = _viewsFactory.Create<BarWithText>(ViewIDs.SimpleHealthBar);

                _view.Add(healthBarView);

                EntityHealthPresenter entityHealthPresenter = _gameplayPresentersFactory.CreateEntityHealthPresenter(entity, healthBarView);
                entityHealthPresenter.Initialize();

                IDisposable removeReason = entity.IsDead.Subscribe((oldvalue, isDead) =>
                {
                    if (isDead)
                        RemoveHealthBarFor(entity);
                });

                _entityToHealthBarInfo.Add(entity, new EntityHealthBarInfo(healthBarPoint, removeReason, entityHealthPresenter));

            }
        }

        public void LateUpdate()
        {
            foreach (KeyValuePair<Entity, EntityHealthBarInfo> info in _entityToHealthBarInfo)
            {
                _view.UpdatePositionFor(info.Value.EntityHealthPresenter.Bar, info.Value.HealthBarPoint.position);
            }
                
        }

        private void RemoveHealthBarFor(Entity entity)
        {
            EntityHealthBarInfo info = _entityToHealthBarInfo[entity];

            DisposeFor(info);

            _entityToHealthBarInfo.Remove(entity);
        }

        private void DisposeFor(EntityHealthBarInfo info)
        {
            info.RemoveReason.Dispose();

            _view.Remove(info.EntityHealthPresenter.Bar);

            _viewsFactory.Release(info.EntityHealthPresenter.Bar);

            info.EntityHealthPresenter.Dispose();
        }


        private class EntityHealthBarInfo
        {
            public EntityHealthBarInfo(
                Transform healthBarPoint,
                IDisposable removeReason,
                EntityHealthPresenter entityHealthPresenter)
            {
                HealthBarPoint = healthBarPoint;
                RemoveReason = removeReason;
                EntityHealthPresenter = entityHealthPresenter;
            }

            public Transform HealthBarPoint { get; }

            public IDisposable RemoveReason { get; }

            public EntityHealthPresenter EntityHealthPresenter { get; }

        }

    }
}
