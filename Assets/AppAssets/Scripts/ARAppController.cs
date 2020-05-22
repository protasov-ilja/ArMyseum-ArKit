//using GoogleARCore;
using UnityEngine;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
//using Input = GoogleARCore.InstantPreviewInput;
#endif
namespace ARMuseum
{
    /// <summary>
    /// Controls the HelloAR example.
    /// </summary>
    public class ARAppController : MonoBehaviour
    {
        /// <summary>
        /// places on FirstPersonCamera
        /// </summary>
        public ArrowDirection ArrowDirection;

        public Transform _cameraTransform;
        
        // user position
        public GameObject CameraTarget;
        
        [HideInInspector]
        public Vector3 PrevARPosePosition;
        
        private bool _isTracking = false;

        /// <summary>
        /// True if the app is in the process of quitting due to an ARCore connection error,
        /// otherwise false.
        /// </summary>
        private bool _isQuitting = false;
        
        public void Awake()
        {
            // Enable ARCore to target 60fps camera capture frame rate on supported devices.
            // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            //set initial position
            PrevARPosePosition = Vector3.zero;
        }
        
        public void Update()
        {
            // Move the person indicator according to position
            Vector3 currentARPosition = _cameraTransform.position;
            if (!_isTracking)
            {
                _isTracking = true;
                PrevARPosePosition = _cameraTransform.position;
            }
            
            // Remember the previous position so we can apply deltas
            Vector3 deltaPosition = currentARPosition - PrevARPosePosition;
            PrevARPosePosition = currentARPosition;
            if (CameraTarget != null)
            {
                // The initial forward vector of the sphere must be aligned with the initial camera direction in the XZ plane.
                // We apply translation only in the XZ plane.
                CameraTarget.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z);

                // Set the pose rotation to be used in the CameraFollow script
                // deprecated: FirstPersonCamera.GetComponent<ArrowDirection>().targetRot = Frame.Pose.rotation;
                // new:
                //Debug.Log($"Camera Direction { Frame.Pose.rotation.eulerAngles }");
                ArrowDirection.TargetRotation = _cameraTransform.rotation;
            }
        }
    }
}
  