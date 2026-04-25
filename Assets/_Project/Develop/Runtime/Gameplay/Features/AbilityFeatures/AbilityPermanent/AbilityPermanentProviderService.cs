using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.Data;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class AbilityPermanentProviderService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly List<string> _abilities = new();

        public AbilityPermanentProviderService(
            PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyList<string> AbilitiesPermanentsID => _abilities;

        public void Add(string ID)
        {
            if (_abilities.Contains(ID))
                return;

            _abilities.Add(ID);
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (String abilityID in data.AbilitiesPermanentsID)
            {
                if (_abilities.Contains(abilityID) == false)
                    _abilities.Add(abilityID);
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (string abilityID in _abilities)
            {
                if (data.AbilitiesPermanentsID.Contains(abilityID) == false)
                    data.AbilitiesPermanentsID.Add(abilityID);
            }
        }
    }
}
