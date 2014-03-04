//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.vo
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
	 * This <code>value object (VO)</code> contains the phrases for UI display 
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
	public class Phrases	
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		/**
		 * Button label text before interactivity.
		*/		
		public var buttonLabel_str : String;
		
		/**
		 * Text display after hitting the button.
		*/		
		public var message_str : String;
		
		//PUBLIC CONSTANTS
		
		//PRIVATE
		
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * The constructor accepts the full list of phrase values to store.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aButtonLabel_str Button label text before interactivity.
		 * @param aMessage_str Text display after hitting the button.
		*/
		public function Phrases ( aButtonLabel_str : String, aMessage_str : String )
		{
			//SUPER
			super(); 
			
			//VARIABLES
			
			//PROPERTIES
			buttonLabel_str 	= aButtonLabel_str;
			message_str 		= aMessage_str;	
			
			//METHODS
			
			//EVENTS

		}
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		
		//PRIVATE	
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		//EVENT DISPATCHER
		
		//EVENT HANDLERS

		
	}
}
