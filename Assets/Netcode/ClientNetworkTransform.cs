using Unity.Netcode.Components;
using UnityEngine;

namespace Netcode
{
    [DisallowMultipleComponent]
    public class ClientNetworkTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}
    
    
