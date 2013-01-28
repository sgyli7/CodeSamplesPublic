package
{
	import com.rmc.projects.casuallyconnecteddata.data.types.ImageData;
	import com.rmc.projects.casuallyconnecteddata.display.ImageSprite;
	
	import flash.display.Sprite;
	import flash.errors.IOError;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.StatusEvent;
	import flash.net.InterfaceAddress;
	import flash.net.NetworkInfo;
	import flash.net.NetworkInterface;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;
	import flash.utils.describeType;
	
	import air.net.URLMonitor;
	
	public class CasuallyConnectedDB extends Sprite
	{
		
		private var monitor:URLMonitor;
		private var _IMAGE_HEIGHT:uint = 50;
		public function CasuallyConnectedDB()
		{
			init();
			
			
		}
		
		protected function init():void
		{
			//initMonitoring();
			initLoading();
			
			
		}
		
		
		
		
		protected function initLoading():void
		{
			//assume online, load data
			var urlRequest : URLRequest = new URLRequest ("./server/data/data.xml");
			var urlLoader : URLLoader = new URLLoader (urlRequest);
			urlLoader.dataFormat = URLLoaderDataFormat.TEXT;
			urlLoader.addEventListener(Event.COMPLETE, _onComplete, false, 0, true)
			urlLoader.addEventListener(IOErrorEvent.IO_ERROR, _onIOError, false, 0, true)
			
			//wait data
			
			//parse data (trace)
			
			//put data into 
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
			
			//PARSE (CUSTOM SOLUTION)
			var imageDatas_vector : Vector.<ImageData> = _doParseXMLListToImageData (new XMLList (urlLoader.data))
			
			//RENDER (CUSTOM SOLUTION)
			_doRenderImageData (imageDatas_vector);
			
			
		}		
		
		private function _doRenderImageData(aImageDatas_vector:Vector.<ImageData>):void
		{
			
			var x_uint : uint = 0;
			var y_uint : uint = 0;
			var imageSprite : ImageSprite;
			for each (var imageData : ImageData in aImageDatas_vector) {
				//
				imageSprite = new ImageSprite (imageData);
				imageSprite.x = x_uint;
				imageSprite.y = y_uint;
				addChild(imageSprite);
				
				//update position
				y_uint += _IMAGE_HEIGHT;
			}
			
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
		
		protected function initMonitoring():void
		{
			//  Alert.show("Your Network State changed", "INFO");
			var urlRequest : URLRequest = new URLRequest('http://www.google.com')
			urlRequest.method = "HEAD"; //just get the head, small k-size
			monitor = new URLMonitor(urlRequest);
			monitor.addEventListener(StatusEvent.STATUS, _onStatus);
			monitor.start();
		}
		
		protected function _onStatus(e:StatusEvent):void 
		{
			if(monitor.available) {
				trace ("Status change. You are connected to the internet", "INFO");
			} else {
				trace ("Status change. You are not connected to the internet", "INFO");
			}
			
			showNetworkInfo()
			
			//monitor.stop();
		}
		
		private function showNetworkInfo():void
		{
			var networkInfo:NetworkInfo = NetworkInfo.networkInfo; 
			var interfaces:Vector.<NetworkInterface> = networkInfo.findInterfaces(); 
			
			if( interfaces != null ) 
			{ 
				trace( "Interface count: " + interfaces.length ); 
				for each ( var networkInterface:NetworkInterface in interfaces ) 
				{ 
					trace( "\nname: "             	+ networkInterface.name ); 
					trace( "display name: "     		+ networkInterface.displayName ); 
					trace( "mtu: "                 	+ networkInterface.mtu ); 
					trace( "active?: "             	+ networkInterface.active ); 
					trace( "parent interface: " 		+ networkInterface.parent ); 
					trace( "hardware address: " 		+ networkInterface.hardwareAddress ); 
					if( networkInterface.subInterfaces != null ) 
					{ 
						trace( "# subinterfaces: " + networkInterface.subInterfaces.length ); 
					} 
					trace("# addresses: "     + networkInterface.addresses.length ); 
					for each ( var address:InterfaceAddress in networkInterface.addresses ) 
					{ 
						trace( "  type: "           		+ address.ipVersion ); 
						trace( "  address: "         	+ address.address ); 
						trace( "  broadcast: "         	+ address.broadcast ); 
						trace( "  prefix length: "     	+ address.prefixLength ); 
					} 
					
					var hasWifi:Boolean = false;
					var hasMobile:Boolean = false
					if ( networkInterface.active && (networkInterface.name == "en0" || networkInterface.name == "en1") ) hasWifi = true;
					if ( networkInterface.active && (networkInterface.name == "pdp_ip0" || networkInterface.name == "pdp_ip1" || networkInterface.name == "pdp_ip2") ) hasMobile = true;
					trace( "has Mobile Internet: " + hasMobile );
					trace( "has Wifi Internet: " + hasWifi );
				}             
			} 
		}     
	}
}