using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text counterText;

    private float seconds, minutes;


    void Update()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        counterText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
}
