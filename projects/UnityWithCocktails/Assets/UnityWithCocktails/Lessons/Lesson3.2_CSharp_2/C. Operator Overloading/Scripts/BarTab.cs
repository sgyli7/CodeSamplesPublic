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
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System;

//--------------------------------------
//  Class
//--------------------------------------
public class BarTab 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	// GETTER / SETTER
	///<summary>
	///	ASSUME: That this value is the most important value exposed by the BarTab class. 
	/// 
	/// NOTE: We overload all operators to help us work with this value.
	/// 
	///</summary>
	private float _totalValue_float;
	public float totalValue 
	{ 
		get
		{
			return _totalValue_float;
		}
		set
		{
			_totalValue_float = value;
			
		}
	}
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Constructor
	//		This runs when "BarTab barTab = new BarTab();" is called
	///</summary>
	public BarTab (float aInitialTotalValue_float = 0) 
	{
		//Debug.Log ("BarTab.constructor()");
		_totalValue_float = aInitialTotalValue_float;
		
	}
	
	///<summary>
	///	Destructor
	//		This runs when "barTab = null;" is called
	///</summary>
	~BarTab () 
	{
		//Debug.Log ("BarTab.destructor()");

		
	}
	
	
		
	// PUBLIC
	
	
		
	// PUBLIC STATIC
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static BarTab operator + (BarTab aBarTab1, BarTab aBarTab2)
	{
	  BarTab barTab = new BarTab();
	  barTab.totalValue = aBarTab1.totalValue + aBarTab2.totalValue;
	  return barTab;
	}
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static BarTab operator - (BarTab aBarTab1, BarTab aBarTab2)
	{
	  BarTab barTab = new BarTab();
	  barTab.totalValue = aBarTab1.totalValue - aBarTab2.totalValue;
	  return barTab;
	}
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static bool operator == (BarTab aBarTab1, BarTab aBarTab2)
	{
		bool equals_boolean = false;
		if (aBarTab1.totalValue == aBarTab2.totalValue) {
			equals_boolean = true;
		}
		return equals_boolean;
	}
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static bool operator != (BarTab aBarTab1, BarTab aBarTab2)
	{
		bool equals_boolean = false;
		if (aBarTab1.totalValue == aBarTab2.totalValue) {
			equals_boolean = true;
		}
		return !equals_boolean;
	}
	
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static bool operator < (BarTab aBarTab1, BarTab aBarTab2)
	{
		bool lessThan_boolean = false;
		if (aBarTab1.totalValue < aBarTab2.totalValue) {
			lessThan_boolean = true;
		}
		return lessThan_boolean;
	}
	
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static bool operator > (BarTab aBarTab1, BarTab aBarTab2)
	{
		bool greaterThan_boolean = false;
		if (aBarTab1.totalValue > aBarTab2.totalValue) {
			greaterThan_boolean = true;
		}
		return greaterThan_boolean;
	}
	
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static bool operator <= (BarTab aBarTab1, BarTab aBarTab2)
	{
		bool lessThanOrEqualTo_boolean = false;
		if (aBarTab1.totalValue <= aBarTab2.totalValue) {
			lessThanOrEqualTo_boolean = true;
		}
		return lessThanOrEqualTo_boolean;
	}
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public static bool operator >= (BarTab aBarTab1, BarTab aBarTab2)
	{
		bool greaterThanOrEqualTo_boolean = false;
		if (aBarTab1.totalValue >= aBarTab2.totalValue) {
			greaterThanOrEqualTo_boolean = true;
		}
		return greaterThanOrEqualTo_boolean;
	}
	
	
	///<summary>
	///	OPERATOR OVERLOAD
	///</summary>
	public override string ToString()
	{
		return "[BarTab "+ _totalValue_float.ToString("00.00")+" ]";
	}
	
	/// <summary>
	/// 	Without this override a warning is shown. I don't really 'do' anything here though.
	/// 
	/// 	NOTE: In your usage, you may need to override this function too.
	/// 
	/// </summary>
	public override bool Equals (object obj)
	{
		return base.Equals (obj);
	}
	
	
	/// <summary>
	/// 	Without this override a warning is shown. I don't really 'do' anything here though.
	/// 
	/// 	NOTE: In your usage, you may need to override this function too.
	/// 
	/// </summary>
	public override int GetHashCode ()
	{
		return base.GetHashCode ();
	}
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}
