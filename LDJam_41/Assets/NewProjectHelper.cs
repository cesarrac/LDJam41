using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewProjectHelper : MonoBehaviour {

	void Start(){
		CreateMainFolders();
	}
	void CreateMainFolders()
    {
		string[] startUpFolders = new string[]{"Scripts", "Prefabs", "Resources", "Materials", "Animation", "Scenes"};
		for (int i = 0; i < startUpFolders.Length; i++)
		{
			AssetDatabase.CreateFolder("Assets", startUpFolders[i]);
        	//string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
		}

		string[] scriptFolders = new string[]{"Controllers", "Models"};
		for (int i = 0; i < scriptFolders.Length; i++)
		{
			AssetDatabase.CreateFolder("Scripts", scriptFolders[i]);
		}

		string[] resFolders = new string[]{"Sprites", "Audio"};
		for (int i = 0; i < resFolders.Length; i++)
		{
			AssetDatabase.CreateFolder("Resources", resFolders[i]);
		}

		// .... destroy self
		Destroy(this.gameObject);
    }
	public void CreateSubFolders(){
		
	}
}
