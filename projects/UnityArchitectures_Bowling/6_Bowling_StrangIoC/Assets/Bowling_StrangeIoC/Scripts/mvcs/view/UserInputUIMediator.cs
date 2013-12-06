/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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
using com.rmc.projects.bowling_strangeioc.mvc.controller.signals;
using com.rmc.projects.bowling_strangeioc.mvc.model;
using com.rmc.projects.bowling_strangeioc.mvc.model.vo;
using com.rmc.projects.bowling_strangeioc.mvc.view.ui;
using strange.extensions.mediation.impl;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_strangeioc.mvc.view
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
	public class UserInputUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------

		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public UserInputUI view 	{ get; set;}

		/// <summary>
		/// Gets or sets the input mode change signal.
		/// </summary>
		/// <value>The input mode change signal.</value>
		[Inject]
		public InputModeChangeSignal inputModeChangeSignal 		{ get; set;}
		//
		[Inject]
		public InputModeChangedSignal inputModeChangedSignal 	{ get; set;}




		[Inject]
		public BowlingBallStateChangeSignal bowlingBallStateChangeSignal 	{ get; set;}
		//
		[Inject]
		public BowlingBallStateChangedSignal bowlingBallStateChangedSignal 	{ get; set;}

		[Inject]
		public BowlingBallDoMoveSignal bowlingBallDoMoveSignal 	{ get; set;}

		//TODO, DON'T CALL BALL FROM HERE?
		public GameObject bowlingBallPrefab;

		// PUBLIC

		
		// PUBLIC STATIC
		
		// PRIVATE

		private InputMode _inputMode;

		private BowlingBallState _bowlingBallState;
		
		// PRIVATE STATIC
		private static float _MOVE_BY_AMOUNT_FLOAT = 0.1f;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		


		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{

			bowlingBallPrefab = GameObject.Find ("BowlingBallPrefab");
			inputModeChangedSignal.AddListener (onInputModeChangedSignal);
			bowlingBallStateChangedSignal.AddListener (onBowlingBallStateChangedSignal);



		}

		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			inputModeChangedSignal.RemoveListener (onInputModeChangedSignal);
			bowlingBallStateChangedSignal.RemoveListener (onBowlingBallStateChangedSignal);
		}


		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{


			//	TOGGLE BETWEEN KEYBOARD ***OR*** MOUSE MODE
			if (Input.GetKeyDown (KeyCode.LeftArrow) 	||
			    Input.GetKeyDown (KeyCode.RightArrow) 	||
			    Input.GetKeyDown (KeyCode.UpArrow) 		||
			    Input.GetKeyDown (KeyCode.DownArrow) 	||
			    Input.GetKeyDown (KeyCode.Space)		) {

				//Debug.Log ("key");
				inputModeChangeSignal.Dispatch (InputMode.KEYBOARD_ONLY);
			}
			
			//	TOGGLE BETWEEN KEYBOARD ***OR*** MOUSE MODE
			if (Input.GetAxis("Mouse Y") != 0 ||
			    Input.GetAxis("Mouse X") != 0 ||
			    Input.GetMouseButton(0)			){
				inputModeChangeSignal.Dispatch (InputMode.MOUSE_ONLY);
			}
			
			//WHILE MOVING
			if (_bowlingBallState == BowlingBallState.MOVING_GAME_MODE) {
				bowlingBallDoMoveSignal.Dispatch (new BowlingBallMoveVO (MoveType.SPIN_LEFT));	
			}

			if (_inputMode == InputMode.KEYBOARD_ONLY) {
				_doUpdateForKeys();
			} else {
				_doUpdateForMouse();
			}

		}

		
		//	PUBLIC
		
		/// <summary>
		/// Throws the ball.
		/// </summary>
		public void doThrowBall ()
		{
			//	STOP AIMING VIA INPUT
			bowlingBallStateChangeSignal.Dispatch (BowlingBallState.MOVING_GAME_MODE);

			//	START MOVING WITH PHYSICS TOWARD PINS (AND UP IN THE AIR A LITTLE BIT)
			bowlingBallDoMoveSignal.Dispatch (new BowlingBallMoveVO (MoveType.THROW));
			
		}
		
		
		/// <summary>
		/// Moves the ball.
		/// 
		/// NOTE: We don't move the z.
		/// 
		/// </summary>
		public void doMoveBallTo (Vector2 aPosition_vector2)
		{
			bowlingBallDoMoveSignal.Dispatch (new BowlingBallMoveVO (MoveType.MOVE_TO, aPosition_vector2));
		}
		
		/// <summary>
		/// Moves the ball.
		/// 
		/// NOTE: We don't move the z.
		/// 
		/// </summary>
		public void doMoveBallBy (Vector2 aMoveBy_vector2)
		{
			bowlingBallDoMoveSignal.Dispatch (new BowlingBallMoveVO (MoveType.MOVE_BY, aMoveBy_vector2));
		}
		
		/// <summary>
		/// Resets the game.
		/// 
		/// NOTE: This works great. In a more mature game, you may need to manually place each item again.
		/// 
		/// </summary>
		public void doResetGame ()
		{
			Debug.Log ("USERMED.doResetGame by Application.LoadLevel(): ");
			Application.LoadLevel(Application.loadedLevel);
		}

		
		// PRIVATE


		
		/// <summary>
		/// Dos the update for keys.
		/// </summary>
		private void _doUpdateForKeys () 
		{
			
			if (_bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE || true) {
				
				//	HANDLE MOVE
				if (Input.GetKeyDown (KeyCode.LeftArrow) ) {
					doMoveBallBy ( new Vector2 (-_MOVE_BY_AMOUNT_FLOAT, 0));
				} else if (Input.GetKeyDown (KeyCode.RightArrow) ) {
					doMoveBallBy ( new Vector2 (_MOVE_BY_AMOUNT_FLOAT, 0));
				}
				
				//	HANDLE MOVE
				if (Input.GetKeyDown (KeyCode.UpArrow) ) {
					doMoveBallBy ( new Vector2 (0, _MOVE_BY_AMOUNT_FLOAT));
				} else if (Input.GetKeyDown (KeyCode.DownArrow) ) {
					doMoveBallBy ( new Vector2 (0, -_MOVE_BY_AMOUNT_FLOAT));
				}
				
				
				// 	HANDLE THROW
				if (Input.GetKeyDown (KeyCode.Space) ) {
					doThrowBall();
				}
				
				
			} else {
				
				//	HANDLE RESET
				if (Input.GetKeyDown (KeyCode.Space) ) {
					doResetGame();
					
				}
				
				
			} //END IF KEYBOARD MODE
		}


		
		///<summary>
		///	Called once per frame
		///</summary>
		private void _doUpdateForMouse () 
		{
			
			if (_bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
				
				
				
				//	HANDLE MOVE
				//	NOTE: IF YOUR MOUSE 'HITS' THE InvisibleMouseDetectionCubeLayer GAMEOBJECT THEN ITS A LEGAL POSITION
				//	NOTE: THE "BowlingBallPrefab" HAS A LAYER OF "Ignore Raycast", WHICH WE REQUIRE
				//
				RaycastHit raycastHit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity)) {
					
					if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer ("InvisibleMouseDetectionCubeLayer")) {
						doMoveBallTo (new Vector2 (raycastHit.point.x, raycastHit.point.y));
					}
				} 
				
				
				//	HANDLE THROW
				if (Input.GetMouseButton (0)) {
					doThrowBall();
				}
				
				
			} else {
				
				//	HANDLE RESET
				if (Input.GetMouseButtonDown (0)) {
					doResetGame();
					
				}
					
				
			} //END IF MOUSEMODE
		}



		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the input mode changed signal.
		/// </summary>
		/// <param name="inputMode">Input mode.</param>
		private void onInputModeChangedSignal (InputMode aInputMode) 
		{

			//Debug.Log ("now : " + aInputMode);
			_inputMode = aInputMode;

		}


		/// <summary>
		/// Ons the bowling ball state changed signal.
		/// </summary>
		/// <param name="aBowlingBallState">A bowling ball state.</param>
		private void onBowlingBallStateChangedSignal (BowlingBallState aBowlingBallState) 
		{
			
			//Debug.Log ("USERMED. onBowlingState() : " + aBowlingBallState);
			_bowlingBallState = aBowlingBallState;
			
		}



	}
}

