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
package com.rmc.data.types.enums
{
	//--------------------------------------
	//  Imports
	//--------------------------------------
	
	
	//--------------------------------------
	//  Special Instructions
	//--------------------------------------
	/**
	 * Subclasses of <code>Enum<code> automatically get injected with a 'name' property within each Enum property below matching its 
	 * reference name to assist debugging through Flex Builder's 'Variables' Panel - samr
	 * It is solely to help debugging.  Set a breakpoint and introspect an instance of this class to see.
	 * 
	 * REQUIRED: In every subclass, but not in superclass.
	 */	
	//{CStringUtils.InitEnumConstants(GameState);} //keep commented out in this class, use only in subclasses
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/**
	 * <p>The <code>Enum</code> is a strong type used for 'state' checking.</p>
	 *
	 */
	public class Enum extends Object
	{		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		//PUBLIC GETTER/SETTERS
		
		//PUBLIC
		public var Text :String;
		
		//PUBLIC CONST
		
		//PRIVATE
		
		//--------------------------------------
		//  Constructor
		//--------------------------------------

		//--------------------------------------
		//  Methods
		//--------------------------------------		
		//PUBLIC	
		/**
		 * Aids output panel statements on the object references to show the name.
		 *
		 * @return String
		 */
		public function toString () : String
		{
			return Text;
		}
		
		//PRIVATE	
		
		
	}
}