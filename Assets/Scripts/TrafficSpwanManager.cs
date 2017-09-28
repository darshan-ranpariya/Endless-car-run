using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpwanManager : MonoBehaviour
{
    public GameObject carPlayer;
    public GameObject[] trafficCars;
    public List<GameObject> currentTrafficList;
    public FuelGanerator fuelGanerator;
    public BoosterGanerator boosterGanerator;

    private Vector3 newPos;

    private void Start()
    {
        carPlayer = FindObjectOfType<CarMoveManager>().gameObject;
        currentTrafficList = new List<GameObject>();
        newPos = Vector3.zero;
        StartCoroutine(coinSpwner());
        StartCoroutine(fuelSpwner());
        StartCoroutine(boosterSpwner());
    }

    private IEnumerator boosterSpwner()
    {
        while (true)
        {
            int xPos = Random.Range(-4, 4);
            if (xPos % 2 != 0)
            {
                xPos += 1;
            }
            newPos.x = xPos;
            newPos.y = 0.8f;
            newPos.z = carPlayer.transform.position.z + Random.Range(40, 75);
            boosterGanerator.spwanBooster(newPos);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }        
    }

    private IEnumerator coinSpwner()
    {
        while (true)
        {
            int xPos = Random.Range(-4, 4);
            if (xPos % 2 != 0)
            {
                xPos += 1;
            }
            newPos.x = xPos;
            newPos.y = 0.8f;
            newPos.z = carPlayer.transform.position.z + Random.Range(40, 75);
            GetComponent<CoinGenerator>().spwanCoins(newPos, Random.Range(3, 8));
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

    private IEnumerator fuelSpwner()
    {
        while (true)
        {
            int xPos = Random.Range(-4, 4);
            if (xPos % 2 != 0)
            {
                xPos += 1;
            }
            newPos.x = xPos;
            newPos.y = 0.5f;
            newPos.z = carPlayer.transform.position.z + Random.Range(40, 75);
            fuelGanerator.spwanFuel(newPos);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        ganerateTraffic();
    }

    private void ganerateTraffic()
    {
        if (currentTrafficList.Count < 5)
        {
            int xPos = Random.Range(-4, 4);
            if (xPos % 2 != 0)
            {
                xPos += 1;
            }
            newPos.x = xPos;
            newPos.y = 0.21f;
            newPos.z = carPlayer.transform.position.z + Random.Range(40, 75);
            GameObject inst = Instantiate(trafficCars[Random.Range(0, trafficCars.Length)],
                newPos, Quaternion.identity);
            currentTrafficList.Add(inst);
        }
    }
}
