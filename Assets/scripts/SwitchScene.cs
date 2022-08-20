using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void ChangeOffenceTrainingScene() {
      SceneManager.LoadScene("OffenceTrainingScene");
    }

    public void ChangeDefenceTrainingScene() {
      SceneManager.LoadScene("DefenceTrainingScene");
    }

    public void ChangeStartScene() {
      SceneManager.LoadScene("StartScene");
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
