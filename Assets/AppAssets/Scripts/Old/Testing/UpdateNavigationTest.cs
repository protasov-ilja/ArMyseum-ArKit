﻿using UnityEngine;

namespace ARMuseum.Utils
{
    public class UpdateNavigationTest : MonoBehaviour
    {
        public GameObject trigger; // collider to change arrows
        public GameObject indicator; // arrow prefab to spawn
        public GameObject arCoreDeviceCam; // ar camera
        public GameObject arrowHelper; // box facing the arrow of person indicator used to calculate spawned AR arrow direction
        public LineRenderer line; // line renderer used to calculate spawned ARarrow direction
        
        //private Anchor _anchor; //spawned anchor when putting somthing AR on screen
        private bool _hasEntered; //used for onenter collider, make sure it happens only once
        private bool _hasExited; //used for onexit collider, make sure it happens only once

        private void Start()
        {
            _hasEntered = false;
            _hasExited = false;
        }

        private void Update()
        {
            _hasEntered = false;
            _hasExited = false;
        }

        // what to do when entering a collider
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
            // if it is a navTrigger then calculate angle and spawn a new AR arrow
            if (other.name.Equals("NavTriggerTest(Clone)") && line.positionCount > 0)
            {
                if (_hasEntered)
                {
                    return;
                }
                
                _hasEntered = true;

                //logic to calculate arrow angle
                Vector2 personPos = new Vector2(transform.position.x, 
                         transform.position.z);
                Vector2 personHelp = new Vector2(arrowHelper.transform.position.x, 
                         arrowHelper.transform.position.z);
                Vector3 node3D = line.GetPosition(1);
                Vector2 node2D = new Vector2(node3D.x, node3D.z);

                float angle = Mathf.Rad2Deg * (Mathf.Atan2(personHelp.y - personPos.y, 
                         personHelp.x - personPos.x) - Mathf.Atan2(node2D.y - personPos.y, 
                         node2D.x - personPos.x));

                // position arrow a bit before the camera and a bit lower
                Vector3 pos = arrowHelper.transform.position +
                              arrowHelper.transform.up * -0.5f;

                // rotate arrow a bit
                Quaternion rot = arCoreDeviceCam.transform.rotation * 
                         Quaternion.Euler(20, 180, 0);

                // create new anchor
                //_anchor = Session.CreateAnchor(new Pose(pos, rot));

                //spawn arrow
                GameObject spawned = Instantiate(indicator, 
                    pos, rot);

                // use calculated angle on spawned arrow
                spawned.transform.Rotate(0, angle, 0, Space.Self);
                var connectedTrigger = other.gameObject.GetComponent<NavigationTriggerTest>(); // move script on NavTrigger prefab before start
                connectedTrigger.NavigationArrow = spawned;
                
                Debug.Log($"arrow spawned { spawned.transform.rotation }");
            }
        }

        //what to do when exiting a collider
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("OnTriggerExit");
            //if it is a navTrigger then delete Anchor and arrow and create a new trigger
            if (other.name.Equals("NavTriggerTest(Clone)"))
            {
                if (_hasExited)
                {
                    return;
                }
                
                _hasExited = true;
                Destroy(other.gameObject);

                Instantiate(trigger, transform.position, transform.rotation);
            }
        }
    }
}