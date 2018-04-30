using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Image background, fillArea;
	
	[SerializeField] private Color excellent, good, medium, bad;
	private Slider healthSlider;

	PlayerController m_playerController;

	void Awake() {
		healthSlider = GetComponent<Slider>();
		m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();		
	}

	void Update() {
		healthSlider.value = m_playerController.currentHP;
		healthSlider.maxValue = m_playerController.maxHP;

		if(healthSlider.value <= 100 && healthSlider.value >= 76) {
			fillArea.color = excellent;
		} else if(healthSlider.value <= 75 && healthSlider.value >= 51) {
			fillArea.color = good;
		} else if(healthSlider.value <= 50 && healthSlider.value >= 26) {
			fillArea.color = medium;
		} else if(healthSlider.value <= 25 && healthSlider.value >= 0) {
			fillArea.color = bad;
		}
	}

}
