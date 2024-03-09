using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] List<BoxCollider> spawnZones;
    [SerializeField] List<float> weights;
    [SerializeField] float portalMargin;
    [SerializeField] float terrainMargin;
    [SerializeField] float spawnFrequency;
    [SerializeField] int spawnBurstNumber = 1;
    [SerializeField] int startBurstNumber = 10;
    [SerializeField] GameObject portalPrefab;
    [SerializeField] bool spawn = false;

    //have bounds for spawn areas, maybe cubes? - list
    //random rate of spawn - time frequency based? and capped by a max?
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

    private void Start()
    {
        GameObject [] spawnParents = GameObject.FindGameObjectsWithTag("SpawnZone");
        for (int i = 0; i< spawnParents.Length; i++)
        {
            spawnZones.Add(spawnParents[i].GetComponentInChildren<BoxCollider>());
            spawnParents[i].GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        CalculateWeights();
        SpawnPortal(startBurstNumber);
    }

    public void FixedUpdate()
    {
        if(spawn == true)
        {
            spawn = false;
            SpawnPortal(spawnBurstNumber);
        }
    }
    void CalculateWeights()
    {
        float sum = 0;
        weights = new List<float>();

        for(int i = 0; i < spawnZones.Count; i++) 
        {
            float weightMultiplier = 1;
            if (spawnZones[i].gameObject.GetComponent<SpawnProperties>() != null)
            {
                weightMultiplier = spawnZones[i].gameObject.GetComponent<SpawnProperties>().GetWeight(); // if there are exceptional weight multipliers
            }
            weights.Add(spawnZones[i].bounds.size.x * spawnZones[i].bounds.size.y * spawnZones[i].bounds.size.z * weightMultiplier); //populating the weight array
            sum += weights[i]; //creating the total sum of the weights
        }

        float cumulative = 0;

        for(int i = 0; i < spawnZones.Count; i++) 
        {
            weights[i] *= (1 / sum); //normalizing the weights to a value between 0 and 1
            cumulative += weights[i];
            weights[i] = cumulative; //weight entries become cumulative sum entries
        }

    }

    void SpawnPortal(int amount)
    {
        for (int i = 0; i < amount; i++) //for each portal
        {
            float probability = Random.value;
            int spawnZoneNumber=0;
            for (int j = 0; j < weights.Count; j++) { //choosing the spawn zone we will be spawning in
                if(weights[j] > probability) //check against cumulative sum of weights
                {
                    spawnZoneNumber = j;
                    break;
                }
            }
            BoxCollider zone = spawnZones[spawnZoneNumber];
            bool found = false;
            Vector3 xyz = new Vector3();
        
            while (found == false)
            {
                found = true;
                xyz = ChooseCoordinates(zone);
                Collider[] hitColliders = Physics.OverlapSphere(xyz, portalMargin);
                foreach (var hitCollider in hitColliders) //checking for nearby portals
                {
                    if (hitCollider.gameObject.tag == "Portal" || hitCollider.gameObject.tag == "End" || hitCollider.gameObject.tag == "Opening")
                    {
                        found = false; //invalid area, keep looking
                    }
                }
            }
            Instantiate(portalPrefab, xyz, Quaternion.Euler(Random.Range(25f, 25f), Random.Range(-180f, 180f), Random.Range(-25, 25)));
        }
    }

    Vector3 ChooseCoordinates(BoxCollider zone)
    {
        return new Vector3(
                        Random.Range(zone.bounds.min.x, zone.bounds.max.x),
                        Random.Range(zone.bounds.min.y, zone.bounds.max.y),
                        Random.Range(zone.bounds.min.z, zone.bounds.max.z)
                   );
    }
}
