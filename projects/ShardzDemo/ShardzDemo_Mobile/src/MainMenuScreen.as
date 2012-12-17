package
{
	import feathers.controls.Button;
	import feathers.controls.Header;
	import feathers.controls.Screen;
	
	import starling.events.Event;
	
	public class MainMenuScreen extends Screen
	{
		public static var ID:String = "MainMenuScreenNavigatorItem";

		private var _header:Header;

		private var _button:Button;
		public function MainMenuScreen()
		{
			super();
		}
		
		override protected function initialize () : void 
		{
			_header = new Header ();
			_header.title = "Main";
			addChild(_header);
			
			_button = new Button();
			_button.label = "Click";
			_button.addEventListener(Event.TRIGGERED, _onTriggered);
			addChild(_button);
		}
		override protected function draw () : void 
		{
			_header.width = actualWidth;
			_button.x = actualWidth/2 - _button.width/2;
			_button.y = ((actualHeight - _header.height)/2 + _header.height)/2;
			
		}
		
		private function _onTriggered(aEvent : Event):void
		{
			trace ("_onTriggered" + aEvent);
			dispatchEventWith(Event.COMPLETE);
			
			
		}
		
		
	}
}