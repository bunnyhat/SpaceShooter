using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloController : MonoBehaviour {

	public bool isOnline = true;
	SpriteRenderer m_spriteRenderer;
	Animator m_animator;

	void Start() {
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		m_animator = GetComponent<Animator>();
	}

	void Update() {
		if(Input.GetKey(KeyCode.X)) {
			isOnline = false;
		}

		if(isOnline) {
			//apply damage boost or more resource gain
			m_spriteRenderer.enabled = true;
		} else {
			//no resource and buffs for you!
			m_spriteRenderer.enabled = false;
		}
	}


}
