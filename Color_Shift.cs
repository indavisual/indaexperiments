using UnityEngine;
using System.Collections;

public class Color_Shift : MonoBehaviour {

	public float changeSpeed = 0.01f;
	private ProceduralMaterial eyeSubstance;
	private float currentEyeColor, nextEyeColor, transEyeColor;
	private TileColor eyeColor;
	private float tol = 0.0001f;
	
	void Start() {
		eyeSubstance = GetComponent<Renderer>().sharedMaterial as ProceduralMaterial;
		currentEyeColor = eyeSubstance.GetProceduralFloat("Iris_Hue");
	}
		
	void Update() {
/*
		float currentIrisHue = eyeSubstance.GetProceduralFloat("Iris_Hue");
		//print(currentIrisHue);
		currentIrisHue += Time.deltaTime;
		currentIrisHue %= 1;
		eyeSubstance.SetProceduralFloat("Iris_Hue", currentIrisHue);
		
		Color currentIrisHueColor = eyeSubstance.GetProceduralColor("Iris_Hue");
		currentIrisHueColor = new Color(1, 0, 0);
		eyeSubstance.SetProceduralColor("Iris_Hue", currentIrisHueColor);
		//print(currentIrisHueColor);
		
		
		float currentDetailHue = eyeSubstance.GetProceduralFloat("Detail_Hue");
		currentDetailHue += Time.deltaTime;
		currentDetailHue %= 1;
		eyeSubstance.SetProceduralFloat("Detail_Hue", currentDetailHue);
	*/	
		if (Mathf.Abs(currentEyeColor - nextEyeColor) >= tol) {
			currentEyeColor += transEyeColor;
			eyeSubstance.SetProceduralFloat("Iris_Hue", currentEyeColor);
			eyeSubstance.SetProceduralFloat("Detail_Hue", currentEyeColor);
			eyeSubstance.RebuildTexturesImmediately();
		}
		print (currentEyeColor);
	}
	
	void OnCollisionEnter(Collision tile) {
		TileColor newColor = tile.gameObject.GetComponent<Tile_Color>().tileColor;
		SetEyeColor(newColor);
	}
	
	void SetEyeColor(TileColor nc) {
		switch (nc) {
			case TileColor.brown:
				nextEyeColor = 0.0f;
				break;
			case TileColor.green:
				nextEyeColor = 0.1f;
				break;
			case TileColor.blue:
				nextEyeColor = 0.25f;
				break;
			case TileColor.purple:
				nextEyeColor = 0.3f;
				break;
			case TileColor.magenta:
				nextEyeColor = 0.35f;
				break;
			case TileColor.red:
				nextEyeColor = 0.45f;
				break;
		}
		transEyeColor = (nextEyeColor - currentEyeColor) * changeSpeed;
	}
	
	void UpdateEyeColor(float cur, float nex, float trans) {

	}
	
	void ListProperties() {
		ProceduralPropertyDescription[] inputs = eyeSubstance.GetProceduralPropertyDescriptions();
		int i = 0;
		while (i < inputs.Length) {
			ProceduralPropertyDescription input = inputs[i];
			string inputName = input.name;
			ProceduralPropertyType type = input.type;
			print (inputName + ": " + type);
			i++;
		}
	}
}
