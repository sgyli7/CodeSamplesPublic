//Marks the right margin of code *******************************************************************
package flexunittests
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import flexunit.framework.TestCase;
	import flexunit.framework.TestSuite;
	
	import org.rivello.projects.puremvctemplate.PureMVCTemplateApplication;
	import org.rivello.projects.puremvctemplate.view.MainUI;
	import org.rivello.projects.puremvctemplate.view.MainUIMediator;
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This is the typical format of a simple multiline comment
	 * such as for a <code>TemplateClass<code> class.
	 * 
	 * <p><u>REVISIONS</u> : <br>
	 * <table width="500" cellpadding="0">
	 * <tr><th>Date</th><th>Author</th><th>Description</th></tr>
	 * <tr><td>MM/DD/YYYY</td><td>AUTHOR</td><td>Class created.</td></tr>
	 * <tr><td>MM/DD/YYYY</td><td>AUTHOR</td><td>DESCRIPTION.</td></tr>
	 * </table>
	 * </p>
	 * 
	 * @example Here is a code example.  
     * <listing version="3.0" >
	 * 	//Code example goes here.
	 * </listing>
	 *
     * <span class="hide">Any hidden comments go here.</span>
     *
	*/
	public class MainUIMediatorTestCase extends TestCase
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC

		//PRIVATE
		/**
		 * Contains the UI
		*/
		private var _mainUIMediator : MainUIMediator;		
		
		/**
		 * The full app, needed to access UI elements
		*/
		private var _application : PureMVCTemplate;		
		
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aMethodName_str The method name to test.
		 * @param param2 Describe param2 here.
		*/
		public function MainUIMediatorTestCase (aMethodName_str : String, aApplication : PureMVCTemplate)
		{
			//SUPER
			super (aMethodName_str); 
			_application = aApplication;

		}
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC STATIC
		/**
		 * Create a <code>TestSuite</code> with each method to test.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return TestSuite
		*/
  		public static function suite(aApplication : PureMVCTemplate) : TestSuite 
  		{
   			var testSuite:TestSuite = new TestSuite ();
   			testSuite.addTest( new MainUIMediatorTestCase ( "testInitialized", aApplication ) );
   			testSuite.addTest( new MainUIMediatorTestCase ( "testRenderMethods", aApplication ) );
   			return testSuite;
   		}
   		
   		
		//PUBLIC OVERRIDE
  		/**
  		 * Called before *each* test method
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/
   		override public function setUp () : void 
   		{
   			_mainUIMediator = new MainUIMediator ( _application.mainUI);
   		}
   		
  		/**
  		 * Called after *each* test method
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/
   		override public function tearDown () : void 
   		{
   			//'UNDO' the testCase's changes
			_mainUIMediator.destructor();
			_mainUIMediator = null;
   		}
   		
   		
   		//PUBLIC
		/**
		 * Perform Unit Test.  Purpose: Test the initial state.
		 * 
		 * The full list of assertions includes;
		 * 		<code>assertEquals()</code>
   		 *  	<code>assertFalse()</code>
   		 *  	<code>assertNotNull()</code>
   		 *  	<code>assertNotUndefined()</code>
   		 *  	<code>assertNull()</code>
   		 *  	<code>assertStrictlyEquals()</code>
   		 *  	<code>assertTrue()</code>
   		 *  	<code>assertUndefined()</code>
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/
  		public function testInitialized () : void 
  		{
  			var mainUI : MainUI = _mainUIMediator.getViewComponent() as MainUI;
   			assertEquals ( "", 	mainUI.textarea.text,	"");
   		}
   		
		/**
		 * Perform Unit Test.  Purpose: Test the render methods.
		 * 
		 * The full list of assertions includes;
		 * 		<code>assertEquals()</code>
   		 *  	<code>assertFalse()</code>
   		 *  	<code>assertNotNull()</code>
   		 *  	<code>assertNotUndefined()</code>
   		 *  	<code>assertNull()</code>
   		 *  	<code>assertStrictlyEquals()</code>
   		 *  	<code>assertTrue()</code>
   		 *  	<code>assertUndefined()</code>
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/
  		public function testRenderMethods () : void 
  		{
  			var mainUI : MainUI = _mainUIMediator.getViewComponent() as MainUI;
  			
  			_mainUIMediator.setTitleText("hi");
  			
   			assertEquals ( "", 	mainUI.panel.title,	"hi");
   		}

   		
		//PRIVATE	
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		
		
	}
}