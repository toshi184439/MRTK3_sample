using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAnimator : MonoBehaviour
{
    Animator _animator;
    AnimatorStateInfo _animeStateInfo;
    private float startTime;
    private float currentTime;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool _throw = false;
    private bool _addforce = false;

    // Start is called before the first frame update
    void Awake() {
      startPosition = this.transform.position;
      startRotation = this.transform.rotation;
    }
    void Start()
    {
      _animator = this.transform.GetComponent<Animator>();
      startTime = Time.time;
      //_animeStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
      currentTime = Time.time;
      //Debug.Log(_animeStateInfo.length /* _animeStateInfo.normalizedTime*/);
      if(_throw == false) {
        if(currentTime - startTime > 3.0f) {
          _throw = true;
          _animator.SetBool("blThrow", true);
          startTime = currentTime;            
        }
      } else {
        if(currentTime - startTime > 3.0f) {
          _throw = false;
          _animator.SetBool("blThrow", false);
          this.transform.position = startPosition;
          this.transform.rotation = startRotation;
          startTime = currentTime;
          _addforce = false;
        } else if(currentTime - startTime > 1.65f) {
          if(_addforce == false) {
            BallTest.instance.AddForce();
            _addforce = true;
          }
        }
      }
    }
}
