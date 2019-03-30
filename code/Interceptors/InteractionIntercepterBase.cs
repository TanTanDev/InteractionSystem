
namespace InteractionSystem
{
    public abstract class InteractionIntercepterBase<TInteraction, TInteractable> : IInteractionIntercepterT<TInteraction, TInteractable>
        where TInteraction : IInteraction
    {
        public System.Type GetInteractionType()
        {
            return typeof(TInteraction);
        }

        abstract public void Intercept(TInteraction a_interaction, TInteractable a_interactable);
    }

}
