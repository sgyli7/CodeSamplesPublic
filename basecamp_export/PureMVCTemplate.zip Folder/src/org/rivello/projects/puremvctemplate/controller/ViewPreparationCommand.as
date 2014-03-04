//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.controller
{
	//--------------------------------------
	//  Imports
	//--------------------------------------	
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	import org.rivello.projects.puremvctemplate.view.MainUIMediator;
    
    
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * Create and register <code>Mediator</code>s with the <code>View</code>.
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
    public class ViewPreparationCommand extends SimpleCommand
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
        override public function execute( aNotification : INotification ) : void  
        {
						
        	//ECHO
        	trace ("ViewPreparationCommand.execute()");
            
            //VARIABLES
			var application : PureMVCTemplate =  aNotification.getBody() as PureMVCTemplate;
			
			//PROPERTIES
			
			//METHODS
           	facade.registerMediator( new MainUIMediator ( application.mainUI ) );   

        }	

                
    }
}



