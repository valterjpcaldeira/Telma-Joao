using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	[SerializeField]
	private AudioClip jumpClip;

	private float jumpForce = 12f, fowardForce = 0f;

	private Rigidbody2D myBody;

	private bool canJump;

	private Button jumpBtn;

	// Use this for initialization
	void Awake () {

		myBody = GetComponent<Rigidbody2D> ();

		jumpBtn = GameObject.Find ("jumpButton").GetComponent<Button>();

		jumpBtn.onClick.AddListener (() => jump());
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (myBody.velocity.y) == 0) {
			canJump = true;
		}
	}

	void jump(){

		if (canJump) {
			canJump = false;

			AudioSource.PlayClipAtPoint (jumpClip, transform.position);

			if (transform.position.x < 0) {
				fowardForce = 1f;
			} else {
				fowardForce = 0f;
			}

			myBody.velocity = new Vector2 (fowardForce, jumpForce);


		}

	}
}//Player JUMP



































