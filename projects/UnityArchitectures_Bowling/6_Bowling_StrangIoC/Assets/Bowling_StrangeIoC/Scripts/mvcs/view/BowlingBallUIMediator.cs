/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
    public class BowlingBallUIMediator : Mediator
    {

        //--------------------------------------
        //  Properties
        //--------------------------------------

        //TODO, DON'T CALL MODEL FROM VIEW
        [Inject]
        public IGameStateModel iGameStateModel { get; set; }


        /// <summary>
        /// Gets or sets the bowling ball state changed signal.
        /// </summary>
        /// <value>The bowling ball state changed signal.</value>
        [Inject]
        public BowlingBallStateChangedSignal bowlingBallStateChangedSignal { get; set; }

        /// <summary>
        /// Gets or sets the bowling ball do move signal.
        /// </summary>
        /// <value>The bowling ball do move signal.</value>
        [Inject]
        public BowlingBallDoMoveSignal bowlingBallDoMoveSignal { get; set; }

        /// <summary>
        /// Gets or sets all views initialized signal.
        /// </summary>
        /// <value>All views initialized signal.</value>
        [Inject]
        public AllViewsInitializedSignal allViewsInitializedSignal { get; set; }


        // PUBLIC

        // PUBLIC STATIC

        // PRIVATE
        /// <summary>
        /// The state of the __bowling ball.
        /// </summary>
        private BowlingBallState __bowlingBallState;
        private BowlingBallState _bowlingBallState
        {
            get
            {
                return __bowlingBallState;
            }
            set
            {
                __bowlingBallState = value;
                //
                switch (__bowlingBallState)
                {
                    case BowlingBallState.PRE_GAME_AIM_MODE:
                        GetComponent<Rigidbody>().isKinematic = true;
                        break;
                    case BowlingBallState.MOVING_GAME_MODE:
                        GetComponent<Rigidbody>().isKinematic = false;
                        break;
                    default:
                        break;
                }

            }
        }




        // PRIVATE STATIC

        //--------------------------------------
        //  Methods
        //--------------------------------------



        /// <summary>
        /// Raises the register event.
        /// </summary>
        public override void OnRegister()
        {

            //bowlingBallPrefab = GameObject.Find ("BowlingBallPrefab");
            bowlingBallStateChangedSignal.AddListener(onBowlingBallStateChangedSignal);
            bowlingBallDoMoveSignal.AddListener(onBowlingBallDoMoveSignal);


            //TODO: THIS IS DESIGN SO THE ORCHESTRATION ON STARTUP CAN RESET THE MODEL
            //		**AFTER** ALL THE VIEW IS READY TO HEAR FROM THE SIGNALS WHICH 
            //		THE MODEL WILL DISPATCH UPON RESET.
            //
            //		DOING THE RESET IN THE MODELS 'POSTCONSTRUCT' WAS TOO EARLY FOR THE VIEW.
            //
            Debug.Log("3. BowlingMed CALLING     allViewsInitializedSignal.Dispatch()");
            allViewsInitializedSignal.Dispatch();
            Debug.Log("5. BowlingMed JUST CALLED allViewsInitializedSignal.Dispatch()");


        }

        /// <summary>
        /// Raises the remove event.
        /// </summary>
        public override void OnRemove()
        {
            bowlingBallStateChangedSignal.RemoveListener(onBowlingBallStateChangedSignal);
            bowlingBallDoMoveSignal.RemoveListener(onBowlingBallDoMoveSignal);
        }



        ///<summary>
        ///	Called once per frame
        ///</summary>
        void Update()
        {


            /*
			 * 3. SPIN THE BALL (TODO: WE COULD MOVE THIS TO BALL MEDIATOR)
			 * 
			*/
            if (_bowlingBallState == BowlingBallState.MOVING_GAME_MODE)
            {
                bowlingBallDoMoveSignal.Dispatch(new BowlingBallMoveVO(MoveType.SPIN_LEFT));
            }

            /*
			 * 
			 *	OPTIONAL
			 *
			 *
			 *
			if (gameStateModel.bowlingBallState == BowlingBallState.PRE_GAME_AIM_MODE) {
				
				//	HANDLE THROW
				if (Input.GetMouseButton (0)) {
					
					//TODO: IF YOU WANT TO PLAY A SOUND UPON 'THROW' DO IT HERE
					
				}
				
				//	RESET
				_hasCollidedWithWoodFloor_boolean = false;
				
			}
			*/

        }


        //	PUBLIC


        // PRIVATE

        /// <summary>
        /// Throws the ball.
        /// </summary>
        private void _doThrowBall()
        {

            //	ADD PHYSICS PUSH FORWARD
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 100f, 600f * GetComponent<Rigidbody>().mass), ForceMode.Force);

            //	ADD PHYSICS PUSH TO THE LEFT
            GetComponent<Rigidbody>().AddForce(new Vector3(-20f * GetComponent<Rigidbody>().mass, 0, 0), ForceMode.Force);

        }

        /// <summary>
        /// _dos the spin left.
        /// </summary>
        private void _doSpinLeft()
        {
            //	ADD PHYSICS SPIN TO THE LEFT
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 1200f * GetComponent<Rigidbody>().mass), ForceMode.Acceleration);
        }




        /// <summary>
        /// Moves the ball.
        /// 
        /// NOTE: We don't move the z.
        /// 
        /// </summary>
        private void _doMoveBallTo(Vector2 aPosition_vector2)
        {
            transform.position = new Vector3(aPosition_vector2.x, aPosition_vector2.y, transform.position.z);
        }

        /// <summary>
        /// Moves the ball.
        /// 
        /// NOTE: We don't move the z.
        /// 
        /// </summary>
        private void _doMoveBallBy(Vector2 aMoveBy_vector2)
        {
            transform.position = new Vector3(
                transform.position.x + aMoveBy_vector2.x,
                transform.position.y + aMoveBy_vector2.y,
                transform.position.z);
        }


        // PRIVATE STATIC

        // PRIVATE COROUTINE

        // PRIVATE INVOKE

        //--------------------------------------
        //  Events
        //--------------------------------------
        /// <summary>
        /// Ons the bowling ball state changed signal.
        /// </summary>
        /// <param name="aBowlingBallState">A bowling ball state.</param>
        public void onBowlingBallStateChangedSignal(BowlingBallState aBowlingBallState)
        {

            //Debug.Log ("BALLMED. onBowlingState() : " + aBowlingBallState);
            _bowlingBallState = aBowlingBallState;


        }


        /// <summary>
        /// Ons the bowling ball do move signal.
        /// </summary>
        /// <param name="aBowlingBallMoveVO">A bowling ball move V.</param>
        public void onBowlingBallDoMoveSignal(BowlingBallMoveVO aBowlingBallMoveVO)
        {
            switch (aBowlingBallMoveVO.moveType)
            {
                case MoveType.THROW:
                    _doThrowBall();
                    break;
                case MoveType.SPIN_LEFT:
                    _doSpinLeft();
                    break;
                case MoveType.MOVE_BY:
                    _doMoveBallBy(aBowlingBallMoveVO.vector2);
                    break;
                case MoveType.MOVE_TO:
                    _doMoveBallTo(aBowlingBallMoveVO.vector2);
                    break;
                default:
                    break;

            }
        }


    }

}


