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
using com.rmc.projects.spider_strike.mvcs.model.data;


namespace com.rmc.projects.spider_strike.mvcs.view.ui
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
	public class TurretUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// Gets or sets the target rotation.
		/// </summary>
		/// <value>The target rotation.</value>
		public float firingAngle { 

			get{

				return turretFiringAngle_lerptarget.targetValue;

			}
			set
			{
				turretFiringAngle_lerptarget.targetValue = value;
				//turretFiringAngle_lerptarget.targetValue = _clampAngle (turretFiringAngle_lerptarget.targetValue);
				//Debug.Log ("NOW: " + turretFiringAngle_lerptarget.targetValue);

			}
		}

		// PUBLIC
		/// <summary>
		/// The turret rotator.
		/// </summary>
		public GameObject turretRotator;

		/// <summary>
		/// The turret barrel.
		/// </summary>
		public GameObject turretBulletSpawnPoint;

		/// <summary>
		/// The turret targeting light.
		/// </summary>
		public GameObject turretTargetingLight;

		/// <summary>
		/// The turret spinning barrel.
		/// </summary>
		public GameObject turretSpinningBarrel;



		// PUBLIC STATIC



		
		// PRIVATE
		/// <summary>
		/// The is currently firing_boolean.
		/// </summary>
		private bool isCurrentlyFiring_boolean = false;

		/// <summary>
		/// The turret spinning_lerptarget.
		/// </summary>
		private LerpTarget turretSpinning_lerptarget;
		
		/// <summary>
		/// The turret firing angle_lerptarget.
		/// </summary>
		private LerpTarget turretFiringAngle_lerptarget;


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
		}

		///<summary>
		///	Use this for initialization
		///</summary>
		public void init () 
		{
			turretSpinning_lerptarget 		= new LerpTarget (0, 0, 10, 2f);
			turretFiringAngle_lerptarget	= new LerpTarget (0, 0, 0, 5f);
		}

		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//ROTATE THE BARREL IF FIRING
			if (isCurrentlyFiring_boolean) {
				turretSpinning_lerptarget.lerpCurrentToTarget (Time.deltaTime);
			} else {
				turretSpinning_lerptarget.lerpCurrentToReset (Time.deltaTime);
			}
			turretSpinningBarrel.transform.Rotate (new Vector3 (0, turretSpinning_lerptarget.current, 0));


			//ROTATE THE BASE TO THE DESIRED SHOOTING ANGLE
			turretFiringAngle_lerptarget.lerpCurrentToTarget (Time.deltaTime);
			Vector3 eulerAngles_vector3 = turretRotator.transform.localEulerAngles;
			eulerAngles_vector3.z = turretFiringAngle_lerptarget.current;
			turretRotator.transform.localEulerAngles = eulerAngles_vector3;


			//TOGGLE ON THE RED LIGHTS WHEN ANY TARGET IS 'FOUND'
			//TODO: OPTIMIZE, DON'T 'SET' ENABLED VALUE IF ALREADY SET
			if (_getFirstGameObjectInFiringRange() != null) {
				turretTargetingLight.SetActive (true);
			} else {
				turretTargetingLight.SetActive (false);
			}


			
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


		/// <summary>
		/// Sets the is firing.
		/// </summary>
		/// <param name="aIsFiring_boolean">If set to <c>true</c> a is firing_boolean.</param>
		public void doSetIsFiring (bool aIsFiring_boolean)
		{
			//INSTEAD OF SINGLE SHOTS, I THINK WE'LL NEED TO TURN ON, REPEATEDLY 'FIRE', AND TURN OFF, THE GUN
			//TO MAKE THE ANIMATION LOOK GOOD
			//Debug.Log ("is: "+ aIsFiring_boolean);
			if (isCurrentlyFiring_boolean != aIsFiring_boolean) {
				//Debug.Log ("doSetIsFiring: "+ aIsFiring_boolean);
				isCurrentlyFiring_boolean = aIsFiring_boolean;

				if (isCurrentlyFiring_boolean) {
					_doFireOnce();
				}
			}
			
		}


		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _dos the fire once.
		/// </summary>
		private void _doFireOnce() 
		{
			//Debug.Log ("_doFireOnce");
			GameObject enemyHit_gameObject = _getFirstGameObjectInFiringRange();
			if (enemyHit_gameObject) {
				enemyHit_gameObject.GetComponent<EnemyUI>().doTakeDamage(10);
			}

		}

		/*
		 * //THE MATH WORKS HERE, BUT THEN THE ROTATION SPINS COUNTER-WISE SOMETIMES
		 * //FOR NOW: IGNORE THE NEED FOR THIS. 
		private float _clampAngle(float angle) 
		{
			if(angle < 0) {
				angle = 360 + angle;
			} else if (angle > 360) {
				angle = 360 - angle;
			}
			return angle;
		}
		*/


		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		
		
		private GameObject _getFirstGameObjectInFiringRange ()
		{

			GameObject firstGameObjectInFiringRange = null;

			//
			Debug.DrawRay (turretBulletSpawnPoint.transform.position, turretBulletSpawnPoint.transform.forward*10);
			//
			RaycastHit raycastHit;
			if (Physics.Raycast(turretBulletSpawnPoint.transform.position, turretBulletSpawnPoint.transform.forward*10, out raycastHit)) {
				
				if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer (EnemyUI.LAYER_NAME)) {
					//TODO, USE STRANGE SIGNAL FOR 'HITTING?'
					firstGameObjectInFiringRange = raycastHit.collider.gameObject;

				}
			}

			return firstGameObjectInFiringRange;

		}
	}
}

