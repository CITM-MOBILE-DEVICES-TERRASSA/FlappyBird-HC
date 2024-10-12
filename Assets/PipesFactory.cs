using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesFactory : MonoBehaviour
{
    [SerializeField] private GameObject basicPipePrefab;
    [SerializeField] private GameObject movingPipePrefab;
    [SerializeField] private GameObject doublePipePrefab;

    public enum PipeType
    {
        Basic,
        Moving,
        Double
    }

    public GameObject CreatePipe(PipeType pipeType)
    {
        GameObject pipe = null;
        switch(pipeType)
        {
            case PipeType.Basic:
                pipe = Instantiate(basicPipePrefab, transform);
            break;
            case PipeType.Moving:
                pipe = Instantiate(movingPipePrefab, transform);
            break;
            case PipeType.Double:
                pipe = Instantiate(doublePipePrefab, transform);
            break;
        }
        return pipe;
    }
}
