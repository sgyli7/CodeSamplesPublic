//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.controller 
{	
	//--------------------------------------
	//  Imports
	//--------------------------------------	
	import org.puremvc.as3.patterns.command.MacroCommand;
    
    
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This is when the user first interacts.  This is a useful spot 
	 * to do debugging, such as immediatly making a prompt appear, but
	 * any major, permanent functionality should happen outside this command.
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
    public class AwaitFirstInteractivityCommand extends MacroCommand
    {        
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		/**
		 * Startup the model and view
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/		
        override protected function initializeMacroCommand() : void 
        {
        	
        	//ECHO
        	trace ("AwaitFirstInteractivityCommand.initializeMacroCommand ()");
            
            //VARIABLES
			
			//PROPERTIES
			
			//METHODS
			
        }
        
        
    }
}


