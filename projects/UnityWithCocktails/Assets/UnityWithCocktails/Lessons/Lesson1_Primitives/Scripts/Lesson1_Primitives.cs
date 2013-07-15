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
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson1_Primitives : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	///<summary>
	///	This is a sample getter/setter property.
	///</summary>
		
	// PUBLIC
	///<summary>
	///	An enum is often used for storing and checking the category/type of things.
	///</summary>
	public enum DrinkTemperatureType
	{
		COLD,
		HOT,
		ROOM_TEMPERATURE
	}
	
	// PUBLIC STATIC
	///<summary>
	///	This is a sample public static property.
	///</summary>
	
	// PRIVATE
	///<summary>
	///	This is a sample private property.
	///</summary>
	
	// PRIVATE STATIC
	///<summary>
	///	This is a sample private static property.
	///</summary>
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//	REFERENCE
		// 	SEE ALSO sbyte, byte, char, short, ushort, long, ulong, more on 
		//		http://msdn.microsoft.com/en-us/library/exx3b86w%28VS.80%29.aspx
		//		http://msdn.microsoft.com/en-us/library/ya5y69ds%28v=VS.80%29.aspx
		
		
		
		//*********************************************************************
		//
		//	UNITY WITH COCKTAILS THEME: WINE
		//
		//*********************************************************************
				
		
		//	DECLARE 
		string		ourTheme_string   					= "wine";
		bool		isARedWine_boolean 					= true;
		uint		totalMillilitersPerBottle_uint  	= 750;
		int 		myRatingForMerlot_int 				= -10;
		float 		totalOuncesPerBottle_float 			= 25.4f; //the 'f' forces 'float' (accurate) instead of default 'double' (more accurate, more memory needed)
		double      averageGrapesPerBottleOfWine_double = 550.3;
		
		//	Enums
		DrinkTemperatureType   hisDrinkType = DrinkTemperatureType.COLD;
		DrinkTemperatureType   herDrinkType = DrinkTemperatureType.HOT;

		//	Arrays
		string[]    favoriteRedWines_array     	= new string[2];
		favoriteRedWines_array[0]				= "Malbec";
		favoriteRedWines_array[1]				= "Merlot";
		//
		string[]    favoriteWhiteWines_array    = new string[2];
		favoriteWhiteWines_array[0]				= "Chardonnay";
		favoriteWhiteWines_array[1]				= "Pinot Grigio";
		
		//	Anonymous Object Creation (quick & easy, for prototyping)
		var      emptyBottleOfWine_object       = new { color = "red", isFlavorful_boolean = true};
		
		
		//	USE
		Debug.Log ("--------------");
		Debug.Log ("ourTheme_string: 						" 	+ ourTheme_string);
		Debug.Log ("isARedWine_boolean: 					" 	+ isARedWine_boolean);
		Debug.Log ("totalMillilitersPerBottle_uint: 		" 	+ totalMillilitersPerBottle_uint);
		Debug.Log ("myRatingForMerlot_int: 							" 	+ myRatingForMerlot_int);
		Debug.Log ("totalOuncesPerBottle_float: 			" 	+ totalOuncesPerBottle_float);
		Debug.Log ("averageGrapesPerBottleOfWine_double: 	" 	+ averageGrapesPerBottleOfWine_double);
		//
		Debug.Log ("favoriteRedWines_array: 				" 	+ favoriteRedWines_array[0]);
		Debug.Log ("favoriteWhiteWines_array: 				" 	+ favoriteWhiteWines_array.ToString());
		Debug.Log ("emptyBottleOfWine_object.color: 		" 	+ emptyBottleOfWine_object.color);
		//
		Debug.Log ("same drinktype?: " 	+ (hisDrinkType == herDrinkType));
		
		//	REFLECTION - WHAT INFORMATION IS IS AVAILABLE ABOUT EACH VARIABLE? 
		Debug.Log ("--------------");
		Debug.Log ("ourTheme_string:" 	+ ourTheme_string			);
		Debug.Log ("	type 	: " + ourTheme_string.GetType()		);
		Debug.Log ("	typeof 	: " + typeof(string)		);
		Debug.Log ("	is 		: " + (ourTheme_string is string)	);
		Debug.Log ("	as 		: " + (ourTheme_string as string)	);
		
		
	}
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		
	}
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------

}

