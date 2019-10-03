using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Temptation : MonoBehaviour
{
    public float speed = 1.0f;

    private Text text;
    private float time;

    private enum objType {
        TEXT,
        IMAGE
    };
    private objType thisobjType = objType.TEXT;

    void Start()
    {
        if (this.gameObject.GetComponent<Text>())
        {
            thisobjType = objType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }
    }

    void Update()
    {
        if (thisobjType == objType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }
}
