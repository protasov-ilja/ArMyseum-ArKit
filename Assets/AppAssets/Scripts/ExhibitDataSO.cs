using UnityEngine;
using UnityEngine.UI;

namespace AppAssets.Scripts
{
    [CreateAssetMenu(fileName = "NewExhibitData", menuName = "ARMuseum/ExhibitData", order = 0)]
    public class ExhibitDataSO : ScriptableObject
    {
        [SerializeField] private string _exhibitName;
        [SerializeField] private Image[] _images;
        [SerializeField] private string _description;
        [SerializeField] private string _hallName;
        [SerializeField] private AudioClip _audioGuid;
        [SerializeField] private GameObject _prefab3DObject;

        public bool Has3dObject => _prefab3DObject != null;
    }
}