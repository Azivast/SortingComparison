using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MergeSort : SortingAlgorithm
{
    // function merge_sort(list m) is
    // // Base case. A list of zero or one elements is sorted, by definition.
    // if length of m ≤ 1 then
    //     return m

    // // Recursive case. First, divide the list into equal-sized sublists
    // // consisting of the first half and second half of the list.
    // // This assumes lists start at index 0.
    // var left := empty list
    // var right := empty list
    // for each x with index i in m do
    //     if i < (length of m)/2 then
    //         add x to left
    //     else
    //         add x to right

    // // Recursively sort both sublists.
    // left := merge_sort(left)
    // right := merge_sort(right)

    // // Then merge the now-sorted sublists.
    // return merge(left, right)
    public override List<SphereBehaviour> Sort(List<SphereBehaviour> spheres) {
    	if (spheres.Count <= 1) return spheres;

        int leftCapacity = Mathf.CeilToInt(spheres.Count / 2f);
        int rightCapacity = spheres.Count/2;
        List<SphereBehaviour> left = new List<SphereBehaviour>(leftCapacity);
        List<SphereBehaviour> right = new List<SphereBehaviour>(rightCapacity);


        for (int i = 0; i < spheres.Count; i++) {
            if (i < leftCapacity) left.Add(spheres[i]);
            else right.Add(spheres[i]);
        }

        left = Sort(left);
        right = Sort(right);

        return Merge(left, right);
    }

    private List<SphereBehaviour> Merge(List<SphereBehaviour> left, List<SphereBehaviour> right) {
        List<SphereBehaviour> result = new List<SphereBehaviour>(left.Count + right.Count);

        int leftIndex = 0, rightIndex = 0, resultIndex = 0;
        while (leftIndex < left.Count && rightIndex < right.Count ) {
            if (left[leftIndex].Distance <= right[rightIndex].Distance) {
                result.Add(left[leftIndex]);
                leftIndex++;
            }
            else {
                result.Add(right[rightIndex]);
                rightIndex++;
            }
            resultIndex++;
        }

        // Either left or right may have elements left; consume them.
        // (Only one of the following loops will actually be entered.)
        while (leftIndex != left.Count) {
            result.Add(left[leftIndex]);
            leftIndex++;
            resultIndex++;
        }

        while (rightIndex < right.Count) {
            result.Add(right[rightIndex]);
            rightIndex++;
            resultIndex++;
        }

        return result;
    }
}