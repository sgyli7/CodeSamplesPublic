//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.controller
{
	//--------------------------------------
	//  Imports
	//--------------------------------------	
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	import org.rivello.projects.puremvctemplate.model.MessageProxy;
	import org.rivello.projects.puremvctemplate.view.MainUIMediator;	
    
    
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * Show a message
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
    public class ShowMessageCommand extends SimpleCommand
    {        
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		/**
		 * 
		 * Execute the command.
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aNotification The <code>INotification</code> accompanying the command.
		 * 
		 * return void
		 * 
		*/	
        override public function execute( aNotification : INotification ):void
        {
			
        	//ECHO
        	trace ("ShowMessageCommand.execute()");
            
            //VARIABLES
			var messageProxy : MessageProxy = facade.retrieveProxy(MessageProxy.NAME) as MessageProxy;
			var mainUIMediator : MainUIMediator = facade.retrieveMediator ( MainUIMediator.NAME ) as MainUIMediator;

			//PROPERTIES
			
			//METHODS
			mainUIMediator.enabled = true;
			mainUIMediator.setMessageTextColor(MainUIMediator.SUCCESS_TEXT_COLOR);
            mainUIMediator.setMessageText(messageProxy.returnText);

        }
			
                
    }
}


