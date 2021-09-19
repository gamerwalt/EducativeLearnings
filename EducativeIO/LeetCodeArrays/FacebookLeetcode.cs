using Educative.IO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook
{
    public class FacebookLeetcode
    {
        public static int runningSum = 0;
        public static int BinarySearch(int[] list, int target)
        {
            if (list == null || list.Length == 0) return -1;

            var first = 0;
            var last = list.Length;

            while (first <= last)
            {
                var midPoint = (last - first) / 2 + first;

                if (list[midPoint] == target) return midPoint;
                if (list[midPoint] > target)
                {
                    last = midPoint - 1;
                }
                else
                {
                    first = midPoint + 1;
                }
            }

            return -1;
        }

        //https://leetcode.com/problems/valid-palindrome/
        ///Given a string s, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        public static bool ValidPalindrome1(string s)
        {
            var newString = s.ToLower();
            //we can use the 2 pointer approach here
            //the plan is to iterate once through the string and not use extra space
            //we only check alphanumerica characters, and ignore the rest
            //if at any point, the characters do not match, we bail out

            //samples
            //aca
            //a,ca
            //a,cca;
            //acba
            //ate

            var left = 0;
            var right = newString.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(newString[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(newString[right]))
                    right--;

                if (left == right) break;

                if (newString[left] != newString[right])
                    return false;
                else
                {
                    left++;
                    right--;
                }
            }

            return true;
        }

        public bool ValidPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            return IsValidPalindrome(s, 0, s.Length - 1, false);
        }

        private bool IsValidPalindrome(string s, int left, int right, bool characterDeleted)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    if (characterDeleted)
                        return false;

                    return IsValidPalindrome(s, left + 1, right, true) || IsValidPalindrome(s, left, right - 1, true);
                }

                left++;
                right--;
            }

            return true;
        }

        ///The array-form of an integer num is an array representing its digits in left to right order.
        ///For example, for num = 1321, the array form is [1,3,2,1]
        ///Given num, the array-form of an integer, and an integer k, return the array-form of the integer num + k.
        ///Example
        ///input: num = [1299], k = 34
        ///Output: 1333
        public static IList<int> AddToArrayForm(int[] num, int k)
        {
            if (num == null || num.Length == 0) return new List<int>();
            if (k == 0) return new List<int>(num);

            var returnList = new LinkedList<int>();

            var i = num.Length - 1;
            var carry = 0;
            var sum = 0;

            while (i >= 0 && k > 0)
            {
                sum = carry;

                if (k > 0 && i <= num.Length)
                {
                    sum += num[i--] + (k % 10);
                    k = k / 10;
                    carry = sum / 10;

                    returnList.AddFirst(sum % 10);
                }
            }

            while (k > 0)
            {
                sum = carry;
                sum += k % 10;
                k = k / 10;
                carry = sum / 10;

                returnList.AddFirst(sum % 10);
            }

            while (i >= 0)
            {
                sum = carry;
                sum += num[i--];
                carry = sum / 10;

                returnList.AddFirst(sum % 10);
            }

            if (carry > 0)
                returnList.AddFirst(carry);


            return returnList.ToList();
        }

        ///https://leetcode.com/problems/add-strings/
        ///Given two non-negative integers, num1 and num2 represented as string, return the sum of num1 and num2 as a string.
        ///You must solve the problem without using any built-in library for handling large integers (such as BigInteger). 
        ///You must also not convert the inputs to integers directly.
        ///Example:
        ///Input: num1 = "11", num2 = "123"
        ///Output: "134"
        ///Input: num1 = "456", num2 = "77"
        ///Output: "533"
        ///Input: num1 = "0", num2 = "0"
        ///Output: "0"
        public static string AddStrings(string first, string second)
        {
            if (string.IsNullOrWhiteSpace(first) && string.IsNullOrWhiteSpace(second)) return string.Empty;

            var firstPointer = first.Length - 1;
            var secondPointer = second.Length - 1;

            var stringBuilder = new StringBuilder();
            var carry = 0;

            while (firstPointer >= 0 && secondPointer >= 0)
            {
                var sum = carry;
                if (firstPointer >= 0) sum += first[firstPointer--] - '0';
                if (secondPointer >= 0) sum += second[secondPointer--] - '0';

                carry = AppendSumAndReturnCarry(stringBuilder, sum);
            }

            while (firstPointer >= 0)
            {
                var sum = carry;
                if (firstPointer >= 0) sum += first[firstPointer--] - '0';

                carry = AppendSumAndReturnCarry(stringBuilder, sum);
            }

            while (secondPointer >= 0)
            {
                var sum = carry;
                if (secondPointer >= 0) sum += second[secondPointer--] - '0';

                carry = AppendSumAndReturnCarry(stringBuilder, sum);
            }

            if (carry > 0)
                stringBuilder.Append(carry);

            var charArray = stringBuilder.ToString().ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        private static int AppendSumAndReturnCarry(StringBuilder stringBuilder, int sum)
        {
            int carry = sum / 10;
            stringBuilder.Append(sum % 10);
            return carry;
        }

        ///https://leetcode.com/problems/multiply-strings/
        ///Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
        ///Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
        ///Example
        ///Input: num1 = "2", num2 = "3"
        ///Output: "6"
        ///Input: num1 = "123", num2 = "456"
        ///Output: "56088"
        public static string MultiplyStrings(string first, string second)
        {
            if (string.IsNullOrWhiteSpace(first) && string.IsNullOrWhiteSpace(second)) return string.Empty;
            if (first == "0" || second == "0") return "0";

            //the ans of any multipled number is the addition of the length of both numbers - 1
            var ans = new int[first.Length + second.Length - 1];
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    ans[i + j] += (first[i] - '0') * (second[j] - '0');
                }
            }

            for (int i = ans.Length - 1; i > 0; i--)
            {
                if (ans[i] >= 10)
                {
                    ans[i - 1] += ans[i] / 10;
                    ans[i] %= 10;

                }
            }

            var sb = new StringBuilder();
            foreach (var item in ans)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }

        public static int[] Array1Question(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { };

            var result = new int[nums.Length];
            result[0] = 1;

            for (int j = 1; j < nums.Length; j++)
            {
                result[0] *= nums[j];
            }

            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = (result[0] / nums[i]) * nums[0];
            }

            return result;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { };

            var right = new int[nums.Length];
            var left = new int[nums.Length];
            var results = new int[nums.Length];

            left[0] = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                left[i + 1] = left[i] * nums[i];
            }

            right[nums.Length - 1] = 1;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                right[i - 1] = right[i] * nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                results[i] = left[i] * right[i];
            }

            return results;
        }

        public static string AddBinary(string a, string b)
        {
            var sb = new StringBuilder();

            var i = a.Length - 1;
            var j = b.Length - 1;
            var carry = 0;

            while (i >= 0 && j >= 0)
            {
                int sum = carry;

                if (a[i] > 0) sum += a[i--] - '0';
                if (b[j] > 0) sum += b[j--] - '0';

                sb.Append(sum % 2);
                carry = sum / 2;
            }

            if (carry != 0) sb.Append(carry);

            var finalString = sb.ToString();
            var charAray = finalString.ToCharArray();
            Array.Reverse(charAray);

            return new string(charAray);
        }

        //https://leetcode.com/problems/longest-common-prefix/solution/
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            if (strs.Length == 1) return strs[0];

            var sb = new StringBuilder();
            var st = new List<string>();

            var firstString = strs[0];
            for (int j = 1; j < strs.Length; j++)
            {
                var currentString = strs[j];
                for (int i = 0; i < firstString.Length; i++)
                {
                    if (i > currentString.Length - 1) break;

                    if (firstString[i] == currentString[i])
                        sb.Append(firstString[i]);
                    else
                        break;
                }
                st.Add(sb.ToString());
                sb.Clear();
            }

            if (st.Count == 1)
                return st[0];

            return LongestCommonPrefix(st.ToArray());
        }

        //https://leetcode.com/problems/longest-common-prefix/solution/
        public static string LongestCommonPrefix2(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";

            return LongestCommonPrefix(strs, 0, strs.Length - 1);
        }

        private static string LongestCommonPrefix(string[] strs, int left, int right)
        {
            if (left == right)
                return strs[left];

            var mid = left + ((right - left) / 2);
            var lcpLeft = LongestCommonPrefix(strs, left, mid);
            var lcpRight = LongestCommonPrefix(strs, mid + 1, right);

            return LongestCommonPrefix(lcpLeft, lcpRight);
        }

        private static string LongestCommonPrefix(string left, string right)
        {
            var min = Math.Min(left.Length, right.Length);
            for (int i = 0; i < min; i++)
            {
                if (left[i] != right[i])
                    return left.Substring(0, i);
            }

            return left.Substring(0, min);
        }

        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(needle)) return 0;
            if (string.IsNullOrWhiteSpace(haystack)) return -1;
            if (needle.Length > haystack.Length) return -1;
            if (haystack == needle) return 0;

            //we need this so we don't go out of bounds when checking the haystack
            var toCheck = haystack.Length - needle.Length;
            for (int i = 0; i <= toCheck; i++)
            {
                for (int j = 0; j < needle.Length && haystack[i + j] == needle[j]; j++)
                    if (j == needle.Length - 1) return i;
            }

            return -1;
        }

        public static int ClosestValue(TreeNode root, double target)
        {
            var nums = new List<int>();
            InOrderTraversalBuildNums(root, nums);

            return FindClosestValue(nums, target);
        }

        private static void InOrderTraversalBuildNums(TreeNode root, List<int> nums)
        {
            if (root == null)
                return;

            InOrderTraversalBuildNums(root.left, nums);
            nums.Add(root.val);
            InOrderTraversalBuildNums(root.right, nums);
        }

        private static int FindClosestValue(List<int> nums, double target)
        {
            var closestItem = 0;
            double previousClosestResult = double.MaxValue;
            foreach (var item in nums)
            {
                var itemResult = Math.Abs(item - target);

                closestItem = itemResult <= previousClosestResult ? item : closestItem;

                previousClosestResult = itemResult;
            }

            return closestItem;
        }

        ///https://leetcode.com/problems/search-in-a-binary-search-tree/
        ///You are given the root of a binary search tree (BST) and an integer val.
        ///Find the node in the BST that the node's value equals val and return the subtree rooted with that node. 
        ///If such a node does not exist, return null.
        public static TreeNode SearchBST(TreeNode root, int val)
        {
            while (root != null)
            {
                if (root.val == val)
                {
                    return root;
                }
                else if (root.val > val)
                {
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }

            return new TreeNode();
        }

        ///https://leetcode.com/problems/insert-into-a-binary-search-tree/
        ///You are given the root node of a binary search tree (BST) and a value to insert into the tree. 
        ///Return the root node of the BST after the insertion. 
        ///It is guaranteed that the new value does not exist in the original BST.
        ///Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. 
        ///You can return any of them.
        public static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            if (val > root.val)
                root.right = InsertIntoBST(root.right, val);
            else
                root.left = InsertIntoBST(root.left, val);

            return root;
        }

        ///https://leetcode.com/problems/path-sum/
        ///Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.
        ///A leaf is a node with no children.
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            targetSum -= root.val;

            if (root.left == null && root.right == null)
                return targetSum == 0;
            else
                return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
        }

        ///https://leetcode.com/problems/path-sum-ii/solution/
        ///Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where each path's sum equals targetSum.
        ///A leaf is a node with no children.
        public static IList<IList<int>> PathSum2(TreeNode root, int targetSum)
        {
            if (root == null) return new List<IList<int>>();

            var pathList = new List<IList<int>>();
            var pathNodes = new List<int>();

            IsPathSum(root, targetSum, pathNodes, pathList);

            return pathList;
        }

        private static void IsPathSum(TreeNode root, int remainingSum, List<int> pathNodes, List<IList<int>> pathList)
        {
            if (root == null) return;

            pathNodes.Add(root.val);

            if (root.val == remainingSum && root.right == null && root.left == null)
            {
                pathList.Add(new List<int>(pathNodes));
            }
            else
            {
                IsPathSum(root.left, remainingSum - root.val, pathNodes, pathList);
                IsPathSum(root.right, remainingSum - root.val, pathNodes, pathList);
            }

            pathNodes.RemoveAt(pathNodes.Count - 1);
        }

        ///https://leetcode.com/problems/binary-tree-paths/
        ///Given the root of a binary tree, return all root-to-leaf paths in any order.
        ///A leaf is a node with no children.
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            if (root == null) return new List<string>();

            var results = new List<string>();
            var sb = new StringBuilder();

            GetBinaryTreePaths(root, results, sb);

            return results;
        }

        private static void GetBinaryTreePaths(TreeNode root, List<string> results, StringBuilder sb)
        {
            if (root == null) return;

            sb.Append(root.val);

            if (IsLeaveNode(root))
            {
                results.Add(sb.ToString());
                return;
            }

            sb.Append("->");
            var save = sb.ToString();
            GetBinaryTreePaths(root.left, results, sb);
            GetBinaryTreePaths(root.right, results, new StringBuilder(save));

        }

        ///https://leetcode.com/problems/smallest-string-starting-from-leaf/
        ///You are given the root of a binary tree where each node has a value in the range [0, 25] representing the letters 'a' to 'z'
        ///Return the lexicographically smallest string that starts at a leaf of this tree and ends at the root.
        ///As a reminder, any shorter prefix of a string is lexicographically smaller.
        ///For example, "ab" is lexicographically smaller than "aba"
        public static string SmallestFromLeaf(TreeNode root)
        {
            if (root == null) return string.Empty;

            var lookup = new Dictionary<int, char>()
            {
                {0, 'a'},{1, 'b'},{2, 'c'},{3, 'd'},{4, 'e'},{5, 'f'},{6, 'g'},{7, 'h'},{8, 'i'},{9, 'j'},
                {10, 'k'},{11, 'l'},{12, 'm'},{13, 'n'},{14, 'o'},{15, 'p'},{16, 'q'},{17, 'r'},{18, 's'},{19, 't'},
                {20, 'u'},{21, 'v'},{22, 'w'},{23, 'x'},{24, 'y'},{25, 'z'}
            };

            var sb = new StringBuilder();
            minSum = int.MaxValue;

            SmallestFromLeaf(root, sb, lookup);

            return ans;
        }

        private static int smallestRunningSum = 0;
        private static int minSum = 0;
        private static string ans = "";
        private static void SmallestFromLeaf(TreeNode root, StringBuilder sb, Dictionary<int, char> lookup)
        {
            if (root == null) return;

            lookup.TryGetValue(root.val, out var value);
            sb.Append(value);

            smallestRunningSum += root.val;

            if (IsLeaveNode(root))
            {
                if (smallestRunningSum < minSum)
                {
                    minSum = smallestRunningSum;

                    var charArray = sb.ToString().ToCharArray();
                    Array.Reverse(charArray);
                    ans = new string(charArray);
                }
                smallestRunningSum -= root.val;
            }
            else
            {
                SmallestFromLeaf(root.left, sb, lookup);
                SmallestFromLeaf(root.right, sb, lookup);

                smallestRunningSum -= root.val;
            }

        }

        private static bool IsLeaveNode(TreeNode root)
        {
            return root.left == null && root.right == null;
        }

        public static int Summation = 0;

        public static int SumNumbers(TreeNode root)
        {
            var rootToLeaf = 0;
            var currentNumber = 0;

            Queue<KeyValuePair<TreeNode, int>> stack = new Queue<KeyValuePair<TreeNode, int>>();
            stack.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));

            while (!(stack.Count == 0))
            {
                var currentNode = stack.Dequeue();
                root = currentNode.Key;
                currentNumber = currentNode.Value;

                if (root != null)
                {
                    currentNumber = currentNumber * 10 + root.val;
                    if (IsLeaveNode(root))
                    {
                        rootToLeaf += currentNumber;
                    }
                    else
                    {
                        stack.Enqueue(new KeyValuePair<TreeNode, int>(root.right, currentNumber));
                        stack.Enqueue(new KeyValuePair<TreeNode, int>(root.left, currentNumber));
                    }
                }
            }

            return rootToLeaf;
        }

        //index tells us what coin we are considering
        public static long MakeChange(int[] coins, int money, int index, Dictionary<string, long> memo)
        {
            if (money == 0)
                return 1;
            if (index >= coins.Length)
                return 0;

            var key = money + "-" + index;
            if (memo.ContainsKey(key))
            {
                memo.TryGetValue(key, out var value);
                return value;
            }

            var amountWithCoin = 0;
            long ways = 0;
            while (amountWithCoin <= money)
            {
                var remainingMoney = money - amountWithCoin;
                ways += MakeChange(coins, remainingMoney, index + 1, memo);
                amountWithCoin += coins[index];
            }
            memo.Add(key, ways);
            return ways;
        }

        ///https://leetcode.com/problems/diameter-of-binary-tree/
        ///Given the root of a binary tree, return the length of the diameter of the tree.
        ///The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
        ///This path may or may not pass through the root.
        ///The length of a path between two nodes is represented by the number of edges between them.

        private static int diameter = 0;
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            DFS(root);

            return diameter;
        }

        private static int DFS(TreeNode node)
        {
            if (node == null) return -1;

            var left = DFS(node.left);
            var right = DFS(node.right);

            //diameter of a node
            diameter = Math.Max(diameter, 2 + left + right);
            //Height of a node
            return 1 + Math.Max(left, right);
        }

        ///https://leetcode.com/problems/range-sum-of-bst/
        ///Given the root node of a binary search tree and two integers low and high, 
        ///return the sum of values of all nodes with a value in the inclusive range [low, high].
        private static int SumRangeSumBST = 0;
        public static int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null) return 0;

            RangeSumBSTDfs(root, low, high);

            return SumRangeSumBST;
        }

        private static void RangeSumBSTDfs(TreeNode node, int low, int high)
        {
            if (node == null) return;

            if (low < node.val)
                RangeSumBSTDfs(node.left, low, high);
            if (node.val < high)
                RangeSumBSTDfs(node.right, low, high);

            if (node.val >= low && node.val <= high)
            {
                SumRangeSumBST += node.val;
            }
        }

        ///https://leetcode.com/problems/verifying-an-alien-dictionary/
        ///In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. 
        ///The order of the alphabet is some permutation of lowercase letters.
        ///Given a sequence of words written in the alien language, and the order of the alphabet, 
        ///return true if and only if the given words are sorted lexicographically in this alien language.

        public static bool IsAlienSorted(string[] words, string order)
        {
            if (words == null || words.Length == 0) return false;
            if (order == null || order.Length == 0) return false;

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (IsAlienSortedCompare(words[i], words[i + 1], order) > 0)
                    return false;
            }

            return true;
        }

        private static int IsAlienSortedCompare(string word1, string word2, string order)
        {
            var i = 0;
            var j = 0;
            var compareValue = 0;

            while (i < word1.Length && j < word2.Length && compareValue == 0)
            {
                compareValue = order.IndexOf(word1[i]) - order.IndexOf(word2[j]);
                i++;
                j++;
            }

            if (compareValue == 0)
                return word1.Length - word2.Length;
            else
                return compareValue;
        }

        public static string RemoveDuplicates(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            var charStack = new Stack<char>();

            foreach (var item in s)
            {
                UpsertItemIntoStack(charStack, item);
            }

            return new string(ReverseString(GenerateStringFromStack(charStack)));
        }

        private static char[] ReverseString(StringBuilder sb)
        {
            var charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            return charArray;
        }

        private static StringBuilder GenerateStringFromStack(Stack<char> charStack)
        {
            var sb = new StringBuilder();
            while (charStack.Count > 0)
            {
                sb.Append(charStack.Pop());
            }

            return sb;
        }

        private static void UpsertItemIntoStack(Stack<char> charStack, char item)
        {
            if (charStack.Count > 0)
            {
                PushOrPopItem(charStack, item);
            }
            else
            {
                charStack.Push(item);
            }
        }

        private static void PushOrPopItem(Stack<char> charStack, char item)
        {
            if (!charStack.Peek().Equals(item))
                charStack.Push(item);
            else
                charStack.Pop();
        }

        public static int FindKthPositive(int[] arr, int k)
        {
            //if the number at the first index is greater than k, then the number must be K
            //example arr = {4, 6, 8, 9}, k = 3
            //4 > 3, so we return 3
            if (arr[0] > k) return k;

            var low = 0;
            var high = arr.Length - 1;
            var positionToMissingNumber = 0;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                if (arr[mid] - (mid + 1) < k)
                {
                    positionToMissingNumber = mid + 1;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return k + positionToMissingNumber;

        }

        //*****************************************************************************************//
        //*****************************************************************************************//
        //***********************************MEDIUMS***********************************************//
        //*****************************************************************************************//
        //*****************************************************************************************//
        public static int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            if (dividend == int.MinValue && divisor == 1) return int.MinValue;

            var hasSign = (dividend < 0) ^ (divisor < 0);

            dividend = dividend > 0 ? -dividend : dividend;
            divisor = divisor > 0 ? -divisor : divisor;

            var quotient = 0;

            var i = 1; var accumulator = divisor;
            var max = int.MinValue >> 1;
            while (accumulator >= max && dividend <= accumulator + accumulator)
            {
                i += 1;
                accumulator += accumulator;
            }
            while (dividend <= divisor)
            {
                if (dividend <= accumulator)
                {
                    dividend -= accumulator;
                    quotient += i;
                }
                accumulator >>= 1;
                i >>= 1;
            }

            return hasSign ? -quotient : quotient;
        }

        public static int[][] MergeIntervals(int[][] intervals)
        {
            intervals = intervals.OrderBy(c => c[0]).ToArray();
            var items = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (items.Count == 0 || items.Last()[1] < interval[0])
                {
                    items.Add(interval);
                }
                else
                {
                    items.Last()[1] = Math.Max(items.Last()[1], interval[1]);
                }
            }

            return items.ToArray();
        }

        ///https://leetcode.com/problems/meeting-rooms/
        ///Given an array of meeting time intervals where intervals[i] = [starti, endi], determine if a person could attend all meetings.
        public static bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length == 0) return true;
            if (intervals == null) return true;

            intervals = intervals.OrderBy(c => c[0]).ToArray();

            for (int i = 0; i < intervals.Length - 1; i++)
            {
                if (intervals[i][1] > intervals[i + 1][0])
                    return false;
            }

            return true;
        }

        ///https://leetcode.com/problems/climbing-stairs/
        ///You are climbing a staircase. It takes n steps to reach the top.
        ///Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
        public static int ClimbStairs(int n)
        {
            var memo = new int[n + 1];
            return ClimbStairs(0, n, memo);
        }

        private static int ClimbStairs(int counter, int totalStairs, int[] memo)
        {
            if (counter > totalStairs) return 0;

            if (counter == totalStairs) return 1;

            if (memo[counter] > 0) return memo[counter];

            memo[counter] = ClimbStairs(counter + 1, totalStairs, memo) + ClimbStairs(counter + 2, totalStairs, memo);

            return memo[counter];
        }

        ///https://leetcode.com/problems/combination-sum/
        ///Given an array of distinct integers candidates and a target integer target, 
        ///return a list of all unique combinations of candidates where the chosen numbers sum to target. 
        ///You may return the combinations in any order.
        ///The same number may be chosen from candidates an unlimited number of times.
        ///Two combinations are unique if the frequency of at least one of the chosen numbers is different.
        ///It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0) return new List<IList<int>>();

            var combination = new List<int>();
            var results = new List<IList<int>>();

            CombinationSumBackTrack(target, candidates, 0, combination, results);

            return results;
        }

        private static void CombinationSumBackTrack(
            int remainFromTarget, int[] candidates,
            int startCounter, List<int> combination, List<IList<int>> results)
        {
            if (remainFromTarget == 0)
            {
                //We've reached the point where we've found an actual list
                //we need to add it to the results
                results.Add(new List<int>(combination));
            }
            else if (remainFromTarget < 0)
            {
                //we've exceeded the target
                //we need to exit/return
                return;
            }

            //at this point, we're still looking for more cobinations from the startCounter
            for (int i = startCounter; i < candidates.Length; i++)
            {
                //add the current combinationValue
                combination.Add(candidates[i]);

                //let's recurse and check if we've passed the target (< 0) or reached the target (== 0) or we need to keep moving
                CombinationSumBackTrack(remainFromTarget - candidates[i], candidates, i, combination, results);

                //we need to backtrack and remove the last digit we just inserted
                var lastValue = combination.Last();
                var indexOfLastValue = combination.LastIndexOf(lastValue);
                combination.RemoveAt(indexOfLastValue);
            }
        }

        ///https://leetcode.com/problems/same-tree/
        ///Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        ///Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            if (p.val != q.val) return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        ///https://leetcode.com/problems/maximum-depth-of-binary-tree/
        ///Given the root of a binary tree, return its maximum depth.
        ///A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
        private static int maxDepthMax = 0;
        private static int currentMaxDepth = 0;
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            var leftMax = MaxDepth(root.left);
            var rightMax = MaxDepth(root.right);

            return Math.Max(leftMax, rightMax) + 1;
        }

        ///https://leetcode.com/problems/linked-list-cycle/
        ///Given head, the head of a linked list, determine if the linked list has a cycle in it.
        ///There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
        ///Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
        ///Return true if there is a cycle in the linked list. Otherwise, return false.
        public static bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var fast = head.next;
            var slow = head;

            while (fast != null)
            {
                if (fast == slow) return true;

                if (fast.next == null) return false;

                fast = fast.next.next;
                slow = slow.next;
            }

            return false;
        }

        ///https://leetcode.com/problems/reverse-bits/
        ///Reverse bits of a given 32 bits unsigned integer.
        public static uint ReverseBits(uint n)
        {
            uint result = 0;
            for(int i = 0; i<32; i++)
            {
                result <<= 1;

                if ((n & 1) == 1)
                    result++;

                n >>= 1;
            }

            return result;
        }

        ///https://leetcode.com/problems/number-of-1-bits/
        ///Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).
        public static int HammingWeight_NumberOfBits(uint n)
        {
            if (n == 0) return 0;

            var result = 0;
            for(int i = 0; i<32; i++)
            {
                if ((n & 1) == 1)
                    result++;
                n >>= 1;
            }

            return result;
        }

        ///https://leetcode.com/problems/reverse-linked-list/
        ///Given the head of a singly linked list, reverse the list, and return the reversed list.
        public static ListNode ReverseList(ListNode head)
        {
            var current = head;
            var previous = default(ListNode);

            while(current != null)
            {
                var temp = current.next;

                current.next = previous;
                previous = current;

                current = temp;
            }

            return previous;
        }

        ///https://leetcode.com/problems/invert-binary-tree/
        ///Given the root of a binary tree, invert the tree, and return its root.
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var left = InvertTree(root.left);
            var right = InvertTree(root.right);

            root.right = left;
            root.left = right;

            return root;
        }

        ///https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
        ///Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.
        ///According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between 
        ///two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null) return null;

            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor(root.left, p, q);
            else if (root.val < p.val && root.val < q.val)
                return LowestCommonAncestor(root.right, p, q);
            else
                return root;
        }

        ///https://leetcode.com/problems/missing-number/
        ///Given an array nums containing n distinct numbers in the range [0, n], 
        ///return the only number in the range that is missing from the array.
        ///Follow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?
        public static int MissingNumber(int[] nums)
        {
            var n = nums.Length;
            Array.Sort(nums);

            if (nums[nums.Length - 1] != nums.Length)
                return nums.Length;
            else if (nums[0] != 0)
                return 0;

            for(int i = 0; i <= n; i++)
            {
                if (i != nums[i])
                    return i;
                    
            }

            return -1;
        }

        public static int MissingNumber2(int[] nums)
        {
            var exptectedSum = nums.Length * (nums.Length + 1) / 2;
            var actualSum = 0;

            for (int i = 0; i < nums.Length; i++)
                actualSum += nums[i];

            return exptectedSum - actualSum;
        }

        ///https://leetcode.com/problems/counting-bits/solution/
        ///Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), 
        ///ans[i] is the number of 1's in the binary representation of i.
        
        //O(N log N)
        //O(1)
        public static int[] CountBitsNonOptimal(int n)
        {
            var ans = new int[n + 1];
            for(int i = 0; i<=n; i++)
            {
                ans[i] = CountOnes(i);
            }

            return ans;
        }

        private static int CountOnes(int n)
        {
            var count = 0;
            while (n != 0)
            {
                n &= n - 1;
                count++;
            }

            return count;
        }

        //O(N)
        //O(1)
        public static int[] CountBits(int n)
        {
            var dp = new int[n + 1];
            var offset = 1;

            for(int i = 1; i<=n; i++)
            {
                if (offset * 2 == i)
                    offset = i;

                dp[i] = 1 + dp[i - offset];
            }

            return dp;
        }

        ///https://leetcode.com/problems/subtree-of-another-tree/
        ///Given the roots of two binary trees root and subRoot, 
        ///return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.
        ///A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. 
        ///The tree tree could also be considered as a subtree of itself.
        ///
        //Time Complexity = O(m + n) where m == nodes in root and n == nodes in subRoot
        //Space Complexity = O(max(m, n))
        public static bool IsSubTree(TreeNode root, TreeNode subRoot)
        {
            if (root == null || subRoot == null) return false;

            var stringBuilderRoot = new StringBuilder();
            PreOrderTree(root, stringBuilderRoot);
            var stringBuilderSubRoot = new StringBuilder();
            PreOrderTree(subRoot, stringBuilderSubRoot);

            return stringBuilderRoot.ToString().IndexOf(stringBuilderSubRoot.ToString()) >= 0;
        }

        private static void PreOrderTree(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("null");
                return;
            }

            sb.Append("#" + node.val);
            PreOrderTree(node.left, sb);
            PreOrderTree(node.right, sb);
        }

        public static bool IsSubTree2(TreeNode s, TreeNode t)
        {
            if (s == null)
                return t == null;

            return IsSame(s, t) || IsSubTree2(s.left, t) || IsSubTree2(s.right, t);
        }

        private static bool IsSame(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s == null || t == null) return false;

            if (s.val == t.val) return true;

            return IsSame(s.left, t.left) && IsSame(s.right, t.right);
        }


        ///https://leetcode.com/problems/single-number/
        ///Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
        ///You must implement a solution with a linear runtime complexity and use only constant extra space.
        public static int SingleNumber(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for(int i = 0; i<nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict.Remove(nums[i]);
                else
                    dict.Add(nums[i], 1);
            }

            return dict.FirstOrDefault(c => c.Value == 1).Key;
        }

        ///https://leetcode.com/problems/find-the-difference/solution/
        ///You are given two strings s and t.
        ///String t is generated by random shuffling string s and then add one more letter at a random position.
        ///Return the letter that was added to t.
        public static char FindTheDifference(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s)) return t[0];
            if (string.IsNullOrWhiteSpace(t)) return s[0];

            var dict = new Dictionary<char, int>();
            foreach(var c in s)
            {
                if(dict.ContainsKey(c))
                {
                    dict.TryGetValue(c, out var counter);
                    counter++;
                    dict[c] = counter;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            if (dict.Count == 0) return t[0];
            var extraChar = default(Char);
            foreach(var c in t)
            {
                dict.TryGetValue(c, out var counterOfChar);
                if(counterOfChar == 0)
                {
                    extraChar = c;
                }
                else
                {
                    dict[c] = counterOfChar - 1;
                }
            }

            return extraChar;
        }

        ///https://leetcode.com/problems/word-pattern/
        ///Given a pattern and a string s, find if s follows the same pattern.
        ///Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
        public static bool WordPattern(string pattern, string s)
        {
            if (string.IsNullOrWhiteSpace(pattern)) return false;
            if (string.IsNullOrWhiteSpace(s)) return false;

            var dict = new Dictionary<char, string>();
            var sArray = s.Split(' ');

            if (sArray.Length != pattern.Length) return false;

            for (int i = 0; i < pattern.Length; i++)
            {
                var currentChar = pattern[i];

                if (dict.ContainsKey(currentChar))
                {
                    if (dict[currentChar] != sArray[i]) return false;
                }
                else
                {
                    if (dict.ContainsValue(sArray[i])) return false;

                    dict.Add(currentChar, sArray[i]);
                }
            }

            return true;
        }

        ///https://leetcode.com/problems/spiral-matrix/
        ///Given an m x n matrix, return all elements of the matrix in spiral order.
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null) return new List<int>();

            var top = 0;
            var left = 0;
            var right = matrix[0].Length-1;
            var bottom = matrix.Length-1;

            var result = new List<int>();
            var totalEntries = (matrix.Length * matrix[0].Length);
            while (result.Count < totalEntries)
            {
                for(int i = left; i<=right && result.Count < totalEntries; i++)
                {
                    result.Add(matrix[top][i]);
                }
                top++;
                for(int i = top; i<= bottom && result.Count < totalEntries; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;
                for(int i = right; i>= left && result.Count < totalEntries; i--)
                {
                    result.Add(matrix[bottom][i]);
                }
                bottom--;
                for(int i = bottom; i>= top && result.Count < totalEntries; i--)
                {
                    result.Add(matrix[i][left]);
                }
                left++;
            }

            return result;
        }

        ///https://leetcode.com/problems/generate-parentheses/
        ///Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        ///Input: n = 3
        ///Output: ["((()))","(()())","(())()","()(())","()()()"]
        public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return new List<string>();
            if (n == 1) return new List<string>() { "()" };
            var result = new List<string>();
            var sb = new StringBuilder();

            GenerateParenthesisBacktrack(0, 0, n, result, sb);

            return result;
        }

        private static void GenerateParenthesisBacktrack(int openCounter, int closedCounter, int total, List<string> result, StringBuilder sb)
        {
            if ((openCounter == closedCounter) && total == openCounter)
            {
                result.Add(sb.ToString());
                return;
            }

            if (openCounter < total)
            {
                sb.Append("(");
                GenerateParenthesisBacktrack(openCounter + 1, closedCounter, total, result, sb);
                sb.Remove(sb.Length - 1, 1);
            }

            if(closedCounter < openCounter)
            {
                sb.Append(")");
                GenerateParenthesisBacktrack(openCounter, closedCounter + 1, total, result, sb);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        ///https://leetcode.com/problems/rotate-image/
        ///You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
        public static void RotateImage(int[][] matrix)
        {
            Transpose(matrix);
            Reflect(matrix);
        }
        
        private static void Transpose(int[][] matrix)
        {
            var n = matrix.Length;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    var temp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = temp;
                }
            }
        }

        private static void Reflect(int[][] matrix)
        {
            var n = matrix.Length;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n/2; j++)
                {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = tmp;
                }
            }
        }

        ///https://leetcode.com/problems/group-anagrams/
        ///Given an array of strings strs, group the anagrams together. You can return the answer in any order.
        ///An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
        ///typically using all the original letters exactly once.
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0) return new List<IList<string>>()
            {
                new List<string>()
                {
                    ""
                }
            };

            var dict = new Dictionary<string, List<string>>();
            var count = new int[26];

            //Iterate through all the strings
            foreach (var s in strs)
            {
                //on each iteration, clear the array of counts
                Array.Clear(count, 0, count.Length);
                //get 
                foreach (var ch in s)
                    count[ch - 'a']++;

                var sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(count[i]);
                }
                var key = sb.ToString();
                if (!dict.ContainsKey(key))
                    dict.Add(key, new List<string>());

                dict[key].Add(s);
            }

            var list =  dict.Values.ToList();
            var returnList = new List<IList<string>>();
            foreach(var item in list)
            {
                returnList.Add(item);
            }

            return returnList;
        }

        ///https://leetcode.com/problems/jump-game/
        ///You are given an integer array nums. You are initially positioned at the array's first index, 
        ///and each element in the array represents your maximum jump length at that position.
        ///Return true if you can reach the last index, or false otherwise.
        ///Sample [2, 3, 1, 1, 4]
        public static bool CanJump(int[] nums)
        {
            if (nums == null || nums.Length == 0) return false;
            if (nums.Length == 1) return true;
            if (nums[0] == 0) return false;

            var lastGoodIndexPosition = nums.Length - 1;

            for(int i = nums.Length - 1; i>=0; i--)
            {
                if (i + nums[i] >= lastGoodIndexPosition)
                    lastGoodIndexPosition = i;
            }

            return lastGoodIndexPosition == 0;
        }

        ///https://leetcode.com/problems/insert-interval/
        ///You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] 
        ///represent the start and the end of the ith interval and intervals is sorted in ascending order by start i. 
        ///You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
        public static int[][] InsertInterval(int[][] intervals, int[] newInterval)
        {
            if (intervals == null || intervals.Length == 0 || newInterval == null || newInterval.Length == 0) return new int[0][];
            if (newInterval.Length < 2) return intervals;

            var result = new List<int[]>();
            var newStart = newInterval[0];
            var newEnd = newInterval[1];
            var index = 0;
            var n = intervals.Length;

            //Add all intervals that have a start time before the new interval's start time
            while (index < n && newStart > intervals[index][0])
                result.Add(intervals[index++]);

            var interval = new int[2];
            //if there is no intervals that start before the new interval's start time
            //meaning the result is empty, add the interval
            if (result.Count == 0 || result.Last()[1] < newStart)
                result.Add(newInterval);
            else
            {
                //if there's an overlap, merge with the last interval in the result
                interval = result.Last();
                result.RemoveAt(result.Count - 1);
                interval[1] = Math.Max(interval[1], newEnd);
                result.Add(interval);
            }

            //Add the remaining intervals, merge with newInterval if needed
            //index is now at the point where the interval's start time is greater than the newInterval's
            while(index < n)
            {
                interval = intervals[index++];
                var start = interval[0];
                var end = interval[1];

                if (result.Last()[1] < start)
                    result.Add(interval);
                else
                {
                    interval = result.Last();
                    result.RemoveAt(result.Count - 1);
                    interval[1] = Math.Max(interval[1], end);
                    result.Add(interval);
                }
            }

            return result.ToArray();
        }

        ///https://leetcode.com/problems/unique-paths/
        ///A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        ///The robot can only move either down or right at any point in time. 
        ///The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
        ///How many possible unique paths are there?
        public static int UniquePaths(int m, int n)
        {
            var dp = new int[m][];
            
            for(int i = 0; i<dp.Length; i++)
            {
                dp[i] = new int[n];
                dp[i][0] = 1;
            }

            for(int i = 0; i < dp[0].Length; i++)
            {
                dp[0][i] = 1;
            }

            for(int i = 1; i < dp.Length; i++)
            {
                for(int j = 1; j < dp[i].Length; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];
        }

        ///https://leetcode.com/problems/unique-paths-ii/
        ///A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        ///The robot can only move either down or right at any point in time. 
        ///The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
        ///Now consider if some obstacles are added to the grids. How many unique paths would there be?
        ///An obstacle and space is marked as 1 and 0 respectively in the grid.
        public static int UniquePathsWithObstacles(int[][] grid)
        {
            if (grid[grid.Length][grid.Length] == 1) return 0;
            if (grid[0][0] == 1) return 0;

            for(int i = 0; i < grid.Length; i++)
            {
                for(var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                        grid[i][j] = 2;
                }
            }

            for(int i = 0; i<grid.Length; i++)
            {
                if (grid[i][0] != -1)
                    grid[i][0] = 1;
            }

            for(int i = 0; i < grid[0].Length; i++)
            {
                if (grid[0][i] != -1)
                    grid[0][i] = 1;
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                        grid[i][j] = 0;
                }
            }

            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[i].Length; j++)
                {
                    if(grid[i][j] != -1)
                        grid[i][j] = GetGridValue(grid, i - 1, j) + GetGridValue(grid, i, j - 1);
                }
            }

            var rows = grid.Length;
            var cols = grid[0].Length;

            return grid[rows - 1][cols - 1];
        }

        private static int GetGridValue(int[][] grid, int i, int j)
        {
            if (grid[i][j] == -1)
                return 0;
            else
                return grid[i][j];
        }

        ///https://leetcode.com/problems/set-matrix-zeroes/
        ///Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's, and return the matrix.
        ///You must do it in place.
        public void SetZeros(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;

            var rows = new HashSet<int>();
            var cols = new HashSet<int>();

            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[0].Length; col++)
                {
                    if(matrix[row][col] == 0)
                    {
                        rows.Add(row);
                        cols.Add(col);
                    }
                }
            }

            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[0].Length; col++)
                {
                    if (rows.Contains(row) || cols.Contains(col))
                        matrix[row][col] = 0;
                }
            }
        }

        public void SetZeros2(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;
            var isCol = false;

            for(var row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][0] == 0)
                    isCol = true;

                for(var col = 0; col < matrix[0].Length; col++)
                {
                    if(matrix[row][col] == 0)
                    {
                        matrix[0][col] = 0;
                        matrix[row][0] = 0;
                    }
                }
            }

            for(var row = 1; row < matrix.Length; row++)
            {
                for(var col = 1; col < matrix[0].Length; col++)
                {
                    if (matrix[row][0] == 0 || matrix[0][col] == 0)
                        matrix[row][col] = 0;
                }
            }

            if(matrix[0][0] == 0)
            {
                for (var col = 0; col < matrix[0].Length; col++)
                    matrix[0][col] = 0;
            }

            if(isCol)
            {
                for (var row = 0; row < matrix.Length; row++)
                    matrix[row][0] = 0;
            }
            
        }

        ///https://leetcode.com/problems/word-search/
        ///Given an m x n grid of characters board and a string word, return true if word exists in the grid.
        ///The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. 
        ///The same letter cell may not be used more than once.
        public static bool WordSearchExists(char[][] board, string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;
            if (board.Length == 0) return false;

            for(var row = 0; row < board.Length; row++)
            {
                for(var col = 0; col < board[0].Length; col++)
                {
                    if (word[0] == board[row][col] && WordSearchExistsDFS(board, row, col, 0, word))
                        return true;
                }
            }

            return false;
        }

        private static bool WordSearchExistsDFS(char[][] board, int row, int col, int index, string word)
        {
            if (index == word.Length) return true;

            if (row < 0 || row >= board.Length || col < 0 || col >= board[row].Length || board[row][col] != word[index])
                return false;

            var currentChar = board[row][col];
            board[row][col] = '#';

            var found = WordSearchExistsDFS(board, row + 1, col, index + 1, word) ||
                WordSearchExistsDFS(board, row - 1, col, index + 1, word) ||
                WordSearchExistsDFS(board, row, col + 1, index + 1, word) ||
                WordSearchExistsDFS(board, row, col - 1, index + 1, word);

            board[row][col] = currentChar;

            return found;
        }

        
        public static int NumberOfDecodings(string s)
        {
            //cache
            var dp = new int[s.Length + 1];

            dp[0] = 1; //the first index will decode the number of ways to decode a string of lenght 0
            dp[1] = s[0] == '0' ? 0 : 1; //if the first letter is equal to 0, then the number of ways is 0, else then it is 1 way
            for(int i = 2; i <= s.Length; i++)
            {
                var oneDigit = Convert.ToInt32(s.Substring(i - 1, 1));
                var twoDigits = Convert.ToInt32(s.Substring(i - 2, 2));
                if (oneDigit >= 1)
                    dp[i] += dp[i - 1];

                if (twoDigits >= 10 && twoDigits <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[s.Length];
        }

        ///https://leetcode.com/problems/validate-binary-search-tree/
        ///Given the root of a binary tree, determine if it is a valid binary search tree (BST).
        public static bool IsValidBST(TreeNode root)
        {
            if (root == null) return false;

            return IsValidBST(root, null, null);
        }

        private static bool IsValidBST(TreeNode root, int? lowerLimit, int? higherLimit)
        {
            if (root == null) return true;

            if ((lowerLimit.HasValue && root.val >= lowerLimit.GetValueOrDefault()) || 
                (higherLimit.HasValue && root.val <= higherLimit.GetValueOrDefault()))
                return false;

            return IsValidBST(root.right, root.val, higherLimit) && IsValidBST(root.left, lowerLimit, root.val);
        }

        public static bool IsValidBSTWithDFS(TreeNode root)
        {
            if (root == null) return false;

            var list = new List<int>();
            InOrderizeTree(root, list);

            for(int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] >= list[i + 1])
                    return false;
            }

            return true;
        }

        private static void InOrderizeTree(TreeNode node, List<int> nums)
        {
            if (node == null) return;

            InOrderizeTree(node.left, nums);
            nums.Add(node.val);
            InOrderizeTree(node.right, nums);
        }

        ///https://leetcode.com/problems/find-k-closest-elements/
        ///Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array. 
        ///The result should also be sorted in ascending order.
        ///An integer a is closer to x than an integer b if:
        ///|a - x| < |b - x|, or
        ///|a - x| == |b - x| and a<b
        
        ///Testing[1,2,3,4,5], k = 4, x = 3
        ///Output: [1,2,3,4]
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            //Binary search because we're looking for something in a SORTED array

            var left = 0;
            var right = arr.Length - k;

            while(left < right)
            {
                var mid = (left + right) / 2;
                if (x - arr[mid] > arr[mid + k] - x)
                    left = mid + 1;
                else
                    right = mid;
            }

            var result = new List<int>();
            for(var index = left; index < left + k; index++)
            {
                result.Add(arr[index]);
            }

            return result;
        }

        ///https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
        ///Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree 
        ///and inorder is the inorder traversal of the same tree, construct and return the binary tree.
        
        ///Create a hashmap to store the inOrder values and it's index
        ///We will be using that to go back through the preOrder Array
        private static int preOrderIndex = 0;
        private static Dictionary<int, int> inOrderIndices;
        public static TreeNode BuildTree(int[] preOrder, int[] inOrder)
        {
            preOrderIndex = 0;
            for(int index = 0; index < inOrder.Length; index++)
            {
                inOrderIndices.Add(inOrder[index], index);
            }

            return ArrayToTree(preOrder, left: 0, right: preOrder.Length - 1);
        }

        private static TreeNode ArrayToTree(int[] preOrder, int left, int right)
        {
            if (left > right) return null;

            var nodeValue = preOrder[preOrderIndex++];
            var node = new TreeNode(nodeValue)
            {
                left = ArrayToTree(preOrder, left, inOrderIndices[nodeValue] - 1),
                right = ArrayToTree(preOrder, inOrderIndices[nodeValue] + 1, right)
            };

            return node;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var result = int.MinValue;
            var map = new HashSet<int>();
            //We will use this for a window and essentially remove and add to the hashset
            //if we find a character we have seen before, we remove it from the hashset
            //if we haven't, we add to the hashset and move the end forward to increase the window of what we've seen
            //basically, the amount of characters in the hashset is the window size or number of characters
            //without repeating characters
            var start = 0;
            var end = 0;

            while (end < s.Length)
            {
                if (!map.Contains(s[end]))
                {
                    map.Add(s[end]);
                    end++;
                    result = Math.Max(result, map.Count);
                }
                else
                {
                    //Remove it
                    map.Remove(s[start]);
                    start++;
                }
            }

            return result;
        }
    }
}
