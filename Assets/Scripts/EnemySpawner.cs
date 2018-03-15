using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform[] spawners;
	public GameObject enemyPrefab;
	public float spawnTimer;
	public int randLocation;

	void Update() {
		spawnTimer -= Time.deltaTime;
		if(spawnTimer <= 0) {
			GetLocation();
			spawnTimer = 2;
		}
	}

	void GetLocation() {
		randLocation = Random.Range(0, spawners.Length);
		GameObject enemyClone = Instantiate(enemyPrefab, spawners[randLocation].position, spawners[randLocation].rotation);
	}

}
