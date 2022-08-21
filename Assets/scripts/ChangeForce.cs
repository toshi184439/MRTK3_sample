using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForce : MonoBehaviour
{

    int _changePower = 30; //変化させる力

    Vector3 _shootDirection = new Vector3(-1.0f, -1.0f, 0);
    Vector3 _sliderDirection = new Vector3(1.0f, -0.1f, 0);
    Vector3 _forkDirection = new Vector3(0.0f, -1.0f, 0);
    Vector3 _straightDirection = Vector3.zero;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "Ball") {
            Debug.Log("change direction");
            Rigidbody ball_rb = other.gameObject.GetComponent<Rigidbody>();
            ball_rb.AddForce(_sliderDirection * _changePower);//ボールに力を加える
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
