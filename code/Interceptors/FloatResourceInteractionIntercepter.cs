namespace InteractionSystem
{
    public class FloatResourceInteractionIntercepter : InteractionIntercepterBase<FloatResourceInteraction, FloatResourceInteractable>
    {
        public override void Intercept(FloatResourceInteraction a_interceptedInteraction, FloatResourceInteractable a_interactable)
        {
            FloatResource floatResource = a_interceptedInteraction.GetModifyResourceBy();
            FloatResource newValue = new FloatResource(floatResource.Value*0.5f);
            a_interceptedInteraction.SetModifyResourceBy(newValue);
            a_interceptedInteraction.Invoke(a_interactable);
            a_interceptedInteraction.SetModifyResourceBy(floatResource);
        }


    }

}
