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
//Marks the right margin of code *******************************************************************
package com.rmc.projects.lockbox.data.types
{
	import com.rmc.projects.lockbox.utils.Converter;
	
	import flash.utils.ByteArray;
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>The <code>CCPacket</code> class is ...</p>
	 * 
	 */
	public class Packet
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		/**
		 *  
		 */		
		private var _key_str : String;
		public function get key () 					: String 	{ return _key_str; }
		public function set key (aValue : String) 	: void 		{ _key_str = aValue; }
		
		/**
		 *  
		 */		
		private var _data : Object;
		public function get data () 					: Object 	{ return _data; }
		public function set data (aValue : Object) 	: void 		{ 
			
			if (aValue is ByteArray) {
				_data = aValue; 
			} else {
				_data = Converter.Convert(packetDataFormat, PacketDataFormat.BYTE_ARRAY, aValue);
			}
			
		}
		
		/**
		 *  
		 */		
		private var _packetDataFormat : PacketDataFormat;
		public function get packetDataFormat () 					: PacketDataFormat 	{ return _packetDataFormat; }
		public function set packetDataFormat (aValue : PacketDataFormat) 	: void 		{ _packetDataFormat = aValue; }
		
		// PUBLIC CONST
		
		// PRIVATE
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function Packet(aKey_str : String, aPacketDataFormat : PacketDataFormat, aData : Object = null)
		{
			// SUPER
			super();
			
			// EVENTS
			
			// VARIABLES
			key 					= aKey_str;
			packetDataFormat 	= aPacketDataFormat;
			data					= aData;
			
			// PROPERTIES
			
			// METHODS
			
		}
		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		// PUBLIC
		public function toString () : String
		{
			return "[Packet ( k=" + key + ", f=" + packetDataFormat + ", hasData: " + (data != null) +")]"
		}
		
		// PRIVATE
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		
		
		
		public static function fromObject(aPacketObject:Object):Packet
		{
			var key_str 				: String 			= aPacketObject["key"];
			var packetDataFormat 	: PacketDataFormat 	= PacketDataFormat.fromString(aPacketObject["packetDataFormat"]["Text"] as String);
			var data 				: * 					= aPacketObject["data"];
			var packet 				: Packet 			= new Packet (key_str, packetDataFormat, data );
			return packet;
		}
	}
}

