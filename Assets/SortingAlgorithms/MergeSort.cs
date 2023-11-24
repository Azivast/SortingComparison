using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : SortingAlgorithm
{
    public override SphereBehaviour[] Sort(SphereBehaviour[] spheres) {
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
    	if (spheres.Length <= 1) return spheres; // TODO: Save array.length to variable?

        SphereBehaviour[] left = new SphereBehaviour[Mathf.CeilToInt(spheres.Length/2f)];
        SphereBehaviour[] right = new SphereBehaviour[spheres.Length/2];

        for (int i = 0; i < spheres.Length; i++) {
            if (i < left.Length) left[i] = spheres[i];
            else right[i-left.Length] = spheres[i];
        }

        left = Sort(left);
        right = Sort(right);

        return Merge(left, right);
    }

    private SphereBehaviour[] Merge(SphereBehaviour[] left, SphereBehaviour[] right) {
        SphereBehaviour[] result = new SphereBehaviour[left.Length + right.Length];

        int leftIndex = 0, rightIndex = 0, resultIndex = 0;
        while (leftIndex < left.Length && rightIndex < right.Length ) {
            if (left[leftIndex].Distance <= right[rightIndex].Distance) {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
            }
            else {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
            }
            resultIndex++;
        }

        // Either left or right may have elements left; consume them.
        // (Only one of the following loops will actually be entered.)'
        while (leftIndex != left.Length) {
            result[resultIndex] = left[leftIndex];
            leftIndex++;
            resultIndex++;
        }

        while (rightIndex < right.Length) {
            result[resultIndex] = right[rightIndex];
            rightIndex++;
            resultIndex++;
        }

        return result;
    }
}