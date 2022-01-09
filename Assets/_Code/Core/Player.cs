using TutanDev.References;
using UnityEngine;

namespace TutanDev.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float speed = 1.0f;
        [SerializeField] float rotationSpeed = 1.0f;
        [SerializeField] float angleLimit = 45.0f;

        [SerializeField] BoolReference flyInput;

        Transform myTransform;
        Transform graphics;

        private void Awake()
        {
            myTransform = transform;
            graphics = myTransform.GetChild(0);
        }

        private void Update()
        {
            MoveVertically();
            RotateBaseOnInput();
        }

        void MoveVertically()
        {
            myTransform.position = Vector3.ProjectOnPlane(myTransform.position + myTransform.right * (speed * Time.deltaTime), Vector3.right);
        }

        void RotateBaseOnInput()
        {


            float targetAngle = flyInput.value ? rotationSpeed : -rotationSpeed;
            targetAngle *= Time.deltaTime;
            targetAngle += myTransform.eulerAngles.z;
            targetAngle = ClampAngle(targetAngle, -angleLimit, angleLimit);
            Vector3 targetEulerRotation = Vector3.forward * targetAngle;
            //if (targetEulerRotation.z > 45) targetEulerRotation.z = 45;
            //else if (targetEulerRotation.z < 315) targetEulerRotation.z = 315;
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.Euler(targetEulerRotation), 0.8f);
        }

        float ClampAngle(float angle, float from, float to)
        {
            if (angle < 0f) angle = 360 + angle;
            if (angle > 180f) return Mathf.Max(angle, 360 + from);
            return Mathf.Min(angle, to);
        }
    }
}