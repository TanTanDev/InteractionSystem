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
        [SerializeField] private TResource m_modifyResourceBy;

        public ResourceInteraction(TResource a_modifyResourceBy)
        {
            SetModifyResourceBy(a_modifyResourceBy);
        }

        public void SetModifyResourceBy(TResource a_modifyResourceBy)
        {
            m_modifyResourceBy = a_modifyResourceBy;
        }

        public TResource GetModifyResourceBy()
        {
            return m_modifyResourceBy;
        }

        protected override void OnInvoke(TResourceInteractable resourceInteractable)
        {
            resourceInteractable.Modify(m_modifyResourceBy);

        }
    }
}
