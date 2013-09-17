    using UnityEditor;
    using System.IO;
     
    public class MyAssetModificationProcessor : UnityEditor.AssetModificationProcessor
    {
    public static string[] OnWillSaveAssets( string[] paths )
    {
    // Get the name of the scene to save.
    string scenePath = string.Empty;
    string sceneName = string.Empty;
     
	Debug2.Log ("SAVING");
    foreach( string path in paths )
    {
			Debug2.Log (" NEXT: ");
    if( path.Contains( ".unity" ))
    {
    scenePath = Path.GetDirectoryName( path );
    sceneName = Path.GetFileNameWithoutExtension( path );
    }
    }
     
    if( sceneName.Length == 0 )
    {
    return paths;
    }
     
    // DO WHAT YOU NEED TO DO HERE.
    // FOR EXAMPLE, CALL A STATIC FUNCTION FROM ANOTHER CLASS
	Debug2.Log ("	\nscenePath: " + scenePath);
	Debug2.Log ("	sceneName: " + sceneName);
     
     
    return paths;
    }
    }