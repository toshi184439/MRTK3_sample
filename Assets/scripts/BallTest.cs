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
    private Vector3 firstDirection = new Vector3(0f, 0.05f, -2.0f); //カメラの方向に投げてみる
    private Vector3 startPosition;
    private Quaternion startRotation;
    private GameObject ballObject;
    private float startTime;
    private int speedcount;
    private float speedsum;

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
      if (currentPosition.z < -0.5 || currentPosition.y < -1.5) {
        if (currentPosition.z < -0.5 && speedcount < 1) {
          speedcount++;
          speedsum += _rb.velocity.z;
          float speedText = ((speedsum / speedcount) * -3.6f);
          speedText = Mathf.Floor(speedText);
          DisplaySpeedEvent?.Invoke(speedText.ToString() + "km/h");
          speedcount = 0;
          speedsum = 0.0f;
        }
      }
    }

    public void AddForce() {
      _rb.velocity = Vector3.zero;
      _rb.angularVelocity = Vector3.zero;
      ballObject.transform.position = startPosition;
      ballObject.transform.rotation = startRotation;
      _rb.AddForce(firstDirection * power);
    }
}
