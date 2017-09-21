using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {

    public GameObject basketPrefap;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	void Start () {
        basketList = new List<GameObject>();

		for (int i = 0; i <numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate(basketPrefap) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY = (basketSpacingY * i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
	}

    public void AppleDestroyed() {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {
            Application.LoadLevel("_Scene_0");
        }
    }
	
	void Update () {
		
	}
}
