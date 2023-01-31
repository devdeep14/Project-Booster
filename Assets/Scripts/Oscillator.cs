using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;

    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);


    }

    // Update is called once per frame
    void Update()
    {
        if(period == Mathf.Epsilon) { return; }
        float cycles = Time.time / period;      // Continuous growing over time

        const float tau = Mathf.PI * 2;     // Const value of 6.28
        float rawSine = Mathf.Sin(cycles * tau);        // Going from -1 ro 1

        movementFactor = (rawSine + 1f) / 2f;       // Recalculate from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
