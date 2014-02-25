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
using com.rmc.projects.spider_strike.mvcs.model.data;
using com.rmc.projects.spider_strike.components.effects;
using com.rmc.projects.spider_strike.mvcs.controller.signals;



//--------------------------------------
//  Namespace
//--------------------------------------
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

				return _turretFiringAngle_lerptarget.targetValue;

			}
			set
			{
				_turretFiringAngle_lerptarget.targetValue = value;
				//turretFiringAngle_lerptarget.targetValue = _clampAngle (turretFiringAngle_lerptarget.targetValue);
				//Debug.Log ("NOW: " + turretFiringAngle_lerptarget.targetValue);

			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="com.rmc.projects.spider_strike.mvcs.view.ui.TurretUI"/> is
		/// running update.
		/// 
		/// NOTE: This is set by mediator based on GameState.
		/// NOTE: Defaults to false
		/// 
		/// </summary>
		/// <value><c>true</c> if is running update; otherwise, <c>false</c>.</value>
		public bool isRunningUpdate {get;set;}

		// PUBLIC
		/// <summary>
		/// When the turret rotator.
		/// </summary>
		public GameObject turretRotator;

		/// <summary>
		/// When the turret barrel.
		/// </summary>
		public GameObject turretBulletSpawnPoint;

		/// <summary>
		/// When the turret targeting light.
		/// </summary>
		public GameObject turretTargetingLight;

		/// <summary>
		/// When the turret spinning barrel.
		/// </summary>
		public GameObject turretSpinningBarrel;

		/// <summary>
		/// Gets or sets the turret health change signal.
		/// </summary>
		/// <value>The turret health change signal.</value>
		[Inject]
		public TurretHealthChangeSignal turretHealthChangeSignal 		{ get; set;}




		// PUBLIC STATIC



		
		// PRIVATE
		/// <summary>
		/// When the is currently firing_boolean.
		/// </summary>
		private bool _isCurrentlyFiring_boolean = false;

		/// <summary>
		/// When the turret spinning_lerptarget.
		/// </summary>
		private LerpTarget _turretSpinning_lerptarget;
		
		/// <summary>
		/// When the turret firing angle_lerptarget.
		/// </summary>
		private LerpTarget _turretFiringAngle_lerptarget;

		/// <summary>
		/// When the _turret bullet spawn point component.
		/// </summary>
		private TurretBulletSpawnPointComponent _turretBulletSpawnPointComponent;


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
			_turretBulletSpawnPointComponent = turretBulletSpawnPoint.GetComponent<TurretBulletSpawnPointComponent>();
		}

		///<summary>
		///	Use this for initialization
		///</summary>
		public void init () 
		{
			isRunningUpdate = false;
			_turretSpinning_lerptarget 		= new LerpTarget (0, 0, 10, 2f);
			_turretFiringAngle_lerptarget	= new LerpTarget (0, 0, 0, 5f);
		}

		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//
			if (isRunningUpdate) {

				//ROTATE THE BARREL IF FIRING
				if (_isCurrentlyFiring_boolean) {
					_turretSpinning_lerptarget.lerpCurrentToTarget (Time.deltaTime);
				} else {
					_turretSpinning_lerptarget.lerpCurrentToReset (Time.deltaTime);
				}
				turretSpinningBarrel.transform.Rotate (new Vector3 (0, _turretSpinning_lerptarget.current, 0));


				//ROTATE THE BASE TO THE DESIRED SHOOTING ANGLE
				_turretFiringAngle_lerptarget.lerpCurrentToTarget (Time.deltaTime);
				Vector3 eulerAngles_vector3 = turretRotator.transform.localEulerAngles;
				eulerAngles_vector3.z = _turretFiringAngle_lerptarget.current;
				turretRotator.transform.localEulerAngles = eulerAngles_vector3;


				//TOGGLE ON THE RED LIGHTS WHEN ANY TARGET IS 'FOUND'
				//TODO: OPTIMIZE, DON'T 'SET' ENABLED VALUE IF ALREADY SET
				if (_hasTargetInSights()) {
					turretTargetingLight.SetActive (true);
				} else {
					turretTargetingLight.SetActive (false);
				}

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
			if (_isCurrentlyFiring_boolean != aIsFiring_boolean) {
				//Debug.Log ("doSetIsFiring: "+ aIsFiring_boolean);
				_isCurrentlyFiring_boolean = aIsFiring_boolean;

				if (_isCurrentlyFiring_boolean) {
					_doFireOnce();
				}
			}
			
		}

		/// <summary>
		/// Dos the take damage.
		/// </summary>
		/// <param name="i">The index.</param>
		public void doTakeDamage (int aDamageAmount_int)
		{

			turretHealthChangeSignal.Dispatch (-aDamageAmount_int);
		}

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Do fire once.
		/// </summary>
		private void _doFireOnce() 
		{

			//
			_turretBulletSpawnPointComponent.showMuzzleFlash();

			//Debug.Log ("_doFireOnce");
			Collider firstCollider = _getFirstColliderInFiringRange();
			if (firstCollider) {
				firstCollider.gameObject.GetComponent<EnemyUI>().doTakeDamage(10);
			}

		}

		/// <summary>
		/// _hases the target in sights.
		/// </summary>
		/// <returns><c>true</c>, if target in sights was _hased, <c>false</c> otherwise.</returns>
		private bool _hasTargetInSights ()
		{
			
			return _getFirstColliderInFiringRange() != null;
			
		}
		/// <summary>
		/// _gets the first collider in firing range.
		/// </summary>
		/// <returns>The first collider in firing range.</returns>
		private Collider _getFirstColliderInFiringRange ()
		{
			
			//
			Debug.DrawRay (turretBulletSpawnPoint.transform.position, turretBulletSpawnPoint.transform.forward*10);
			//
			Collider firstCollider = null;
			EnemyUI enemyUI;
			RaycastHit raycastHit;
			//
			if (Physics.Raycast(turretBulletSpawnPoint.transform.position, turretBulletSpawnPoint.transform.forward*10, out raycastHit)) {

				//
				if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer (EnemyUI.LAYER_NAME)) {

					//
					enemyUI = raycastHit.collider.gameObject.GetComponent<EnemyUI>();
					if (enemyUI && enemyUI.isAlive) {
						firstCollider = raycastHit.collider;
						Debug.DrawRay (raycastHit.point, raycastHit.normal);
					}
					
				}
			}
			
			return firstCollider;
			
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




	}
}

