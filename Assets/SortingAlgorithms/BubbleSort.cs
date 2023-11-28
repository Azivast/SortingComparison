using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : SortingAlgorithm {
    // procedure bubbleSort(A : list of sortable items)
    //     n := length(A)
    //     repeat
    //         swapped := false
    //         for i := 1 to n-1 inclusive do
    //             { if this pair is out of order }
    //             if A[i-1] > A[i] then
    //                 { swap them and remember something changed }
    //                 swap(A[i-1], A[i])
    //                 swapped := true
    //             end if
    //         end for
    //     until not swapped s
    // end procedure

    public override List<SphereBehaviour> Sort(List<SphereBehaviour> spheres) {
        bool swapped = true;
        while (swapped) {
            swapped = false;
            for (int i = 1; i < spheres.Count; i++) {
                // if not in order
                if (spheres[i - 1].Distance > spheres[i].Distance) {
                    // swap
                    (spheres[i - 1], spheres[i]) = (spheres[i], spheres[i - 1]);
                    swapped = true;
                }
            }
        } 
        return spheres;
    }
}
