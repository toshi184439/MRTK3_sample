using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTest : MonoBehaviour
{
    public Rigidbody _rb;
    public int power;
    private Vector3 firstDirection = new Vector3(0f, 0.1f, -1.0f); //カメラの方向に投げてみる
    private Vector3 startPosition;
    private Quaternion startRotation;
    private GameObject ballObject;
    private float startTime;

    // Start is called before the first frame update
    void Start() {
        ballObject = this.gameObject;
        startPosition = ballObject.transform.position;
        startRotation = ballObject.transform.rotation;
        _rb.AddForce(firstDirection * power);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        Vector3 currentPosition = ballObject.transform.position;
        if (currentPosition.z < -0.5 && (Time.time - startTime ) > 3.0f ) {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            ballObject.transform.position = startPosition;
            ballObject.transform.rotation = startRotation;
            _rb.AddForce(firstDirection * power);
        }
    }
}
