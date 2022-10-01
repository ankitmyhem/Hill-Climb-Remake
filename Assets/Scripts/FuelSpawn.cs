using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawn : MonoBehaviour
{

    public GameObject fuelContainer;
    public EdgeCollider2D track;
    public float spawnDistance;
    public Transform car;
    Transform m_referenceFuel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn(track, car);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 3)
        {
            Spawn(track, m_referenceFuel);
        }
        
        if(transform.GetChild(0).transform.position.x < car.position.x - spawnDistance)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

    }

    void Spawn(EdgeCollider2D edgeCollider2D, Transform reference)
    {
        float heightFromTrack = 1;

        Vector2 nextFuelDistance = new Vector2(reference.position.x + spawnDistance, reference.position.y);
        Vector2 nextFuelPoint = edgeCollider2D.ClosestPoint(nextFuelDistance);

        GameObject newFuel = Instantiate(fuelContainer, new Vector3(nextFuelPoint.x, nextFuelPoint.y + heightFromTrack, 0), Quaternion.identity);
        newFuel.transform.parent = this.transform;
        m_referenceFuel = newFuel.transform;
    }
    
}
