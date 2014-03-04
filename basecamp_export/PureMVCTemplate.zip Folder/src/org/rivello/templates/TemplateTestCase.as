//Marks the right margin of code *******************************************************************
package org.rivello.templates
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import flexunit.framework.TestCase;
	import flexunit.framework.TestSuite;
	
	
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
	public class TemplateTestCase extends TestCase
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------

		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aMethodName_str The method name to test.
		 * @param param2 Describe param2 here.
		*/
		public function TemplateTestCase(aMethodName_str : String)
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
   			testSuite.addTest( new TemplateTestCase ( "testSampleTest" ) );
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
   			trace ("setUp");
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
   			trace ("tearDown");
   		}
   		
   		
   		//PUBLIC
		/**
		 * Perform Unit Test.  Purpose: 
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
  		public function testSampleTest () : void 
  		{
   			assertEquals( "0 Should Equal 0", 0, 0 );
   		}
   		
		

   		
		//PRIVATE	
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		
		
	}
}