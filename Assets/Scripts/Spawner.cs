using System.Collections;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private TextMeshProUGUI waveText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for (int n = 0; n < 5; n++)
        {   
            for (int i = 0; i < 3; i++)
            {
                waveText.text = "Level" + "" + (n + 1)  + "-" + "Wave" + "" + (i + 1);
                yield return new WaitForSeconds(2.0f);
                waveText.text = "";
                for (int j = 0; j < 10; j++)
                {
                    Vector3 spawnPoint = new Vector3(transform.position.x, Random.Range(-4.60f, 4.60f),0);
                    Instantiate(enemy, spawnPoint, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(3f);
        }
        
    }
}
