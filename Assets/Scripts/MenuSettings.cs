using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettings : SingletonComponent<MenuSettings> {

    public float maxMoveSpeed = 6f;
    public float minMoveSpeed = 2f;
    public float headDeadZoneMin = 0.05f;
    public float headDeadZoneMax = 0.125f;

    public bool toggleGrip = false;

    public bool USE_TRACKPAD = false;
    public bool USE_TELEPORT = false;
    public bool USE_JOGGING = true;

    public bool IS_EXPERIMENT = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
