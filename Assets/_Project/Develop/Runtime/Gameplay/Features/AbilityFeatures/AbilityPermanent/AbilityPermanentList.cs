using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public class AbilityPermanentList
    {
        public event Action<AbilityPermanent> Added;

        private List<AbilityPermanent> _elements = new();

        public IReadOnlyList<AbilityPermanent> Elements => _elements;

        public virtual void Add(AbilityPermanent element)
        {
            _elements.Add(element);
            Added?.Invoke(element);
        }
    }
}
