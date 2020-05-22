using System;
using UnityEngine;

namespace ARMuseum.Utils
{
    public class NavigationTriggerTest : MonoBehaviour
    {
        public GameObject NavigationArrow { get; set; }

        public void OnDestroy()
        {
            if (NavigationArrow != null)
            {
                Destroy(NavigationArrow); 
            }
        }
    }
}