//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.controller
{
	//--------------------------------------
	//  Imports
	//--------------------------------------	
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	import org.rivello.projects.puremvctemplate.model.MessageProxy;
	import org.rivello.projects.puremvctemplate.model.PhrasesProxy;	
    
    
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * Create and register <code>Proxy</code>s with the <code>Model</code>.
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
    public class ModelPreparationCommand extends SimpleCommand
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
        	trace ("ModelPreparationCommand.execute()");
            
            //VARIABLES
			
			//PROPERTIES
			
			//METHODS
            facade.registerProxy(	new PhrasesProxy ()	);
            facade.registerProxy(	new MessageProxy ()	);

        }	
                
    }
}


