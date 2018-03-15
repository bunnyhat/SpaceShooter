using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour {

	private string beamColor;
	[SerializeField] private float beamSpeed;
	Animator m_animator;
	Rigidbody2D m_rigidbody;

	void Awake() {
		m_animator = GetComponent<Animator>();
		m_rigidbody = GetComponent<Rigidbody2D>();

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

	void Update() {
		PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

		if(playerController.transform.position.x == -2) {
			transform.position = new Vector2(-2, transform.position.y);
		} else if(playerController.transform.position.x == 0) {
			transform.position = new Vector2(0, transform.position.y);
		} else if(playerController.transform.position.x == 2) {
			transform.position = new Vector2(2, transform.position.y);
		}

		m_rigidbody.AddForce(Vector2.up * beamSpeed);
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
