using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour {

	public float fallSpeed;
	public Color[] currencyColor;
	public float currencyAmount;
	
	public bool isCollected;

	SpriteRenderer m_spriteRenderer;
	Rigidbody2D m_rigidbody;

	PlayerController m_playerController;

	
	void Awake() {
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		m_rigidbody = GetComponent<Rigidbody2D>();

		m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

		RandomizeCurrency();
	}

	void Update() {
		m_rigidbody.AddRelativeForce(Vector3.down * fallSpeed);
	}

	void LateUpdate() {
		if(isCollected) {
			Destroy(this.gameObject);
		}
	}

	void RandomizeCurrency() {
		if(gameObject.name == "Currency") {
			currencyAmount = Random.Range(5, 10);

			float randomColor = Random.Range(0, 100);
			if(randomColor >= 0 && randomColor <= 25) {
				this.m_spriteRenderer.color = currencyColor[0];
				this.gameObject.name = "CurrencyR";
			} else if(randomColor >= 26 && randomColor <= 50) {
				this.m_spriteRenderer.color = currencyColor[1];
				this.gameObject.name = "CurrencyG";
			} else if(randomColor >= 51 && randomColor <= 75) {
				this.m_spriteRenderer.color = currencyColor[2];
				this.gameObject.name = "CurrencyB";
			} else if(randomColor >= 76 && randomColor <= 100) {
				this.m_spriteRenderer.color = currencyColor[3];
				this.gameObject.name = "CurrencyY";
			}
		}
	}
	
}
