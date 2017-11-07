using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StirlingMulvey;

namespace MaureenMuthoni
{
    public class RigiEnabled : MonoBehaviour
    {
        Rigidbody myRigi;

        // Use this for initialization
        void Start()
        {
            myRigi = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            myRigi.isKinematic = !GlobalGameManager.gameActive;
        }
    }
}
