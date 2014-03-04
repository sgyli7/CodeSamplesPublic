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
	 * This <code>value object (VO)</code> contains the phrases for UI display 
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
	public class PhrasesVO	
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		
		//PUBLIC
		/**
		 * Title for application
		*/		
		public var title_str : String;
		
		/**
		 * Button label text before interactivity.
		*/		
		public var buttonLabel_str : String;
		

		
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
		public function PhrasesVO ( aTitle_str : String, aButtonLabel_str : String )
		{
			//SUPER
			super(); 
			
			//VARIABLES
			
			//PROPERTIES
			title_str			= aTitle_str;
			buttonLabel_str 	= aButtonLabel_str;
			
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
