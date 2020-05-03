using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectScript : MonoBehaviour
{
    private LevelSettings levelSetting;
    private void Start()
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
