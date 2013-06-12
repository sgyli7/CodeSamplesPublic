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
public class ModelComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	///<summary>
	///	This is a sample getter/setter property.
	///</
	
	private GameObject _wayPoint;
	public GameObject wayPoint { 
		get 
		{ 
			return _wayPoint; 
		}
		set 
		{ 
			_wayPoint = value; 
			
			float time_float = 3;
			iTween.MoveTo (gameObject, iTween.Hash (
				iT.MoveTo.time,  time_float,
				iT.MoveTo.delay, 0,
				iT.MoveTo.easetype, iTween.EaseType.easeInOutExpo,
				iT.MoveTo.x, wayPoint.transform.position.x,
				//iT.MoveTo.y, wayPoint.transform.position.y,
				iT.MoveTo.z, wayPoint.transform.position.z
				));
			/*
			iTween.MoveBy (gameObject, iTween.Hash (
				iT.MoveBy.time,  time_float/2,
				iT.MoveBy.delay, 0,
				iT.MoveBy.y, wayPoint.transform.position.y + 10,
				iT.MoveBy.looptype, iTween.LoopType.none
				));
			
			iTween.MoveBy (gameObject, iTween.Hash (
				iT.MoveBy.time,  time_float/2,
				iT.MoveBy.delay, time_float/2,
				iT.MoveBy.y, wayPoint.transform.position.y,
				iT.MoveBy.looptype, iTween.LoopType.none
				));
				*/
			
		}
	}
		
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	///<summary>
	///	This is a sample private property.
	///</summary>
	private Light spotlightAbove_light;
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
	    GameObject light_gameobject = new GameObject("The Light");
	    spotlightAbove_light = light_gameobject.AddComponent<Light>();
		
		spotlightAbove_light.transform.parent = gameObject.transform;
		spotlightAbove_light.type = LightType.Spot;
		spotlightAbove_light.range = 8;
		spotlightAbove_light.intensity = .1f;
		spotlightAbove_light.spotAngle = 60;
		spotlightAbove_light.color = new Color (182, 175, 240); 
		spotlightAbove_light.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z);
		
		spotlightAbove_light.transform.LookAt (gameObject.transform);
	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		gameObject.transform.RotateAround (new Vector3 (0,1,0), 0.01f);
		//Debug.DrawRay (transform.position, Vector3.up);
		
	}
	
	// PUBLIC
	
	///<summary>
	///	This is a public method.
	///</summary>
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
}
