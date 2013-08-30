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
using System;

//--------------------------------------
//  Class Attributes
//--------------------------------------
/*
 * The Serializable attribute lets you embed a class with sub properties in the inspector.
 * 
 * 	NOTE: This is a Unity-specific subject
 * 
 *	NOTE: More on serialization: 	http://blogs.unity3d.com/2012/10/25/unity-serialization/
 *									http://answers.unity3d.com/questions/264347/serialization.html
 *
*/
[System.Serializable]

/*
 * 
 *  The RequireComponent attribute lets automatically add required component as a dependency.
 * 
 * 	When you add a script which uses RequireComponent, the required component will automatically 
 * 	be added to the game object. This is useful to avoid setup errors. For example a script might 
 * 	require that a rigid body is always added to the same game object. Using RequireComponent 
 * 	this will be done automatically, thus you can never get the setup wrong.
 * 
 * 	NOTE: This is a Unity-specific subject
 * 
 * 
 *  TODO: Remove all components from 'ManagersGameObject', then 
 * 			just add 'Lesson32_CSharp_2_Attributes' and
 * 			the 'ThisComponentIsRequired' will be added automatically. Its for convenience.
 * 			(Suprisingly, no error is thrown when you remove just 'ThisComponentIsRequired')
 * 
*/
[RequireComponent (typeof (ThisComponentIsRequired))]

/*
 * SEE BELOW, AT: _doDemoOfAttribute_MyCustomAttribute()
*/
[MyCustomAttribute ("Hello, This is a message.")]
//--------------------------------------
//  Class
//--------------------------------------
public class Lesson32_CSharp_2_Attributes: MonoBehaviour 
{

	//--------------------------------------
	//  Properties & Property/Variable Attributes
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
    /// <summary>
    /// The 'publicFloatThatIsNotSerialized' is public, but will not be serialized nor show in inspector
    /// </summary>
	[System.NonSerialized]
	public float publicFloatThatIsNotSerialized = 1.1f;
	
    /// <summary>
    /// The 'publicFloatThatIsSerialized' is public (by default it *IS* serialized and show in inspector
    /// </summary>
	public float publicFloatThatIsSerialized = 1.1f;
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// The 'privateFloatThatIsSerialized' that is serialized. Normally private variables are not serialized/shown in inspector
	/// </summary>
    [SerializeField]
    private float privateFloatThatIsSerialized = 99.99f;
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		
		//	(SIMPLE USE OF VARIABLE TO PREVENT HARMLESS COPILER WARNING)
		privateFloatThatIsSerialized += privateFloatThatIsSerialized;
		
		
		/*
		 * ATTRIBUTES
		 * 
		 * REFERENCE: http://docs.unity3d.com/412/Documentation/ScriptReference/20_class_hierarchy.Attributes.html
		 * 
		 * PARTIAL LIST (FOR BREVITY, MOST ARE NOT SHOWN IN THIS DEMO)
		 * 
		 *  	RUNTIME CLASSES
   		 * 		AddComponentMenu
   		 * 		ContextMenu
   		 * 		ExecuteInEditMode
   		 * 		HideInInspector
   		 * 		ImageEffectOpaque
   		 * 		ImageEffectTransformsToLDR
   		 * 		NonSerialized
   		 * 		NotConvertedAttribute
   		 * 		NotFlashValidatedAttribute
   		 * 		NotRenamedAttribute
   		 * 		PropertyAttribute
   		 * 		RPC
   		 * 		RequireComponent
   		 * 		Serializable
   		 *		SerializeField
   		 *
   		 *		EDITOR CLASSES
   		 *  	CanEditMultipleObjects
   		 *  	CustomEditor
   		 *  	CustomPropertyDrawer
   		 *  	DrawGizmo
   		 *  	MenuItem
   		 *  	PostProcessAttribute
   		 *  	PreferenceItem
		 * 
		*/
		Debug.Log ("\n");
		Debug.Log ("//	[OBSOLETE1]	///////////////////////");
		//	TODO: COMMENT THIS IN AND SEE THE PURPOSEFUL COMPILER ERROR
		//_doDemoOfAttribute_Obsolete();
		
		
		Debug.Log ("\n");
		Debug.Log ("//	[OBSOLETE2]	///////////////////////");
		//	TODO: COMMENT THIS IN AND SEE THE PURPOSEFUL COMPILER ERROR
		//_doDemoOfAttribute_ObsoleteWithError();
		
		Debug.Log ("\n");
		Debug.Log ("//	CUSTOM ATTRIBUTE	///////////////////////");
		_doDemoOfAttribute_MyCustomAttribute();
	}
	
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	//******************************************************
	//******************************************************
	//**	OBSOLETE
	//******************************************************
	//******************************************************
	
	// PRIVATE
	///<summary>
	///	DEMO
	///</summary>
	[Obsolete("Use '_doDemoOfAttribute_NotObsolete' instead.",false)]
	private void _doDemoOfAttribute_Obsolete () 
	{
		
		//SOME CODE...
		
	}
	
	///<summary>
	///	DEMO
	///</summary>
	[Obsolete("Use '_doDemoOfAttribute_NotObsolete' instead.",true)]
	private void _doDemoOfAttribute_ObsoleteWithError () 
	{
		
		//SOME CODE...
		
	}
	
	///<summary>
	///	DEMO
	///</summary>
	private void _doDemoOfAttribute_MyCustomAttribute () 
	{
		
		//SOME CODE...
		object[] attributes_object = this.GetType().GetCustomAttributes ( typeof (MyCustomAttribute), true);
		MyCustomAttribute myCustomAttribute = attributes_object[0] as MyCustomAttribute;
		
		Debug.Log ("	CustomAttribute: " + myCustomAttribute.message_string);
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
