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
using UnityEditor;
using System.IO;
using com.rmc.managers.mom;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.editors
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Create default folders menu.
	/// </summary>
	[InitializeOnLoad]
	public class CreateDefaultFoldersMenu
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
	
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		// PUBLIC
		static CreateDefaultFoldersMenu()
		{
			//
			Debug.Log ("CreateDefaultFoldersMenu.constructor()");
			//CreateDefaultFoldersMenu.CreateDefaultFolders();
			
			
		}
		
		
		// PUBLIC STATIC
		/// <summary>
		/// Creates the default folders.
		/// </summary>
		[MenuItem("RMC/Create Default Folders")]
		public static void CreateDefaultFolders ()
		{
			_createFoldersIfNew("Assets", 				"Standard Assets");
			_createFoldersIfNew("Assets", 				"3rdParty Assets");
			_createFoldersIfNew("Assets", 				"[ProjectName]");
			_createFoldersIfNew("Assets/[ProjectName]", 	"Components");
			_createFoldersIfNew("Assets/[ProjectName]", 	"Images");
			_createFoldersIfNew("Assets/[ProjectName]", 	"Materials");
			_createFoldersIfNew("Assets/[ProjectName]", 	"Prefabs");
			_createFoldersIfNew("Assets/[ProjectName]", 	"Scripts");
			_createFoldersIfNew("Assets/[ProjectName]", 	"Scenes");
			
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		/// <summary>
		/// Creates the folders if new.
		/// </summary>
		public static void _createFoldersIfNew (string aParentFolderPath_string, string aFolderName_string)
		{
			if (!System.IO.Directory.Exists(Application.dataPath + System.IO.Path.GetDirectoryName(aParentFolderPath_string).TrimStart("Assets".ToCharArray()) + "/" + aFolderName_string)) {
        		AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(aParentFolderPath_string), aFolderName_string);
    		}
			
		}
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		
	}
}

