using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanover.Physics
{
    public class PlayerPhysics : MonoBehaviour
    {
        /*
         * I can't really write the physics until there are basic inputs to let me test them.
         * 
         * Here's my plan of attack:
         * - "primary surfaces" (things we want to have gravity) have a script attached to them that adds a
         *   trigger collider around them.
         * - if the player is in multiple, closest wins. (by center for freestanding, to surface for flat geometry)       
         * - If the player is not in any trigger zones, they only have their momentum, but have free vectoring 
         *   (not realisitic but would probably be unplayable otherwise)
         * - No friction/drag in 'air', normal in ground state.
         * -        
         */       

        void Start()
        {

        }

        void FixedUpdate()
        {

        }
    }
}
