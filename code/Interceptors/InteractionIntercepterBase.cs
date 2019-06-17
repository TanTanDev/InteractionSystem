
namespace InteractionSystem
{
    public abstract class InteractionIntercepterBase<TInteraction, TInteractable> : IInteractionIntercepter//: IInteractionIntercepterT<TInteraction, TInteractable>
        where TInteraction : IInteraction
        where TInteractable : class, IInteractable
    {
        public override System.Type GetInteractionType()
        {
            return typeof(TInteraction);
        }

        abstract public void OnIntercept(TInteraction a_interaction, TInteractable a_interactable);

        public override void Intercept(IInteraction a_interaction, InteractableCollection a_interactableCollection,
            InteractionEventType a_interactionType, int a_identifier = int.MinValue)
        {
            TInteractable interactable = a_interactableCollection.LocateInteractable<TInteractable>(a_eventType: a_interactionType, a_identifier: a_identifier);
            OnIntercept((TInteraction)a_interaction, (TInteractable)interactable);
        }
        //public void Intercept(TInteraction a_interaction, TInteractable a_interactable)
        //{
        //    OnIntercept(a_interaction, a_interactable);
        //}
    }
}
