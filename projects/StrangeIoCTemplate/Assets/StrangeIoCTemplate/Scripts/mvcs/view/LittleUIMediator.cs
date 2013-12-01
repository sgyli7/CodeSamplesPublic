/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.examples.signals.fun;
using strange.examples.signals.blah;

namespace strange.examples.signals.fun
{
	//Not extending EventMediator anymore
	public class LittleUIMediator : Mediator
	{
		[Inject]
		public LittleUI view{ get; set;}
		
		public override void OnRegister()
		{
			
			Debug.Log("LittleUIMediator REGISTER");
		}
	}
}



