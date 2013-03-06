package
{
	import com.rmc.projects.lockbox.LockBox;
	import com.rmc.projects.lockbox.data.types.ImageData;
	import com.rmc.projects.lockbox.data.types.Packet;
	import com.rmc.projects.lockbox.data.types.PacketDataFormat;
	import com.rmc.projects.lockbox.display.ImageSprite;
	import com.rmc.projects.lockbox.errors.LockBoxEvent;
	import com.rmc.projects.lockbox.utils.Converter;
	import com.rmc.projects.lockbox.utils.CasuallyConnectedNetworkUtility;
	
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;
	import flash.utils.ByteArray;
	
	public class LockBoxDemo extends Sprite
	{
		
		private var _IMAGE_HEIGHT:uint = 50;
		private static const _DATA_XML_URL:String = "./server/data/data.xml";
		public function LockBoxDemo()
		{
			init();
			
			
		}
		
		protected function init():void
		{
			_doInitNetworkUtility();
			
			
			/* SAMPLE API
			
			*/
			/*
			var ccs : CasuallyConnectedStorage = new CasuallyConnectedStorage ("myDBName", SQLiteCCSAdapter);
			ccs.addEventListner (CasuallyConnectedStorageEvent.INITIALIZED, _onInitialized); 
			ccs.init();
			
			//IN _onInitialized
			if (ccs.isNetworkAvailable) {
				//load my live data
				
				//store them in ccs
				ccs.setItem("name", value);
				
				//or delete
				ccs.clearAllItems();
			} else {
				
				//retreve local data from ccs
				ccs.getItem("name", value);
			}
			
			*/
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
			
			if (LockBox.getInstance().hasPacketForKey (itemKey_str) ) {
				
				//GET THE PACKET WITH DATA
				var xmlPacket : Packet = LockBox.getInstance().getPacketByKey (itemKey_str);
				
				//PARSE & RENDER
				var xmlList : XMLList = new XMLList (xmlPacket.data);
				var imageDatas_vector 	: Vector.<ImageData> 	= _doParseXMLListToImageData (xmlList)
				_doRenderImageData (imageDatas_vector);
				
				trace ("Internet Not Connected: Successfull Loading From Local");
				
			} else {
				
				trace ("Internet Not Connected: Failed Loading From Local");
				//throw new Error ("have no item");
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
			LockBox.getInstance().setPacket (new Packet (_DATA_XML_URL, PacketDataFormat.TEXT, xmlList.toXMLString()));
			
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
			var imagePacket			: Packet			= new Packet (itemKey_str, PacketDataFormat.BITMAPDATA, imageSprite.imageContentBitmap.bitmapData);//
			LockBox.getInstance().setPacket (imagePacket);
			
			//NOW THE BITMAPDATA HAS BEEN STORED LOCALLY AS A PNG
			//SO NEXT TIME WE RESTAR THE APP, WE COULD CHECK THESE INSTEAD OF LOADING FROM ONLINE
			trace ("has : " + LockBox.getInstance().hasPacketForKey (imagePacket.key)	);
			trace ("get : " + LockBox.getInstance().getPacketByKey (imagePacket.key)	);
			
			
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
			CasuallyConnectedNetworkUtility.getInstance().addEventListener(LockBoxEvent.NETWORK_AVAILABLE_CHANGE, _onInternetAvailableChange)
			CasuallyConnectedNetworkUtility.getInstance().startNetworkMonitor();
			
		}
		
		protected function _onInternetAvailableChange(aEvent:LockBoxEvent):void
		{
			var isNetworkAvailable_boolean : Boolean = CasuallyConnectedNetworkUtility.getInstance().isNetworkAvailable;
			//
			isNetworkAvailable_boolean = true; //(Math.random() < 0.5);
			trace ("isNetworkAvailable_boolean: " + isNetworkAvailable_boolean);
			//
			if (isNetworkAvailable_boolean) {
				trace ("Internet Connected: Loading From Server");
				_doLoadData_FromServer();
			} else {
				_doLoadData_FromLocal();
				
			}
			
		}
		
	}
}