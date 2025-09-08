using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Action OnChangePerspective;

    [SerializeField] private InputManager _inputManager;

    [SerializeField] public CameraState CameraState;
    [SerializeField] private CinemachineCamera _fpsCamera;
    [SerializeField] private CinemachineCamera _tpsCamera;


    private void Start()
    {
        _inputManager.OnChangePOV += SwitchCamera;
    }

    private void OnDestroy()
    {
        _inputManager.OnChangePOV -= SwitchCamera;
    }

    public void SetFPSClampedCamera(bool isClamped, Vector3 playerRotation)
    {
        CinemachinePanTilt pov = _fpsCamera.GetComponent<CinemachinePanTilt>();
        if (isClamped)
        {
            pov.PanAxis.Wrap = false;
            pov.PanAxis.Range = new Vector2(playerRotation.y - 45, playerRotation.y + 45);
        }
        else
        {
            pov.PanAxis.Range = new Vector2(-180, 180);
            pov.PanAxis.Wrap = true;
        }
    }

    private void SwitchCamera()
    {
        OnChangePerspective();
        if (CameraState == CameraState.ThirdPerson)
        {
            CameraState = CameraState.FirstPerson;
            _tpsCamera.gameObject.SetActive(false);
            _fpsCamera.gameObject.SetActive(true);
        }
        else
        {
            CameraState = CameraState.ThirdPerson;
            _tpsCamera.gameObject.SetActive(true);
            _fpsCamera.gameObject.SetActive(false);
        }
    }

    public void SetTPSFieldOfView(float fieldOfView)
    {
        _tpsCamera.Lens.FieldOfView = fieldOfView;
    }
}