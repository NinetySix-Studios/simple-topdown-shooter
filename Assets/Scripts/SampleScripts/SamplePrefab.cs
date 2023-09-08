using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Services;

public class SamplePrefab : MonoBehaviour
{
    public static SamplePrefab Services { get { if (_samplePrefab == null) _samplePrefab = Game.Services.Get<SamplePrefab>(); return _samplePrefab; } }
    private static SamplePrefab _samplePrefab;
    
    public void SampleMethod()
    {
        Debug.Log("Sample Bind: Game Binding is working!");
    }
}
