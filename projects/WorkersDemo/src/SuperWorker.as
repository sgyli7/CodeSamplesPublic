package 
{
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.system.MessageChannel;
	import flash.system.Worker;
	import flash.system.WorkerDomain;
	
	public class SuperWorker extends Sprite
	{
		
		private var worker:Worker;
		public var wtm:MessageChannel;
		
		public var mtw:MessageChannel;
		public var state:String;
		
		//
		public function SuperWorker()
		{
			
			worker = WorkerDomain.current.createWorker(Worker.current);
			
			wtm = worker.createMessageChannel(Worker.current);
			mtw = Worker.current.createMessageChannel(worker);
			
			worker.setSharedProperty("wtm", wtm);
			worker.setSharedProperty("mtw", mtw);
			
			wtm.addEventListener(Event.CHANNEL_MESSAGE, onMessage)
			
			trace ("s: " + worker.state);
			worker.start();
			trace ("s: " + worker.state);
		}
		
		protected function onMessage(aEvent:Event):void
		{
			trace ("onMessage2 : " + wtm.receive());
			
		}
		
		
		public function start():void
		{
			// TODO Auto Generated method stub
			
		}
	}
}











