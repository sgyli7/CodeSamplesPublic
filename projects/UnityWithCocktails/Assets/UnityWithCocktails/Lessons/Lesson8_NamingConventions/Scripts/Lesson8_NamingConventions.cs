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
using lesson_8_naming_conventions;
using Lesson8NamingConventions;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace sample_namespace
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
	public class Lesson8_NamingConventions : MonoBehaviour 
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
		// PUBLIC
		
		///<summary>
		///	Use this for initialization
		///</summary>
void Start () 
{

//-----------------------------------------------------------------
//  1. RMC Naming Conventions
//
//			(See http://www.rivellomultimediaconsulting.com/c-sharp-coding-conventions-and-standards/ )
//
//-----------------------------------------------------------------

// INSTANTIATE
//1.1
ClassWithRMCConventions classWithRMCConventions = new ClassWithRMCConventions();	

// STATIC MEMBER
//1.2
ClassWithRMCConventions.SamplePublicStaticMethod("foo string1");					
//1.3
string s1 = ClassWithRMCConventions.SAMPLE_PUBLIC_STATIC_CONSTANT;					

// INSTANCE MEMBER
//1.4
classWithRMCConventions.samplePublicMethod("foo string1");							
//1.5
classWithRMCConventions.samplePublicVariable = "foo blah string1";					



//-----------------------------------------------------------------
//  2. C# Naming Conventions 	
//
//			(See http://msdn.microsoft.com/en-us/library/vstudio/ff926074.aspx)
//			(See http://msdn.microsoft.com/en-us/library/ms229045.aspx)
//
//-----------------------------------------------------------------

// INSTANTIATE
//2.1
ClassWithCSharpConventions classWithCSharpConventions = new ClassWithCSharpConventions();	

// STATIC MEMBER
//2.2
ClassWithCSharpConventions.SamplePublicStaticMethod("foo string2");							
//2.3
string s2 = ClassWithCSharpConventions.SamplePublicStaticConstant;							

// INSTANCE MEMBER
//2.4
classWithCSharpConventions.SamplePublicMethod("foo string2");								
//2.5
classWithCSharpConventions.SamplePublicVariable = "foo blah string2";						

//-----------------------------------------------------------------
//  A. Analysis of Naming Convention - Class External (Referring ONLY to outside of a class, its API, as shown above)	
//
//			1. RMC Convention 	 is **unique**   across each; public vs. static, method vs variable, non-constant vs constant.
//			2. CSharp Convention is **the same** across each.
//
//-----------------------------------------------------------------


//-----------------------------------------------------------------
//  B. Analysis of Naming Convention - Class Internal (Referring ONLY to inside of a class)	
//
//			1. RMC Convention 	 is TBD.
//			2. CSharp Convention is TBD.
//
//-----------------------------------------------------------------

}
		
		// PUBLIC
	
		// PUBLIC STATIC

		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
	}
}
