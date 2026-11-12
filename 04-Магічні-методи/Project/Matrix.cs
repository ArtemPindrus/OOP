using System.Text;

namespace Project;

public class Matrix {
    public int[,] Data { get; }

    public int Rows { get; }
    public int Columns { get; }

    public int this[int row, int column] {
        get => Data[row, column];
        set => Data[row, column] = value;
    }

    public Matrix(int rows, int columns) { 
        if (rows < 0) throw new ArgumentException("Rows must be positive.", nameof(rows));
        if (columns < 0) throw new ArgumentException("Columns must be positive.", nameof(columns));

        Data = new int[rows, columns];

        Rows = rows;
        Columns = columns;
    }

    public static Matrix FromInitialData(int[,] data) {
        Matrix m = new(data.GetLength(0), data.GetLength(1));
        Array.Copy(data, m.Data, data.Length);

        return m;
    }

    public static Matrix operator +(Matrix a, Matrix b) {
        if (a.Rows != b.Rows || a.Columns != b.Columns) {
            throw new ArgumentException("Matrices must have the same dimensions for addition.");
        }

        var result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++) {
            for (int j = 0; j < a.Columns; j++) {
                result.Data[i, j] = a.Data[i, j] + b.Data[i, j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix m, int number) {
        var result = new Matrix(m.Rows, m.Columns);

        for (int i = 0; i < m.Rows; i++) {
            for (int j = 0; j < m.Columns; j++) {
                result.Data[i, j] = m.Data[i, j] * number;
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b) {
        if (a.Columns != b.Rows) {
            throw new ArgumentException("Number of columns in the first matrix must equal the number of rows in the second matrix for multiplication.");
        }

        var result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++) {
            for (int j = 0; j < b.Columns; j++) {
                for (int k = 0; k < a.Columns; k++) {
                    result.Data[i, j] += a.Data[i, k] * b.Data[k, j];
                }
            }
        }

        return result;
    }

    public static bool operator ==(Matrix a, Matrix b) {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        if (a.Rows != b.Rows || a.Columns != b.Columns) return false;

        for (int i = 0; i < a.Rows; i++) {
            for (int j = 0; j < a.Columns; j++) {
                if (a.Data[i, j] != b.Data[i, j]) return false;
            }
        }

        return true;
    }
    
    public static bool operator !=(Matrix a, Matrix b) {
        return !(a == b);
    }

    public override bool Equals(object? obj) => obj is Matrix matrix && this == matrix;

    public override string ToString() {
        StringBuilder sb = new();

        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                sb.Append(Data[i, j]);
                if (j < Columns - 1) sb.Append(" ");
            }
            if (i < Rows - 1) sb.AppendLine();
        }

        return sb.ToString();
    }

    public override int GetHashCode() => HashCode.Combine(Data, Rows, Columns);
}