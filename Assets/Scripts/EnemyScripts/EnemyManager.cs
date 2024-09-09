using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    public string CliffHanger;

    void Update()
    {
        // Check if there are any active enemies with the "EnemyArmed" tag
        enemies = GameObject.FindGameObjectsWithTag("EnemyArmed");
        if (enemies.Length == 0)
        {
            // Load the next scene
            SceneManager.LoadScene(CliffHanger);
        }
    }
}

