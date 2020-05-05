using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace ARMuseum.ARObjectTracking
{
    public class ARObjectsTrackingSystem : MonoBehaviour
    {
        [SerializeField] private ARTrackedObjectManager _trackedObjectManager;

        [SerializeField] private TMP_Text _imageNameText;

        [SerializeField] private GameObject[] _arObjectsToPlace;
        
        private Dictionary<string, GameObject> _arObjects = new Dictionary<string, GameObject>();

        private void Awake()
        {
            foreach (var arObject in _arObjectsToPlace)
            {
                var newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
                newARObject.name = arObject.name;
                _arObjects.Add(arObject.name, newARObject);
            }
        }

        private void OnEnable()
        {
            _trackedObjectManager.trackedObjectsChanged += OnTrackedObjectsChanged;
        }
        
        private void OnDisable()
        {
            _trackedObjectManager.trackedObjectsChanged -= OnTrackedObjectsChanged;
        }

        private void OnTrackedObjectsChanged(ARTrackedObjectsChangedEventArgs args)
        {
            foreach (var trackedObject in args.added)
            {
                UpdateARImage(trackedObject);
            }
            
            foreach (var trackedObject in args.updated)
            {
                UpdateARImage(trackedObject);
            }
            
            foreach (var trackedObject in args.removed)
            {
                _arObjects[trackedObject.name].SetActive(false);
            }
        }

        private void UpdateARImage(ARTrackedObject trackedObject)
        {
            _imageNameText.text = trackedObject.referenceObject.name;

            AssignGameObject(trackedObject.referenceObject.name, trackedObject.transform.position);
            
            Debug.Log($"tracked image reference name: { trackedObject.referenceObject.name }");
        }

        private void AssignGameObject(string referenceObjectName, Vector3 newPosition)
        {
            if (_arObjectsToPlace != null)
            {
                _arObjects[referenceObjectName].SetActive(true);
                _arObjects[referenceObjectName].transform.position = newPosition;
                _arObjects[referenceObjectName].transform.localScale = Vector3.one;

                foreach (var gO in _arObjects.Values)
                {
                    Debug.Log($"GameObject in arObjects.Values: { gO.name }");
                    if (gO.name != referenceObjectName)
                    {
                        gO.SetActive(false);
                    }
                }
            }
        }
    }
}