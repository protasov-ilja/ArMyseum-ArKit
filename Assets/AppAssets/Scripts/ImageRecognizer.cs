using System;
using UnityEngine;

namespace ARMuseum
{
    public class ImageRecognizer : MonoBehaviour
    {
        //        public Texture2D  _texture;
       public bool SearchingForMarker = true;
       public GameObject UserPosition;
       public Transform[] QRCodePrefabsLocations;

//        public void Awake()
//        {
//            Debug.Log("ImageRecognitionTest!!!");
//            
//            // create a barcode reader instance
//            IBarcodeReader reader = new BarcodeReader();
//            // get texture Color32 array
//            var barcodeBitmap = _texture.GetPixels32();
//            // detect and decode the barcode inside the Color32 array
//            var result = reader.Decode(barcodeBitmap, _texture.width, _texture.height);
//            // do something with the result
//            if (result != null)
//            {
//                Debug.Log(result.BarcodeFormat.ToString());
//                Debug.Log(result.Text);
//            }
//        }

        public void Update()
        {
            if (!SearchingForMarker)
            {
                Repositioning();
            }
        }

        // is used at start of application to set initial position
        public bool StartPosition(WebCamTexture wt) 
        {
            bool succeeded = false;

            try
            {
                // IBarcodeReader barcodeReader = new BarcodeReader();
                // // decode the current frame
                // var result = barcodeReader.Decode(wt.GetPixels32(), wt.width, wt.height);
                // if (result != null)
                // {
                //     Debug.Log("StartPosition!");
                //     Relocate(result.Text);
                //     succeeded = true;
                // }
            }
            catch (Exception ex)
            {
                Debug.LogWarning("Warning!: " + ex.Message);
            }
            
            return succeeded;
        }

        // move to person indicator to the new spot
        private void Relocate(string text)
        {
            Debug.Log("Relocate!");
            text = text.Trim(); //remove spaces
            // find the correct location scanned and move the person to its position
            var userRotationEuler = UserPosition.transform.rotation.eulerAngles;
            foreach (var location in QRCodePrefabsLocations)
            {
                if (location.name.Equals(text))
                {
                    Debug.Log($"text: { text }, Location: { location.name }");
                    UserPosition.transform.position = new Vector3(location.position.x, 
                        UserPosition.transform.position.y, location.position.z);

                    break;
                }
            }
            
            SearchingForMarker = false;
        }
        
        public void Repositioning()
        {
            byte[] imageByteArray = null;
            int width;
            int height;
            
            // using (var imageBytes = Frame.CameraImage.AcquireCameraImageBytes())
            // {
            //     if (!imageBytes.IsAvailable)
            //     {
            //         return;
            //     }
            //     
            //     int bufferSize = imageBytes.YRowStride * imageBytes.Height;
            //     imageByteArray = new byte[bufferSize];
            //     Marshal.Copy(imageBytes.Y, imageByteArray, 0, bufferSize);
            //     width = imageBytes.Width;
            //     height = imageBytes.Height;
            // }
            //
            // try
            // {
            //     IBarcodeReader barcodeReader = new BarcodeReader();
            //     var result = barcodeReader.Decode(imageByteArray, width, height,
            //         RGBLuminanceSource.BitmapFormat.Gray8);
            //     
            //     if (result != null)
            //     {
            //         Debug.Log("StartPosition!");
            //         Relocate(result.Text);
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Debug.LogWarning("Warning!: " + ex.Message);
            // }
        }
        
    }
}