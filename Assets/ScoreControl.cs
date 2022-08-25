using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    private string TagNumber;
    private float timeFlow;
    
    public int score { get; set; }
    
    private void OnTriggerEnter(Collider other)
    {
        // Box Collider ların box isimlerine göre tag isimleri ver, ardından switch ile tag kontolü yap     OK
        // tag contolü yaptıktan sonra score ekle   OK
        // score sistemine hılzı olan kazanır mekaniğini ekle
        // bu mekaniği spawn olan objenin yaratıldığı andan trigger edişe kadarki süresine göre score'a ekstra puanlar ekle
        
        
        // eğer hiç trigger lanamazsa Destory(gameobject, 5) ve score da düşmeye sebep ol
        
        // trigger oldu ancak yanlış kutuya oldu, puan düşür aynı şekilde

        if (other.tag == "Cube" && gameObject.tag == "Cube")
        {
            score += 5;
            timeFlow += Time.deltaTime;
            if (timeFlow > 5f)
            {
                score++;
                timeFlow = 0;
            }
            Destroy(gameObject, 10);
        }
        else if (other.tag == "Sphere" && gameObject.tag == "Sphere")
        {
            score++;
            score += 5;
            timeFlow += Time.deltaTime;
            if (timeFlow > 5f)
            {
                score++;
                timeFlow = 0;
            }
            Destroy(gameObject, 10);
        }
        else if (other.tag == "Capsule" && gameObject.tag == "Capsule")
        {
            score += 5;
            timeFlow += Time.deltaTime;
            if (timeFlow > 5f)
            {
                score++;
                timeFlow = 0;
            }
            Destroy(gameObject, 10);
        }
        else
        {
            score -= 2;
            Destroy(gameObject, 10);
        }
        
    }
}
