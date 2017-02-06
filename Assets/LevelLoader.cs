using UnityEngine;
using System.Collections;

[System.Serializable]
public class ColorToPrefab {
    public Color32 color;
    public GameObject prefab;
}

public class LevelLoader : MonoBehaviour {

    public Texture2D levelMap;

    public ColorToPrefab[] colorToPrefab;

	// Use this for initialization
	void Awake () {
        if (levelMap != null)
        {
            LoadMap();
        }
	}

    void EmptyMap() {
        while (transform.childCount > 0) {
            Transform c = transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }
    }

    void LoadMap() {
        EmptyMap();

        Color32[] allPixels = levelMap.GetPixels32();
        int width = levelMap.width;
        int height = levelMap.height;

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {

                SpawnTileAt(allPixels[(y * width) + x], x, y);

            }
        }
    }

    void SpawnTileAt(Color32 c, int x, int y) {

        if (c.a <= 0) {
            return;
        }

        foreach(ColorToPrefab ctp in colorToPrefab) {
            if (c.Equals(ctp.color)) {
                GameObject go = (GameObject)Instantiate(ctp.prefab, new Vector3(x/2f -2.5f, y/2f -3.5f, 0), Quaternion.identity);
                return;
            }
        }
        Debug.LogError("No color to prefab found for : " + c.ToString());
    }
}
