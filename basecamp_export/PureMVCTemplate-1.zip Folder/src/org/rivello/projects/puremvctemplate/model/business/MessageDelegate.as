//Marks the right margin of code *******************************************************************
package org.rivello.projects.puremvctemplate.model.business
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import mx.rpc.AsyncToken;
	import mx.rpc.IResponder;
	import mx.rpc.http.HTTPService;
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * This is the 'worker' that does all the client<->server interaction
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
	public class MessageDelegate 
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		
		
		//PUBLIC CONST
		
		
		//PRIVATE
		/**
		 * Service to call the web
		*/
		private var _HTTPService : HTTPService;	
		
		/**
		 * Service Responder that proxies the result/fault
		*/
		private var _responder : IResponder;	
			
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------
		/**
		 * <span class="hide">Any hidden comments go here.</span>
		*/
		public function MessageDelegate (aResponder : IResponder)
		{
			//SUPER
			super (); 
			
			//VARIABLES
			
			//PROPERTIES
            // constructor will store a reference to the service we're going to call
            _HTTPService = new HTTPService();
            _HTTPService.resultFormat = "text";
            _HTTPService.url="http://www.google.com"; //load gibberish source text for a demo
           
            // and store a reference to the proxy that created this delegate
            _responder = aResponder;
            
			//METHODS
			
			//EVENTS

			

		}
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		/**
		 * Load the returnText from the server
		 *
		 * <span class="hide">Any hidden comments go here.</span>
		 *
		 * @param aResponder The responder to take the result/fault of the server call
		 * 
		 * @return void
		*/
        public function loadMessageReturnText () : void 
        {
            // call the service
            var token:AsyncToken = _HTTPService.send();
            
            // notify this responder when the service call completes
            token.addResponder( _responder );
        }

		//PRIVATE

		
	}
}