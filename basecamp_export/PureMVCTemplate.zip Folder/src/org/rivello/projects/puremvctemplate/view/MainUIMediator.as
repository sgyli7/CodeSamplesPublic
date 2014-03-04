//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.view 
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import flash.events.Event;
	
	import mx.core.UIComponent;
	
	import org.puremvc.as3.interfaces.IMediator;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import org.puremvc.as3.patterns.observer.Notification;
	import org.rivello.projects.puremvctemplate.ApplicationFacade;
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
	public class MainUIMediator extends Mediator implements IMediator
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		/**
		 * Return a named, typed reference to <code>viewComponent</code> to make API clearly understandable.
		*/		
        protected function get mainUI () : MainUI { return viewComponent as MainUI; }
				
		//PUBLIC CONSTANTS
		/**
		 * Set <code>NAME</code> identical to the class name for reference caching.
		 * 
		 * @default MainUIMediator 
		*/
		public static const NAME : String = "MainUIMediator";
		
		//PRIVATE
		/**
		 * Reference to an existing <code>Proxy</code>.
		*/
		private var phrasesProxy : PhrasesProxy;
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * Recieve the sole <code>UIComponent</code> with which this Mediator liaises.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aViewComponent The sole <code>UIComponent</code> with which this Mediator liaises.
		*/		
		public function MainUIMediator ( aViewComponent : UIComponent )		
		{
						
			//SUPER
			 super ("MainUIMediator", aViewComponent ); 
			 
			//ECHO
			//race ("MainUIMediator");
			
			//VARIABLES
			
			//PROPERTIES
			phrasesProxy = facade.retrieveProxy(PhrasesProxy.NAME) as PhrasesProxy;
			
			//METHODS
			
			//EVENTS
			mainUI.addEventListener( MainUI.MAIN_BUTTON_CLICK, onFillTextWithAPhraseButtonClick );
            
		}
		
		
		//--------------------------------------
		//  Destructor
		//--------------------------------------
		/**
		 * Elegantly degrade when instance is longer needed. 
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param void
		*/		
		public function destructor () : void		
		{
						
			//ECHO
			//race ("MainUIMediator.destructor()");
			
			//VARIABLES
			
			//PROPERTIES
			
			//METHODS
			onStartup(); //'restart' class
			
			//EVENTS
			mainUI.removeEventListener( MainUI.MAIN_BUTTON_CLICK, onFillTextWithAPhraseButtonClick );
            
		}
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC
		/**
		 * Returns the array of <code>Notification</code> name strings
		 * which this class will observe.
		 *
		 * <span class="hide">Any hidden comments go here.</span>

		 * @return Array
		*/
        override public function listNotificationInterests() : Array 
        {
            return [ ApplicationFacade.APPLICATION_STARTUP ];
        }
        
		/**
		 * Handles when an observed <code>Notification</code> arrives.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aNotification The notification to arrive.
		 * 
		 * @return void
		*/
        override public function handleNotification( aNotification : INotification ) : void 
        {
            switch (  aNotification.getName() ) {
                case ApplicationFacade.APPLICATION_STARTUP:
                	onStartup();
					break;
            }
        }
        
		/**
		 * Set the message text
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aMessage_str The string to be displayed.
		 * 
		 * @return void
		*/ 
        public function setMessageText (aMessage_str : String ) : void 
        {
        	mainUI.textarea.htmlText = aMessage_str;
        }
        
 		/**
		 * Set the button's label
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aMessage_str The string to be displayed.
		 * 
		 * @return void
		*/ 
        public function setButtonLabelText (aMessage_str : String ) : void 
        {
        	mainUI.button.label = aMessage_str;
        }
				
		//PRIVATE	
		
		//--------------------------------------
		//  Events
		//--------------------------------------		
		//EVENT DISPATCHER

		//EVENT HANDLERS
		/**
		 * Handles the event: ApplicationFacade.APPLICATION_STARTUP.
		*/
      	private function onStartup( aNotification : Notification = null ) : void
      	{    		
			setButtonLabelText (phrasesProxy.buttonLabel);
			setMessageText ("");
		}	
				
		/**
		 * Handles the event: MainUI.MAIN_BUTTON_CLICK.
		*/
      	private function onFillTextWithAPhraseButtonClick( aEvent : Event = null ) : void
      	{      		
      		trace ("onFillTextWithAPhraseButtonClick");
      		sendNotification(ApplicationFacade.FILL_TEXT_WITH_A_PHRASE,this);
		}

		
	}
}
