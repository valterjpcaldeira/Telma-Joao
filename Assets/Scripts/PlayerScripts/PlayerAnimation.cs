using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animator anim;

	public string name = "Joao";

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Obstacle") {
			anim.Play ("Idle"+name);
		}
	}

	void OnCollisionExit2D (Collision2D target) {
		if (target.gameObject.tag == "Obstacle") {
			anim.Play ("Run"+name);
		}
	}
}
