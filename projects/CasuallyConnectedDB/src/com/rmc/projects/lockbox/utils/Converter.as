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
package com.rmc.projects.lockbox.utils
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.errors.SwitchStatementDefaultError;
	import com.rmc.projects.lockbox.data.types.Packet;
	import com.rmc.projects.lockbox.data.types.PacketDataFormat;
	
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Loader;
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.IOErrorEvent;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.geom.Rectangle;
	import flash.net.ObjectEncoding;
	import flash.net.URLRequest;
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
	public class Converter extends EventDispatcher
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

		private static var loader:Loader;
		/**
		 * This is the constructor.
		 * 
		 */
		public function Converter ()
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
		public static function Convert(aFromCCDataFormat: PacketDataFormat, aToCCDataFormat: PacketDataFormat, aSourceData : *) : * 
		{
			var aToData : *;
			
			///////////
			///TEXT
			////////////
			if (aFromCCDataFormat == PacketDataFormat.BYTE_ARRAY &&
				aToCCDataFormat == PacketDataFormat.TEXT) {
				//
				aToData = _ConvertByteArrayToText (aSourceData);
				
			} else if (aFromCCDataFormat == PacketDataFormat.TEXT &&
				aToCCDataFormat == PacketDataFormat.BYTE_ARRAY) {
				//
				aToData = _ConvertTextToByteArray (aSourceData);
				
				
				
				///////////
				///BITMAPDATA
				////////////
			} else if (aFromCCDataFormat == PacketDataFormat.BITMAPDATA &&
				aToCCDataFormat == PacketDataFormat.BYTE_ARRAY) {
				//
				aToData = _ConvertBitmapDataToPNGByteArray (aSourceData);
				
			} else if (aFromCCDataFormat == PacketDataFormat.BYTE_ARRAY &&
				aToCCDataFormat == PacketDataFormat.BITMAPDATA) {
				//
				aToData = _ConvertPNGByteArrayToBitmapData (aSourceData);

			} else {
				//NO CONVERSION POSSIBLE FOR THE REQUESTED COMBINATION TO/FROM
				throw new SwitchStatementDefaultError();
			}
			
			
			//
			return aToData;
			
		}
		
		private static function _ConvertByteArrayToText(aFromData : ByteArray): String
		{
			return aFromData.readObject() as String
		}		
		
		private static function _ConvertTextToByteArray(aFromData : String): ByteArray
		{
			var byteArray : ByteArray = new ByteArray ();
			byteArray.writeObject(aFromData);
			return byteArray;
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
		 * 
		 * 
		 * @param aBitmapData
		 * 
		 * @return ByteArray
		 * 
		 */		
		private static function _ConvertPNGByteArrayToBitmapData(aByteArray : ByteArray) : BitmapData 
		{
			
			//CREATE A TEMP FILE
			var file:File = File.applicationStorageDirectory.resolvePath("_ConvertPNGByteArrayToBitmapData.png");
			
			var fileStream:FileStream = new FileStream();
			try{
				//open file in write mode
				fileStream.open(file,	FileMode.WRITE);
			}catch(e:Error){
				trace("CCSError: " + e.message);
			}
			fileStream.writeBytes(aByteArray);
			
			//close the file
			fileStream.close();
			
			
			loader = new Loader();
			var bmp:Bitmap
			var onDone : Function = function (aEvent : Event) : void
			{
				trace ('ok');
				bmp = Bitmap(loader.content);
			}
			loader.addEventListener(Event.COMPLETE, onDone, false, 0, true);
			loader.addEventListener(Event.COMPLETE, _onblah, false, 0, true);
			loader.addEventListener(IOErrorEvent.IO_ERROR, _onblah, false, 0, true);
			//loader.loadBytes(aByteArray);
			loader.load(new URLRequest(file.url));
			
			trace ("content : " + (loader.content));
			
			//var bitmapdata : BitmapData = new BitmapData ();
			var bitmapData:BitmapData = new BitmapData(30, 30)
			//bitmapData.setPixels(bitmapData.rect, aByteArray);
			
			return bitmapData
			
		}
		
		protected static function _onblah(event:Event):void
		{
			// TODO Auto-generated method stub
			trace ("ok");
			
		}		
		
		// PUBLIC
		
		// PRIVATE
		
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		
		
		public static function ConvertPacketDataFromByteArray(aPacket:Packet):*
		{
			var data : *;
			//write bytes from the byte array
			switch (aPacket.packetDataFormat) {
				case PacketDataFormat.TEXT:
					data = Converter.Convert(PacketDataFormat.BYTE_ARRAY, PacketDataFormat.TEXT, aPacket.data)
					break;
				case PacketDataFormat.BITMAPDATA:
					data = Converter.Convert(PacketDataFormat.BYTE_ARRAY, PacketDataFormat.BITMAPDATA, aPacket.data) 
					break;
				case PacketDataFormat.BYTE_ARRAY:
					data = aPacket.data as ByteArray; //it already is 
					break;
				default:
					throw new SwitchStatementDefaultError();
					break;
			}
			
			return data;
		}
	}
}

