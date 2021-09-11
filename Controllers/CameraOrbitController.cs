using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//[RequireComponent(typeof(Camera))]
public class CameraOrbitController : MonoBehaviour
{
    #region ===== Variables =====

    #region dependencies
    private PlayerCameraInput playerCameraInput;
    #endregion

    #region exposed
    [SerializeField]
    Transform target = null;

    [SerializeField]
    Transform orbiter_horizontal = null;

    [SerializeField]
    Transform orbiter_vertical = null;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float smoothTime = 0.5f;

    [SerializeField]
    private Vector2 verticalRange = new Vector2(-90f, 90f);
    #endregion

    private Vector3 curSpeed;
    #endregion


    private void Start()
    {
        playerCameraInput = PlayerCameraInput.Instance;
    }

    private void LateUpdate()
    {
        transform.LookAt(target);

        // Gradually refresh curSpeed when holding mouse button;
        if (Input.GetMouseButton(0))
        {
            Vector2 axis_input = playerCameraInput.GetAxisInput();

            Vector3 _targetSpeed = new Vector3(speed * axis_input.y, speed * axis_input.x, 0f);

            DOTween.To(() => curSpeed.y,
                x => curSpeed.y = x,
                _targetSpeed.y, smoothTime);

            DOTween.To(() => curSpeed.x,
                x => curSpeed.x = x,
                _targetSpeed.x, smoothTime);
        }

        // Rotate and gradually decrease curSpeed while curSpeed is above a threshold;
        orbiter_horizontal.Rotate(new Vector3(0f, curSpeed.y, 0f));
        orbiter_vertical.Rotate(new Vector3(curSpeed.x, 0f, 0f));

        DOTween.To(() => curSpeed.y,
            x => curSpeed.y = x,
            0f, smoothTime);
        DOTween.To(() => curSpeed.x,
            x => curSpeed.x = x,
            0f, smoothTime);


        // Clamp vertical rotation;
    }

}
