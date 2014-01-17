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
using UnityEditor;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.utilities
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Create default folders menu.
	/// </summary>
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
		//static CreateDefaultFoldersMenu()
		//{
			//
		//	Debug.Log ("CreateDefaultFoldersMenu.constructor()");
			//CreateDefaultFoldersMenu.CreateDefaultFolders();
			
			
		//}
		
		
		// PUBLIC STATIC
		/// <summary>
		/// Creates the default folders.
		/// </summary>
		[MenuItem("RMC/Create Default Folders", false, 10)]
		public static void CreateDefaultFolders ()
		{
			
			//CREATE TOP LEVEL FOLDERS
			_createFoldersUnderParent("Assets", 						"Standard Assets"); //UNITY, INC STUFF
			_createFoldersUnderParent("Assets", 						"Community Assets"); //3RD-PARTY
			_createFoldersUnderParent("Assets", 						"[ProjectName]"); //PROJECT SPECIFIC


			//CREATE SUB FOLDERS
			CreateDefaultFoldersMenu.CreateDefaultSubFoldersFor ("Assets/[ProjectName]");



			//CREATE SUB FOLDERS
			bool isForRMCUse_boolean = true;
			if (isForRMCUse_boolean) {
				_createFoldersUnderParent ("Assets/Community Assets", "RMCLibrary"); //MY RMC LIBRARY
				CreateDefaultFoldersMenu.CreateDefaultSubFoldersFor ("Assets/Community Assets/RMCLibrary", true);
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Runtime", 		"com"); //MY RMC LIBRARY
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Runtime/com", 	"rmc"); //MY RMC LIBRARY
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Runtime/com/rmc", "projects"); //MY RMC LIBRARY
				//
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Editor", 			"com"); //MY RMC LIBRARY
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Editor/com", 		"rmc"); //MY RMC LIBRARY
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Editor/com/rmc", 	"projects"); //MY RMC LIBRARY

				//
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Editor", 			"com"); //MY RMC LIBRARY
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Editor/com", 		"rmc"); //MY RMC LIBRARY
				_createFoldersUnderParent ("Assets/Community Assets/RMCLibrary/Scripts/Editor/com/rmc", 	"projects"); //MY RMC LIBRARY
			}


			
		}



		/// <summary>
		/// Creates the default sub folders for.
		/// </summary>
		/// <param name="aParentFolder_string">A parent folder_string.</param>
		/// <param name="isOnlyCommonFolders_boolean">If set to <c>true</c> is only common folders_boolean.</param>
		public static void CreateDefaultSubFoldersFor (string aParentFolder_string, bool isOnlyCommonFolders_boolean = false)
		{

			//COMMON FOLDERS
			//
			_createFoldersUnderParent	(aParentFolder_string, 					"Scripts");
			_createFoldersUnderParent	(aParentFolder_string + "/Scripts",		"Editor");
			_createFoldersUnderParent 	(aParentFolder_string + "/Scripts", 	"Runtime");
			


			//NOT JUST COMMON FOLDERS
			if (!isOnlyCommonFolders_boolean) {

				_createFoldersUnderParent(aParentFolder_string, 				"Animations");
				_createFoldersUnderParent(aParentFolder_string, 				"Animation Controllers");
				//
				_createFoldersUnderParent(aParentFolder_string, 				"Audio");
				_createFoldersUnderParent(aParentFolder_string + "/Audio", 		"Sound Effects");
				_createFoldersUnderParent(aParentFolder_string + "/Audio", 		"Music");
				//
				
				_createFoldersUnderParent(aParentFolder_string, 				"Fonts");
				_createFoldersUnderParent(aParentFolder_string, 				"GUISkins");
				//
				_createFoldersUnderParent(aParentFolder_string, 				"Images");
				_createFoldersUnderParent(aParentFolder_string, 				"Gizmos");
				_createFoldersUnderParent(aParentFolder_string, 				"Materials");
				_createFoldersUnderParent(aParentFolder_string, 				"Models");
				_createFoldersUnderParent(aParentFolder_string, 				"Physic Materials");
				_createFoldersUnderParent(aParentFolder_string, 				"Prefabs");
				_createFoldersUnderParent(aParentFolder_string, 				"Resources");
				_createFoldersUnderParent(aParentFolder_string, 				"Scenes");
				_createFoldersUnderParent(aParentFolder_string, 				"Shaders");
				//
				_createFoldersUnderParent(aParentFolder_string, 				"Terrains");
				_createFoldersUnderParent(aParentFolder_string, 				"Textures");
			}
		}

		// PRIVATE
		
		// PRIVATE STATIC
		/// <summary>
		/// Creates the folders if new.
		/// </summary>
		public static void _createFoldersUnderParent (string aParentFolderPath_string, string aFolderName_string)
		{
			string desiredFolderName_string = aParentFolderPath_string + "/" + aFolderName_string;
			if (!System.IO.Directory.Exists(desiredFolderName_string) ) {
        		AssetDatabase.CreateFolder(aParentFolderPath_string, aFolderName_string);
    		}
			
			AssetDatabase.Refresh();
			
		}
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		
	}
}

