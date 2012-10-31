package
{
	import flash.display.Sprite;
	import flash.events.Event;
	
	//USE A LOW FRAMERATE, SO WE CAN STUDY CLOSELY
	[SWF(frameRate="1")]
	public class MemoryLeakDemo extends Sprite
	{

		private var listOfDots_vector:Vector.<CustomDot>;
		public function MemoryLeakDemo()
		{
			//REPEAT SOME CODE EVERY SECOND
			addEventListener(Event.ENTER_FRAME, _onEnterFrame);
			
			//CREATE A LIST 
			listOfDots_vector = new Vector.<CustomDot>();
		}
		
		protected function _onEnterFrame(event:Event):void
		{
			//EVERY FRAME WE...
			
			//1. CREATE A NEW 'DOT' (A Red Circle Sprite)
			//MEMORY NOTE: 	'var' is a temporary variable. 
			//				So CustomDot has 0 (permanent) references
			var customDot : CustomDot = new CustomDot();
			
			//2. ADD TO THE STAGE
			//MEMORY NOTE: 	So CustomDot has 1 (permanent) reference; 'this'
			addChild(customDot);
			
			//2B. CREATE ANOTHER REFERENCE TO THE DOT
			//listOfDots_vector.push(customDot);
			
			//3. REMOVE TO THE STAGE
			//MEMORY NOTE: 	So CustomDot has 0 reference
			removeChild(customDot);
			
			//So...
			//THERE IS NO LEAK, UNLESS '2B' IS USED UNCOMMENTED
			//The GC will *mark* the 'customDot' as having 0 references and
			//The GC will *sweep* it away from memory.
			
		}
		
	}
}
