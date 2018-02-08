using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSoundEnd : MonoBehaviour {

	void Update () {
		if(!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
