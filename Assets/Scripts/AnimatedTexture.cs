using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	private Vector2 offset = Vector2.zero;
	private	 Material material;

	private const string _MAIN_TEXTURE_NAME = "_MainTex";

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer> ().material;
		offset = material.GetTextureOffset (_MAIN_TEXTURE_NAME);
	}
	
	// Update is called once per frame
	void Update () {
		offset += speed * Time.deltaTime;
		material.SetTextureOffset (_MAIN_TEXTURE_NAME, offset);
	}
}
