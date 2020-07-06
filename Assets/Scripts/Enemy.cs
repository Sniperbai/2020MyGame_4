using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float hp = 150;
    private float totalHp;
    private Slider hpSlider;
    public GameObject effectExplosion;
    public Transform[] positions;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        positions = Waypoints.positions;
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (index > positions.Length - 1) { return; }

        transform.Translate((positions[index].position - transform.position).normalized*Time.deltaTime*speed);

        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        if (index > positions.Length - 1) 
        {
            ReachDestination();
        }
    }

    void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0) 
        {
            Die();
        }
    }

    public void Die() 
    {
        GameObject effect = GameObject.Instantiate(effectExplosion,transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }
}
