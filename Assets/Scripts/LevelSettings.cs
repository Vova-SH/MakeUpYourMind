using UnityEngine;
using UnityEngine.Events;

public class LevelSettings : MonoBehaviour
{
    public int objectCount = 5;
    public UnityEvent onCollectAll;
    private int objectCurrent = 0;

    public void AddObject()
    {
        objectCurrent++;
        if (objectCount <= objectCurrent)
        {
            onCollectAll.Invoke();
        }
    }
}
