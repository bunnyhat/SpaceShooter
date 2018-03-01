using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour {

	public float currencyGained;

	PlayerController m_playerController;
	CollectibleController m_collectibleController;

	void Awake () {
		m_playerController = GetComponent<PlayerController>();

		currencyGained = 0;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
			m_collectibleController = GameObject.FindGameObjectWithTag("Collectible").GetComponent<CollectibleController>();
			if(other.gameObject.name == "CurrencyR" && m_playerController.shipColor == "Red") {
				m_collectibleController.isCollected = true;
				currencyGained += m_collectibleController.currencyAmount;
				Debug.Log("currency: " + currencyGained);
			}
			if(other.gameObject.name == "CurrencyG" && m_playerController.shipColor == "Green") {
				m_collectibleController.isCollected = true;
				currencyGained += m_collectibleController.currencyAmount;
				Debug.Log("currency: " + currencyGained);
			}
			if(other.gameObject.name == "CurrencyB" && m_playerController.shipColor == "Blue") {
				m_collectibleController.isCollected = true;
				currencyGained += m_collectibleController.currencyAmount;
				Debug.Log("currency: " + currencyGained);
			}
			if(other.gameObject.name == "CurrencyY" && m_playerController.shipColor == "Yellow") {
				m_collectibleController.isCollected = true;
				currencyGained += m_collectibleController.currencyAmount;
				Debug.Log("currency: " + currencyGained);
			}
	}

}
