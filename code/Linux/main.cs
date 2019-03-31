using System;
using InteractionSystem;

namespace LinuxSandbox
{
	class MainClass
	{
		static void Main()
		{
			InteractableCollection interactableCollection = new InteractableCollection();
			// Idle attack
			var idleHealthInteraction = new FloatResourceInteraction(-1.0f);
			// health
			var healthInteractable = new FloatResourceInteractable(100.0f);
			int healthID = interactableCollection.AddInteractable(healthInteractable);
			healthInteractable.OnResourceChanged += (d) => {Console.Write("on health changed! " + d);};
			idleHealthInteraction.Invoke(interactableCollection, healthID);
			Console.WriteLine("Hello");
		}
	}
}
