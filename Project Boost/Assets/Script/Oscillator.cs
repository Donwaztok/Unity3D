using UnityEngine;

public class Oscillator : MonoBehaviour {

	[SerializeField] Vector3 movementVector;
	[SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

	Vector3 startPos;

	void Start() {
		startPos = transform.position;
	}

	void Update() {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startPos + offset;
	}
}
