using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject linePrefab;
    public List<LineRenderer> lines;
    
    //How far appart you want?
    public float lineSpacing;
    //Local use variable
    private float currentSpacing;
    private GameObject currentLine;

    public Vector3 currentPosition;

    public GameObject gridNotes;

    //Stores right, down, up, left
    public List<GameObject> blockPrefabs;

    public int gridBeatNumber = 100;
    public int gridSpacing = 1;


    public void GenerateLines()
    {
        //Clears the list of lines
        lines.Clear();
        
        for (int i = 0; i < 4; i++)
        {
            lines.Add(Instantiate(linePrefab).GetComponent<LineRenderer>());
            
            //Spaces the lines
            if(i == 0)
            {
                currentSpacing = 3;
            }
            else if (i == 1)
            {
                currentSpacing = 1;
            }
            else if (i == 2)
            {
                currentSpacing = -1;
            }
            else if (i == 3)
            {
                currentSpacing = -3;
            }

            //Sets the first position of the line
            currentPosition = lines[i].GetPosition(0);
            lines[i].SetPosition(0, new Vector3(currentSpacing * lineSpacing, currentPosition.y, currentPosition.z));
            
            //Sets the second position of the line
            currentPosition = lines[i].GetPosition(1);
            lines[i].SetPosition(1, new Vector3(currentSpacing * lineSpacing, currentPosition.y, currentPosition.z));

        }
    }

    public void GenerateGrid()
    {
        //Checks that the lines have already been made
        if(lines.Count <= 3)
        {
            Debug.Log("Not enough lines generated");
        }
        else if(blockPrefabs.Count < 4)
        {
            Debug.Log("Not enough block prefabs");
        }
        //If they have then makes toggleable gameobjects at each beat point
        else
        {
            //For each line
            for (int i = 0; i < 4; i++)
            {
                //Sets the current position to the first position of the current line
                currentPosition = lines[i].GetPosition(0);
                
                //Instantiates all the beats blocks on that line
                for (int a = 0; a < gridBeatNumber; a++)
                {
                    Instantiate(blockPrefabs[i], currentPosition, Quaternion.identity, gridNotes.transform);
                    currentPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + gridSpacing);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //if(lines.Count > 0 && lines[0] != null)
        //{
        //    for (int i = 0; i < lines.Count; i++)
        //    {
        //        Gizmos.DrawRay(lines[i].GetPosition(0), Vector3.forward * 200);
        //    }
        //}
        
        

    }


}
