﻿namespace InteractionSystem
{
    // Base class to handle interactions of units.
    public abstract class InteractionBase<TInteractable> : IInteraction
        where TInteractable : class, IInteractable
        //where TIntercepter  : class, IInteractionIntercepterT<TInteractable>
    {
        //public abstract void Invoke(InteractableCollection a_unit, int a_identifier = 0);

        protected TInteractable LocateInteractable(InteractableCollection a_interactableCollection,
            int a_identifier,
            InteractionEventType a_interactionType = null)
        {
            if(a_interactableCollection == null)
                throw new System.NullReferenceException("can't locate interactable from null collection");
            return a_interactableCollection.LocateInteractable<TInteractable>(a_eventType: a_interactionType, a_identifier: a_identifier);
        }


        protected abstract void OnInvoke(TInteractable a_interactable, InteractableCollection a_invokedInteractables, InteractableCollection a_invokerInteractables);

        // Invoke Interaction with provided interactables
        public void Invoke(InteractableCollection a_interactableCollection, InteractionEventType a_interactionType = null,
            int a_identifier = int.MinValue, InteractableCollection a_invokerInteractables = null)
        {
            TInteractable interactable = LocateInteractable(a_interactableCollection, a_identifier, a_interactionType);

            if (interactable != null)
            {
                OnInvoke(interactable, a_interactableCollection, a_invokerInteractables);
            }
        }

        // Invoke Interaction with provided interactable
        public void Invoke(TInteractable a_interactable, InteractableCollection a_invokedInteractables = null, InteractableCollection a_invokerInteractables = null)
        {
            if (a_interactable != null)
                OnInvoke(a_interactable, a_invokedInteractables, a_invokerInteractables);
        }
    }
}
