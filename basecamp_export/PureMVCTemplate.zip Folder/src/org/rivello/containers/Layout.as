//Marks the right margin of code *******************************************************************
package org.rivello.containers
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	import flash.events.Event;
	import flash.events.EventDispatcher;
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * Class to facilitate the <code>layout</code> property of <code>Container</code> classes.
	 * 
	 * @example Here is a code example.  
     * <listing version="3.0" >
	 * 	//Code example goes here.
	 *  var container:Container = new Container ();
	 *  container.layout = Layout.ABSOLUTE;
	 * </listing>
	 *
     * <span class="hide">Any hidden comments go here.</span>
     *
	*/
	public class Layout extends Object
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		
		//PUBLIC CONSTANTS
		/**
		 * Value to facilitate the <code>layout</code> property of <code>Container</code> classes.
		 *
		 * @default ABSOLUTE 
		*/
		public static const ABSOLUTE : String = "absolute";
		
		/**
		 * Value to facilitate the <code>layout</code> property of <code>Container</code> classes.
		 * 
		 * @default VERTICAL 
		*/		
		public static const VERTICAL : String = "vertical";
		
		/**
		 * Value to facilitate the <code>layout</code> property of <code>Container</code> classes.
		 * 
		 * @default HORIZONTAL 
		*/
		public static const HORIZONTAL : String = "horizontal";
		
		//PRIVATE
	
		
		

		
	}
}