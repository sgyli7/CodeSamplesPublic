//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.model.vo
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
	 * This <code>value object (VO)</code> contains the Message from the server
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
	public class MessageVO	
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		
		//PUBLIC
		/**
		 * Server Return text
		*/		
		public var returnText_str : String;
				
		//PUBLIC CONSTANTS
		
		//PRIVATE
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		*/
		public function MessageVO ()
		{
			//SUPER
			super(); 
			
			//VARIABLES
			
			//PROPERTIES
			returnText_str = "";
			
			//METHODS
			
			//EVENTS

		}


		
	}
}
