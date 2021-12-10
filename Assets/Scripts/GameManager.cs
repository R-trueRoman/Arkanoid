
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int _countOfShapes = 10;
        [SerializeField]
        private List<GameObject> _shapes;
        [SerializeField]
        private List<Material> _colors;

        private void Start()
        {
            var startPosition = this.transform.position;
            StartCoroutine (CreateRandomShapes());
        }

        IEnumerator CreateRandomShapes()
        {
            for(int i = 0; i < _countOfShapes; i++)
            {
                int rndRot = Random.Range(0, 179);
                int rnd = Random.Range(0, _shapes.Count);

                Quaternion quat = Quaternion.Euler(rndRot, rndRot, rndRot);
                var newShape = Instantiate(_shapes[rnd], this.transform.position, quat);
                newShape.transform.position += new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                _shapes.Add(newShape);
                newShape.AddComponent<MeshRenderer>();

                var MR = newShape.GetComponent<MeshRenderer>();
                var rnd2 = Random.Range(0, _colors.Count);

                MR.material = _colors[rnd2];
                newShape.AddComponent<ShapeComponent>(); 
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public class ShapeComponent : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
