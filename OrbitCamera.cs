using System;
using UnityEngine;

namespace TDLN.CameraControllers
{
    public class RTSCamera : MonoBehaviour
    {
        public GameObject target;
        public float distance = 5.0f;

        public float xSpeed = 200.0f;
        public float ySpeed = 200.0f;

        public float yMinLimit = -10.0f;
        public float yMaxLimit = 50.0f;

        float x = 0.0f;
        float y = 0.0f;

        void Start()
        {
            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        float prevDistance;

        void LateUpdate()
        {
            if (distance < 2) distance = 2;
            distance -= Input.GetAxis("Mouse ScrollWheel") * 2;
            if (target && (Input.GetMouseButton(1) || Input.GetMouseButton(2)))
            {
                var pos = Input.mousePosition;
                var dpiScale = 1f;
                if (Screen.dpi < 1) dpiScale = 1;
                if (Screen.dpi < 200) dpiScale = 1;
                else dpiScale = Screen.dpi / 200f;

                if (pos.x < 380 * dpiScale && Screen.height - pos.y < 250 * dpiScale) return;

                // comment out these two lines if you don't want to hide mouse curser or you have a UI button 
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);
                var rotation = Quaternion.Euler(y, x, 0);
                var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;
                transform.rotation = rotation;
                transform.position = position;

            }
            else
            {
                // comment out these two lines if you don't want to hide mouse curser or you have a UI button 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (Math.Abs(prevDistance - distance) > 0.001f)
            {
                prevDistance = distance;
                var rot = Quaternion.Euler(y, x, 0);
                var po = rot * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;
                transform.rotation = rot;
                transform.position = po;
            }
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}
