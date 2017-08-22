using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float speed = 0.1f;

	private string maintex = "_MainTex";
	private Vector2 offset = Vector2.zero;
	private Material mat;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset (maintex);
	}
	
	// Update is called once per frame
	void Update () {
		offset.x += speed * Time.deltaTime;
		mat.SetTextureOffset (maintex, offset);
	}
}
