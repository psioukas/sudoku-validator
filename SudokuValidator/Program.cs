public class SudokuValidator {

    public static bool ValidateSudoku(int[][] board) {

        int n = board.Length;
        int sqrtN = (int)Math.Sqrt(n);

        if (n == 0) {
            return false;
        }

        if (sqrtN * sqrtN != n) {
            return false;
        }


        for (int i = 0; i < n; i++) {
            if (!IsValidSet(board[i]) || !IsValidSet(board.Select(row => row[i]).ToArray())) {
                return false;
            }


        }

        for (int row = 0; row < n; row += sqrtN) {
            for (int col = 0; col < n; col += sqrtN) {
                if (!IsValidSubGrid(board, row, col, sqrtN)) {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool IsValidSet(int[] set) {
        int SetLength = set.Length;
        HashSet<int> seen = new HashSet<int>() { };

        foreach (var cell in set) {
            if (cell < 1 || cell > SetLength || seen.Contains(cell)) {
                return false;
            }

            seen.Add(cell);
        }

        return true;
    }

    private static bool IsValidSubGrid(int[][] board, int startRow, int startCol, int size) {
        HashSet<int> seenValues = new HashSet<int>() { };

        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                int num = board[startRow + i][startCol + j];
                if (num < 1 || num > board.Length || seenValues.Contains(num)) {
                    return false;
                }
                seenValues.Add(num);
            }
        }

        return true;
    }




    public static void Main(string[] args) {
        int[][] test = {
            new int[] {7,8,4, 1,5,9, 3,2,6},
            new int[] {5,3,9, 6,7,2, 8,4,1},
            new int[] {6,1,2, 4,3,8, 7,5,9},
            new int[] {9,2,8, 7,1,5, 4,6,3},
            new int[] {3,5,7, 8,4,6, 1,9,2},
            new int[] {4,6,1, 9,2,3, 5,8,7},
            new int[] {8,7,6, 3,9,4, 2,1,5},
            new int[] {2,4,3, 5,6,1, 9,7,8},
            new int[] {1,9,5, 2,8,7, 6,3,4}
        };

        Console.WriteLine("isValid: " + ValidateSudoku(test).ToString());
    }


}
