using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class BallTest : MonoBehaviour
{
    private BallTest() {}
    public static BallTest instance;
    public Rigidbody _rb;
    public int power;
    private UnityEvent<string> DisplaySpeedEvent = new UnityEvent<string>();
    private Vector3 firstDirection = new Vector3(0f, 0.02f, -2.0f); //カメラの方向に投げてみる
    private Vector3 startPosition;
    private Quaternion startRotation;
    private GameObject ballObject;
    private float startTime;
    private bool _speedUpdated = false;

    void Awake() {
      if(instance == null) {
        instance = this;
      }
    }

    // Start is called before the first frame update
    void Start() {
        ballObject = this.gameObject;
        startPosition = ballObject.transform.position;
        startRotation = ballObject.transform.rotation;

        // not player seen position 
        ballObject.transform.position = new Vector3(0.0f, -100.0f, 0.0f);
        startTime = Time.time;
        DisplaySpeedEvent.AddListener(DisplayBallSpeed.instance.DisplayText);
    }

    // Update is called once per frame
    void Update() {
      Vector3 currentPosition = ballObject.transform.position;
      if (currentPosition.z < 3.0 && !_speedUpdated) {
        float speedText = (_rb.velocity.z * -3.6f);
        speedText = Mathf.Floor(speedText);
        DisplaySpeedEvent?.Invoke(speedText.ToString() + "km/h");
        _speedUpdated = true;
      }
    }

    public void AddForce(Transform rightHandTransform) {
      _rb.velocity = Vector3.zero;
      _rb.angularVelocity = Vector3.zero;
      ballObject.transform.position = rightHandTransform.position;
      ballObject.transform.rotation = rightHandTransform.rotation;
      _rb.AddForce(firstDirection * power);
      _speedUpdated = false;
    }
}
