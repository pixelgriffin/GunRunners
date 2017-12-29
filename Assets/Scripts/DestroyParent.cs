using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour {

    public void DestroyChain()
    {
        Transform par = this.transform;
        while(par.parent != null)
        {
            par = par.transform.parent;
        }

        par.gameObject.SetActive(false);
        //Destroy(par.gameObject);
    }
}
