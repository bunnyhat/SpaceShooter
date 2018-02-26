using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour {
	Animator m_animator;

	void Awake() {
		m_animator = GetComponent<Animator>();


		PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		if(playerController.shipColor == "Red") {
			m_animator.Play("BeamR");
		} else if(playerController.shipColor == "Green") {
			m_animator.Play("BeamG");
		} else if(playerController.shipColor == "Blue") {
			m_animator.Play("BeamB");
		} else if(playerController.shipColor == "Yellow") {
			m_animator.Play("BeamY");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

		if(other.gameObject.name == "BeamContainer") {
			Destroy(this.gameObject);
		}
	}
}
