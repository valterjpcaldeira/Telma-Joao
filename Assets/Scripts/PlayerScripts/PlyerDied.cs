using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlyerDied : MonoBehaviour {

	public delegate void EndGame();
	public static event EndGame endGame;

	void playerDiedEndgame(){
		if (endGame != null) {
			endGame ();
		}

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Collector") {
			playerDiedEndgame ();

		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Blood") {
			playerDiedEndgame ();
		}
	}
		
}
