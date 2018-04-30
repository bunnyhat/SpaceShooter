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
	public SpriteRenderer basicEnemy;
	public SpriteRenderer[] shellCount;
	public string shipName;

	private float randEnemyColor;
	private string shellColor;

	Rigidbody2D m_rigidbody;

	void Awake() {
		m_rigidbody = GetComponent<Rigidbody2D>();
		randEnemyColor = Random.Range(0, 4);
	}

	void Update() {
		for(int i = 0; i < shellCount.Length; i++) {
			if(shellColor == "Red") { shellCount[i].color = Color.red; }
			else if(shellColor == "Green") { shellCount[i].color = Color.green; }
			else if(shellColor == "Blue") { shellCount[i].color = Color.blue; }
			else if(shellColor == "Yellow") { shellCount[i].color = Color.yellow; }
		}

		switch(enemyType) {
			case ENEMY_TYPE.BASIC:
				if(randEnemyColor == 0) {
					basicEnemy.color = Color.red;
					shellColor = "Red";
					shipName = "BasicRed";
				}
				if(randEnemyColor == 1) {
					basicEnemy.color = Color.green;
					shellColor = "Green";
					shipName = "BasicGreen";
				}
				if(randEnemyColor == 2) {
					basicEnemy.color = Color.blue;
					shellColor = "Blue";
					shipName = "BasicBlue";
				}
				if(randEnemyColor == 3) {
					basicEnemy.color = Color.yellow;
					shellColor = "Yellow";
					shipName = "BasicYellow";
				}
				m_rigidbody.AddForce(Vector2.down * 1);
				break;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "EnemyCollector") {
			Destroy(this.gameObject);
		}
	}

}
