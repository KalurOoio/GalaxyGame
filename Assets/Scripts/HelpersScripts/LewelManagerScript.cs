using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LewelManagerScript : MonoBehaviour
{
    public GameObject playerShipOriginal;
    Vector3 startPlayerPosition = new Vector3(0, -3.5f, 0);

    public GameObject enemyGroupOriginal;
    public GameObject RamGroupOriginal;
    Vector3 startEnemyGroupPosition = new Vector3(0, 3.15f, 0);

    private BaseGroup currentGroup;
    private GroupType[] levelGroupTypes = { GroupType.ram };
    private int groupCount = 0;

    void Start()
    {
        GameObject newPlayerShip = Instantiate(playerShipOriginal);
        newPlayerShip.transform.position = startPlayerPosition;
        CreateNewGroup();
        groupCount++;
        
    }

    void Update()
    {
        if(currentGroup != null && currentGroup.isAlive == false) {
            if (groupCount == levelGroupTypes.Length) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
                Destroy(currentGroup.gameObject);
                CreateNewGroup();
                groupCount++;
            }
        }
    }

    void CreateNewGroup() 
    {
        GameObject newEnemyGroup = Instantiate(enemyGroupOriginal);
        newEnemyGroup.transform.position = startEnemyGroupPosition;
        currentGroup = newEnemyGroup.GetComponent<FirstGroup>();
    }
}
