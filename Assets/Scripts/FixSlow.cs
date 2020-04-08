using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEditor.EditorPrefs.SetBool("DeveloperMode", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
