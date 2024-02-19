using Unity.XR.PXR;
using UnityEngine;

public class OpenVST : MonoBehaviour
{
    // 开启透视
    void Awake()
    {
        PXR_MixedReality.EnableVideoSeeThrough(true);
    }

    // 应用恢复后，再次开启透视
    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            PXR_MixedReality.EnableVideoSeeThrough(true);
        }
    }
}