package
{
	import com.rmc.projects.lockbox.LockBoxTestCase;
	
	import flash.display.Sprite;
	import flash.display.Stage;
	
	import Array;
	
	import flexunit.flexui.FlexUnitTestRunnerUIAS;
	
	public class FlexUnitApplication extends Sprite
	{
		public static var instance:FlexUnitApplication;
		public function FlexUnitApplication()
		{
			onCreationComplete();
			FlexUnitApplication.instance = this;
		}
		
		private function onCreationComplete():void
		{
			var testRunner:FlexUnitTestRunnerUIAS=new FlexUnitTestRunnerUIAS();
			testRunner.portNumber=8765; 
			this.addChild(testRunner); 
			testRunner.runWithFlexUnit4Runner(currentRunTestSuite(), "LockBoxDemo");
		}
		
		public function currentRunTestSuite():Array
		{
			var testsToRun:Array = new Array();
			testsToRun.push(com.rmc.projects.lockbox.LockBoxTestCase);
			return testsToRun;
		}
	}
}