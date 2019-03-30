
namespace InteractionSystem
{
    public abstract class ResourceInteractable<TResource> : IInteractable
        where TResource: IResource
    {
        public TResource Value;
        public System.Action<TResource> OnResourceChanged;

        public ResourceInteractable(TResource value)
        {
            Value = value;
        }

        abstract public void Modify(TResource value);

        protected void NotifyChange()
        {
            if (OnResourceChanged != null)
                OnResourceChanged.Invoke(Value);
        }
    }
}
