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
using abstract_factory_example;

//--------------------------------------
//  Class
//--------------------------------------
public class Lesson_34_Topic_Abstract_Factory: MonoBehaviour 
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
		
		/*
		 *  PATTERN:		Abstract Factory
		 * 
		 *	DEFINITION:  	Provide an interface for creating families of related or dependent 
		 *					objects without specifying their concrete classes. 
		 * 
		 * 
		 * 	REFERENCE: 		http://www.dofactory.com/Patterns/PatternAbstract.aspx#_self1
		*/
		
		Debug.Log ("\n");
		Debug.Log ("//	ABSTRACT FACTORY	///////////////////////");
		_doDemoOfPattern();

		
		

	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// _dos the demo of the pattern.
	/// </summary>
	private void _doDemoOfPattern ()
	{
		
		IBarFactory woodenBarWithWineFactory 	= new WoodenBarWithWineFactory();
		IBar woodenBarWithWine					= new WoodenBarWithWine(woodenBarWithWineFactory);
		woodenBarWithWine.doSetupBar();
		
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
