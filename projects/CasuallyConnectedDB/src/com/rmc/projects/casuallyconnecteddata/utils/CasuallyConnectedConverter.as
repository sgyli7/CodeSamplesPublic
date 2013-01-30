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
package com.rmc.projects.casuallyconnecteddata.utils
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.errors.SwitchStatementDefaultError;
	import com.rmc.projects.casuallyconnecteddata.data.types.CCDataFormat;
	
	import flash.display.BitmapData;
	import flash.events.EventDispatcher;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.net.ObjectEncoding;
	import flash.utils.ByteArray;
	
	import mx.graphics.codec.PNGEncoder;
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>This is designed to...</p>
	 * 
	 */
	public class CasuallyConnectedConverter extends EventDispatcher
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		
		// PUBLIC CONST
		
		// PRIVATE
		
		//	PRIVATE STATIC
		
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function CasuallyConnectedConverter ()
		{
			
			// SUPER
			
			// EVENTS
			
			// VARIABLES
			
			// PROPERTIES
			
			// METHODS
			
		}
		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		// PUBLIC STATIC
		/**
		 * 
		 * 
		 * @param aBitmapData
		 * 
		 * @return ByteArray
		 * 
		 */		
		public static function Convert(aFromCCDataFormat: CCDataFormat, aToCCDataFormat: CCDataFormat, aFromData : *) : * 
		{
			var aToData : *;
			
			if (aFromCCDataFormat == CCDataFormat.PNG &&
				aToCCDataFormat == CCDataFormat.BYTE_ARRAY) {
				//
				aToData = _ConvertBitmapDataToPNGByteArray (aFromData);
				
			} else if (aFromCCDataFormat == CCDataFormat.XMLLIST &&
				aToCCDataFormat == CCDataFormat.BYTE_ARRAY) {
				//
				aToData = _ConvertXMLListByteArray (aFromData);
				
			} else if (aFromCCDataFormat == CCDataFormat.BYTE_ARRAY &&
				aToCCDataFormat == CCDataFormat.TEXT) {
				//
				aToData = _ConvertByteArrayToText (aFromData);
				
			} else {
				//NO CONVERSION POSSIBLE FOR THE REQUESTED COMBINATION TO/FROM
				throw new SwitchStatementDefaultError();
			}
			
			
			//
			return aToData;
			
		}
		
		private static function _ConvertByteArrayToText(aFromData : ByteArray): String
		{
			var fileStream:FileStream = new FileStream();
			fileStream.open(file, FileMode.READ);
			var text:String = fileStream.readUTFBytes(file.size);
		}		
		
		/**
		 * 
		 * 
		 * 
		 * @param aBitmapData
		 * 
		 * @return ByteArray
		 * 
		 */		
		private static function _ConvertBitmapDataToPNGByteArray(aBitmapData : BitmapData) : ByteArray 
		{
			var pngEncoder	:	PNGEncoder 	= new PNGEncoder();
			return pngEncoder.encode(aBitmapData);
			
		}
		
		/**
		 * 
		 * @param aXMLList
		 * @return 
		 * 
		 */		
		private static function _ConvertXMLListByteArray(aXMLList:XMLList):ByteArray
		{
			var byteArray : ByteArray = new ByteArray();
			byteArray.objectEncoding = ObjectEncoding.AMF3;
			byteArray.writeUTFBytes(aXMLList.toXMLString());
			return byteArray;
		}
		
		// PUBLIC
		
		// PRIVATE
		
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		
		
	}
}

