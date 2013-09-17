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
using System.Collections.Generic;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace abstract_factory_example
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
	public class WoodenBarWithWineFactory  : IBarFactory
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
		///	 Constructor
		///</summary>
		public WoodenBarWithWineFactory ()
		{
			//
			//Debug.Log ("WoodenBarWithWineFactory.constructor()");
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~WoodenBarWithWineFactory ( )
		{
			//Debug.Log ("WoodenBarWithWineFactory.deconstructor()");
			
		}
		
		
		
		// PUBLIC
	
		/// <summary>
		/// Creates the tables.
		/// </summary>
		public List<GameObject> createTables()
		{
		
			GameObject codeInstantiatedPrefab = GameObject.Instantiate( Resources.LoadAssetAtPath("Assets/UnityWithCocktails/Lessons/Lesson3.4_Architecture_1/01. Topic_Abstract_Factory/Prefabs/", typeof(GameObject)) ) as GameObject;
			GameObject barrel_gameobject = 
				GameObject.Instantiate(Resources.Load("WoodBarrelPrefab")) as GameObject;
			Debug.Log ("is: " + codeInstantiatedPrefab);
			return null;
			
		}
		
		/// <summary>
		/// Creates the drinks.
		/// </summary>
		/// <returns>
		/// The drinks.
		/// </returns>
		public List<GameObject> createDrinks()
		{
			return null;
			
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
