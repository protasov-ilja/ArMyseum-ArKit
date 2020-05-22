// using GoogleARCore;
using UnityEngine;
using UnityEngine.UI;

namespace ARMuseum
{
    public class QRCodeScanner : MonoBehaviour
    {
        //public ARCoreSession ArCoreSession; // ARCore device gameobject

        public GameObject helpImage;
        
        private bool camAvailable; // bool used for seeing if rendering with camera is possible
        private WebCamTexture _cameraTexture; // used to obtain video from device camera
        private Texture defaultBackground; 

        public RawImage background; // where to render to
        public AspectRatioFitter fit; // fit rendered view to screen
        public ImageRecognizer ImageRecognizer; // object used to access method for setting location 

        //setup logic to capture camera video
        private void Start()
        {
            defaultBackground = background.texture;
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length == 0)
            {
                Debug.Log("No camera detected");
                camAvailable = false;
                
                return;
            }

            for (int i = 0; i < devices.Length; i++)
            {
                if (!devices[i].isFrontFacing)
                {
                    _cameraTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                }
            }

            if (_cameraTexture == null)
            {
                Debug.Log("unable to find backCam");
                
                return;
            }

            _cameraTexture.Play();
            background.texture = _cameraTexture;
            camAvailable = true;
        }

        //if camera setup render each frame the obtained images
        private void Update()
        {
            if (!camAvailable)
            {
                return;
            }
            
            float ratio = (float)_cameraTexture.width / (float)_cameraTexture.height;
            fit.aspectRatio = ratio;
            float scaleY = _cameraTexture.videoVerticallyMirrored ? -1f : 1f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
            int orient = -_cameraTexture.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
            
            bool result = ImageRecognizer.StartPosition(_cameraTexture);
            //if result found that close this view and start ar application
            if (result)
            {
                Debug.Log("QRCodeFound!!!!");
                //ArCoreSession.enabled = true;
                background.gameObject.SetActive(false);
                helpImage.SetActive(false);
                gameObject.SetActive(false);
            } 
        }
    }
}