using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 [RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
   NavMeshAgent m_Agent;
   RaycastHit m_HitInfo = new RaycastHit();

   private void Start()
   {
    m_Agent = GetComponent<NavMeshAgent>();
   }

   private void Update()
   {
    if(Input.GetMouseButton(0))
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin, ray.direction, out m_HitInfo)) // out eğer kullanıcı doğru bir değer döndürüyorsa kullanılıyor yoksa parametreli olarak geri döndürüyor. 
        //Ekrandaki dokunmları ışın olarak aldığımız ve dokunmaları almak icin.
        {
            m_Agent.destination = m_HitInfo.point; //ışınları ekran üzerined dokunduğumuz poziyona göre hareket ettirmeye calısıyoruz
        }
    }
   }
   

}
