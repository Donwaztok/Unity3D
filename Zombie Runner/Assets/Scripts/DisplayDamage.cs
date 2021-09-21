using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour {

	[SerializeField] Canvas damageCanvas;
	[SerializeField] float damageDuration = 0.5f;

	private void Start() {
		damageCanvas.enabled = false;
	}

	public void ShowDamage() {
		damageCanvas.enabled = true;
		StartCoroutine(HideDamage());
	}

	IEnumerator HideDamage() {
		yield return new WaitForSeconds(damageDuration);
		damageCanvas.enabled = false;
	}
}
