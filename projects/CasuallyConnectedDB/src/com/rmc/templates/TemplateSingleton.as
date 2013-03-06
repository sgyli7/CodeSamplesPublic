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
package com.rmc.templates
{
	
	// --------------------------------------
	// Imports
	// --------------------------------------
	import com.rmc.errors.SingletonInstantiationError;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	
	// --------------------------------------
	// Metadata
	// --------------------------------------
	/**
	 * Dispatched when ...
	 * 
	 * @aEventType com.rmc.templates.TemplateClass.SAMPLE_LOADED
	 * 
	 */
	[Event( name="sampleLoaded", type="flash.events.Event" )]
	
	
	// --------------------------------------
	// Class
	// --------------------------------------
	/**
	 * <p>This is designed to...</p>
	 * 
	 */
	public class TemplateSingleton extends EventDispatcher
	{
		
		// --------------------------------------
		// Properties
		// --------------------------------------
		// PUBLIC GETTER/SETTERS
		/**
		 * Describe this member.
		 * 
		 */
		public function get sample() 						: String 		{ return _sample_str; }
		public function set sample(aValue : String) 		: void 			{ _sample_str = aValue; }
		private var _sample_str : String;
		
		
		// PUBLIC CONST
		/**
		 * 
		 * The <code>TemplateClass.SAMPLE_LOADED</code> constant defines the aValue of the <code>type</code> 
		 * property of the aEvent object of type <code>aEvent</code>.
		 *
		 * <p>The properties of the aEvent object have the following aValues:</p>
		 * <table class='innertable'>
		 * <tr><th>Property</th><th>aValue</th></tr>
		 * <tr><td>bubbles</td><td>false</td></tr>
		 * <tr><td>cancelable</td><td>false</td></tr>
		 * <tr><td>currentTarget</td><td>The object that is actively processing the aEvent object with an aEvent listener.</td></tr>
		 * <tr><td>target</td><td>Any DisplayObject instance with a listener registered for this aEvent.</td></tr>
		 * ...
		 * </table>
		 * 
		 * @aEventType sampleLoaded
		 * 
		 */
		public static const SAMPLE_LOADED : String = "sampleLoaded";
		
		
		/**
		 * Describe this member.
		 * 
		 * @default SAMPLE_STATIC_CONSTANT 
		 * 
		 */
		public static const SAMPLE_STATIC_CONSTANT : String = "SAMPLE_STATIC_CONSTANT";
		
		
		// PRIVATE
		/**
		 * Describe this member.
		 * 
		 */
		private var _sample2_str : String;
		
		
		//	PRIVATE STATIC
		/**
		 * The instance used for Singleton behavior.
		 * 
		 */
		private static var _Instance : TemplateSingleton;
		
		
		
		// --------------------------------------
		// Constructor
		// --------------------------------------
		/**
		 * This is the constructor.
		 * 
		 */
		public function TemplateSingleton (aSingletonEnforcer : SingletonEnforcer)
		{
			if ( _Instance ) {
				throw new SingletonInstantiationError();
			} else {
				
				// SUPER
				
				// EVENTS
				
				// VARIABLES
				
				// PROPERTIES
				
				// METHODS
			}			
			
			
		}
		
		
		// --------------------------------------
		// Methods
		// --------------------------------------
		// PUBLIC STATIC
		/**
		 * Get an instance of the singleton class.
		 * 
		 * @return <code>TemplateSingleton</code> The instance.
		 *
		 */
		public static function getInstance() : TemplateSingleton 
		{
			if (!_Instance) {
				_Instance = new TemplateSingleton( new SingletonEnforcer() );
			}
			return _Instance;
		}
		
		// PUBLIC
		/**
		 * Describe this member.
		 * 
		 * @param aSample_str Describe this parameter.
		 * 
		 * @return String Describe this return.
		 * 
		 */
		public function sampleMethod(aSample_str : String) : String
		{
			return "sample";
		}
		
		
		// PRIVATE
		/**
		 * Describe this member.
		 * 
		 * @param aSample_str Describe this parameter.
		 * 
		 * @return String Describe this return.
		 * 
		 */
		private function _sampleMethod2(aSample_str : String) : String
		{
			return "sample";
		}
		
		
		// --------------------------------------
		// Event Handlers
		// --------------------------------------
		/**
		 * Handles the aEvent: <code>TemplateClass.SAMPLE_LOADED</code>.
		 * 
		 * @param aEvent <code>aEvent</code> The incoming aEvent payload.
		 *  
		 * @return void
		 * 
		 */
		private function _onSampleProcessComplete(aEvent : Event) : void
		{
			
		}
		
	}
}

//--------------------------------------
//  Singleton Enforcer: This Prevents 
//  Instantiation Of The Class Above
//	From Anywhere Outside This Document
//--------------------------------------
internal class SingletonEnforcer {}