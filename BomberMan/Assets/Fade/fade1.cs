using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade fade;
    float time = 0.5f;
    void Start()
    {
        fade.FadeOut(time);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    fade.FadeIn(0.5f);
        //}
        //else if (Input.GetKeyDown(KeyCode.H))
        //{
        //    fade.FadeOut(0.5f);
        //}
    }

    public void Title_Click()
    {
        fade.FadeIn(time, () =>
            SceneManager.LoadScene("Title"));
    
    }
}
