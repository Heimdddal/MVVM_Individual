using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Individual
{
    public class Matrix
    {
        public int matrixSize { get; set; }
        private int[,] matrix;

        public Matrix Matrix1;
        public Matrix Matrix2;
        public int matrixMultiplier { get; set; }

        public Matrix(int matrixSize)
        {
            this.matrixSize = matrixSize;
            this.matrix = new int[matrixSize, matrixSize];
            generateMembers();
        }

        public Matrix()
        {
            matrixMultiplier = 1;
        }

        public Matrix(int[,] matrix)
        {
            matrixSize = matrix.GetLength(0);
            this.matrix = matrix;
        }

        public void createTwoMatrix()
        {
            Matrix1 = new Matrix(matrixSize);
            Matrix2 = new Matrix(matrixSize);
            Matrix1.generateMembers();
            Matrix2.generateMembers();
        }

        private void generateMembers()
        {
            var rand = new Random();
            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = rand.Next(0, 10);
                }
            }

            Thread.Sleep(20);
        }

        public int sumOfElements()
        {
            int sum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    sum += Matrix1.matrix[i, j];
                }
            }
            Console.WriteLine(sum);
            return sum;
        }

        public string Show()
        {
            var result = "";
            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    result += $"{matrix[i, j]}\t";
                }
                result += '\n';
            }
            return result;
        }

        private static int multiplySupport(int indexI, int indexJ, Matrix mat1, Matrix mat2)
        {
            int count = 0;
            int buffer = 0;
            while (count < mat1.matrixSize)
            {
                buffer += mat1.matrix[indexI, count] * mat2.matrix[count, indexJ];
                count++;
            }
            return buffer;
        }

        public Matrix Add()
        {

            var result = new Matrix(matrixSize);

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    result.matrix[i, j] = Matrix1.matrix[i, j] + Matrix2.matrix[i, j];
                }
            }

            return result;
        }

        public Matrix Subtract()
        {

            var result = new Matrix(matrixSize);

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    result.matrix[i, j] = Matrix1.matrix[i, j] - Matrix2.matrix[i, j];
                }
            }
            return result;
        }

        public Matrix MultiplyByNumber()
        {
            var result = new Matrix(matrixSize);

            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    result.matrix[i, j] = Matrix1.matrix[i, j] * matrixMultiplier;
                }
            }

            return result;
        }

        public Matrix Multiply()
        {
            var result = new Matrix(matrixSize);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.matrix[i, j] = multiplySupport(i, j, Matrix1, Matrix2);
                }
            }
            return result;
        }
    }
}
