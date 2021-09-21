using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour {

	[SerializeField] float restoreAngle = 90f;
	[SerializeField] float addIntensity = 1f;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponentInChildren<FlashLight>().RestoreLightAngle(restoreAngle);
			other.gameObject.GetComponentInChildren<FlashLight>().RestoreLightIntensity(addIntensity);
			Destroy(gameObject);
		}
	}
}
