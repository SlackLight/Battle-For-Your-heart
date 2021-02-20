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
    public float bpm;

    public Vector3 currentPosition;

    Grid grid;

    private void Start()
    {
        grid = this.GetComponent<Grid>();
    }

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
