using UnityEngine;
using System.Collections;
using com.rmc.projects.coins_and_platforms.components;
using UnityEditor;

[CustomEditor (typeof (SnapMeComponent))]
public class SnapMeComponentEditor : Editor 
{

	/// <summary>
	/// The _snap me component.
	/// </summary>
	private SnapMeComponent _snapMeComponent;

	// Use this for initialization
	void OnEnable () {
		Debug.Log ("enable");

		_snapMeComponent = target as SnapMeComponent;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("edit");
	}

	void OnSceneGUI () {

		Debug.Log ("onscenegui");
		_snapMeComponent.doSnapMe();
	}
}
