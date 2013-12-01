/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.examples.signals.fun;

namespace strange.examples.signals
{
	//Not extending EventMediator anymore
	public class ExampleMediator2 : Mediator
	{
		[Inject]
		public ExampleView2 view{ get; set;}
		
		public override void OnRegister()
		{

			Debug.Log("ExampleMediator2 REGISTER");
		}
	}
}

