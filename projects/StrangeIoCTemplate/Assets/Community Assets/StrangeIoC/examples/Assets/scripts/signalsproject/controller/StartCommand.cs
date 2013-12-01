/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.examples.signals.fun;
using strange.examples.signals.blah;
using com.rmc.projects.strangeioc_template.view;

namespace strange.examples.signals
{
	public class StartCommand : Command
	{
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		public override void Execute()
		{
			GameObject go = new GameObject();
			go.name = "ExampleView";
			go.AddComponent<ExampleView>();
			go.transform.parent = contextView.transform;

			GameObject go2 = new GameObject();
			go2.name = "ExampleView2";
			go2.AddComponent<ExampleView2>();
			go2.transform.parent = contextView.transform;

			
			GameObject go3 = new GameObject();
			go3.name = "blahhh";
			go3.AddComponent<LittleUI>();
			go3.transform.parent = contextView.transform;

			GameObject go4 = new GameObject();
			go4.name = "who";
			go4.AddComponent<CustomViewUI>();
			go4.transform.parent = contextView.transform;

		}
	}
}

