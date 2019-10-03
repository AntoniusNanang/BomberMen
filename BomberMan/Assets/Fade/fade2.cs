using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fade2 : MonoBehaviour
{
    public Fade fade;
    float time = 0.5f;
    string[] scene_name = { "TitleScene", "Game", "ResultScene" };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        fade.FadeOut(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(scene_name[0] == SceneManager.GetActiveScene().name)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                fade.FadeIn(time, () => SceneManager.LoadScene("ResultScene"));
            }
        }
        else if (scene_name[1] == SceneManager.GetActiveScene().name)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                fade.FadeIn(time, () => SceneManager.LoadScene("ResultScene"));
            }
        }
        else if (scene_name[2] == SceneManager.GetActiveScene().name)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                fade.FadeIn(time, () => SceneManager.LoadScene("TitleScene"));
            }
        }


    }
   
}
