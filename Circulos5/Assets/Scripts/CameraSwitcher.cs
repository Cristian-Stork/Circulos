using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;

public class CameraSwitcher : MonoBehaviour
{
    public static CameraSwitcher instace;

    public List<CinemachineCamera> allCameras;

    private void Awake()
    {
        instace = this;
    }

    public void SwitchToCamera(CinemachineCamera newCam)
    {
        foreach (var cam in allCameras)
        {
            cam.gameObject.SetActive(false);
        }

        newCam.gameObject.SetActive(true);
    }
}
