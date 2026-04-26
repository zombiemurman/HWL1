using Assets._Project.Develop.Runtime.Configs.Gameplay.AbilityPermanent;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay;

namespace Assets._Project.Develop.Runtime.UI.AbilityShop
{
    public class AbilityPermanentDisplayPresenter : IPresenter
    {
        private readonly IconListView _iconListView;
        private readonly ViewsFactory _viewsFactory;
        private readonly AbilityPermanentConfigsContainer _abilityPermanentConfigs;
        private readonly AbilityPermanentProviderService _abilityPermanentProvider;


        public AbilityPermanentDisplayPresenter(
            IconListView iconListView, 
            ViewsFactory viewsFactory, 
            AbilityPermanentConfigsContainer abilityPermanentConfigs, 
            AbilityPermanentProviderService abilityPermanentProvider)
        {
            _iconListView = iconListView;
            _viewsFactory = viewsFactory;
            _abilityPermanentConfigs = abilityPermanentConfigs;
            _abilityPermanentProvider = abilityPermanentProvider;
        }

        public void Initialize()
        {
            foreach(string abilityID in _abilityPermanentProvider.AbilitiesPermanentsID)
            {
                AbilityPermanentConfig config = _abilityPermanentConfigs.GetConfigBy(abilityID);

                IconView abilityIconView = _viewsFactory.Create<IconView>(ViewIDs.AbilityIcon);

                abilityIconView.SetIcon(config.Icon);

                _iconListView.Add(abilityIconView);
            }
        }

        public void Dispose()
        {
            foreach (IconView item in _iconListView.Elements)
            {
                _iconListView.Remove(item);
                _viewsFactory.Release(item);
            }
        }

    }
}
