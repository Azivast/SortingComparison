using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertSort : SortingAlgorithm
{
	//     i ← 1
	//     while i < length(A)
	//         j ← i
	//         while j > 0 and A[j-1] > A[j]
	//             swap A[j] and A[j-1]
	//             j ← j - 1
	//         end while
	//         i ← i + 1
	//     end while
	//
    public override List<SphereBehaviour> Sort(List<SphereBehaviour> spheres) {
    int i = 1;
    while (i < spheres.Count) {
	    int j = i;
	    while (j > 0 && spheres[j-1].Distance > spheres[j].Distance) {
		    (spheres[j-1], spheres[j]) = (spheres[j], spheres[j-1]);
		    j--;
	    }
	    i++;
	}

    return spheres;
    }
}
