using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public float currencyGained;
	private bool canFire = false;

	Rigidbody2D m_rigidbody;
	Animator m_animator;
	CollectibleController m_collectibleController;

	void Start () {
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();

		maxHP = currentHP = 100;
		shipColor = "Red";
		currencyGained = 0;
	}
	
	void Update () {
		if(currentHP <= 0) { isDead = true; }

		if(!isDead) {
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

			if(Input.GetKeyDown(KeyCode.Space)) {
				SwitchShips();
			}

			float nextFire = 0;
			if(Input.GetMouseButtonDown(0) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				GameObject beamClone = Instantiate(beamPrefab, beamSpawner.position, beamSpawner.rotation);
			}
		} else {
			//Player died - KA BOOM!
			m_rigidbody.velocity = Vector2.zero;
		}
		
	}

	void SwitchShips() {
		switch(shipColor) {
			case "Red":
				m_animator.Play("PlayerG");
				shipColor = "Green";
				haloSprite.sprite = haloColor[1];
				break;
			case "Green":
				m_animator.Play("PlayerB");
				shipColor = "Blue";
				haloSprite.sprite = haloColor[2];
				break;
			case "Blue":
				m_animator.Play("PlayerY");
				shipColor = "Yellow";
				haloSprite.sprite = haloColor[3];
				break;
			case "Yellow":
				m_animator.Play("PlayerR");
				shipColor = "Red";
				haloSprite.sprite = haloColor[0];
				break;
			default:
				break;
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		m_collectibleController = GameObject.FindGameObjectWithTag("Collectible").GetComponent<CollectibleController>();
		if(other.gameObject.name == "CurrencyR" && shipColor == "Red") {
			m_collectibleController.isCollected = true;
			currencyGained += m_collectibleController.currencyAmount;
			Debug.Log("currency: " + currencyGained);
		}
		if(other.gameObject.name == "CurrencyG" && shipColor == "Green") {
			m_collectibleController.isCollected = true;
			currencyGained += m_collectibleController.currencyAmount;
			Debug.Log("currency: " + currencyGained);
		}
		if(other.gameObject.name == "CurrencyB" && shipColor == "Blue") {
			m_collectibleController.isCollected = true;
			currencyGained += m_collectibleController.currencyAmount;
			Debug.Log("currency: " + currencyGained);
		}
		if(other.gameObject.name == "CurrencyY" && shipColor == "Yellow") {
			m_collectibleController.isCollected = true;
			currencyGained += m_collectibleController.currencyAmount;
			Debug.Log("currency: " + currencyGained);
		}
	}

}
