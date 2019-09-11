using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fade2 : MonoBehaviour
{
    public Fade fade;
    float time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
       
        fade.FadeOut(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rezalt()
    {
        fade.FadeIn(time, () => SceneManager.LoadScene("Result"));
    }
}
