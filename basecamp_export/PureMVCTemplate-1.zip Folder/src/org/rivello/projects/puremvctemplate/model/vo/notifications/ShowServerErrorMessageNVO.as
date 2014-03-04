//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.model.vo.notifications
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
	 * A <code>Notification Value Object(VO)</code> holds info to modify a notification
	 * 
	 * <p><u>REVISIONS</u> : <br>
	 * <table width="500" cellpadding="0">
	 * <tr><th>Date</th><th>Author</th><th>Description</th></tr>
	 * <tr><td>06/06/08</td><td>Samuel Asher Rivello</td><td>Class created.</td></tr>
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
	public class ShowServerErrorMessageNVO	
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		/**
		 * Message to show
		 * 
		*/		
		public function get message () 					: String 	{ 	return _message_str; 		}
		public function set message (aValue : String) 	: void 		{ 	_message_str = aValue; 		}
		private var _message_str : String;
		
		
		//PUBLIC
				
				
		//PUBLIC CONSTANTS
		
		
		//PRIVATE
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aMessage_str Text display
		*/
		public function ShowServerErrorMessageNVO (aMessage_str : String)
		{
			//SUPER
			super(); 
			
			//VARIABLES
			
			//PROPERTIES
			_message_str = aMessage_str;
			
			//METHODS
			
			//EVENTS

		}


		
	}
}
