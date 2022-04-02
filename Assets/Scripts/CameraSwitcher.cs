using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public static class CameraSwitcher
{
    private static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera activeCamera = null;

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        activeCamera = camera;

        foreach(var cam in cameras)
            if(cam != camera) cam.Priority = 0;
    }

    public static bool isActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == activeCamera;
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}
