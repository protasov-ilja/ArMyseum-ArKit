using UnityEngine;

namespace ARMuseum.ImagesTracking
{
    [CreateAssetMenu(fileName = "ARMuseum/NewImagesData", menuName = "ImagesData")]
    public class ImageData : ScriptableObject
    {
        public ImageTrackingPrefab prefab;
        [TextArea] public string textInfo;
        public AudioClip clip;
    }
}