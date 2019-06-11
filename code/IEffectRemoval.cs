namespace InteractionSystem
{
    public interface IEffectRemoval
    {
        void Update();
        void Reset();
        bool ShouldBeRemoved();
    }
}
