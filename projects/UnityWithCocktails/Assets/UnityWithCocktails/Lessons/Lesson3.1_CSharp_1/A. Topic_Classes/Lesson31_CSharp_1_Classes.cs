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
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson31_CSharp_1_Classes: MonoBehaviour 
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
		
		Debug.Log ("\n");
		Debug.Log ("//	PARTIAL	///////////////////////");
		_doDemoOfPartialClass();
		Debug.Log ("\n");
		Debug.Log ("//	INTERFACE	///////////////////////");
		_doDemoOfInterface();
		Debug.Log ("\n");
		Debug.Log ("//	DOWN CASTING	///////////////////////");
		_doDemoOfDownCasting();
		Debug.Log ("\n");
		Debug.Log ("//	UP CASTING	///////////////////////");
		_doDemoOfUpCasting();
		Debug.Log ("\n");
		Debug.Log ("//	SINGLETON	///////////////////////");
		_doDemoOfSingleton();
		Debug.Log ("\n");
		Debug.Log ("//	STRUCT	///////////////////////");
		_doDemoOfStruct();
		
		

	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	//******************************************************
	//******************************************************
	//**	PARTIAL CLASS
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/vstudio/wa80x488.aspx);
	///</summary>
	private void _doDemoOfPartialClass () 
	{
		// DECLARE
		PartialClass partialClass = new PartialClass ();
		
		// USE
		partialClass.sampleMethod2();
		partialClass.sampleMethod3();
		Debug.Log ("partialClass: " + partialClass);
		
		
	}

	
	//******************************************************
	//******************************************************
	//**	INTERFACE CLASS
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfInterface () 
	{
		// DECLARE WITH TYPE OF INTERFACE 
		//	(TYPE 'IMixer' GIVES MORE ARCHITECTURAL FLEXIBLITY THAN TYPE 'HandMixer')
		IMixer iMixer = new HandMixer ();
		
		// USE
		iMixer.doMixing();
		Debug.Log ("iMixer: " + iMixer);
		
		
	}
	
	
	
	//******************************************************
	//******************************************************
	//**	CASTING
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfDownCasting () 
	{
		// DECLARE WITH TYPE OF SUPERCLASS 
		//	ADVANCED: YOU MAY SOME DAY HAVE REASONS TO DO THIS
		Mixer mixer = new ElectricMixer ();
		
		// USE
		mixer.doMixing();
		Debug.Log ("mixer: " + mixer);
		
		//	1. NOTICE: THE INSTANCE HAS THIS METHOD
		//	BUT THE COMPILER WILL NOW ALLOW
		//mixer.washElectricParts();
		
		//	2. NOTICE: WHEN WE 'DOWNCAST' THIS, THEN IT WORKS.
		//			DOWNCASTING IS TO MAKE THE TYPE BEHAVE AS A *MORE* SPECIFIC TYPE.
		//			MORE SPECIFIC MEANS 'LIKE A SUBCLASS' IN THIS CASE
		(mixer as ElectricMixer).washElectricParts();
	}
	
	
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	///</summary>
	private void _doDemoOfUpCasting () 
	{
		// DECLARE WITH TYPE OF SUPERCLASS 
		//	ADVANCED: YOU MAY SOME DAY HAVE REASONS TO DO THIS
		HandMixer handMixer = new HandMixer ();
		
		//	NOTICE: 'UPCASTING' HAPPENS AUTOMATICALLY HERE. THE METHOD WANTS A 'Mixer'
		//			AND THE COMPILER KNOWS THAT 'HandMixer' CAN BE UPCAST PROPERLY
		//			'UPCASTING' IS TO MAKE THE TYPE BEHAVE AS A *LESS* SPECIFIC TYPE.
		//			LESS SPECIFIC MEANS 'LIKE A SUPERCLASS' IN THIS CASE
		_acceptOnlyAMixer (handMixer);
		
		//	YOU CAN MANUALLY UPCAST TOO, AND THERE MAY BE (RARE) REASONS TO DO THAT
		(handMixer as Mixer).doMixing();
		
	}
	
	/// <summary>
	/// _accepts the only a 'Mixer' typed instance
	/// </summary>
	private void _acceptOnlyAMixer (Mixer aMixer) 
	{
		Debug.Log ("	_acceptOnlyAMixer: " + aMixer);
	}
	
	//******************************************************
	//******************************************************
	//**	SINGLETON
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/ff650316.aspx);
	///</summary>
	private void _doDemoOfSingleton () 
	{
		// USE
		CustomSingleton.Instance.countUp();
		CustomSingleton.Instance.countUp();
		CustomSingleton.Instance.countUp();
		Debug.Log ("CustomSingleton.getCount()" + CustomSingleton.Instance.getCount());
		
	}
	
	
	//******************************************************
	//******************************************************
	//**	STRUCT
	//******************************************************
	//******************************************************
	
	/// <summary>
	/// Demo struct.
	///  NOTE: These are like classes but meant for more 'temporary?' data structures without 'functionality' (methods)
	/// 
	///  NOTE: Seems to have a few differences from a class here on the 'inside' when declaring it
	/// 
	///  OPINION ONLINE: 	The only difference between a class and a struct in C++ is that structs have default public members 
	/// 					and bases and classes have default private members and bases. Both classes and structs can have a 
	/// 					mixture of public and private members, can use inheritance, and can have member functions.
	/// 					I would recommend using structs as plain-old-data structures without any class-like features, 
	/// 					and using classes as aggregate data structures with private data and member functions.
	//
	//	REFERENCE: URL (http://msdn.microsoft.com/en-us/library/ah19swz4%28v=VS.71%29.aspx);
	/// </summary>
	public struct DemoStruct
	{
		// PROPERTIES
		public int sample_int;
		public float sample_float;
		
		// CONSTRUCTORS
		public DemoStruct (int aSample_int, float aSample_float )
	    {
			//INTERESTINGLY, COMPILER REQUIRES THAT *ALL* PROPERTIES MUST BE DECLARED IN CONSTRUCTOR
			sample_float  	= aSample_float;
	        sample_int 		= aSample_int;
			
			//
			_doInit();
	    }
		
		// METHODS
		private void _doInit()
		{
			//do something else...
			sample_float = 5.5f;
		}
		
	}
	
	
	
	
	/// <summary>
	/// _dos the demo of struct.
	/// </summary>
	private void _doDemoOfStruct () 
	{
		
		//SEEMS TO BEHAVE VERY MUCH LIKE A CLASS FROM THE 'OUTSIDE'
		DemoStruct myDemoStruct = new DemoStruct (1, 1.1f);
		myDemoStruct.sample_int = 2;
		_doDemoOfStructWhichPassByValue (myDemoStruct); //changes myDemoStruct.sample_float to 99.99f
		
		Debug.Log ("_doDemoOfStruct() myDemoStruct: " + myDemoStruct);
		Debug.Log ("_doDemoOfStruct() myDemoStruct.sample_int: " + myDemoStruct.sample_int);
		Debug.Log ("_doDemoOfStruct() myDemoStruct.sample_float: " + myDemoStruct.sample_float);
		
	}
	
	/// <summary>
	/// _dos the demo of struct which pass by value.
	/// </summary>
	/// 
	/// NOTE: FYI, if you pass a class instance it is passed by reference
	/// NOTE: *BUT*, if you pass a struct instance it is passed by value ( a copy )
	/// 
	/// <param name='aDemoStruct'>
	/// A demo struct.
	/// </param>
	private void _doDemoOfStructWhichPassByValue (DemoStruct aDemoStruct) 
	{
		
		//THIS WILL NOT 'PERMANTELY' AFFECT THE DemoStruct INSTANCE 
		aDemoStruct.sample_float = 2.2f;
		
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
