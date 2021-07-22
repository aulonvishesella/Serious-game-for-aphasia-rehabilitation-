using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*

This class lets us control the data of a waypoint to an objective, that will be used by the WaypointController class.

A waypoint will have reference to a UI image(this image will be an arrow/marker for visual aid so the user knows where the target is) as well as a reference to the position
of the target.

*/

//System.Serializable will allow the members of our custom class,WaypointModel, to appear in the inpsector
[System.Serializable]
public class WaypointModel
{
    public Transform target;
    public Image img;
}
