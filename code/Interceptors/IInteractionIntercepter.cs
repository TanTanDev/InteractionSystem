namespace InteractionSystem
{
    public abstract class IInteractionIntercepter
    {
        public abstract System.Type GetInteractionType();
        public abstract void Intercept(IInteraction a_interaction, InteractableCollection a_interactableCollection,
            InteractionEventType a_interactionType, int a_identifier);
    }
}
