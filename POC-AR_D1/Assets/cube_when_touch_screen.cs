using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class cube_when_touch_screen : MonoBehaviour
{
    public GameObject Cube;
    public ARRaycastManager Rayon;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase != TouchPhase.Began) {
            return;
        }

        List<ARRaycastHit> touch = new List<ARRaycastHit>();
        Rayon.Raycast(Input.GetTouch(0).position, touch, UnityEngine.XR.ARSubsystems.TrackableType.Planes);        
        if (touch.Count > 0)
        {
            GameObject.Instantiate(Cube, touch[0].pose.position, touch[0].pose.rotation);
        }
    }
}
