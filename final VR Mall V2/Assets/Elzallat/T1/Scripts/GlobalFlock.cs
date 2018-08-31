using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {
	
	//public GameObject FishPrefab;
	public List<GameObject> FishPrefabs;
	public int NumFishes = 10;
	public Vector3 SwimLimit;// = new Vector3 (5, 5, 5);

	public static GameObject[] AllFishes;
	[HideInInspector]
	public GlobalFlock MyFlock;
	[HideInInspector]
	public Vector3 GoalPos;

	void Start () {
		AllFishes = new GameObject[NumFishes];
		MyFlock = this;
		GoalPos = this.transform.position;

		for (int i = 0; i < NumFishes; i++) {
			Vector3 pos = this.transform.position + new Vector3 (Random.Range (-SwimLimit.x, SwimLimit.x),
				              Random.Range (-SwimLimit.y, SwimLimit.y),
				              Random.Range (-SwimLimit.z, SwimLimit.z));
			
			int Index = Random.Range (0, FishPrefabs.Count);
			AllFishes [i] = (GameObject)Instantiate (FishPrefabs[Index], pos, Quaternion.identity);
			AllFishes [i].GetComponent<Flock>().MyManager = this;
		}
	}

	void Update () {
		if (Random.Range (0, 10000) < 50) {
			GoalPos = this.transform.position + new Vector3 (Random.Range (-SwimLimit.x, SwimLimit.x),
				Random.Range (-SwimLimit.y, SwimLimit.y),
				Random.Range (-SwimLimit.z, SwimLimit.z));
		}
	}
}
