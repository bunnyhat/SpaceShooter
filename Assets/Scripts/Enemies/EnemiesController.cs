using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum ENEMY_TYPE {
	BASIC,
	EASY,
	MEDIUM,
	HARD,
	BOSS
}

public class EnemiesController : MonoBehaviour {

	[SerializeField] public ENEMY_TYPE enemyType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
