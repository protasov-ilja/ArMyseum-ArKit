using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace ARMuseum.Utils
{
    public class NavigationTest : MonoBehaviour
    {
        public GameObject trigger; // trigger to spawn and despawn AR arrows
        public Transform[] destinations; // list of destination positions
        public GameObject person; // person indicator

        [SerializeField]
        private LineRenderer _line; // line renderer to display path
        
        private Transform _target; // current chosen destination
        private NavMeshPath _path; // current calculated path
        private bool _destinationSet; // bool to say if a destination is set

        public NavMeshSurface _surface;
        
        //create initial path, get linerenderer.
        private void Start()
        {
            _path = new NavMeshPath();
            _destinationSet = false;
        }

        private void Update()
        {
            //if a target is set, calculate and update path
            if (_target != null)
            {
                Debug.Log("Calculating path!");
                var isFound = NavMesh.CalculatePath(person.transform.position, _target.position, 
                    NavMesh.AllAreas, _path);
                
                //lost path due to standing above obstacle (drift)
                if(!isFound)
                {
                    Debug.Log("Try moving away for obstacles (optionally recalibrate)");
                }
                
                _line.positionCount = _path.corners.Length;
                _line.SetPositions(_path.corners);
                _line.enabled = true;
            }
        }

        //set current destination and create a trigger for showing AR arrows
        public void SetDestination(string destination)
        {
            var destinationName = destination;
            Debug.Log($"NavigationControllerFound! { destinationName }");
            var targetTransform = destinations.Where(d => d.gameObject.name == destinationName).ToList();
            
            var prevTrigger = GameObject.Find("NavTriggerTest(Clone)");
            if (prevTrigger != null)
            {
                Destroy(prevTrigger);
            }
            
            _target = targetTransform[0];
            Instantiate(trigger, person.transform.position, person.transform.rotation);
            
            _destinationSet = true;
            
            _surface.BuildNavMesh();
        }
    }
}