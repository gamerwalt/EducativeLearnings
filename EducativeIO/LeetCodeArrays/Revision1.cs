using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook
{
    public class Revision1
    {
        //return the index
        public static int BinarySearch(int[] nums, int target) 
        {
            //The idea here is this should be a sorted array
            //and we always want to divide the array in half
            //we find the mid point of the where we are in the array
            //if the midpoint is the target, we return the index
            //if it is on the right half, we search through the right half
            //if it is on the left half, we search through the left half
            //we continue these steps until we solve the problem
            //and if we don't find the target, we return -1

            var leftStart = 0;
            var rightEnd = nums.Length - 1;

            while(leftStart < rightEnd)
            {
                var midPoint = leftStart + ((rightEnd - leftStart) / 2);
                
                if (target == nums[midPoint]) return midPoint;

                if(target > nums[midPoint])//search through the right half
                {
                    leftStart = midPoint + 1;
                }
                else
                {
                    rightEnd = midPoint - 1;
                }
            }

            return -1;
        }

        //https://leetcode.com/problems/valid-palindrome-ii/
        //Given a string s, return true if the s can be palindrome after deleting at most one character from it.
        ///Example 1
        ///Input s = "aba"
        ///Output: true
        ///Example 2
        ///Input s = "abca"
        ///Output: true
        ///Input s = "abc"
        ///Output: false
        //The Idea is to loop and find the characters that are not the same and attempt to discard them by moving forward on both pointers
        public static bool IsValidPalindrome2(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            return IsValidPalindrome2(s, 0, s.Length - 1, false);
        }

        private static bool IsValidPalindrome2(string s, int left, int right, bool discardedCharacter)
        {
            while(left < right)
            {
                if (s[left] != s[right])
                {
                    if (discardedCharacter)
                        return false;

                    return IsValidPalindrome2(s, left + 1, right, true) || IsValidPalindrome2(s, left, right - 1, true);
                }

                left++;
                right--;
            }

            return true;
        }

        ///https://leetcode.com/problems/add-binary/
        ///Given two binary strings a and b, return their sum as a binary string.
        ///Examples
        ///Input: a = "11", b = "1"
        ///Output: "100"
        ///Input: a = "1010", b = "1011"
        ///Output: "10101"
        ///The idea here is to add the integers starting from the right side
        ///we keep looping while both pointers are greater than or equal to 0
        ///When we do add, since this is binary number and we have a base of 2,
        ///we have to make sure the addition does not equal to 2, if it does, we have to get the mod and a carry
        ///we have to make sure that the carry is used for the next iteration
        ///if we've finished adding and we have a carry, just add it to the string/addition using a string builder
        ///then we reverse the string in the string builder
        public static string AddBinary(string firstString, string secondString)
        {
            var firstPointer = firstString.Length - 1;
            var secondPointer = secondString.Length - 1;

            var stringBuilder = new StringBuilder();
            var carry = 0;
            while(firstPointer >= 0 || secondPointer >= 0)
            {
                var sum = carry;
                if (firstPointer >= 0) sum += firstString[firstPointer--] - '0';
                if (secondPointer >= 0) sum += secondString[secondPointer--] - '0';

                stringBuilder.Append(sum % 2);
                carry = sum / 2;
            }

            if (carry > 0) stringBuilder.Append(carry);

            var reversedString = stringBuilder.ToString().ToCharArray();
            Array.Reverse(reversedString);

            return new string(reversedString);
        }

        ///https://leetcode.com/problems/add-to-array-form-of-integer/
        ///The array-form of an integer num is an array representing its digits in left to right order.
        ///For example, for num = 1321, the array form is [1,3,2,1].
        ///Given num, the array-form of an integer, and an integer k, return the array-form of the integer num + k
        public static IList<int> AddToArrayForm(int[] num, int k)
        {
            if (num == null || num.Length == 0) return new List<int>() { k };

            var list = new LinkedList<int>();
            var numLength = num.Length;
            var i = numLength - 1;

            var carry = 0;
            while(i >= 0 && k > 0)
            {
                var sum = carry + (k % 10) + num[i--];
                k /= 10;
                carry = sum / 10;

                list.AddFirst(sum % 10);
            }

            while(k > 0)
            {
                var sum = carry + (k % 10);
                k /= 10;
                carry = sum / 10;

                list.AddFirst(sum % 10);
            }

            while(i >= 0)
            {
                var sum = carry + num[i--];
                carry = sum / 10;

                list.AddFirst(sum % 10); 
            }

            if (carry > 0)
                list.AddFirst(carry);

            return list.ToList();
        }

    }
}
