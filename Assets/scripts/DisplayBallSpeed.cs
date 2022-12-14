using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBallSpeed : MonoBehaviour
{
    private DisplayBallSpeed() {}
    public static DisplayBallSpeed instance;
    public TextMeshPro _text;

    void Awake() {
      if(instance == null) {
        instance = this;
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        _text = this.transform.GetComponent<TextMeshPro>();
    }

    // Display ball speed
    public void DisplayText(string text) {
        _text.SetText(text);
        Debug.Log(text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
