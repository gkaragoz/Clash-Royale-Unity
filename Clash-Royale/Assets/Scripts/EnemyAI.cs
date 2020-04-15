using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    bool some;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(DeployEnemy());
        }
    }

    IEnumerator DeployEnemy()
    {
        some = true;

        while (some)
        {
            Deploy();

            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }


    void Deploy()
    {
        GameObject enemy = ObjectPooler.instance.SpawnFromPool("Ingame_Enemy", new Vector3(Random.Range(3, 13), Random.Range(18, 28), 0), Quaternion.identity);
        enemy.SetActive(true);
    }
}
