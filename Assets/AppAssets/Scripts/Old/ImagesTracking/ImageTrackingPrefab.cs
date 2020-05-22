using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ARMuseum.ImagesTracking
{
    public class ImageTrackingPrefab : MonoBehaviour 
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public ARTrackedImage Image;

        public bool isCornersImage = false;
        
        
        /// <summary>
        /// A model for the lower left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameLowerLeft;

        /// <summary>
        /// A model for the lower right corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameLowerRight;

        /// <summary>
        /// A model for the upper left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameUpperLeft;

        /// <summary>
        /// A model for the upper right corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameUpperRight;
        
        /// <summary>
        /// A single model for visualization
        /// </summary>
        public GameObject ModelForVizualization;

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            // if (Image == null || Image.trackingState != TrackingState.Tracking)
            // {
            //     if (isCornersImage)
            //     {
            //         FrameLowerLeft.SetActive(false);
            //         FrameLowerRight.SetActive(false);
            //         FrameUpperLeft.SetActive(false);
            //         FrameUpperRight.SetActive(false);
            //     }
            //     else
            //     {
            //         ModelForVizualization.SetActive(false);
            //     }
            //     
            //     return;
            // }
            //
            // if (isCornersImage)
            // {
            //     float halfWidth = Image.extents.x / 2;
            //     float halfHeight = Image.extents.y / 2;
            //     FrameLowerLeft.transform.localPosition =
            //         (halfWidth * Vector3.left) + (halfHeight * Vector3.back);
            //     FrameLowerRight.transform.localPosition =
            //         (halfWidth * Vector3.right) + (halfHeight * Vector3.back);
            //     FrameUpperLeft.transform.localPosition =
            //         (halfWidth * Vector3.left) + (halfHeight * Vector3.forward);
            //     FrameUpperRight.transform.localPosition =
            //         (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);
            //
            //     FrameLowerLeft.SetActive(true);
            //     FrameLowerRight.SetActive(true);
            //     FrameUpperLeft.SetActive(true);
            //     FrameUpperRight.SetActive(true);
            // }
            // else
            // {
            //     ModelForVizualization.SetActive(true);
            // }
        }
    }
}