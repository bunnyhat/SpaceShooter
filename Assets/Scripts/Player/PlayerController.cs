using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float currentHP, maxHP;
	public bool isDead = false;
	public string shipColor;
	
	public SpriteRenderer haloSprite;
	public Sprite[] haloColor;

	public GameObject beamPrefab;
	public Transform beamSpawner;
	public float fireRate;

	private bool canFire = true;

	private Vector3 target;

	Rigidbody2D m_rigidbody;
	Animator m_animator;


	void Awake () {
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();

		maxHP = currentHP = 100;
		shipColor = "Red";
	}
	
	void Update () {
		if(currentHP <= 0) { 
			isDead = true;
			currentHP = 0;
		}
		if(currentHP > 100) { currentHP = 100; }

		if(!isDead) {
			m_rigidbody.velocity = Vector2.zero;
			if(m_rigidbody.velocity == Vector2.zero) { canFire = true; }

			if(Input.GetKeyDown(KeyCode.A)) {
				if(transform.position.x == -2) {
					transform.position = new Vector2(-2, transform.position.y);
				} else if(transform.position.x == 0) {
					transform.position = new Vector2(-2, transform.position.y);
				} else if(transform.position.x == 2) {
					transform.position = new Vector2(0, transform.position.y);
				}
			}
			if(Input.GetKeyDown(KeyCode.D)) {
				if(transform.position.x == 2) {
					transform.position = new Vector2(2, transform.position.y);
				} else if(transform.position.x == 0) {
					transform.position = new Vector2(2, transform.position.y);
				} else if(transform.position.x == -2) {
					transform.position = new Vector2(0, transform.position.y);
				}
			}

			fireRate -= 1;
			if(fireRate <= 0) {
				GameObject beamClone = Instantiate(beamPrefab, this.transform.position, beamSpawner.rotation);
				fireRate = 30;
			}
		} else {
			//Player died - KA BOOM!
			m_rigidbody.velocity = Vector2.zero;
			canFire = false;
		}
	}

	public void SwitchShips() {
		switch(shipColor) {
			case "Red":
				m_animator.Play("PlayerR");
				shipColor = "Red";
				haloSprite.sprite = haloColor[0];
				break;
			case "Green":
				m_animator.Play("PlayerG");
				shipColor = "Green";
				haloSprite.sprite = haloColor[1];
				break;
			case "Blue":
				m_animator.Play("PlayerB");
				shipColor = "Blue";
				haloSprite.sprite = haloColor[2];
				break;
			case "Yellow":
				m_animator.Play("PlayerY");
				shipColor = "Yellow";
				haloSprite.sprite = haloColor[3];
				break;
			default:
				break;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
	}

}
