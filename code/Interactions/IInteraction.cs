namespace InteractionSystem
{
    public interface IInteraction
    {
        void Invoke(InteractableCollection a_interactableCollection, InteractionEventType a_interactionType, int a_identifier, InteractableCollection a_invokerInteractables);
        //void Invoke<TInteractable>(TInteractable a_interactable);
    }
}