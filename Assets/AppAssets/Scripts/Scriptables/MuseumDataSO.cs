using UnityEngine;

namespace ARMuseum.Scriptables
{
    [CreateAssetMenu(fileName = "NewMuseumData", menuName = "ARMuseum/MuseumData", order = 0)]
    public class MuseumDataSO : ScriptableObject
    {
        [SerializeField] private string _museumName;
        [SerializeField] private string _museumDescription;
        [SerializeField] private Sprite _museumImage;
        [SerializeField] private GameObject _navigationMapData;
        [SerializeField] private ExhibitDataSO[] _exhibits;
    }
}