using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloGUI : MonoBehaviour {

	PlayerController m_player;

	void Awake() {
		m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	public void SwitchToShip(string m_shipColor) {
		if(m_player.isSelectorActive) {
			if(m_shipColor == "Red") { m_player.shipColor = "Red"; }
			else if(m_shipColor == "Green") { m_player.shipColor = "Green"; }
			else if(m_shipColor == "Blue") { m_player.shipColor = "Blue"; }
			else if(m_shipColor == "Yellow") { m_player.shipColor = "Yellow"; }
			m_player.SwitchShips();
		}
	}

}
