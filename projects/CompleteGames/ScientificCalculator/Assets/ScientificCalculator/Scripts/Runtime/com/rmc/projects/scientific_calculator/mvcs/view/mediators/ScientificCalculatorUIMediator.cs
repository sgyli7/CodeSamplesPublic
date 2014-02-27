/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using com.rmc.projects.scientific_calculator.mvcs.controller.signals;
using com.rmc.projects.scientific_calculator.mvcs.view.ui;
using com.rmc.projects.scientific_calculator.mvcs.model;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.scientific_calculator.mvcs.view.mediators.core;
using com.rmc.projects.scientific_calculator.mvcs.view.signals;


namespace com.rmc.projects.scientific_calculator.mvcs.view.mediators
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
	public class ScientificCalculatorUIMediator : SuperControllerUIMediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		/*
		 * NOTE: According to my tests and
		 * 		http://kendlj.wordpress.com/2014/01/03/unit-testing-strangeioc-mediator/
		 * 
		 * 		We cannot do "mediationBinder.Bind<IControllerUI>().To<VirtualControllerUIMediator>();
		 * 
		 * 		So this is a workaround
		 * 
		 **/
		[Inject]
		public ScientificCalculatorUI viewConcrete 	
		{ 
			set {
				view = value;
			}
			get {
				return view as ScientificCalculatorUI;
			}
		}


		/// <summary>
		/// Gets or sets the display text changed signal.
		/// </summary>
		/// <value>The display text changed signal.</value>
		[Inject]
		public DisplayTextChangedSignal displayTextChangedSignal { get; set;}

		/// <summary>
		/// Gets or sets all views initialized signal.
		/// 
		/// NOTE: We arbitrarily choose this UI to dispatch this and assume all other UI are ready
		/// 
		/// </summary>
		/// <value>All views initialized signal.</value>
		[Inject]
		public AllViewsInitializedSignal allViewsInitializedSignal { get; set;}

		/// <summary>
		/// Gets or sets the calculator mode changed signal.
		/// </summary>
		/// <value>The calculator mode changed signal.</value>
		[Inject]
		public CalculatorModelChangedSignal calculatorModeChangedSignal { get; set;}


		// PUBLIC
		
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start()
		{
			allViewsInitializedSignal.Dispatch();
		}


		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			base.OnRegister();
			displayTextChangedSignal.AddListener (_onDisplayTextChangedSignal);
			calculatorModeChangedSignal.AddListener (_onCalculatorModeChangedSignal);
			
		}
		
		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			base.OnRemove();
			displayTextChangedSignal.RemoveListener (_onDisplayTextChangedSignal);
			calculatorModeChangedSignal.AddListener (_onCalculatorModeChangedSignal);

		}
		
		
		//	PUBLIC
		
		
		// PRIVATE

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// _ons the display text changed signal.
		/// </summary>
		/// <param name="aDisplayText_string">A display text_string.</param>
		private void _onDisplayTextChangedSignal (string aDisplayText_string)
		{

			viewConcrete.setDisplayText (aDisplayText_string);

		}

		/// <summary>
		/// _ons the calculator mode changed signal.
		/// </summary>
		/// <param name="aDisplayText_string">A display text_string.</param>
		private void _onCalculatorModeChangedSignal (CalculatorMode aCalculatorMode)
		{
			
			viewConcrete.setModeText (Constants.MODE_TEXT_PREFIX +  Constants.GetModeTextByCalculatorMode(aCalculatorMode));
			
		}



		/// <summary>
		/// When the cross platform changed signal fires.
		/// 
		/// NOTE: 	During startup we dispatch this signal based on
		/// 		Application.platform so obvservers can handle themselves.
		/// 
		/// </summary>
		/// <param name="aRuntimePlatform">A runtime platform.</param>
		override protected void _onCrossPlatformChangedSignal (RuntimePlatform aRuntimePlatform)
		{
			//THIS FUNCTIONALITY SHOULD RUN ONLY ON SOME PLATFORMS.
			if (aRuntimePlatform != RuntimePlatform.IPhonePlayer) {

				//gameObject.SetActive (false);
			} else {
				//gameObject.SetActive (true);
			}
			
		}


	}
}

