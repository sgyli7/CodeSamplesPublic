package com.rmc.projects.lockbox
{
	import com.rmc.projects.lockbox.data.types.ImageData;
	import com.rmc.projects.lockbox.data.types.Packet;
	import com.rmc.projects.lockbox.data.types.PacketDataFormat;
	import com.rmc.projects.lockbox.display.ImageSprite;
	import com.rmc.projects.lockbox.utils.Converter;
	
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.html.script.Package;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;
	import flash.utils.ByteArray;
	
	import org.flexunit.asserts.assertNotNull;
	import org.flexunit.asserts.assertTrue;
	import org.flexunit.async.Async;
	import org.flexunit.async.AsyncHandler;
	
	public class LockBoxTestCase
	{		
		
		private var _lockBox:LockBox;
		
		private var _imageURL_str:String;
		
		private var _xmlURL_str:String;
		[Before]
		public function setUp():void
		{
			_lockBox = LockBox.getInstance();
		}
		
		[After(async,timeout="3000")]
		public function tearDown():void
		{
			//_lockBox = null;
		}
		
		[BeforeClass]
		public static function setUpBeforeClass():void
		{
		}
		
		[AfterClass]
		public static function tearDownAfterClass():void
		{
		}
		
		
		[Test]
		public function testCreation () : void 
		{
			assertNotNull(_lockBox);
		}
		
		
		/*
		
		//////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////
		
		*/
		[Test(async,timeout="2000")]
		public function testSetPNG() : void 
		{
			_imageURL_str 	= "./server/images/binoculars_v1.png";
			//
			
			var imageData	: ImageData 		= new ImageData ("Binoc title", "Binoc Caption", _imageURL_str);
			var imageSprite : ImageSprite 	= new ImageSprite (imageData);
			imageSprite.addEventListener(Event.COMPLETE, Async.asyncHandler(this, _onImageSpriteComplete,2000, null), false, 0, true);
			imageSprite = new ImageSprite (imageData);
			
		}
		
		public function _onImageSpriteComplete (aEvent : Event, aPassThroughObject: * = null) : void
		{
			var imageSprite 			: ImageSprite 	= (aEvent.currentTarget as ImageSprite);
			var packet 				: Packet			= new Packet (_imageURL_str, PacketDataFormat.BITMAPDATA, imageSprite.imageContentBitmap.bitmapData);
			
			//SET
			_lockBox.setPacket(packet);
			
			//GET
			var responsePacket : Packet = _lockBox.getPacketByKey(_imageURL_str);
			
			//TEST
			assertNotNull(responsePacket);
			assertNotNull(responsePacket.key);
			assertNotNull(responsePacket.packetDataFormat);
			assertNotNull(responsePacket.data);
			
			//CONVERT
			var dataConverted : * = Converter.ConvertPacketDataFromByteArray (responsePacket);
			trace ("dataConverted_str: " + dataConverted);
			
			var s : Sprite = new Sprite();
			s.graphics.beginFill(0xFF0000);
			s.graphics.drawCircle(0, 0, 100);
			s.graphics.endFill();
			var bitmap : Bitmap = new Bitmap (dataConverted);
			bitmap.x = 10;
			bitmap.y = 10;
			FlexUnitApplication.instance.addChild (s);
			FlexUnitApplication.instance.addChild (bitmap);
			//assertTrue(dataConverted_str is BitmapData);
			
		}
		
		/*
		
		//////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////
		
		*/
		[Test(async,timeout="2000")]
		public function testSetXML() : void 
		{
			_xmlURL_str 	= "./server/data/data.xml";
			
			//assume online, load data
			var urlRequest : URLRequest 	= new URLRequest (_xmlURL_str);
			var urlLoader : URLLoader 	= new URLLoader (urlRequest);
			urlLoader.dataFormat 		= URLLoaderDataFormat.TEXT;
			urlLoader.addEventListener(Event.COMPLETE, 			Async.asyncHandler(this, _onCompleteNotNull, 2000, null), 	false, 0, true)
			
			
		}
		
		protected function _onCompleteNotNull(aEvent:Event, aPassThroughObject: * = null):void
		{
			var urlLoader : URLLoader = aEvent.currentTarget as URLLoader;
			var xmlList				: XMLList				= new XMLList (urlLoader.data);
			
			var packet : Packet = new Packet (_xmlURL_str, PacketDataFormat.TEXT, xmlList.toXMLString())
			
			//SET
			_lockBox.setPacket(packet);
			
			//GET
			var responsePacket : Packet = _lockBox.getPacketByKey(_xmlURL_str);
			
			//TEST
			assertNotNull(responsePacket);
			assertNotNull(responsePacket.key);
			assertNotNull(responsePacket.packetDataFormat);
			assertNotNull(responsePacket.data);
			
			//CONVERT
			var dataConverted_str : * = Converter.ConvertPacketDataFromByteArray (responsePacket);
			assertTrue(dataConverted_str is String);
			
		}	
		
		
	}
}