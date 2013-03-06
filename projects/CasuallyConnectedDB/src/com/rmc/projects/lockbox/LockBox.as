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
package com.rmc.projects.lockbox
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.errors.SingletonInstantiationError;
	import com.rmc.errors.SwitchStatementDefaultError;
	import com.rmc.projects.lockbox.data.types.Packet;
	import com.rmc.projects.lockbox.data.types.PacketDataFormat;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.net.registerClassAlias;
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
	public class LockBox extends EventDispatcher
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
		private static var _Instance : LockBox;
		
		
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function LockBox (aSingletonEnforcer : SingletonEnforcer)
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
		public static function getInstance() : LockBox 
		{
			if (!_Instance) {
				_Instance = new LockBox( new SingletonEnforcer() );
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
		public function setPacket(aPacket : Packet):void
		{
			var file:File = File.applicationStorageDirectory.resolvePath(aPacket.key);
			trace (file.nativePath);
			//Use a FileStream to save the bytearray as bytes to the new file
			var fileStream:FileStream = new FileStream();
			try{
				//open file in write mode
				fileStream.open(file,FileMode.WRITE);
			}catch(e:Error){
				trace("CCSError: " + e.message);
			}
			
			
			fileStream.writeObject(aPacket);
			
			//close the file
			fileStream.close();
		}
		
		
		public function hasPacketForKey(aKey_str : String):Boolean
		{
			var file:File = File.applicationStorageDirectory.resolvePath(aKey_str);
			return file.exists;
			
		}
		
		public function getPacketByKey(aKey_str : String): Packet
		{
			var returnPacket : Packet;
			if (hasPacketForKey(aKey_str)) {
				var file:File = File.applicationStorageDirectory.resolvePath(aKey_str);
				
				//Use a FileStream to save the bytearray as bytes to the new file
				var fileStream:FileStream = new FileStream();
				try{
					//open file in write mode
					fileStream.open(file,FileMode.READ);
					
				}catch(e:Error){
					trace("CCSError: " + e.message);
				}
				
				
				//DO NOT DO registerClassAlias("com.rmc.projects.lockbox.data.types.Packet", Packet);
				//BECAUSE WE WANT TO DESERIALIZE BY HAND TO KEEP PRIVATE ACCESS WITHIN PACKET (personal preference)
				var packetObject : Object = fileStream.readObject();
				trace ("object : " + packetObject);
				returnPacket = Packet.fromObject (packetObject);
				trace ("returnPacket : " + returnPacket);
				trace ("returnPacket : " + returnPacket);
				
				//close the file
				fileStream.close();
				
			} else {
				throw Error ("CCS.as has no item for key: " + returnPacket.key);
			}
			
			//trace ("getpacket with data " + aPacket.data);
			
			return returnPacket;
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