using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint[] checkpoints;

    private void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>();
    }
    
    //every t is a checkpoint in the array
    public Checkpoint GetLastCheckpointThatWasPassed()
    {
        return checkpoints.Last(t => t.Passed);
    }
}
