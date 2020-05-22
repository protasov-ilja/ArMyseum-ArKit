using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.XR.ARFoundation;

namespace ARMuseum.ImagesTracking
{
    /// <summary>
    /// Controller for AugmentedImage example.
    /// </summary>
    /// <remarks>
    /// In this sample, we assume all images are static or moving slowly with
    /// a large occupation of the screen. If the target is actively moving,
    /// we recommend to check <see cref="AugmentedImage.TrackingMethod"/> and
    /// render only when the tracking method equals to
    /// <see cref="AugmentedImageTrackingMethod"/>.<c>FullTracking</c>.
    /// See details in <a href="https://developers.google.com/ar/develop/c/augmented-images/">
    /// Recognize and Augment Images</a>
    /// </remarks>
    public class ARImagesController : SerializedMonoBehaviour
    {
        /// <summary>
        /// A prefab for visualizing an AugmentedImage.
        /// </summary>
        public Dictionary<string, ImageData> ARImageTrackingPrefabs = new Dictionary<string, ImageData>();

        /// <summary>
        /// The overlay containing the fit to scan user guide.
        /// </summary>
        public GameObject FitToScanOverlay;

        [Header("InterfaceReferences")] 
        public GameObject userInterface;
        public TextMeshProUGUI textInfo;
        public AudioSource audioSource;

        private Dictionary<int, ImageTrackingPrefab> m_Visualizers
            = new Dictionary<int, ImageTrackingPrefab>();

        private List<ARTrackedImage> m_TempAugmentedImages = new List<ARTrackedImage>();

        /// <summary>
        /// The Unity Awake() method.
        /// </summary>
        public void Awake()
        {
            // Enable ARCore to target 60fps camera capture frame rate on supported devices.
            // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
            Application.targetFrameRate = 60;
        }

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // // Get updated augmented images for this frame.
                            // Session.GetTrackables<AugmentedImage>(
                            //     m_TempAugmentedImages, TrackableQueryFilter.Updated);
                            //
                            // // Create visualizers and anchors for updated augmented images that are tracking and do
                            // // not previously have a visualizer. Remove visualizers for stopped images.
                            // foreach (var image in m_TempAugmentedImages)
                            // {
                            //     ImageTrackingPrefab visualizer = null;
                            //     m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
                            //     if (image.TrackingState == TrackingState.Tracking && visualizer == null)
                            //     {
                            //         // Create an anchor to ensure that ARCore keeps tracking this augmented image.
                            //         Anchor anchor = image.CreateAnchor(image.CenterPose);
                            //         Debug.Log($"imageName: { image.Name } Created!!!");
                            //         var imageData = ARImageTrackingPrefabs[image.Name];
                            //         visualizer = Instantiate(imageData.prefab, anchor.transform);
                            //         visualizer.Image = image;
                            //         m_Visualizers.Add(image.DatabaseIndex, visualizer);
                            //
                            //         textInfo.text = imageData.textInfo;
                            //         if (imageData.clip != null)
                            //         {
                            //             audioSource.clip = imageData.clip;
                            //         }
                            //     }
                            //     else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
                            //     {
                            //         Debug.Log($"deleted: { image.Name } Created!!!");
                            //         m_Visualizers.Remove(image.DatabaseIndex);
                            //         GameObject.Destroy(visualizer.gameObject);
                            //     }
                            // }

            // Show the fit-to-scan overlay if there are no images that are Tracking.
            // foreach (var visualizer in m_Visualizers.Values)
            // {
            //     if (visualizer.Image.trackingState == TrackingState.Tracking)
            //     {
            //         userInterface.SetActive(true);
            //         FitToScanOverlay.SetActive(false);
            //         return;
            //     }
            // }

            userInterface.SetActive(false);
            FitToScanOverlay.SetActive(true);
        }

        public void PlaySound()
        {
            if (audioSource.clip != null)
            {
                audioSource.Play();
                Debug.Log("SoundPlayed");
            }
        }

        public void StopSound()
        {
            if (audioSource.clip != null)
            {
                audioSource.Stop();
                Debug.Log("SoundStopped");
            }
        }
    }
}