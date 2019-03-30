namespace InteractionSystem
{
    // Base class to handle interactions of units.
    public abstract class InteractionBase<TInteractable> : IInteraction
        where TInteractable : class, IInteractable
        //where TIntercepter  : class, IInteractionIntercepterT<TInteractable>
    {
        //public abstract void Invoke(InteractableCollection a_unit, int a_identifier = 0);

        protected TInteractable LocateInteractable(InteractableCollection a_unit, int a_identifier)
        {
            return a_unit.LocateInteractable<TInteractable>(a_identifier: a_identifier);
        }


        protected abstract void OnInvoke(TInteractable a_interactable);

        public void Invoke(InteractableCollection a_unit, int a_identifier)
        {
            TInteractable resourceInteractable = LocateInteractable(a_unit, a_identifier);

            if (resourceInteractable != null)
                OnInvoke(resourceInteractable);
        }

        public void Invoke(TInteractable a_interactable)
        {
            if(a_interactable != null)
                OnInvoke(a_interactable);
        }

    }
}
