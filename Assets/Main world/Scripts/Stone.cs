using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {
    public float amountStones;
    public float perc;
    public float stonesPerHit;
    public bool destroyObject;
    public float speed;
    public float startScale;
    Mesh mesh;
    Vector3[] vertices;
    Vector3[] normals;
    public GameObject PS_Impact;

    void Start () {
        float randVal = Random.Range(1f, 4f);
        transform.localScale = new Vector3(randVal, randVal, randVal);
        amountStones = 10 * transform.localScale.x;
        startScale = transform.localScale.x;
        perc = (startScale / 2) / amountStones;
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        destroyObject = false;
        speed = 0.01f;

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        normals = mesh.normals;

        //for (int i = 0; i < vertices.Length; i++)
        //{
        //    for(int u = 0; u < vertices.Length; u++)
        //    {
        //        if (vertices[i].x == vertices[u].x)
        //        {
        //            vertices[i] += new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        //            vertices[u] += new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
        //        }
        //    }
        //}
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            destroyObject = true;
        if (destroyObject)
        {
            GetComponent<MeshCollider>().enabled = false;
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] -= vertices[i].normalized / 50;
            }
            mesh.vertices = vertices;
            speed += 0.0005f;
            if (speed >= 0.05f)
            {
                GameObject impact = Instantiate(PS_Impact, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            //Vector3 position = transform.position;
            //transform.position -= new Vector3(0, speed / 2, 0);
            //transform.localScale -= new Vector3(speed, speed, speed);
            //if(transform.localScale.x <= 0)
            //{
            //    Destroy(this.gameObject);
            //}

        }
    }
}
