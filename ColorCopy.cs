#pragma warning disable 649
using UnityEngine;

class ColorCopy : MonoBehaviour {
	
	SpriteRenderer sprite;
	string clipboard {
		get => GUIUtility.systemCopyBuffer;
		set => GUIUtility.systemCopyBuffer = value;
	}
	
	void Awake() {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void OnMouseDown() {
		clipboard = ColorUtility.ToHtmlStringRGB(sprite.color);
	}
}
