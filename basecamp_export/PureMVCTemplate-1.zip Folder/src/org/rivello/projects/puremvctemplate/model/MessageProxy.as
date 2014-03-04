//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.model
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import mx.rpc.IResponder;
	
	import org.puremvc.as3.interfaces.IProxy;
	import org.puremvc.as3.patterns.proxy.Proxy;
	import org.rivello.projects.puremvctemplate.ApplicationFacade;
	import org.rivello.projects.puremvctemplate.model.business.MessageDelegate;
	import org.rivello.projects.puremvctemplate.model.vo.MessageVO;
	import org.rivello.projects.puremvctemplate.model.vo.notifications.ShowServerErrorMessageNVO;
	
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This proxy manages the Message data class.
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
	public class MessageProxy extends Proxy implements IProxy, IResponder
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		/**
		 * Button label text before interactivity.
		*/		
		public function get returnText () : String 	{ 	return message.returnText_str; 		}
		
		
		//PUBLIC CONSTANTS
		/**
		 * Set <code>NAME</code> identical to the class name for reference caching.
		 * 
		 * @default PUBLIC_STATIC_CONSTANT 
		*/
		public static const NAME : String = "MessageProxy";

		//PRIVATE
		/**
		 * Return a named, typed reference to <code>data</code> for clarity
		 * 
		 * @default PUBLIC_STATIC_CONSTANT 
		*/
		private function get message () : MessageVO	{ return data as MessageVO; }
		
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
		public function MessageProxy ( aData : Object = null )
		{
			//SUPER
            super ( NAME, aData );

			//VARIABLES
						
			//PROPERTIES
			data = new MessageVO();
			
			//METHODS
			
			//EVENTS

		}	
		
		//PUBLIC
		/**
		 * Load the message from the server
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/
		public function load () : void 
		{
            // create a worker (delegate) who will go get some data
            // pass it a reference to this proxy so the delegate knows where to return the data
            var messageDelegate : MessageDelegate = new MessageDelegate( this ); 
            
            // make the delegate do some work
            messageDelegate.loadMessageReturnText();
				
		}

		/**
		 * IResponder Method: This is called when the delegate receives a result from the service
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/ 
        public function result( aObject : Object ) : void
        {
            // populate the employee list in the proxy with the results from the service call
            message.returnText_str = aObject.result;
            sendNotification( ApplicationFacade.SHOW_MESSAGE );
        }
        
		/**
		 * IResponder Method: This is called when the delegate receives a fault from the service
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @return void
		*/ 
        public function fault( aObject : Object ) : void 
        {
            sendNotification( ApplicationFacade.SHOW_SERVER_ERROR, new ShowServerErrorMessageNVO (aObject.toString()) );
            
        }	
        
        
        //PRIVATE
        
        
	}
}