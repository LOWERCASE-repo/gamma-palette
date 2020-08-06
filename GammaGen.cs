#pragma warning disable 649
using UnityEngine;
using UnityEditor;

class GammaGen : MonoBehaviour {
	
	internal static GammaGen instance;
	
	string clipboard {
		get => GUIUtility.systemCopyBuffer;
		set => GUIUtility.systemCopyBuffer = value;
	}
	
	[SerializeField]
	SpriteRenderer[] tints, shades;
	SpriteRenderer main;
	Camera cam;
	int length = 3;
	
	void Awake() {
		instance = this;
		main = GetComponent<SpriteRenderer>();
		cam = Camera.main;
		SetColor(main.color);
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			Color color;
			if (ColorUtility.TryParseHtmlString("#" + clipboard, out color)) {
				GammaGen.instance.SetColor(color);
			}
		}
	}
	
	internal void SetColor(Color color) {
		Vector3 background = Vector3.zero;
		main.color = color;
		for (int i = 0; i < length; i++) {
			tints[i].color = color;
			shades[i].color = color;
			for (int j = 0; j <= i; j++) {
				tints[i].color = tints[i].color.gamma;
				shades[i].color = shades[i].color.linear;
			}
			background.x += tints[i].color.r;
			background.y += tints[i].color.g;
			background.z += tints[i].color.b;
			background.x += tints[i].color.r;
			background.y += tints[i].color.g;
			background.z += tints[i].color.b;
		}
		background /= length * 2f;
		cam.backgroundColor = new Color(1f - background.x, 1f - background.y, 1f - background.z);
	}
}
