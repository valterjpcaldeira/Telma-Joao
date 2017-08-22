using UnityEngine;
using System.Collections;

public class PlayerIsReady : MonoBehaviour {

	public delegate void IsReady();
	public static event IsReady isReady;

	void playerIsReady(){
		if (isReady != null) {
			isReady ();
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "EndObstacle") {
			target.gameObject.SetActive(false);
			playerIsReady ();
		}
	}
}
