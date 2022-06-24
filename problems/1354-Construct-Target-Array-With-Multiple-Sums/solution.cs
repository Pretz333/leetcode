public class Solution : IComparer<int> {
    public bool IsPossible(int[] target) {
        // Essentially, we're going to work backwards from the largest element in the array, subtracting
        // chunks we know we can make and seeing if we can make the remainder can still be made.
        // sum of all elements in target array
        long sum = 0;

        // A priority queue to store the elements of the target array. 
        // It will return the largest element first.
        PriorityQueue<int,int> pq = new PriorityQueue<int,int>(this);
        
        // Calculate the sum of all elements in target array and store it in queue.
        foreach(int number in target) { // O(n)
            sum += number;
            pq.Enqueue(number, number);
        }

        while(pq.Peek() != 1) {
            // Get the next biggest element in the queue.
            int nextBiggest = pq.Dequeue();

            // Calculate the remainder of the sum after subtracting the next biggest element.
            long remainder = sum - nextBiggest;

            // If the remainder is 0, bigger than (or equal to) the next biggest element, or cannot be made by the
            // remaining elements, then our target cannot be made.
            if(remainder == 0 || remainder >= nextBiggest || (remainder != 1 && nextBiggest % (int) remainder == 0)) {
                return false; 
            }

            // If the remainder can be made by the elements, then we repurpose nextBiggest to be what special number we still need
            // to make our solution. By this, I mean that we still think that we can make the target, but we need to update sum and 
            // priority queue to be what we need to not only make the other elements, but also the element we just made.
            nextBiggest = nextBiggest % (int) remainder;
            sum = remainder + nextBiggest;
            pq.Enqueue(nextBiggest, nextBiggest);
        }
        
        // If we make it here, then we have a solution, meaning target can be made.
        return true;
    }
    
    // IComparer<int> implementation. This allows us to use a priority queue that returns the largest element first.
    // I'm not confident that this is faster than what I did before (making the priority Int32.MaxValue - value), but
    // it is definitely the solution that the documentation wants you to do.
    public int Compare(int a, int b) {
        return b-a;
    }

    // Please note: the 100% score is not because this solution is good, but because so few people use C# on LeetCode.
}