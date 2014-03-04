//Marks the right margin of code *******************************************************************
package flexunittests
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import flexunit.framework.TestCase;
	import flexunit.framework.TestSuite;
	
	import org.rivello.projects.puremvctemplate.model.PhrasesProxy;
	
	
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
	public class PhrasesProxyTestCase extends TestCase
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC

		//PRIVATE
		/**
		 * Contains all diplay text for aplication
		*/
		private var _phrasesProxy : PhrasesProxy;		
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aMethodName_str The method name to test.
		 * @param param2 Describe param2 here.
		*/
		public function PhrasesProxyTestCase(aMethodName_str : String)
		{
			//SUPER
			super (aMethodName_str); 

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
  		public static function suite() : TestSuite 
  		{
   			var testSuite:TestSuite = new TestSuite ();
   			testSuite.addTest( new PhrasesProxyTestCase ( "testDefaultValues" ) );
   			testSuite.addTest( new PhrasesProxyTestCase ( "testGettersSetters" ) );
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
   			_phrasesProxy = new PhrasesProxy ();
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
  		public function testDefaultValues () : void 
  		{
			assertEquals ( "", 	_phrasesProxy.title,		"PureMVCTemplate");
   			assertEquals ( "", 	_phrasesProxy.buttonLabel,	"Click To Load Message!");
   		}
   		
		/**
		 * Perform Unit Test.  Purpose: Test get/set methods
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
  		public function testGettersSetters () : void 
  		{
  			_phrasesProxy.title 		= "test2";
  			_phrasesProxy.buttonLabel 	= "test1";
  			
  			assertEquals ( "", 	_phrasesProxy.title,		"test2");
   			assertEquals ( "", 	_phrasesProxy.buttonLabel,	"test1");
   			
   		}

   		
		//PRIVATE	
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		
		
	}
}