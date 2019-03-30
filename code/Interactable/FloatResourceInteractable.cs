using System.Collections;
using System.Collections.Generic;


namespace InteractionSystem
{
    public class FloatResourceInteractable : ResourceInteractable<FloatResource>
    {
        public FloatResourceInteractable(FloatResource value) : base(value)
        {
        }

        public FloatResourceInteractable(float value) : base(new FloatResource(value))
        {
        }

        public override void Modify(FloatResource a_value)
        {
            Value.Value += a_value.Value;
            base.NotifyChange();
        }
    }
}
