using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFader : MonoBehaviour {

    public float fadeSpeed = 10f;

    public bool bounceOut = true;

    public bool fadeOut = false;
    public bool fadeIn = false;

    private MeshRenderer rend;

	void Start () {
        rend = GetComponent<MeshRenderer>();
    }
	
    public void ResetFade()
    {
        Color oldColor = rend.material.color;
        rend.material.color = new Color(oldColor.r, oldColor.g, oldColor.b, 0f);

        fadeIn = false;
        fadeOut = false;
    }

	void Update () {
        Color oldColor = rend.material.color;

        float alphaChange = oldColor.a;

        if (fadeOut)
        {
            alphaChange = oldColor.a - (fadeSpeed * Time.deltaTime);
            if (alphaChange < 0f)
                alphaChange = 0f;
        }
        else if(fadeIn)
        {
            alphaChange = oldColor.a + (fadeSpeed * Time.deltaTime);
            if (alphaChange > 1f)
            {
                alphaChange = 1f;

                if(bounceOut)
                {
                    fadeOut = true;
                    fadeIn = false;
                }
            }
        }

        rend.material.color = new Color(oldColor.r, oldColor.g, oldColor.b, alphaChange);
	}
}
