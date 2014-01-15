using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor( typeof( PlayerInputComponent ) )]
public class PlayerInputComponentEditor : Editor {
	
	
	PlayerInputComponent m_Instance;
	PropertyField[] m_fields;
	
	
	public void OnEnable()
	{
		m_Instance = target as PlayerInputComponent;

		m_fields = ExposeProperties.GetProperties( m_Instance );

		Debug.Log ("m_fields: " + m_fields.Length);
	}
	
	public override void OnInspectorGUI () {

		Debug.Log ("m_fields: " + m_fields.Length);
		if ( m_Instance == null )
			return;
		
		this.DrawDefaultInspector();
		
		ExposeProperties.Expose( m_fields );
		
	}
}