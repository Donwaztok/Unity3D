using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

	[SerializeField] AudioClip success;
	[SerializeField] AudioClip crash;
	[SerializeField] ParticleSystem successParticle;
	[SerializeField] ParticleSystem explosionParticle;

	AudioSource audioSource;

	bool isTransitioning = false;

	private void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision other) {
		if (!isTransitioning) {
			switch (other.gameObject.tag) {
				case "Friendly":
					Debug.Log("Friendly");
					break;
				case "Finish":
					StartSuccessSequence();
					break;
				case "Fuel":
					Debug.Log("Fuel");
					break;
				default:
					StartCrashSequence();
					break;
			}
		}
	}

	void StartCrashSequence() {
		isTransitioning = true;
		audioSource.PlayOneShot(crash);
		explosionParticle.Play();
		GetComponent<Movement>().enabled = false;
		Invoke("ReloadLevel", 1);
	}

	void StartSuccessSequence() {
		isTransitioning = true;
		audioSource.PlayOneShot(success);
		successParticle.Play();
		GetComponent<Movement>().enabled = false;
		Invoke("LoadNextLevel", 1);
	}

	void ReloadLevel() {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}

	void LoadNextLevel() {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		int nextSceneIndex = currentSceneIndex + 1;
		if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
			nextSceneIndex = 0;
		}
		SceneManager.LoadScene(nextSceneIndex);
	}
}
