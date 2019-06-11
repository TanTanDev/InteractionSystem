namespace InteractionSystem
{
    // DANGER, you are about to enter the cave of amazing code.
    [System.Serializable]
    public abstract class ResourceInteraction<TResource, TResourceInteractable> : 
        // Base class
        InteractionBase<TResourceInteractable>
        where TResource : IResource
        where TResourceInteractable : ResourceInteractable<TResource>
    {
        public TResource ModifyResourceBy;

        public ResourceInteraction(TResource a_modifyResourceBy)
        {
            SetModifyResourceBy(a_modifyResourceBy);
        }

        public void SetModifyResourceBy(TResource a_modifyResourceBy)
        {
            ModifyResourceBy = a_modifyResourceBy;
        }

        public TResource GetModifyResourceBy()
        {
            return ModifyResourceBy;
        }

        protected override void OnInvoke(TResourceInteractable resourceInteractable,
            InteractableCollection a_invokedInteractables,
            InteractableCollection a_invokerInteractables)
        {
            resourceInteractable.Modify(ModifyResourceBy);

        }
    }
}
