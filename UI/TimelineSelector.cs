using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class TimelineSelector : MonoBehaviour
{
    /*
    On start, create Timeline selection buttons,
    each with a Display Name and Playable Director reference.
    Clicking a button plays the corresponding Playable Director.
    */

    #region Variables

    [System.Serializable]
    public struct TimelineInfo
    {
        public string displayName;
        public PlayableDirector playableDirector;
    }
    public TimelineInfo[] timelineInfoArray;
    public GameObject buttonPrefab;  // Timeline selection button prefab;
    //public float yOffset = -30f;  // Y offset for each new button;
    public Vector3 initPos = new Vector3(0f, 0f, 0f);
    public Vector3 posOffset = new Vector3(0f, -30f, 0f); // Offset for each new button;

    #endregion

    #region Initialize

    private void Start()
    {
        Vector3 _pos = initPos;
        // For each Timeline Info, create a button;
        foreach(TimelineInfo timelineInfo in timelineInfoArray)
        {
            // Instantiate button prefab;
            GameObject _buttonObject = Instantiate(buttonPrefab,
                transform.localPosition,
                transform.localRotation,
                this.transform);

            // Set position;
            RectTransform _buttonRect = _buttonObject.GetComponent<RectTransform>();
            //_buttonRect.localPosition = new Vector3(0f, _ypos, 0f);
            _buttonRect.localPosition = _pos;
            //_ypos += yOffset;
            _pos += posOffset;

            // Set button text;
            //_buttonObject.GetComponentInChildren<Text>().text = timelineInfo.displayName;
            _buttonObject.GetComponentInChildren<TextMeshProUGUI>().SetText(timelineInfo.displayName);

            // Set button OnClick to SelectTimeline() function;
            Button _button = _buttonObject.GetComponent<Button>();
            _button.onClick.AddListener(
                delegate { 
                    SelectTimeline(timelineInfo.playableDirector); 
                }); 
        }
    }

    #endregion

    #region Functions

    // Select and play a timeline in a Playable Director;
    public void SelectTimeline(PlayableDirector targetPlayableDirector)
    {
        // Stop all Playable Directors;
        foreach (TimelineInfo timelineInfo in timelineInfoArray)
        {
            timelineInfo.playableDirector.Stop();
        }

        // Then, play this Playable Director;
        targetPlayableDirector.Play();
    }

    #endregion
}
