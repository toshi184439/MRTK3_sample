using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForce : MonoBehaviour
{
    public enum TypeOfBreakingBall : int {
      straight = 0,
      actual = 1
    }

    private ChangeForce() {}

    ChangeForce instance;

    int _changePower = 30; //変化させる力

    public TypeOfBreakingBall _TypeOfBreakingBall = TypeOfBreakingBall.actual;

    Vector3 _shootDirection = new Vector3(-1.0f, -0.1f, 0);
    Vector3 _sinkerDirection = new Vector3(-0.5f, -0.5f, 0);
    Vector3 _forkDirection = new Vector3(0.0f, -1.0f, 0);
    Vector3 _curveDirection = new Vector3(0.5f, -0.5f, 0);
    Vector3 _sliderDirection = new Vector3(1.0f, -0.1f, 0);

    string[] _typeofBrakingBall = new string[] {"straight", "shoot", "sinker", "fork", "curve", "slider"};

    List<Vector3> _typeBreackingBallVec = new List<Vector3>();

    void Awake() {
      if(instance == null) {
        instance = this;
      }

      _typeBreackingBallVec.Add(Vector3.zero);
      _typeBreackingBallVec.Add(_shootDirection);
      _typeBreackingBallVec.Add(_sinkerDirection);
      _typeBreackingBallVec.Add(_forkDirection);
      _typeBreackingBallVec.Add(_curveDirection);
      _typeBreackingBallVec.Add(_sliderDirection);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "Ball") {
            Debug.Log("change direction");
            Rigidbody ball_rb = other.gameObject.GetComponent<Rigidbody>();
            ChangeBallForce(ball_rb);
        }
    }

    private void ChangeBallForce(Rigidbody ball_rb) {
      int rnd = Random.Range(0, 6);
      ball_rb.AddForce(_typeBreackingBallVec[rnd] * _changePower);  //ボールに力を加える
      Debug.Log(_typeofBrakingBall[rnd]);
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
