package com.rmc.projects.superworker
{
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.system.Worker;
	import flash.system.WorkerDomain;

	public class SuperWorkerDemo extends Sprite
	{
		private var superWorker:*
			
			;
		
		public function SuperWorkerDemo()
		{
			superWorker = WorkerDomain.current.createWorker(Workers.SuperWorker);
			
			superWorker.addEventListener(Event.CHANNEL_MESSAGE, onMessage)
			trace ("s: " + superWorker.state);
			superWorker.start();
			trace ("s: " + superWorker.state);
		}
		
		protected function onMessage(aEvent:Event):void
		{
			trace ("onMessage : " + superWorker.wtm.receive());
			
			
		}
	}
}











