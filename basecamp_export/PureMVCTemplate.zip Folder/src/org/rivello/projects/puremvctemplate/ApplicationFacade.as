//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate
{
	//-------------------------------------
	//  Imports
	//--------------------------------------
    import org.puremvc.as3.patterns.facade.Facade;
    import org.rivello.projects.puremvctemplate.controller.ApplicationAwaitFirstInteractivityCommand;
    import org.rivello.projects.puremvctemplate.controller.ApplicationStartupCommand;
    import org.rivello.projects.puremvctemplate.controller.FillTextWithAPhraseCommand;

	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This <code>Facade</code> subclass contains all the <code>Notification</code> names
	 * and the registration of some of those to the appropriate <code>Command</code> classes.
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
    public class ApplicationFacade extends Facade
    {		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS

		//PUBLIC CONSTANTS
		/**
		 * Defines a <code>Notification</code>: When the application is first loading up.
		 * 
		 * @default APPLICATION_STARTUP 
		*/
		public static const APPLICATION_STARTUP : String 					= "APPLICATION_STARTUP";		
		
		/**
		 * Defines a <code>Notification</code>: When the application is first 'touched' by UX
		 * 
		 * @default APPLICATION_AWAIT_FIRST_INTERACTIVITY 
		*/
		public static const APPLICATION_AWAIT_FIRST_INTERACTIVITY : String 	= "APPLICATION_AWAIT_FIRST_INTERACTIVITY";		
		
		/**
		 * Defines a <code>Notification</code>: When the UI should show the phrase.
		 * 
		 * @default FILL_TEXT_WITH_A_PHRASE 
		*/
		public static const FILL_TEXT_WITH_A_PHRASE : String 				= "FILL_TEXT_WITH_A_PHRASE";		
						
		//PRIVATE	
		
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		/**
		 * Returns a reference to this <code>ApplicationFacade</code> instance.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return ApplicationFacade
		*/
        public static function getInstance( ) : ApplicationFacade 
        {
            if ( instance == null ) instance = new ApplicationFacade( );
            return instance as ApplicationFacade;
        }
        
		/**
		 * Override required to map each <code>Notification</code> name to 
		 * a <code>Command</code> in the <code>Controller</code>.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return ApplicationFacade
		*/
        override protected function initializeController( ) : void 
        {
            super.initializeController(); 
            
            //Register Notifications to Commands, See explainations near CONST's above       
            registerCommand( APPLICATION_STARTUP, ApplicationStartupCommand );
            registerCommand( APPLICATION_AWAIT_FIRST_INTERACTIVITY, ApplicationAwaitFirstInteractivityCommand );
            registerCommand( FILL_TEXT_WITH_A_PHRASE, FillTextWithAPhraseCommand );
           
        }		
		
		/**
		 * Called within the FlexEvent.CREATION_COMPLETE of the app.  
		 * This call is the primary bridge between Flex and PMVC that 
		 * kicks off the PMVC environment.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return ApplicationFacade
		*/
        public function startup( app : PureMVCTemplateApplication ):void
        {
            sendNotification( APPLICATION_STARTUP, app );
        }
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		
		
	}
}
