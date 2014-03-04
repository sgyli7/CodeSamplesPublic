//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.model
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import org.puremvc.as3.interfaces.IProxy;
	import org.puremvc.as3.patterns.proxy.Proxy;
	import org.rivello.projects.puremvctemplate.model.vo.PhrasesVO;
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This proxy manages the phrase data class.
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
	public class PhrasesProxy extends Proxy implements IProxy
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		/**
		 * Text display after hitting the button.
		*/		
		public function get title () 					: String 	{ 	return phrases.title_str; 		}
		public function set title (aValue : String) 	: void 		{ 	phrases.title_str = aValue; 		}
		
		
		/**
		 * Button label text before interactivity.
		*/		
		public function get buttonLabel () 					: String 	{ 	return phrases.buttonLabel_str; 		}
		public function set buttonLabel (aValue : String) 	: void 		{ 	phrases.buttonLabel_str = aValue; 		}

		
		//PUBLIC CONSTANTS
		/**
		 * Set <code>NAME</code> identical to the class name for reference caching.
		 * 
		 * @default PUBLIC_STATIC_CONSTANT 
		*/
		public static const NAME : String = "PhrasesProxy";

		//PRIVATE
		/**
		 * Return a named, typed reference to <code>data</code> for clarity
		 * 
		 * @default PUBLIC_STATIC_CONSTANT 
		*/
		private function get phrases () : PhrasesVO	{ return data as PhrasesVO; }
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * Setup <code>data</data> with default value(s).
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aData The data object to proxy i/o for.
		*/
		public function PhrasesProxy ( aData : Object = null )
		{
			//SUPER
            super ( NAME, aData );

			//VARIABLES
						
			//PROPERTIES
			data = new PhrasesVO("PureMVCTemplate", "Click To Load Message!"); //populate with hardcoded values
			
			//METHODS
			
			//EVENTS

		}	
		
		
	}
}