/**
 * Copyright (C) 2005-2012 by Rivello Multimedia Consulting (RMC).                    
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
package com.rmc.projects.casuallyconnected
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.errors.SingletonInstantiationError;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.utils.ByteArray;
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	/**
	 * Dispatched when ...
	 * 
	 * @aEventType com.rmc.templates.TemplateClass.SAMPLE_LOADED
	 * 
	 */
	[Event( name="sampleLoaded", type="flash.events.Event" )]
	
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>This is designed to...</p>
	 * 
	 */
	public class CasuallyConnectedStorage extends EventDispatcher
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		
		// PRIVATE
		
		
		//	PRIVATE STATIC
		/**
		 * The instance used for Singleton behavior.
		 * 
		 */
		private static var _Instance : CasuallyConnectedStorage;
		
		
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function CasuallyConnectedStorage (aSingletonEnforcer : SingletonEnforcer)
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
		public static function getInstance() : CasuallyConnectedStorage 
		{
			if (!_Instance) {
				_Instance = new CasuallyConnectedStorage( new SingletonEnforcer() );
			}
			return _Instance;
		}
		
		// PUBLIC
		/**
		 * Describe this member.
		 * 
		 * @param aItemKey_str
		 * @param aItemValue_bytearray
		 *  
		 * @return void
		 * 
		 */
		public function setItem(aItemKey_str:String, aItemValue_bytearray:ByteArray):void
		{
			var file:File = File.applicationStorageDirectory.resolvePath(aItemKey_str);
			trace (file.nativePath);
			//Use a FileStream to save the bytearray as bytes to the new file
			var fileStream:FileStream = new FileStream();
			try{
				//open file in write mode
				fileStream.open(file,FileMode.WRITE);
				//write bytes from the byte array
				fileStream.writeBytes(aItemValue_bytearray);
				//close the file
				fileStream.close();
			}catch(e:Error){
				trace(e.message);
			}
		}
		
		
		public function hasItem(aItemKey_str:String):Boolean
		{
			var file:File = File.applicationStorageDirectory.resolvePath(aItemKey_str);
			return file.exists;
			
		}
		
		public function getItem(aItemKey_str:String): ByteArray
		{
			var item : *;
			if (hasItem(aItemKey_str)) {
				var file:File = File.applicationStorageDirectory.resolvePath(aItemKey_str);
				item = file;
			} else {
				throw Error ("CCS.as has no item");
			}
			
			return item;
		}
		
		
		// PRIVATE
		
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		/**
		 * Handles the aEvent: <code>TemplateClass.SAMPLE_LOADED</code>.
		 * 
		 * @param aEvent <code>aEvent</code> The incoming aEvent payload.
		 *  
		 * @return void
		 * 
		 */
		private function _onSampleProcessComplete(aEvent : Event) : void
		{
			
		}
		
	}
}

//--------------------------------------
//  Singleton Enforcer: This Prevents 
//  Instantiation Of The Class Above
//	From Anywhere Outside This Document
//--------------------------------------
internal class SingletonEnforcer {}