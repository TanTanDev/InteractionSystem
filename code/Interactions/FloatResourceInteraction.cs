using System;
using System.Collections;
using System.Collections.Generic;

namespace InteractionSystem
{
    public class FloatResourceInteraction : ResourceInteraction<FloatResource, FloatResourceInteractable>
    {
        public FloatResourceInteraction(float value) : base(new FloatResource(value))
        {
        }
    }
}
