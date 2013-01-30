package
{
	import com.rmc.projects.casuallyconnected.CasuallyConnectedEvent;
	import com.rmc.projects.casuallyconnected.CasuallyConnectedStorage;
	import com.rmc.projects.casuallyconnecteddata.data.types.CCDataFormat;
	import com.rmc.projects.casuallyconnecteddata.data.types.ImageData;
	import com.rmc.projects.casuallyconnecteddata.display.ImageSprite;
	import com.rmc.projects.casuallyconnecteddata.utils.CasuallyConnectedConverter;
	import com.rmc.projects.casuallyconnecteddata.utils.CasuallyConnectedNetworkUtility;
	
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;
	import flash.utils.ByteArray;
	
	public class CasuallyConnectedDemo extends Sprite
	{
		
		private var _IMAGE_HEIGHT:uint = 50;
		private static const _DATA_XML_URL:String = "./server/data/data.xml";
		public function CasuallyConnectedDemo()
		{
			init();
			
			
		}
		
		protected function init():void
		{
			_doInitNetworkUtility();
			
			
			
		}
		
		
		protected function _doLoadData_FromServer():void
		{
			//assume online, load data
			var urlRequest : URLRequest 	= new URLRequest (_DATA_XML_URL);
			var urlLoader : URLLoader 	= new URLLoader (urlRequest);
			urlLoader.dataFormat 		= URLLoaderDataFormat.TEXT;
			urlLoader.addEventListener(Event.COMPLETE, 			_onComplete, 	false, 0, true)
			urlLoader.addEventListener(IOErrorEvent.IO_ERROR, 	_onIOError, 		false, 0, true)
			
			//wait data
			
			//parse data (trace)
			
			//put data into 
		}
		
		protected function _doLoadData_FromLocal():void
		{
			//
			var itemKey_str 			: String 		= _DATA_XML_URL;
			
			if (CasuallyConnectedStorage.getInstance().hasItem (itemKey_str) ) {
				
				var file : File = CasuallyConnectedStorage.getInstance().getItem (itemKey_str);
				var text:String = CasuallyConnectedConverter.Convert(CCDataFormat.BYTE_ARRAY, CCDataFormat.TEXT, file);
				
				//PARSE & RENDER
				var xmlList : XMLList = new XMLList (text);
				var imageDatas_vector 	: Vector.<ImageData> 	= _doParseXMLListToImageData (xmlList)
				_doRenderImageData (imageDatas_vector);
				
			} else {
				throw new Error ("have no item");
			}
		}
		
		protected function _onIOError(aEvent:IOErrorEvent):void
		{
			// TODO Auto-generated method stub
			trace ("_onIOError" + aEvent.text);
			
		}
		
		protected function _onComplete(aEvent:Event):void
		{
			trace ("_onComplete"); 
			var urlLoader : URLLoader = aEvent.currentTarget as URLLoader;
			
			//
			var xmlList				: XMLList				= new XMLList (urlLoader.data);
			
			//PARSE & RENDER
			var imageDatas_vector 	: Vector.<ImageData> 	= _doParseXMLListToImageData (xmlList)
			_doRenderImageData (imageDatas_vector);
			
			//
			var itemKey_str 			: String 		= _DATA_XML_URL;
			var itemValue_bytearray 	: ByteArray 		= CasuallyConnectedConverter.Convert(CCDataFormat.XMLLIST, CCDataFormat.BYTE_ARRAY, xmlList);
			//
			CasuallyConnectedStorage.getInstance().setItem (itemKey_str, itemValue_bytearray);
			
		}		
		
		
		private function _doParseXMLListToImageData(aXMLList : XMLList):Vector.<ImageData>
		{
			var version			: String 	= (aXMLList[0] as XML).@version
			var date				: String 	= (aXMLList[0] as XML).@date
			var images_xmllist 	: XMLList 	= aXMLList[0].galleries.gallery.images.image
			trace ("---------");
			trace ("version : " + version)
			trace ("date 	: " + date)
			var imageDatas_vector : Vector.<ImageData> = new Vector.<ImageData>();
			for each (var image_xml : XML in images_xmllist) {
				trace ("--");
				trace ("	" + image_xml.title)
				trace ("	" + image_xml.caption)
				trace ("	" + image_xml.url)
				imageDatas_vector.push ( new ImageData (image_xml.title, image_xml.caption, image_xml.url)	);
			}
			
			
			//
			return imageDatas_vector;
			
		}
		
		
		private function _doRenderImageData(aImageDatas_vector:Vector.<ImageData>):void
		{
			
			var x_uint : uint = 0;
			var y_uint : uint = 0;
			var imageSprite : ImageSprite;
			//
			for each (var imageData : ImageData in aImageDatas_vector) {
				//
				imageSprite = new ImageSprite (imageData);
				imageSprite.x = x_uint;
				imageSprite.y = y_uint;
				addChild(imageSprite);
				
				//
				imageSprite.addEventListener(Event.COMPLETE, _onImageSpriteComplete, false, 0, true);
				
				//update position
				y_uint += _IMAGE_HEIGHT;
			}
			
		}		
		
		protected function _onImageSpriteComplete(aEvent:Event):void
		{
			trace ("_onImageSpriteComplete");
			//
			var imageSprite 			: 	ImageSprite 	= aEvent.currentTarget as ImageSprite;
			//
			var itemKey_str 			: String 		= imageSprite.imageData.url;
			var itemValue_bytearray 	: ByteArray 		= CasuallyConnectedConverter.Convert(CCDataFormat.PNG, CCDataFormat.BYTE_ARRAY, imageSprite.imageContentBitmap.bitmapData);
			//
			CasuallyConnectedStorage.getInstance().setItem (itemKey_str, itemValue_bytearray);
			
			//NOW THE BITMAPDATA HAS BEEN STORED LOCALLY AS A PNG
			//SO NEXT TIME WE RESTAR THE APP, WE COULD CHECK THESE INSTEAD OF LOADING FROM ONLINE
			trace ("has : " + CasuallyConnectedStorage.getInstance().hasItem (itemKey_str));
			trace ("get : " + CasuallyConnectedStorage.getInstance().getItem (itemKey_str));
			
			
			//NEXT.....
			
			//STORE XML TOO AS LOCAL FILE
			
			//RETRIEVE IMAGE FROM LOCAL 
			
			//RETRIEVE XML FROM LOCAL
			
			//CREATE THE METHOD .removeItem(itemKey_str)
			
			//look at lawnchair project to see how it handles image vs xml vs json, etc..
			
			//CHECK DATA VERSION #, COMPARE SERVER TO LOCAL, BUT DO NOTHING - USERS CAN USE THAT IF WANTED
			
			
		}		
		
		protected function _doInitNetworkUtility():void
		{
			CasuallyConnectedNetworkUtility.getInstance().addEventListener(CasuallyConnectedEvent.NETWORK_AVAILABLE_CHANGE, _onInternetAvailableChange)
			CasuallyConnectedNetworkUtility.getInstance().startNetworkMonitor();
			
		}
		
		protected function _onInternetAvailableChange(aEvent:CasuallyConnectedEvent):void
		{
			var isNetworkAvailable_boolean : Boolean = CasuallyConnectedNetworkUtility.getInstance().isNetworkAvailable;
			//
			isNetworkAvailable_boolean = (Math.random() < 0.5);
			trace ("isNetworkAvailable_boolean: " + isNetworkAvailable_boolean);
			//
			if (isNetworkAvailable_boolean) {
				_doLoadData_FromServer();
			} else {
				_doLoadData_FromLocal();
				
			}
			
		}
		
	}
}