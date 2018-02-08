using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTiltTracker : MonoBehaviour {

	void Update () {
        if (MenuSettings.Instance.USE_JOGGING)
        {
            if (this.transform.rotation.z > 10)
                Statistics.Instance.data.leftTime += Time.deltaTime;
            if (this.transform.rotation.z < -10)
                Statistics.Instance.data.rightTime += Time.deltaTime;
            if (this.transform.rotation.x > 10)
                Statistics.Instance.data.forwardTime += Time.deltaTime;
            if (this.transform.rotation.x < -20)
                Statistics.Instance.data.backTime += Time.deltaTime;
        }
    }
}
