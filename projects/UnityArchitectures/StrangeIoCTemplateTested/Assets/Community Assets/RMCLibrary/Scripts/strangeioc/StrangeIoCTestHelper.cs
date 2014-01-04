using UnityEngine;
using strange.extensions.injector.api;
using strange.extensions.command.api;

public class StrangeIoCTestHelper {

	public static void ExecuteCommand <T> (IInjectionBinder aInjectionBinder) where T : ICommand
	{
		Debug.Log ("1*****Executed****");
		aInjectionBinder.Bind<ICommand>().To (typeof (T));
		ICommand command = aInjectionBinder.GetInstance<ICommand>() as ICommand;
		aInjectionBinder.Unbind<ICommand>();
		command.data = null;
		command.Execute(); 
		Debug.Log ("2*****Executed****");
	}
}
