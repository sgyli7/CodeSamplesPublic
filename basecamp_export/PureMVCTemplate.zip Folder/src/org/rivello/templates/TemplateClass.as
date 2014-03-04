//Marks the right margin of code *******************************************************************
package org.rivello.templates
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import flash.events.Event;
	import flash.events.EventDispatcher;
	
	
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
	public class TemplateClass extends EventDispatcher implements TemplateInterface
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		/**
		 * This is the typical format of a simple comment for sample.
		 * 
		*/		
		public function get sample () 					: String 	{ 	return _sample_str; 		}
		public function set sample (aValue : String) 	: void 		{ 	_sample_str = aValue; 		}
		private var _sample_str : String;
		
		
		//PUBLIC CONST
		/**
		 * This is the typical format of a simple comment for <code>PUBLIC_STATIC_CONSTANT</code>.
		 * 
		 * @default PUBLIC_STATIC_CONSTANT 
		*/
		public static const PUBLIC_STATIC_CONSTANT : String = "PUBLIC_STATIC_CONSTANT";
		
		
		//PRIVATE
		/**
		 * This is the typical format of a simple comment for _sample2_str.
		*/
		private var _sample2_str : String;		
		
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * This is the typical format of a simple multiline comment
		 * such as for a <code>TemplateClass</code> constructor.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param param1 Describe param1 here.
		 * @param param2 Describe param2 here.
		*/
		public function TemplateClass ()
		{
			//SUPER
			super (); 
			
			//VARIABLES
			var localSample_str : String = TemplateClass.PUBLIC_STATIC_CONSTANT;
			
			//PROPERTIES
			_sample_str = TemplateClass.PUBLIC_STATIC_CONSTANT;
			_sample2_str = TemplateClass.PUBLIC_STATIC_CONSTANT;
			
			//METHODS
			sampleMethod (_sample_str, _sample_str);
			
			//EVENTS
			addEventListener (Event.INIT, onInit);

			

		}
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		/**
		 * This is the typical format of a simple multiline comment
		 * such as for a <code>sampleMethod</code> method.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param param1 Describe param1 here.
		 * @param param2 Describe param2 here.
		 * 
		 * @return void
		*/
		public function sampleMethod (aArgument_str : String, aArgument2_str : String) : void 
		{
			sampleMethod2 (aArgument_str, aArgument2_str);
		}
		
		
		//PRIVATE	
		/**
		 * This is the typical format of a simple multiline comment
		 * such as for a <code>sampleMethod</code> method.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param param1 Describe param1 here.
		 * @param param2 Describe param2 here.
		 * 
		 * @return void
		*/
		private function sampleMethod2 (aArgument_str : String, aArgument2_str : String) : void 
		{
			dispatchSample ();	
		}
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		//Event Dispatchers
		/**
		 * Dispatches the event: Event.SAMPLE
		*/
		[Event(name="SAMPLE", type="flash.events.Event")]
		private function dispatchSample () : void
		{
			//dispatchEvent ( new Event (Event.SAMPLE) );			
		}

		
		//Event Handlers
		/**
		 * Handles the event: Event.INIT
		*/
		private function onInit (aEvent : Event) : void 
		{				

		}

		
	}
}