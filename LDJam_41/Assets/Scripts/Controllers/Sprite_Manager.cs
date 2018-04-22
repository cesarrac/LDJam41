using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Manager : MonoBehaviour {

	//// 	This will later on read Sprites from Resources folder ////
	public static Sprite_Manager instance {get; protected set;}
	public Sprite[] unitSprites;
	private void Awake() {
		instance = this;
	}
	public Sprite GetUnitSprite(string unitName){
		foreach (Sprite sprite in unitSprites)
		{
			if (sprite.name == unitName)
				return sprite;
		}
		return null;
	}
}
