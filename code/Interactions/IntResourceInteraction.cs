
namespace InteractionSystem
{
    public class IntResourceInteraction : ResourceInteraction<IntResource, IntResourceInteractable>
    {
        public IntResourceInteraction(int value) : base(new IntResource(value))
        {
        }
    }
}
