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
namespace com.rmc.projects.triple_match.mvc.view.view_components
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
	public class GemExplosionViewComponent : MonoBehaviour
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// 	GETTER / SETTER
		
		// 	PUBLIC

		
		// 	PRIVATE
		
		[SerializeField]
		private GameObject _particleSystemPrefab;

		//
		private ParticleSystem _particleSystem;
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	
		
		
		//--------------------------------------
		//	Unity Methods
		//--------------------------------------

		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{

			GameObject particleSystemPrefabInstance = Instantiate (_particleSystemPrefab) as GameObject;
			particleSystemPrefabInstance.transform.SetParent (transform, false);

			_particleSystem = particleSystemPrefabInstance.GetComponent<ParticleSystem>();

			//	FOR SHURIKEN PARTICLE EFFECTS ON TOP OF UNITY 4.6.X 2D, WE MUST ADJUST THE SORTING LAYER
			_particleSystem.renderer.sortingLayerName = TripleMatchConstants.SORTING_LAYER_PARTICLE_EFFECTS;
			_particleSystem.renderer.sortingOrder = 1;
		}

		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		protected void OnDestroy () 
		{
			
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		//	PUBLIC
		
		
		//	PRIVATE
		
		
		//--------------------------------------
		//	Event Handlers
		//--------------------------------------
	}
}