package
{
	import flash.display.Sprite;
	import flash.system.MessageChannel;
	import flash.system.Worker;
	
	public class CustomWorker extends Sprite
	{
		private var wtm:MessageChannel;
		private var mtw:MessageChannel;
		public function CustomWorker()
		{
			super();
			
			wtm = Worker.current.getSharedProperty("wtm");
			mtw = Worker.current.getSharedProperty("mtw");
			
			wtm.send("from worker!");
		}
	}
}