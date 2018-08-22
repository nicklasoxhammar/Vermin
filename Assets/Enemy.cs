using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    bool done = false;
    public float speed;
    [HideInInspector] public SpriteRenderer sprite;
    public GameObject marker;
    List<GameObject> markers = new List<GameObject>();

	void Start () {

        sprite = GetComponent<SpriteRenderer>();
        speed = GameManager.gm.enemySpeed;
        InvokeRepeating("GoUp", speed, speed);

        GameObject _marker = Instantiate(marker, transform.position, transform.rotation);
        markers.Add(_marker);

        transform.localScale = new Vector3(1.0f, 0.1f, 1.0f);
		
	}
	
	void Update () {

        if (!done) {
            if (transform.position.y == -1) {
                sprite.enabled = true;
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                CancelInvoke();
                GameManager.gm.EnemyAtSmashPoint(this);

                done = true;

            }
        }
		
	}

    void GoUp() {

        if(transform.position.y < -1) {

            transform.position += Vector3.up;

            GameObject _marker = Instantiate(marker, transform.position, transform.rotation);
            markers.Add(_marker);

        }
        
    }

    public void DestroyMarkers() {
        
        foreach(GameObject m in markers) {
            Destroy(m);
        }
    }




}
