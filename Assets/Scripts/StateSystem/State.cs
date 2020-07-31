using UnityEngine;

namespace VM.Common.StateSystem
{
	public abstract class State<T> where T : MonoBehaviour
	{
	    protected T owner;
	
	    public abstract void Tick();
	
	    public virtual void OnStateEnter() { }
	    public virtual void OnStateExit() { }
	
	    public State(T owner)
	    {
	        this.owner = owner;
	    }
	}
}