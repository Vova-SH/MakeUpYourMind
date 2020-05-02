using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectScript : MonoBehaviour
{
    public LevelSettings levelSetting;
    private void OnStart()
    {
        levelSetting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelSettings>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerScript>();
        if (player != null)
        {
            levelSetting.AddObject();
            Destroy(gameObject);
        }
    }
}
