using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject levelGenerator;
    private float spacing;

    public float bpm;
    private float bps;

    public bool hasStarted;

    public AudioSource song;

    private void Start()
    {
        bps = bpm / 60;
        spacing = levelGenerator.GetComponent<LevelGeneration>().gridSpacing;
    }

    private void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
                song.Play();
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, (bps + spacing) * Time.deltaTime);
        }
    }
}
