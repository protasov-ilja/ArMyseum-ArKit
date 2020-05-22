using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARMuseum.ImagesTracking
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}