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
//Marks the right margin of code *******************************************************************
package {
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import flash.text.engine.EastAsianJustifier;
	
	import feathers.controls.ScreenNavigator;
	import feathers.controls.ScreenNavigatorItem;
	import feathers.motion.transitions.ScreenSlidingStackTransitionManager;
	import feathers.themes.MetalWorksMobileTheme;
	
	import starling.animation.Transitions;
	import starling.core.Starling;
	import starling.display.DisplayObject;
	import starling.display.DisplayObjectContainer;
	import starling.display.Sprite;
	import starling.events.Event;
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>The <code>Game</code> class.</p>
	 * 
	 */
	public class Game extends Sprite{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		
		// PUBLIC CONST
		
		
		// PRIVATE
		
		// --------------------------------------
		// Constructor
		// --------------------------------------

		private var _screenNavigator:ScreenNavigator;
		/**
		 * This is the constructor.
		 * 
		 */ 
		public function Game(){
			
			// SUPER
			super();

			// EVENTS
			addEventListener(Event.ADDED_TO_STAGE, _onAddedToStage);
		}
		
		
		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		private function _doLayout () : void
		{
			//
			_setThemeClass (MetalWorksMobileTheme);
			
			_screenNavigator = new ScreenNavigator ();
			addChild(_screenNavigator);
			
			//
			var mainMenuScreenNavigatorItem : ScreenNavigatorItem = new ScreenNavigatorItem (MainMenuScreen, {complete: _onScreenComplete});
			_screenNavigator.addScreen(MainMenuScreen.ID, mainMenuScreenNavigatorItem);
			
			var listMenuScreenNavigatorItem : ScreenNavigatorItem = new ScreenNavigatorItem (ListMenuScreen, {complete: _onScreenComplete});
			_screenNavigator.addScreen(ListMenuScreen.ID, listMenuScreenNavigatorItem);
			
			//
			_screenNavigator.showScreen(MainMenuScreen.ID);
			
			var screenSlidingStackTransitionManager : ScreenSlidingStackTransitionManager = new ScreenSlidingStackTransitionManager (_screenNavigator);
			screenSlidingStackTransitionManager.delay 		= 0.0;
			screenSlidingStackTransitionManager.duration 	= 0.5;
			screenSlidingStackTransitionManager.ease 		= Transitions.EASE_IN_OUT;
		}	
		
		private function _onScreenComplete(aEvent : Event) : void
		{
			if (aEvent.currentTarget is MainMenuScreen) {
				_screenNavigator.showScreen(ListMenuScreen.ID);
			} else if (aEvent.currentTarget is ListMenuScreen) {
				_screenNavigator.showScreen(MainMenuScreen.ID);
			} else {
				//TODO, MAKE ERROR
				throw new Error ("Switchstatement");
			}
		}
		
		private function _setThemeClass(aTheme_class:Class):void
		{
			new aTheme_class (this);
			
		}	
		
		
		
		// --------------------------------------
		// Events
		// --------------------------------------
		/**
		 * Handles the Event: <code>Event.ADDED_TO_STAGE</code>.
		 * 
		 * @param aEvent <code>Event</code> The incoming aEvent payload.
		 *  
		 * @return void
		 * 
		 */	
		private function _onAddedToStage (aEvent : Event) : void
		{
			_doLayout();
			
		}
		
		
		

		
	}
}
