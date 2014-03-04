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
	 * Cue the preparation <code>Command</code>s for the <code>Model</code> and the <code>View</code>.
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
    public class ApplicationStartupCommand extends MacroCommand
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
        	trace ("ApplicationStartupCommand.initializeMacroCommand()");
            
            //VARIABLES
			
			//PROPERTIES
			
			//METHODS
            addSubCommand(ModelPreparationCommand );
            addSubCommand(ViewPreparationCommand );	
            addSubCommand(ApplicationAwaitFirstInteractivityCommand );			
        }
        
        
    }
}


