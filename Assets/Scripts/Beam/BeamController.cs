using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour {

	private string beamColor;
	Animator m_animator;

	void Awake() {
		m_animator = GetComponent<Animator>();

		PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		if(playerController.shipColor == "Red") {
			m_animator.Play("BeamR");
			beamColor = "Red";
		} else if(playerController.shipColor == "Green") {
			m_animator.Play("BeamG");
			beamColor = "Green";
		} else if(playerController.shipColor == "Blue") {
			m_animator.Play("BeamB");
			beamColor = "Blue";
		} else if(playerController.shipColor == "Yellow") {
			m_animator.Play("BeamY");
			beamColor = "Yellow";
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy") {
			EnemiesController enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemiesController>();
			if(enemyController.shipName == "BasicRed" && beamColor == "Red") {
				//Destory shells and beams here till ship is dead
			}
		}

		if(other.gameObject.name == "BeamContainer") {
			Destroy(this.gameObject);
		}
	}
}
