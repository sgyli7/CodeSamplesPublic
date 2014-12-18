/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
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


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.mvc.model.data
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GemVO 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		
		// 	PUBLIC
		public int RowIndex;
		public int ColumnIndex;
		public int GemTypeIndex;
		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	

		public GemVO (int rowIndex, int columnIndex, int gemTypeIndex)
		{
			
			RowIndex = rowIndex;
			ColumnIndex = columnIndex;
			GemTypeIndex = gemTypeIndex;
			
			//
			//Debug.Log (this);
		}
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// PUBLIC
		
		/// <summary>
		/// Show nice debuggable output
		/// </summary>
		override public string ToString ()
		{
			return "[GemVO (r="+RowIndex+", c="+ColumnIndex+", gti="+GemTypeIndex+")]";
			
		}
		
		
		//	PRIVATE
		
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}




