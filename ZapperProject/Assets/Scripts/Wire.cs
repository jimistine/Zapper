using UnityEngine;
using System.Collections;
using System; 

public class Wire : IComparable<Wire>
{
	public string name;
	public Vector3 start_pos;
    
	public Wire(Vector3 newStart)
	{
		start_pos = newStart;
	}
    
	//This method is required by the IComparable
	//interface. 
	public int CompareTo(Wire other)
     	{
     		if(other == null)
     		{
     			return 1;
     		}
             
//     		//Return the difference in power.
//     		return start_pos - other.start_pos;
     	}
}