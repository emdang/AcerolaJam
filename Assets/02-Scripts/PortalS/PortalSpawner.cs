using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    //have bounds for spawn areas, maybe cubes? - list
    //random rate of spawn - time frequency based?
    //burst spawn at the beginning of the level, maybe in a certain area
    //list of portals already in scene
    
    //when it is time
    //for each spawn area generate a random position
    //pick random position
    //generate list of all portals
    //if position close to an existing portal choose the next position; maybe move portal spawner physically and spherecast for tagged portals?
    //could potentially spherecast for terrain proximity as well
    //if all positions are invalid generate more positions
    //spawn portal at current position
}
