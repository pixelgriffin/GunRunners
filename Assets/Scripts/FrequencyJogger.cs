using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrequencyJogger : MonoBehaviour {

    public Transform hmd;

    [Tooltip("Expressed in seconds")]
    public float checkInterval = 0.5f;//seconds
    public float ampThreshold = 0.05f;
    public float maxAmpThreshold = 0.085f;
    public int slopeSamples = 5;
    public float slopeThreshold = 0f;

    public UnityEvent OnJogStart, OnJogEnd;

    private float maxAmp, minAmp;
    private float previousY;

    private List<float> slopes;

	void Start () {
        slopes = new List<float>();

        InvokeRepeating("FireJog", 0f, checkInterval);
        InvokeRepeating("SampleSlope", 0f, checkInterval / (float)slopeSamples);

        previousY = hmd.position.y;
	}

    // Update is called once per frame
    void Update()
    {
        float amp = hmd.position.y - previousY;
        if(amp < minAmp)
        {
            minAmp = amp;
        }
        if(amp > maxAmp)
        {
            maxAmp = amp;
        }
        Debug.Log("min: " + minAmp);
        Debug.Log("max: " + maxAmp);
        Debug.Log("amp: " + Mathf.Abs((maxAmp - minAmp) / Mathf.Max(maxAmp, 1f)));
    }

    void SampleSlope()
    {
        float point = hmd.position.y;
        slopes.Add(point);
    }

    void FireJog()
    {
        bool negativeSlope = false;
        bool positiveSlope = false;
        for(int i = 0; i < slopes.Count - 1; i++)
        {
            float slope = slopes[i] - slopes[i + 1];
            if(slope < slopeThreshold)
            {
                negativeSlope = true;
            }
            else if(slope > slopeThreshold)
            {
                positiveSlope = true;
            }
        }

        if (negativeSlope && positiveSlope)
        {
            //Gather amplitude ratio of jog
            float ampRatio = Mathf.Abs((maxAmp - minAmp) / maxAmp);

            if (ampRatio > ampThreshold && ampRatio < maxAmpThreshold)
            {
                //started jogging
                OnJogStart.Invoke();
                Debug.Log("You're running bud");
            }
            else
            {
                //stopped jogging
                OnJogEnd.Invoke();
                Debug.Log("Oh you stopped");
            }
        }
        else
        {
            OnJogEnd.Invoke();
            Debug.Log("Oh you stopped");
        }

        //reset min and max
        maxAmp = -10000000f;
        minAmp = 10000000f;

        slopes.Clear();
    }
}
