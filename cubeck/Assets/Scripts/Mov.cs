using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mov : MonoBehaviour
{
    public Text text;
    public GameObject[] tr;
    private int _score;
    private List<GameObject> coll;
    private List<GameObject> _remove;
    Vector3 pos;
    Vector3 rndPos;
    private float speed = .2f;
    private float radius = 1;
    private float Hsize;
    private float Wsize;
    private float YmaxPerfect = 2.5f;
    private float YminPerfect = -2.5f;
    private float YmaxGood = 6f;
    private float YminGood = -6f;

    void Start()
    {
        coll = new List<GameObject>();
        Hsize = Camera.main.orthographicSize;
        Wsize = Camera.main.aspect * Hsize;
        //Invoke("Respawn", 2);
        Respawn();
    } 

    void Update()
    {
        //Перебор списка действующих объектов
        foreach (var go in coll)
        {
            //Движение объекта
            pos = go.transform.position;
            pos.y -= speed;
            go.transform.position = pos;
            
            InputValue(go);
            text.text = _score.ToString();

            //Добавление объекта в список удаления
            if (go.transform.position.y <= -Wsize - radius)
            {
                _remove = new List<GameObject>();
                _remove.Add(go);
            }
            //Удаление объекта через список удаления
        }
        if (_remove != null)
        {
            foreach (var item in _remove)
            {
                coll.Remove(item);
                Destroy(item);
            }
        }
    }
    //Создание объекта и добавление его в список действующих объектов
    public void Respawn() 
    {
        rndPos = new Vector3(Random.Range(-25, 25), 60, 0);
        int value = Random.Range(0, tr.Length);
        GameObject go = Instantiate(tr[value].gameObject) as GameObject;
        go.transform.position = rndPos;
        coll.Add(go);
        Invoke("Respawn", Random.Range(1, 5));
    }
    //Какую кнопку нажали
    void InputValue(GameObject go) 
    {
        switch (go.tag) 
        {
            case "W":
                if (go.transform.position.y < YmaxPerfect && go.transform.position.y > YminPerfect && Input.GetKeyDown(KeyCode.W))
                {
                    _score += 10;
                    Debug.Log("Perfect+");
                }
                if (go.transform.position.y < YmaxGood && go.transform.position.y > YmaxPerfect && Input.GetKeyDown(KeyCode.W))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                if (go.transform.position.y < YminPerfect && go.transform.position.y > YminGood && Input.GetKeyDown(KeyCode.W))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                break;

            case "S":
                if (go.transform.position.y < YmaxPerfect && go.transform.position.y > YminPerfect && Input.GetKeyDown(KeyCode.S))
                {
                    _score += 10;
                    Debug.Log("Perfect+");
                }
                if (go.transform.position.y < YmaxGood && go.transform.position.y > YmaxPerfect && Input.GetKeyDown(KeyCode.S))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                if (go.transform.position.y < YminPerfect && go.transform.position.y > YminGood && Input.GetKeyDown(KeyCode.S))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                break;

            case "D":
                if (go.transform.position.y < YmaxPerfect && go.transform.position.y > YminPerfect && Input.GetKeyDown(KeyCode.D))
                {
                    _score += 10;
                    Debug.Log("Perfect+");
                }
                if (go.transform.position.y < YmaxGood && go.transform.position.y > YmaxPerfect && Input.GetKeyDown(KeyCode.D))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                if (go.transform.position.y < YminPerfect && go.transform.position.y > YminGood && Input.GetKeyDown(KeyCode.D))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                break;

            case "A":
                if (go.transform.position.y < YmaxPerfect && go.transform.position.y > YminPerfect && Input.GetKeyDown(KeyCode.A))
                {
                    _score += 10;
                    Debug.Log("Perfect+");
                }
                if (go.transform.position.y < YmaxGood && go.transform.position.y > YmaxPerfect && Input.GetKeyDown(KeyCode.A))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                if (go.transform.position.y < YminPerfect && go.transform.position.y > YminGood && Input.GetKeyDown(KeyCode.A))
                {
                    _score += 5;
                    Debug.Log("Good");
                }
                break;

        }
    }

}
