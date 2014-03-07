/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.paddle_soccer.mvcs.controller.signals;
using System.Collections;
using com.rmc.projects.paddle_soccer.components;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.ui
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// Enemy placement.
	/// </summary>
	public enum EnemyPlacement
	{
		DEBUG,
		PRODUCTION

	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class GameManagerUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The player paddle_gameobject.
		/// </summary>
		public GameObject playerPaddle_gameobject;

		/// <summary>
		/// The cpu paddle_gameobject.
		/// </summary>
		public GameObject cpuPaddle_gameobject;


		/// <summary>
		/// When the intro user interface game object.
		/// </summary>
		public GameObject introUIGameObject;

		/// <summary>
		/// Gets or sets all views initialized signal.
		/// </summary>
		/// <value>All views initialized signal.</value>
		[Inject]
		public AllViewsInitializedSignal allViewsInitializedSignal {get; set;}



		// PUBLIC STATIC
		
		// PRIVATE

		/// <summary>
		/// The cpu paddle component.
		/// </summary>
		public PaddleComponent cpuPaddleComponent {set; get;}

		/// <summary>
		/// The player paddle component.
		/// </summary>
		public PaddleComponent playerPaddleComponent {set; get;}

		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();

			//
			cpuPaddleComponent 		= cpuPaddle_gameobject.GetComponent<PaddleComponent>();
			playerPaddleComponent	= playerPaddle_gameobject.GetComponent<PaddleComponent>();

			//WE DISABLE THE INTRO TO EASE THE USE OF THE UNITY IDE
			//HERE WE ENABLE IT
			introUIGameObject.SetActive (true);

			//
			StartCoroutine ( Wait_ThenAllViewsInitializedSignal ());
		}


		/// <summary>
		/// Wait_s the then all views initialized signal.
		/// </summary>
		/// <returns>The then all views initialized signal.</returns>
		public IEnumerator Wait_ThenAllViewsInitializedSignal ()
		{

			/*
			 * TODO: WHAT IS THE BEST WAY TO NOTIFY THE MVCS SYSTEM THAT THE VIEWS ARE READY?
			 * 
			 * THIS IS A FULLY FUNCTIONAL WORKAROUND, BUT WE ARE MANUALLY 'WAITING'
			 * 
			 * 
			 **/
			yield return new  WaitForEndOfFrame ();


			//
			allViewsInitializedSignal.Dispatch ();

		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
		}
		
		// PUBLIC
		
		
		// PUBLIC STATIC

		
		// PRIVATE


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

