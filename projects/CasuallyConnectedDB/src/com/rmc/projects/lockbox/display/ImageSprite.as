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
package com.rmc.projects.lockbox.display
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.projects.lockbox.data.types.ImageData;
	
	import flash.display.Bitmap;
	import flash.display.Loader;
	import flash.display.LoaderInfo;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.net.URLRequest;
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>The <code>ImageSprite</code> class is ...</p>
	 * 
	 */
	public class ImageSprite extends Sprite
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		/**
		 *  
		 */		
		private var _imageData : ImageData;
		public function get imageData () 					: ImageData 	{ return _imageData; }
		public function set imageData (aValue : ImageData) 	: void 		{ _imageData = aValue; }

		
		/**
		 *  
		 */		
		private var _imageContentBitmap : Bitmap;
		public function get imageContentBitmap () 					: Bitmap 	{ return _imageContentBitmap; }
		public function set imageContentBitmap (aValue : Bitmap) 	: void 		{ _imageContentBitmap = aValue; }
		
		// PUBLIC CONST
		
		// PRIVATE
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function ImageSprite (aImageData : ImageData)
		{
			// SUPER
			super();
			
			// EVENTS
			
			// VARIABLES
			_imageData = aImageData;
			
			// PROPERTIES
			
			// METHODS
			_doRender()
			
		}
		
		private function _doRender():void
		{
			var myLoader:Loader = new Loader();
			myLoader.contentLoaderInfo.addEventListener(Event.COMPLETE, 			_onComplete, false, 0, true);
			myLoader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, 	_onIOError, false, 0, true);
			myLoader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS, 	_onProgress, false, 0, true);
			
			var fileRequest:URLRequest = new URLRequest(imageData.url);
			myLoader.load(fileRequest);
			
		}		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		// PUBLIC
		
		// PRIVATE
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		
		public function _onComplete(aEvent:Event) : void 
		{     
			//STORE
			_imageContentBitmap = (aEvent.currentTarget as LoaderInfo).content as Bitmap;
			
			//SHOW
			addChild( _imageContentBitmap	 );
			
			//SEND
			dispatchEvent( new Event (Event.COMPLETE) );
		}	
		
		public function _onIOError(aEvent:Event) : void {     
			trace ("_onIOError: " + aEvent);
		}
		
		public function _onProgress(aEvent:ProgressEvent) : void {   
			// this is where progress will be monitored     
			trace(aEvent.bytesLoaded, aEvent.bytesTotal); 
		}
		
		
	}
}
