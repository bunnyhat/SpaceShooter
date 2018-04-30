using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaloGUI : MonoBehaviour {

	private bool isMenuShown = false;
	private float fadeTimer = 3f;
	private float resetFadeTimer;
	Image m_selector;
	// Animator m_animaton;
	PlayerController m_player;

	void Awake() {
		m_selector = GetComponent<Image>();
		// m_animaton = GetComponent<Animator>();
		m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		resetFadeTimer = fadeTimer;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(!isMenuShown) {
				isMenuShown = true;
			} else {
				isMenuShown = false;
			}
		}

		if(isMenuShown) { m_selector.enabled = true; } 
		else { m_selector.enabled = false; }

	}

	public void SwitchToShip(string m_shipColor) {
		if(isMenuShown) {
			if(m_shipColor == "Red") { m_player.shipColor = "Red"; }
			else if(m_shipColor == "Green") { m_player.shipColor = "Green"; }
			else if(m_shipColor == "Blue") { m_player.shipColor = "Blue"; }
			else if(m_shipColor == "Yellow") { m_player.shipColor = "Yellow"; }
			m_player.SwitchShips();
		}
	}

	// IEnumerator FadeTo(float aValue, float aTime) {
	// 	float alpha = m_selector.color.a;
	// 	for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
	// 		Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
	// 		m_selector.color = newColor;
	// 		yield return null;
	// 	}
	// }

}
