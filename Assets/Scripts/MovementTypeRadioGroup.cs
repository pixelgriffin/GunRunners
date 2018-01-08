using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeRadioGroup : MonoBehaviour {

    public int selectedGrid = 0;
    public string[] strings = new string[] { "Jogging", "Linear", "Teleporting" };

    private void OnGUI()
    {
        GUILayout.BeginVertical("Box");
        selectedGrid = GUILayout.SelectionGrid(selectedGrid, strings, 1);
        GUILayout.EndVertical();
    }
}
