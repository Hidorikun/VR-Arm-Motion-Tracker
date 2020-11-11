using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    float deltaTime = 0.0f;
    float second = 1.0f;
    int gfps = 0;
    int count = 0;
    int handFPS = 0;

    public HandTracking handTracking; 

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;

        second -= Time.deltaTime;
        count += 1; 

        if (second < 0)
        {

            second = 1.0f;
            gfps = count;
            count = 0;

            handFPS = handTracking.GetCount();
            handTracking.ResetCount(); 

        }

        
        
        this.GetComponent<Text>().text = "Game FPS: " + gfps + "\nHand FPS: " + handFPS;
    }


}
