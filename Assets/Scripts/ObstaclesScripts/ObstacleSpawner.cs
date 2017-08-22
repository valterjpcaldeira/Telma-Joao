using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles;

	[SerializeField]
	private GameObject endObject;

	private GameObject ending;

	private int END_METERS = 50;

	public float WAIT_RANGE_LESS = 1.5f;

	public float WAIT_RANGE_MORE = 4.5f;

	private List<GameObject> obstaclesForSpawing = new List<GameObject> ();

	[SerializeField]
	private Text scoretext;

	private bool go = true;

	private void Awake(){
		initObstacles ();
	}

	// Use this for initialization
	void Start () {
		ending = Instantiate (endObject, new Vector3 (transform.position.x,
			transform.position.y, -2), Quaternion.identity) as GameObject;
		ending.SetActive (false);
		StartCoroutine (spawnRandomObstacle ());
	}
	

	void initObstacles () {
		int index = 0;

		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles [index], new Vector3(transform.position.x,
				transform.position.y, -2), Quaternion.identity) as GameObject;
			obstaclesForSpawing.Add (obj);
			obstaclesForSpawing [i].SetActive (false);
			index++;
			if (index == obstacles.Length) {
				index = 0;
			}

		}
	}

	void Shuffle(){
		for (int i = 0; i < obstaclesForSpawing.Count; i++) {
			GameObject temp = obstaclesForSpawing [i];
			int random = Random.Range (i, obstaclesForSpawing.Count);
			obstaclesForSpawing [i] = obstaclesForSpawing [random];
			obstaclesForSpawing [random] = temp;
		}
	}

	IEnumerator spawnRandomObstacle(){
		yield return new WaitForSeconds (Random.Range (WAIT_RANGE_LESS, WAIT_RANGE_MORE));

		string[] array = scoretext.text.Split (new string[] { "M" }, System.StringSplitOptions.None);
		int x = int.Parse (array[0]);
		bool goNow = true;

		if (x > END_METERS) {
			if (go) {
				ending.SetActive (true);
				ending.transform.position = new Vector3 (transform.position.x,
					transform.position.y, -2);
				goNow = false;
				go = false;
			}
		}
		if (goNow) {
			int index = Random.Range (0, obstaclesForSpawing.Count);
			while (true) {
				if (!obstaclesForSpawing [index].activeInHierarchy) {
					obstaclesForSpawing [index].SetActive (true);
					obstaclesForSpawing [index].transform.position = new Vector3 (transform.position.x,
						transform.position.y, -2);
					break;
				} else {
					index = Random.Range (0, obstaclesForSpawing.Count);
				}
			}
		}

		StartCoroutine (spawnRandomObstacle ());
	}


}//ObstacleSpawner
















































