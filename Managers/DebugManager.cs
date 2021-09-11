using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public GameObject framerateTextCanvas;
    public GameObject framerateTextObject;
    public bool showFramerate = true;

    private Text framerateText;
    private int fpsDelay = 0;

    private void Awake()
    {
        framerateText = framerateTextObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (showFramerate == true)
        {
            RefreshFramerateStats();
        }
    }

    public void ToggleShowFramerate()
    {
        showFramerate = !showFramerate;
        framerateTextCanvas.SetActive(showFramerate);
    }

    private void RefreshFramerateStats()
    {
        if (fpsDelay == 60)
        {
            fpsDelay = 1;
        }
        else
        {
            fpsDelay += 1;
            return;
        }

        float msec = Time.deltaTime * 1000.0f;
        float fps = 1.0f / Time.deltaTime;
        string text = string.Format("{1:0.} fps\n{0:0.0} ms", msec, fps);
        framerateText.text = text;
    }
}
