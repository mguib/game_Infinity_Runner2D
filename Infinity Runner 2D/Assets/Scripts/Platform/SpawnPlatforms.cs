using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour{

    public List<GameObject> platforms = new List<GameObject>(); //Lista dos prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>(); //Listas das plataformas geradas na cena

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;

    public float ofsset;

    // Start is called before the first frame update
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platforms.Count; i++){
            //Instancia as plataformas em uma distancia de 30
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.5f), transform.rotation).transform;
            currentPlatforms.Add(p);//Adiciona a lista de plataformas clones
            ofsset += 30f;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    void Move(){

        float distance = player.position.x - currentPlatformPoint.position.x; //Salvando a diferença da posição x do player e do finalPoint da plataforma atual

        //Distancia >2 a plataforma é reciclada
        if (distance >= 2){

            //Recicla a plataforma atual
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            //Reinicia a contagem da lista de sprits de plataformas
            if(platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            //Obtem o próximo finalPoint das plataforma clones
            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }


    public void Recycle(GameObject platform){
        platform.transform.position = new Vector2(ofsset, -4.5f);

        if(platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.SpawnEnemies();
        }        
        ofsset += 30f;
    }
}
