using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnglishKidsSpawn : MonoBehaviour
{
    public Image RobotComponent;
    public Camera MainCamera;
    //public Vector2[] SpawnCoords;

    private float[] _posX = new float[] { -140, 110 };
    private Sprite[] _componentSprites;
    private int _robotComponentsCount = 8;

    private void Start()
    {
        LoadSprite();
        SpawnRobotComponents();
    }

    private void LoadSprite()
    {
        _componentSprites = Resources.LoadAll<Sprite>("Sprites");
    }

    void SpawnRobotComponents()
    {
        float _posY = -120;
        for (int iteration = 0; transform.childCount != _robotComponentsCount; iteration++)
        {
            Vector3 RandomSpawn = new Vector3(_posX[iteration%2], _posY, 0);
            Image SpawnComponent = Instantiate(RobotComponent, RandomSpawn, new Quaternion(0, 0, 1, Random.Range(1.75f, 2)));
            SpawnComponent.transform.SetParent(transform, false);
            SpawnComponent.sprite = _componentSprites[iteration];
            SpawnComponent.GetComponent<EnglishKidsComponent>().MainCamera = MainCamera;
            _posY += 100;
        }
    }
}
