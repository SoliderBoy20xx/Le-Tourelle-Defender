/* Pool Interface to reuse objects like the bullets or the enemies 
   and avoid Instaantiaing and destroying to avoid garbage collection spikes, reduce memory allocatio
   and get better performance 
*/

using UnityEngine;

public interface IPoolable
{
    void OnSpawn();
    void OnDespawn();
}