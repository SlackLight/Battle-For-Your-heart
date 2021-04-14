using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingTest : Minigame
{

    bool resetting;

    public GameObject ItemSpawnLocation;

    public GameObject goalItemSquare;

    public GameObject placementSquares;

    public GameObject panelSpawnZone;

    public List<GameObject> spawnablePrefabs;

    public GameObject[] placedList = new GameObject[3];

    public static bool currentlyPressed;

    public override void Start()
    {
        placedList = new GameObject[3];
        base.Start();
        SpawnItems();
    }

    public override void Update()
    {
        base.Update();

        if (gameStillGoing)
        {
            MatchingMinigame();
        }
    }

    public void MatchingMinigame()
    {
        if (!resetting)
        {
            CheckFinished();
        }
        else if (resetting)
        {
            if (restartTimer <= 0)
            {
                //Disable the text
                successTextParent.SetActive(false);
                missTextParent.SetActive(false);
                //Runs clear unity event
                clear.Invoke();

                //Spawns a new set of items
                SpawnItems();

                //Sets it back to not resetting
                resetting = false;

                restartTimer = restartTimerValue;
            }
            else
            {
                restartTimer -= Time.deltaTime;
            }
        }

    }

    public void CheckFinished()
    {
        bool allFinished = true;

        //If all 3 squares true success
        foreach (Transform child in placementSquares.transform)
        {
            if (child.GetComponent<SquareStorage>().currentlyStored == null)
            {
                allFinished = false;
            }
        }

        if (allFinished)
        {
            int successNumber = 0;
            for (int i = 0; i < placedList.Length; i++)
            {
                //If this square is true increment success count
                if (placedList[i].GetComponent<ItemScript>().winItem)
                {
                    successNumber++;
                }

            }
            if (successNumber >= placedList.Length)
            {
                //Won
                scoreValue++;
                score.text = "Score : " + scoreValue;
                successTextParent.SetActive(true);
                scored.Invoke();
            }
            else
            {
                //Lost
                missTextParent.SetActive(true);
                //Runs everthing in miss unity event
                miss.Invoke();
            }
            resetting = true;

            //Empty the array
            for (int i = 0; i < placedList.Length; i++)
            {
                placedList[i] = null;
            }

            //Clears the old items
            if (ItemSpawnLocation.transform.childCount > 0)
            {
                foreach (Transform child in ItemSpawnLocation.transform)
                {
                    Destroy(child.gameObject);
                }
            }

            //Clears the old goal item
            if (goalItemSquare.transform.childCount > 0)
            {
                foreach (Transform child in goalItemSquare.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

    }

    public void SpawnItems()
    {

        int currentWinner = Random.Range(0, spawnablePrefabs.Count - 1);

        for (int i = 0; i < spawnablePrefabs.Count; i++)
        {
            GameObject currentSpawn;
            //If its making the winning combo spawn 3 and the guide square
            if (i == currentWinner)
            {
                for (int j = 0; j < 3; j++)
                {
                    currentSpawn = Instantiate(spawnablePrefabs[currentWinner], RandomPointInBounds(panelSpawnZone.GetComponent<BoxCollider2D>().bounds), Quaternion.identity, ItemSpawnLocation.transform);
                    currentSpawn.GetComponent<ItemScript>().winItem = true;
                }
                //Spawns the victory icon and disables its collider so it cant be dragged
                currentSpawn = Instantiate(spawnablePrefabs[currentWinner], goalItemSquare.transform.position, Quaternion.identity, goalItemSquare.transform);
                currentSpawn.transform.GetComponent<PolygonCollider2D>().enabled = false;
                currentSpawn.transform.localScale *= 100;
            }
            else
            {
                for (int k = 0; k < 2; k++)
                {
                    Instantiate(spawnablePrefabs[i], RandomPointInBounds(panelSpawnZone.GetComponent<BoxCollider2D>().bounds), Quaternion.identity, ItemSpawnLocation.transform);
                }
                
            }
        }

    }

    //Gets a random point inside a collider
    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3
            (
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            placementSquares.transform.position.z
            );
    }

}
