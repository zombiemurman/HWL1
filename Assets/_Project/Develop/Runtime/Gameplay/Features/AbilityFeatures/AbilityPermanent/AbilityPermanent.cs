using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilityFeatures.AbilityPermanent
{
    public abstract class AbilityPermanent
    {
        protected AbilityPermanent(string id)
        {
            ID = id;
        }

        public string ID { get; }

        public abstract void Activate();
    }
}
