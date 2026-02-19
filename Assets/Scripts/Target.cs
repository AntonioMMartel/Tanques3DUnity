using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IHittable
{
    [SerializeField] int scoreValue = 10;
    public void Hit(GameObject owner)
    {

        ScoreManager.Instance.AddScore(scoreValue);
        Destroy(owner);
        Destroy(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
