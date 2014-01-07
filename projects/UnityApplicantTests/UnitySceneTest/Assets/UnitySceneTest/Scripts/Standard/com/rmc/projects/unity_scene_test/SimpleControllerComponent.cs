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
using com.rmc.exceptions;

//--------------------------------------
//  Namespace
//--------------------------------------
using System.Collections.Generic;


namespace com.rmc.projects.unity_scene_test
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum CameraMode
	{
		CAMERA_MODE_MAIN,
		CAMERA_MODE_ZOOM

	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class SimpleControllerComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		// PUBLIC
		/// <summary>
		/// The main camera.
		/// </summary>
		public Camera mainCamera;
		
		/// <summary>
		/// The zoom camera.
		/// </summary>
		public Camera zoomCamera;

		/// <summary>
		/// The GUI component.
		/// </summary>
		public GUIComponent guiComponent;

		/// <summary>
		/// The material_list.
		/// </summary>
		public List<Material> material_list;

		/// <summary>
		/// The URL_string.
		/// </summary>
		public string url_string;

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _material list current index_int.
		/// </summary>
		private int _materialListCurrentIndex_int;




		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_materialListCurrentIndex_int = -1; //so first loaded will be index 0
			doChangeCameraMode (CameraMode.CAMERA_MODE_MAIN);
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			//Debug.Log("Update ()");
			
		}
		
		// PUBLIC
		/// <summary>
		/// Changes the camera mode.
		/// </summary>
		/// <param name="aCameraMode">A camera mode.</param>
		public void doChangeCameraMode (CameraMode aCameraMode)
		{
			switch (aCameraMode) {
				case CameraMode.CAMERA_MODE_MAIN:
					mainCamera.enabled = true;
					zoomCamera.enabled = false;
					guiComponent.buttonsEnabled = false;
					break;
				case CameraMode.CAMERA_MODE_ZOOM:
					mainCamera.enabled = false;
					zoomCamera.enabled = true;
					guiComponent.buttonsEnabled = true;
					break;
				default:
					throw new SwitchStatementException();
					break;
			}

		}

		/// <summary>
		/// Dos the open URL.
		/// </summary>
		/// <param name="aURL_string">A URL_string.</param>
		public void doOpenURL ()
		{
			Application.OpenURL(url_string);
		}

		/// <summary>
		/// Dos the change to random texture for game object.
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void doChangeToRandomTextureForGameObject (GameObject gameObject)
		{
			//GET NEXT TEXTURE (LOOP TO FIRST AS NEEDED)
			if (_materialListCurrentIndex_int++ >= material_list.Count - 1) {
				_materialListCurrentIndex_int = 0;
			}

			//APPLY TEXTURE
			gameObject.renderer.material = material_list[_materialListCurrentIndex_int];
		}

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------


	}
}
