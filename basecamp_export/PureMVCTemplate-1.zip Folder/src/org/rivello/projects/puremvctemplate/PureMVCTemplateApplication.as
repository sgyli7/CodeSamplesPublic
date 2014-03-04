//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import mx.core.Application;
	import mx.events.FlexEvent;
	
	import org.puremvc.as3.patterns.observer.Notification;
	import org.rivello.containers.Layout;
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This is the code-behind for the core <code>Application<code> component-subclass.
	 * This allows the <code>Application<code> component-subclass to be as lean as possible
	 * Facilitating teamwork as the sole file that must be developer-specific is that file.
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
	public class PureMVCTemplateApplication extends Application
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		
		//PUBLIC CONSTANTS
		
		//PRIVATE
		/**
		 * A reference to the <code>ApplicationFacade<code>, the core of PureMVC development
		*/
		private var facade : ApplicationFacade = ApplicationFacade.getInstance();	
		
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		*/
		public function PureMVCTemplateApplication ()
		{
			//SUPER
			super(); 
			
			//VARIABLES
			
			//PROPERTIES
			layout = Layout.ABSOLUTE;
			
			//METHODS
			
			//EVENTS
			addEventListener(FlexEvent.CREATION_COMPLETE, onCreationComplete);

		}

		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		
		//PRIVATE	
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		//EVENT DISPATCHERS
		
		//EVENT HANDLERS
		/**
		 * Handles the FlexEvent.CREATION_COMPLETE event.  Sends the first communication
		 * to all observers, translating the FlexEvent to a PMVC Notification.  Future
		 * communication will be sent via 'SomeCorePMVCClass.sendNotication()' method
		 *
		 * @see SomeCorePMVCClass
		*/
		private function onCreationComplete (aEvent : FlexEvent) : void 
		{			
			ApplicationFacade.getInstance().startup( this );
		}
		
	}
}