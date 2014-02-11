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
using strange.extensions.mediation.impl;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.spider_strike.components.effects
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
	public class TurretBulletSpawnPointComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The muzzle flash materials_array.
		/// </summary>
		public Material[] muzzleFlashMaterials_array;


		/// <summary>
		/// The muzzle flash_gameobject.
		/// </summary>
		public GameObject muzzleFlash_gameobject;
		
		
		// PUBLIC STATIC
		
		
		// PRIVATE
		/// <summary>
		/// The _life duration_float.
		/// </summary>
		private float _lifeDuration_float;


		/// <summary>
		/// The _angle_float.
		/// </summary>
		private float _angle_float;

		
		
		// PRIVATE STATIC
		/// <summary>
		/// The _ LIF e_ DURATIO n_ MINIMU.
		/// </summary>
		private const float _LIFE_DURATION = 0.1f;

		//--------------------------------------
		//  Methods
		//--------------------------------------	

		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		public TurretBulletSpawnPointComponent( )
		{
			//Debug.Log ("1. TurretBulletSpawnPointComponent.constructor()");
			
		}
		
		~TurretBulletSpawnPointComponent()
		{
			
		}


		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{

		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update ()
		{
			muzzleFlash_gameobject.transform.LookAt(Camera.main.transform.position);
			Vector3 eulerAngles_vector3 = muzzleFlash_gameobject.transform.localEulerAngles;
			eulerAngles_vector3.z 		= _angle_float;
			muzzleFlash_gameobject.transform.localEulerAngles 	= eulerAngles_vector3;
		}




		// PUBLIC
		/// <summary>
		/// Shows the muzzle flash.
		/// </summary>
		public void showMuzzleFlash ()
		{
			//
			//Debug.Log ("showMuzzleFlash()");

			//
			_angle_float 				= 90 * Mathf.Round(Random.Range(0,3));


			//
			int materialIndex_int = Mathf.RoundToInt(Random.Range(0,muzzleFlashMaterials_array.Length));
			muzzleFlash_gameobject.renderer.material = muzzleFlashMaterials_array[0];

			CancelInvoke ("_hideMuzzleFlash");
			Invoke ("_hideMuzzleFlash", _LIFE_DURATION);


			//TODO: WHAT IS THE MOST EFFICIENT WAY TO TOGGLE VISIBLITY
			muzzleFlash_gameobject.renderer.enabled = true;
		}


		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _hides the muzzle flash.
		/// </summary>
		private void _hideMuzzleFlash()
		{
			//Debug.Log ("_hideMuzzleFlash()");
			muzzleFlash_gameobject.renderer.enabled = false;
			
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
}

