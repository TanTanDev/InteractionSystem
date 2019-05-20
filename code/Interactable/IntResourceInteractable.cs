using System.Collections;
using System.Collections.Generic;


namespace InteractionSystem
{
    public class IntResourceInteractable : ResourceInteractable<IntResource>
    {
        public IntResourceInteractable(IntResource value) : base(value)
        {
        }

        public IntResourceInteractable(int value) : base(new IntResource(value))
        {
        }

        public override void Modify(IntResource a_value)
        {
            Value.Value += a_value.Value;
            base.NotifyChange();
        }
    }
}
