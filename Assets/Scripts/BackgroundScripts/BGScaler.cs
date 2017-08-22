using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	public string BG_NAME = "background";

	// Use this for initialization
	void Start () {
		var height = Camera.main.orthographicSize * 2f;
		var width = height * Screen.width / Screen.height;

		if (gameObject.name == BG_NAME) {
			transform.localScale = new Vector3 (width, height, 0);
		} else {
			transform.localScale = new Vector3 (width+13f, 5, -3);
		}
	}

}
