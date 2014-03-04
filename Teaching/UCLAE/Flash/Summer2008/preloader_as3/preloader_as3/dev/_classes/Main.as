/*
Copyright (C) 2006 Big Spaceship, LLC

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

To contact Big Spaceship, email info@bigspaceship.com or write to us at 45 Main Street #716, Brooklyn, NY, 11201.
*/

package
{
	// as3
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	
	import flash.display.Loader;
	import flash.display.MovieClip;
	
	// bss
	import com.bigspaceship.utils.Out;
	import com.bigspaceship.frameworks.site.PreloaderClip;
	
	// events
	import flash.events.Event;
	import flash.events.ProgressEvent;
	import com.bigspaceship.events.AnimationEvent;
	
	public class Main extends MovieClip
	{
		/* i like to define my class variables at the top of the page, so i know what i'm working with.
		*  private variables are variables only accessible inside this class. if another class tried to access _swfLoader, flash would display an error message.
		*  these are useful because now i know that the only place these variables will be used or manipulated is in this file.
		*  if i wanted to open them up so other classes could manipulate them, i'd call them public instead of private.
		*
		*  at big spaceship we use a standard for variables: underscore before private vars, nothing before public and dollar sign before arguments.
		*	this helps us figure out what variable is of what type without having to go up and down the code.
		*/
			 
		private var _swfLoader			:Loader;
		private var _xmlLoader			:URLLoader;

		private var _loadCount			:Number;
		private var _loadTotal			:Number			= 1;			// we're loading 2 items total -- a swf and an xml file. count from 0.

		private var _xml				:XML;

		// remember, the Constructor runs automatically. since this is our Document Root class, as soon as the swf starts to run this function is called.
		public function Main()
		{
			Out.enableAllLevels();
			Out.status(this,"Ready to go!");
			
			// first let's start by setting our PreloaderClip to tell us when it's finished. remember, Main is our main timeline and preloader_mc is a PreloaderClip.
			preloader_mc.animateIn();
			preloader_mc.addEventListener(Event.INIT,_onPreloaderIn,false,0,true);
			preloader_mc.addEventListener(Event.COMPLETE,_onPreloaderOut,false,0,true);
		};
		
		// so the preloader is in and now we can start to load.
		// oh, functions can be public and private, too.
		private function _onPreloaderIn($evt:Event):void
		{
			_loadCount = 0;

			// this is how to load swfs, jpgs and such in AS3.
			_swfLoader = new Loader();
			_swfLoader.contentLoaderInfo.addEventListener(Event.INIT,_onSWFLoaded,false,0,true);
			_swfLoader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS,_onLoadProgress,false,0,true);
			_swfLoader.load(new URLRequest("loadedContent.swf"));		
		};
		
		private function _onLoadProgress($evt:Event):void
		{
			Out.status(this,"_onLoadProgress");

			// this is all we need to display load progress.
			preloader_mc.updateProgress($evt.target.bytesLoaded,$evt.target.bytesTotal,_loadCount,_loadTotal);	
		};

		private function _onSWFLoaded($evt:Event):void
		{
			Out.status(this,"_onSWFLoaded");

			_loadCount = 1;

			// so now we can start to load the xml. here's how in as3.
			// note that we can use the same _onProgress function for both swf and xml.
			_xmlLoader = new URLLoader();
			_xmlLoader.addEventListener(Event.COMPLETE,_onXMLLoaded,false,0,true);
			_xmlLoader.addEventListener(ProgressEvent.PROGRESS,_onLoadProgress,false,0,true);
			_xmlLoader.load(new URLRequest("content.xml"));			
		};

		private function _onXMLLoaded($evt:Event):void
		{
			// there's no difference between Out.status and Out.debug. they do the same thing, essentially.
			// the power of the out class is in it's ability "silence" one or the other (or any of the "levels" -- status, debug, fatal, warning, and info).
			// instead of removing or commenting out all Out.status() calls, I can say Out.disableLevel(Out.LEVEL_STATUS); and no Out.status messages will appear
			_xml = new XML($evt.target.data);
			
			Out.status(this,"XML Loaded:");
			Out.debug(this,_xml.toXMLString());

			// both SWF and XML are loaded, we can tell the preloader to just play through.
			preloader_mc.setComplete();
		};

		// preloader has animated away, time to animate the timeline in.
		private function _onPreloaderOut($evt:Event):void
		{
			Out.status(this,"_onPreloaderOut");
			var loadedSWF:MovieClip = _swfLoader.contentLoaderInfo.content as MovieClip;
			addChild(loadedSWF);				// the SWF is added to the stage.
			loadedSWF.gotoAndPlay("IN");		// finally something looks familiar, right? the loaded SWF will play it's in label.
			loadedSWF.addEventListener(AnimationEvent.ANIMATE_IN,_onLoadedSWFAnimateIn,false,0,true);
		};
		
		// the swf is in. all done.
		private function _onLoadedSWFAnimateIn($evt:AnimationEvent):void
		{
			// now let's trace out the XML data in some organized way, just to show how we can specific data.

			// i like to use roman numerals for my loops. so first we loop through conferences...
			for(var i:int=0;i<_xml.conference.length();i++)
			{
				Out.info(this,"***************** " + _xml.conference[i].@name + " CONFERENCE *****************");

				// then divisions...
				for(var ii:int=0;ii<_xml.conference[i].division.length();ii++)
				{
					Out.info(this,"	---- " + _xml.conference[i].@name + " " + _xml.conference[i].division[ii].@name + "----");
					
					// and then teams...
					for(var iii:int=0;iii<_xml.conference[i].division[ii].team.length();iii++)
					{
						Out.info(this,"		" + _xml.conference[i].division[ii].team[iii].@location + " " + _xml.conference[i].division[ii].team[iii].@name);
					}
				}
				
			}

			// all done.
			Out.fatal(this,"Program complete.");
		};
	};	// close the class.
};		// close the package.