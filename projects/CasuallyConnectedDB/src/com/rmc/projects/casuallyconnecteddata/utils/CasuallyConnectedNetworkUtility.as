/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************
package com.rmc.projects.casuallyconnecteddata.utils
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.errors.SingletonInstantiationError;
	import com.rmc.projects.casuallyconnected.CasuallyConnectedEvent;
	
	import flash.events.EventDispatcher;
	import flash.events.StatusEvent;
	import flash.net.InterfaceAddress;
	import flash.net.NetworkInfo;
	import flash.net.NetworkInterface;
	import flash.net.URLRequest;
	
	import air.net.URLMonitor;
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	/**
	 * Dispatched when ...
	 * 
	 * @aEventType com.rmc.projects.casuallyconnected.INTERNET_AVAILABLE_CHANGE
	 * 
	 */
	[Event( name="networkAvailableChange", type="com.rmc.projects.casuallyconnected.CasuallyConnectedEvent" )]
	
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>This is designed to...</p>
	 * 
	 */
	public class CasuallyConnectedNetworkUtility extends EventDispatcher
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		/**
		 *  
		 */		
		private var _isNetworkAvailable_boolean : Boolean;
		public function get isNetworkAvailable () 					: Boolean 	{ return _isNetworkAvailable_boolean; }
		private function set _isNetworkAvailable (aValue : Boolean) 	: void 		{ 
			if (_isNetworkAvailable_boolean != aValue) {
				_isNetworkAvailable_boolean = aValue; 
				dispatchEvent( new CasuallyConnectedEvent (CasuallyConnectedEvent.NETWORK_AVAILABLE_CHANGE));
			}
		}		
		
		
		// PRIVATE
		/**
		 * 
		 */		
		private var _urlMonitor:URLMonitor;
		
		
		//	PRIVATE STATIC
		/**
		 * The instance used for Singleton behavior.
		 * 
		 */
		private static var _Instance : CasuallyConnectedNetworkUtility;
		
		
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function CasuallyConnectedNetworkUtility (aSingletonEnforcer : SingletonEnforcer)
		{
			if ( _Instance ) {
				throw new SingletonInstantiationError();
			} else {
				
				// SUPER
				
				// EVENTS
				
				// VARIABLES
				
				// PROPERTIES
				
				// METHODS
			}			
			
			
		}
		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		// PUBLIC STATIC
		/**
		 * Get an instance of the singleton class.
		 * 
		 * @return <code>TemplateSingleton</code> The instance.
		 *
		 */
		public static function getInstance() : CasuallyConnectedNetworkUtility 
		{
			if (!_Instance) {
				_Instance = new CasuallyConnectedNetworkUtility( new SingletonEnforcer() );
			}
			return _Instance;
		}
		
		// PUBLIC
		/**
		 * 
		 * 
		 */		
		public function startNetworkMonitor():void
		{
			var urlRequest : URLRequest = new URLRequest('http://www.google.com')
			urlRequest.method = "HEAD"; //just get the head, small k-size
			_urlMonitor = new URLMonitor(urlRequest);
			_urlMonitor.addEventListener(StatusEvent.STATUS, _onStatus);
			_urlMonitor.start();
			
			//TRIGGER A FIRST CALL
			_onStatus(null);
			
		}
		
		
		
		private function showNetworkInfo():void
		{
			var networkInfo:NetworkInfo = NetworkInfo.networkInfo; 
			var interfaces:Vector.<NetworkInterface> = networkInfo.findInterfaces(); 
			
			if( interfaces != null ) 
			{ 
				trace( "Interface count: " + interfaces.length ); 
				for each ( var networkInterface:NetworkInterface in interfaces ) 
				{ 
					trace( "\nname: "             	+ networkInterface.name ); 
					trace( "display name: "     		+ networkInterface.displayName ); 
					trace( "mtu: "                 	+ networkInterface.mtu ); 
					trace( "active?: "             	+ networkInterface.active ); 
					trace( "parent interface: " 		+ networkInterface.parent ); 
					trace( "hardware address: " 		+ networkInterface.hardwareAddress ); 
					if( networkInterface.subInterfaces != null ) 
					{ 
						trace( "# subinterfaces: " + networkInterface.subInterfaces.length ); 
					} 
					trace("# addresses: "     + networkInterface.addresses.length ); 
					for each ( var address:InterfaceAddress in networkInterface.addresses ) 
					{ 
						trace( "  type: "           		+ address.ipVersion ); 
						trace( "  address: "         	+ address.address ); 
						trace( "  broadcast: "         	+ address.broadcast ); 
						trace( "  prefix length: "     	+ address.prefixLength ); 
					} 
					
					var hasWifi:Boolean = false;
					var hasMobile:Boolean = false
					if ( networkInterface.active && (networkInterface.name == "en0" || networkInterface.name == "en1") ) hasWifi = true;
					if ( networkInterface.active && (networkInterface.name == "pdp_ip0" || networkInterface.name == "pdp_ip1" || networkInterface.name == "pdp_ip2") ) hasMobile = true;
					trace( "has Mobile Internet: " + hasMobile );
					trace( "has Wifi Internet: " + hasWifi );
				}             
			} 
		}     
		// PRIVATE
		
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		/**
		 * Handles the aEvent: <code>StatusEvent.STATUS</code>.
		 * 
		 * @param aEvent <code>StatusEvent</code> The incoming aEvent payload.
		 *  
		 * @return void
		 * 
		 */
		protected function _onStatus(aEvent:StatusEvent):void 
		{
			//USE SETTER TO TRIGGER EVENT DISPATCH
			_isNetworkAvailable = _urlMonitor.available;
		}
		
	}
}
//--------------------------------------
//  Singleton Enforcer: This Prevents 
//  Instantiation Of The Class Above
//	From Anywhere Outside This Document
//--------------------------------------
internal class SingletonEnforcer {}