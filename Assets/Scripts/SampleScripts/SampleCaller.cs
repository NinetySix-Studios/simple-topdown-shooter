using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers;
using Project.Views;

public class SampleCaller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SampleManager.Services.SampleMethod();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            SamplePrefab.Services.SampleMethod();
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            ViewContainer.Services.OpenSampleView(new SampleView.SampleParams
            {
                Header = "Test View",
                Description = "This is a test description"
            });
        }
    }
}
