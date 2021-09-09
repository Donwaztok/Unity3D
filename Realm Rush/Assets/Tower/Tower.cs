using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	[SerializeField] int cost = 75;
	[SerializeField] float buildTime = 1;

	private void Start() {
		StartCoroutine(Build());
	}

	public bool CreateTower(Tower tower, Vector3 position) {
		Bank bank = FindObjectOfType<Bank>();

		if (bank == null) {
			return false;
		}

		if (bank.CurrentBalance >= cost) {
			Instantiate(tower, position, Quaternion.identity);
			bank.Withdraw(cost);
			return true;
		}

		return false;
	}

	IEnumerator Build() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive(false);
			foreach (Transform grandChild in transform) {
				grandChild.gameObject.SetActive(false);
			}
		}

		foreach (Transform child in transform) {
			child.gameObject.SetActive(true);
			yield return new WaitForSeconds(buildTime);
			foreach (Transform grandChild in transform) {
				grandChild.gameObject.SetActive(true);
			}
		}
	}
}
