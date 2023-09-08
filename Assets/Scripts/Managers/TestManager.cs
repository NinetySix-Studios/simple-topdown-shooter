using System.Collections;
using System.Collections.Generic;
using Collections;
using Project.Services;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // var sampleScriptableObject = Game.Services.Get<SampleScriptableObject>();
        // Debug.Log(sampleScriptableObject.intVariable);

        Debug.Log(SampleScriptableObject.Services.intVariable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
