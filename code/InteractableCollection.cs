using System.Collections.Generic;
using System.Linq;

namespace InteractionSystem
{
    public class InteractableCollection
    {
        // integer identifier mapped to interactable
        protected Dictionary<int, IInteractable> m_interactables;
        protected Dictionary<int, IInteractionIntercepter> m_interceptors;
        protected List<int> m_registeredIdentifiers;


        public InteractableCollection()
        {
            m_interactables = new Dictionary<int, IInteractable>();
            m_registeredIdentifiers = new List<int>(4);
            m_interceptors = new Dictionary<int, IInteractionIntercepter>();
        }

        public InteractableCollection(Dictionary<int, IInteractable> a_interactables)
        {
            m_interactables = a_interactables;
            m_registeredIdentifiers = new List<int>(4);
            m_interceptors = new Dictionary<int, IInteractionIntercepter>();
        }

        private int GenerateUniqueIdentifier()
        {
            int uniqueId;
            if (m_registeredIdentifiers.Count > 0)
                uniqueId = m_registeredIdentifiers.Max() + 1;
            else
                uniqueId = 0;
            return uniqueId;
        }

        // Returns unique identifier incase one wasn't provided
        public int AddInteractable(IInteractable a_interactable, InteractableTypeReference a_identifier = null)
        {
            int finalIdentifier;
            if (a_identifier == null)
                finalIdentifier = finalIdentifier = GenerateUniqueIdentifier();
            else
                finalIdentifier = a_identifier.GUID;

    #if DEBUG
            if (m_interactables.ContainsKey(finalIdentifier))
            {
                throw new System.InvalidOperationException("identifier already registered: " + finalIdentifier);
            }
    #endif

            m_interactables.Add(finalIdentifier, a_interactable);
            m_registeredIdentifiers.Add(finalIdentifier);
            return finalIdentifier;
        }

        // Returns unique identifier incase one wasn't provided
        public int AddIntercepter(IInteractionIntercepter a_intercepter, InteractableTypeReference a_identifier = null)
        {
            int finalIdentifier;
            if (a_identifier == null)
                finalIdentifier = finalIdentifier = GenerateUniqueIdentifier();
            else
                finalIdentifier = a_identifier.GUID;

#if DEBUG
            if (m_interactables.ContainsKey(finalIdentifier))
            {
                throw new System.InvalidOperationException("identifier already registered: " + finalIdentifier);
            }
#endif

            m_interceptors.Add(finalIdentifier, a_intercepter);
            m_registeredIdentifiers.Add(finalIdentifier);
            return finalIdentifier;
        }

        #region Interactable Locators

        public T LocateInteractable<T>(System.Type a_type = null, int a_identifier = int.MinValue) where T: class, IInteractable
        {
            System.Type findType = a_type;
            if (findType == null)
                findType = typeof(T);

            KeyValuePair<int, IInteractable> interactablePair;
            // Filter by only type or ALSO identifier
            if (a_identifier == int.MinValue)
                interactablePair = m_interactables.FirstOrDefault(p => findType == p.Value.GetType());
            else
                interactablePair = m_interactables.FirstOrDefault(p => findType == p.Value.GetType() && p.Key == a_identifier);
            return interactablePair.Value as T;
        }

        public List<T> LocateInteractables<T>(System.Type a_type, int a_identifier = int.MinValue) where T : class, IInteractable
        {
            // Get all IInteractables that have the correct type
            List<KeyValuePair<int, IInteractable>> interactablePairs;

            // Filter by only type or ALSO identifier
            if(a_identifier == int.MinValue)
                interactablePairs = m_interactables.Where((p) => (a_type == p.Value.GetType())).ToList();
            else
                interactablePairs = m_interactables.Where((p) => (a_type == p.Value.GetType() && p.Key == a_identifier)).ToList();

            // Build list of IInteractable instead of pair<int, IInteractable>
            List<IInteractable> interactables = new List<IInteractable>(interactablePairs.Count);
            interactablePairs.ForEach((pair) => { interactables.Add(pair.Value); });
            return interactables as List<T>;
        }
        #endregion

        // Returns an intercepter that intercepts the specified IInteractable type
        public T LocateIntercepter<T>(IInteraction interactable, int a_identifier = int.MinValue)
            where T: class, IInteractionIntercepter
        {
            KeyValuePair<int, IInteractionIntercepter> pair;

            // Filter by only type or ALSO identifier
            if (a_identifier == int.MinValue)
                pair = m_interceptors.FirstOrDefault(p=> interactable.GetType() == p.Value.GetInteractionType());
            else
                pair = m_interceptors.FirstOrDefault(p => interactable.GetType() == p.Value.GetInteractionType() && a_identifier == p.Key);
            return pair.Value as T;
        }

    }
}
