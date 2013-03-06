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
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.data.types.enums.Enum;
	import com.rmc.errors.EnumIllegalConstructionError;
	import com.rmc.errors.SwitchStatementDefaultError;
	import com.rmc.utils.CStringUtils;
	
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>The <code>ButtonState</code> defines the visual state of a button.</p>
	 * 
	 */
	public class PacketDataFormat extends Enum
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		
		// PUBLIC CONST
		/**
		 * DECLARE ALL POSSIBLE ENUMS INSTANCES
		 */		
		public static const BYTE_ARRAY 	: PacketDataFormat = new PacketDataFormat();
		public static const BITMAPDATA 	: PacketDataFormat = new PacketDataFormat();
		public static const TEXT 		: PacketDataFormat = new PacketDataFormat();
		
		// PRIVATE STATIC
		/**
		 * PREVENTS INSTANTIATION OF ENUMS OUTSIDE OF THIS CLASS
		 */		
		static private var _IsLocked_boolean:Boolean = false;
		
		// PRIVATE
		
		// --------------------------------------
		// Metadata
		// --------------------------------------
		{
			CStringUtils.InitEnumConstants(PacketDataFormat);
			_IsLocked_boolean = true;
		} 
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function PacketDataFormat() {
			
			// ERROR CHECK
			if(_IsLocked_boolean) {
				throw new EnumIllegalConstructionError ();
			}
			
			// EVENTS
			
			// VARIABLES
			
			// PROPERTIES
			
			// METHODS
			
		}
		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		// PUBLIC
		
		
		// PRIVATE
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		
		public static function fromString(aString : String):PacketDataFormat
		{
			var packetDataFormat : PacketDataFormat
			switch (aString.toUpperCase()) {
				case PacketDataFormat.TEXT.toString().toUpperCase():
					packetDataFormat = PacketDataFormat.TEXT;
					break;
				case PacketDataFormat.BITMAPDATA.toString().toUpperCase():
					packetDataFormat = PacketDataFormat.BITMAPDATA;
					break;
				case PacketDataFormat.BYTE_ARRAY.toString().toUpperCase():
					packetDataFormat = PacketDataFormat.BYTE_ARRAY;
					break;
				default:
					throw new SwitchStatementDefaultError();
					break;
			}
			return packetDataFormat;
		}
	}
}

