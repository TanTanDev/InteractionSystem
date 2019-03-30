
namespace InteractionSystem
{
    // todo: explain purpose
    public interface IInteractionIntercepterT<TInteraction, TInteractable> : IInteractionIntercepter
    {
        new System.Type GetInteractionType();

        void Intercept(TInteraction a_interaction, TInteractable a_interactable);
    }
}
