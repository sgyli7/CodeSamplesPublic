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
using System.Collections.Generic;
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson31_CSharp_1_Collections : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		//*********************************************************************
		//
		//	UNITY WITH COCKTAILS THEME: COCKTAILS
		//
		//*********************************************************************
		Debug.Log ("//	ARRAY TO LIST		/////////");
		_doDemo_ArrayToList();
		Debug.Log ("//	LIST TO ARRAY		/////////");
		_doDemo_ListToArray();
		Debug.Log ("//	HASH TABLE   		/////////");
		_doDemo_HashTable();
		Debug.Log ("//	DICTIONARY   		/////////");
		_doDemo_Dictionary();
		
	}
	
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	///<summary>
	///	DEMO
	///
	/// NOTE: http://docs.unity3d.com/Documentation/ScriptReference/Array.html
	///
	///</summary>
	private void _doDemo_ArrayToList () 
	{
		//	DEFINE VARIABLES
        string [] strings_array = new string[3];
		strings_array[0] = "white";
		strings_array[1] = "red";
		strings_array[2] = "blend";
		
		//	CONVERT
		List<String> strings_list = new List<String> ();
        foreach (string currentValue_string in strings_array) {
			strings_list.Add (currentValue_string);
        }
		
        //	RUN LOOP
        foreach (string currentValue2_string in strings_list) {
			
            Debug.Log("	VALUE: " +  currentValue2_string);
        }
	
	}
	
	

	///<summary>
	///	DEMO
	///
	/// NOTE: http://docs.unity3d.com/Documentation/ScriptReference/Array.html
	/// 
	/// The key difference between a list and an array is that an array is fixed size while a list is dynamic -- you 
	/// can add new elements to a list, but to add a new element to an array you need to create a new larger array and
	/// copy the old elements. Arrays are a little leaner and more efficient if you don't need dynamic resizing, but 
	/// lists are usually more convenient and the performance difference rarely matters for most applications.
	/// 
	///</summary>
	private void _doDemo_ListToArray () 
	{
		//	DEFINE VARIABLES
		List<String> strings_list = new List<String> ();
		strings_list.Add("white");
		strings_list.Add("red");
		strings_list.Add("blend");
		
		//	CONVERT
		string [] strings_array = strings_list.ToArray();
		
        //	RUN LOOP
        foreach (string currentValue_string in strings_array) {
			
			Debug.Log("	VALUE: " +  currentValue_string);
        }
		
	}
	
	

	///<summary>
	///	DEMO
	///
	/// NOTE: http://www.tutorialspoint.com/csharp/csharp_hashtable.htm
	/// 
	///</summary>
	private void _doDemo_HashTable () 
	{
		//	DEFINE VARIABLES
		Hashtable hashtable = new Hashtable ();
		//				INGREDIENT 		DRINK
		hashtable.Add ("mint", 			"mojito");
		hashtable.Add ("tomato", 		"bloody mary");
		hashtable.Add ("olive", 		"martini");
		
        //	RUN LOOP
		ICollection keys_icollection = hashtable.Keys;
		
		foreach (string key_string in keys_icollection) {
			Debug.Log("	VALUE: " +  key_string + " = " + hashtable[key_string]);
		}
		
		//	HASHTABLE BENEFIT: CHECK DIRECTLY, VALUE BY KEY. VERY FAST ACCESS.
		Debug.Log("	DIRECT VALUE: " +  hashtable["mint"]);
		
	}
	
	


	///<summary>
	///	DEMO
	///
	/// OPINION: DICTIONARY IS LIKE HASHTABLE, BUT WITH STRONGLY TYPED KEY AND VALUE.
	///
	/// NOTE: http://www.dotnetperls.com/dictionary
	/// 
	///</summary>
	private void _doDemo_Dictionary () 
	{
		//	DEFINE VARIABLES
		Dictionary<string, int> drinksConsumed_dictionary = new Dictionary<string, int>();
		//								TYPE(STRING)    	COUNT(INT)
		drinksConsumed_dictionary.Add	("bottles", 		2);
		drinksConsumed_dictionary.Add	("cans", 			1);
		drinksConsumed_dictionary.Add	("glasses", 		7);
		
        //	RUN LOOP
		foreach (KeyValuePair<string, int> keyValuePair in drinksConsumed_dictionary) {
			
			Debug.Log("	VALUE: " +  keyValuePair.Key + " = " + keyValuePair.Value);
		}
		
		
	}
	
	
	
		
	// PRIVATE STATIC
	
	// PRIVATE COROUTINE
	
	// PRIVATE INVOKE
	
	//--------------------------------------
	//  Events 
	//		(This is a loose term for -- handling incoming messaging)
	//
	//--------------------------------------






}
