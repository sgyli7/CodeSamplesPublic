//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate
{
	//-------------------------------------
	//  Imports
	//--------------------------------------
    import org.puremvc.as3.patterns.facade.Facade;
    import org.rivello.projects.puremvctemplate.controller.ApplicationStartupCommand;
    import org.rivello.projects.puremvctemplate.controller.AwaitFirstInteractivityCommand;
    import org.rivello.projects.puremvctemplate.controller.DoLoadMessageCommand;
    import org.rivello.projects.puremvctemplate.controller.ShowMessageCommand;
    import org.rivello.projects.puremvctemplate.controller.ShowServerErrorCommand;

	
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
		 * @default AWAIT_FIRST_INTERACTIVITY 
		*/
		public static const AWAIT_FIRST_INTERACTIVITY : String 	= "AWAIT_FIRST_INTERACTIVITY";		
		
		/**
		 * Defines a <code>Notification</code>: When to display the message.
		 * 
		 * @default DO_LOAD_MESSAGE 
		*/
		public static const DO_LOAD_MESSAGE : String = "DO_LOAD_MESSAGE";	
		
		
		/**
		 * SUCCESS: Defines a <code>Notification</code>: Display server message
		 * 
		 * @default SHOW_MESSAGE 
		*/
		public static const SHOW_MESSAGE : String = "SHOW_MESSAGE";
		
		/**
		 * FAILURE: Defines a <code>Notification</code>: Display any server errors
		 * 
		 * @default SHOW_SERVER_ERROR 
		*/
		public static const SHOW_SERVER_ERROR : String = "SHOW_SERVER_ERROR";		
		
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
            
            //
            registerCommand( DO_LOAD_MESSAGE, 	DoLoadMessageCommand );
            registerCommand( SHOW_MESSAGE, 		ShowMessageCommand );
            registerCommand( SHOW_SERVER_ERROR, ShowServerErrorCommand );
            
           
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

	}
}
