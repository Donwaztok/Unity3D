using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField] float mainThrust = 100f;
	[SerializeField] float rotationThrust = 100f;
	[SerializeField] AudioClip mainEngine;
	[SerializeField] ParticleSystem mainEngineParticle;

	Rigidbody rb;
	AudioSource audioSource;

	void Start() {
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update() {
		ProcessThrust();
		ProcessRotation();
	}

	void ProcessThrust() {
		if (Input.GetKey(KeyCode.Space)) {
			rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
			if (!audioSource.isPlaying)
				audioSource.PlayOneShot(mainEngine);
			if (!mainEngineParticle.isPlaying)
				mainEngineParticle.Play();
		} else {
			audioSource.Stop();
			mainEngineParticle.Stop();
		}
	}

	void ProcessRotation() {
		if (Input.GetKey(KeyCode.A)) {
			ApplyRotation(rotationThrust);
		}
		if (Input.GetKey(KeyCode.D)) {
			ApplyRotation(-rotationThrust);
		}
	}
	public void ApplyRotation(float rotation) {
		rb.freezeRotation = true;
		transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
		rb.freezeRotation = false;
	}
}
