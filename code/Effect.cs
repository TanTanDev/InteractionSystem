using System.Collections.Generic;

namespace InteractionSystem
{
    public class Effect
    {
        private List<IInteraction> m_onEquip;
        private List<IInteraction> m_onDeEquip;
        private List<IInteraction> m_onUpdate;
        private IEffectRemoval m_effectRemoval;

        public Effect(IEffectRemoval a_effectRemoval)
        {
            m_onEquip = new List<IInteraction>();
            m_onDeEquip = new List<IInteraction>();
            m_onUpdate = new List<IInteraction>();
            m_effectRemoval = a_effectRemoval;
        }

        public void AddOnEquipInteraction(IInteraction a_onEquipInteraction)
        {
            m_onEquip.Add(a_onEquipInteraction);
        }

        public void AddOnDeEquipInteraction(IInteraction a_onDeEquipInteraction)
        {
            m_onDeEquip.Add(a_onDeEquipInteraction);
        }

        public void TriggerOnEquip(InteractableCollection a_interactableCollection,
            InteractableCollection a_invokerInteractableCollection,
            InteractionEventType a_eventType = null,
            int a_identifier = int.MinValue)
        {
            for (int i = 0; i < m_onEquip.Count; i++)
                m_onEquip[i].Invoke(a_interactableCollection, a_eventType, a_identifier, a_invokerInteractableCollection);
        }

        public void TriggerOnDeEquip(InteractableCollection a_interactableCollection,
            InteractableCollection a_invokerInteractableCollection,
            InteractionEventType a_eventType = null,
            int a_identifier = int.MinValue)
        {
            for (int i = 0; i < m_onDeEquip.Count; i++)
                m_onDeEquip[i].Invoke(a_interactableCollection, a_eventType, a_identifier, a_invokerInteractableCollection);
        }

        public void TriggerOnUpdate(InteractableCollection a_interactableCollection,
            InteractableCollection a_invokerInteractableCollection,
            InteractionEventType a_eventType = null,
            int a_identifier = int.MinValue)
        {
            for (int i = 0; i < m_onUpdate.Count; i++)
                m_onUpdate[i].Invoke(a_interactableCollection, a_eventType, a_identifier, a_invokerInteractableCollection);

            m_effectRemoval.Update();
        }

        public bool ShouldBeRemoved()
        {
            return m_effectRemoval.ShouldBeRemoved();
        }
    }
}
