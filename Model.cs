using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace MVVM_Individual
{
    internal class Model : INotifyPropertyChanged
    {
        private Matrix matrix = new Matrix();

        public Model()
        {
            matrix.createTwoMatrix();   
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void UseFunction(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                OnPropertyChanged(names[i]);
            }
        }

        public int MatrixSize
        {
            get { return matrix.matrixSize; }
            set
            {
                if (value >= 0)
                {
                    matrix.matrixSize = value;
                    matrix.createTwoMatrix();
                    UseFunction(["Matrix1", "Matrix2", "SumOfElements", "AddMatrix", "SubMatrix", "MulMatrix", "MultiplyByNumber"]);
                }
            }
        }

        public int MatrixMultiplier
        {
            get { return matrix.matrixMultiplier; }
            set
            {
                if(value is int)
                {
                    matrix.matrixMultiplier = value;
                    UseFunction(["MultiplyByNumber"]);
                }   
            }
        }

        public string Matrix1
        {
            get { return matrix.Matrix1.Show(); }
        }

        public string Matrix2
        {
            get { return matrix.Matrix2.Show(); }
        }

        public string SumOfElements
        {
            get { return matrix.sumOfElements().ToString(); }
        }

        public string AddMatrix
        {
            get { return matrix.Add().Show(); }
        }

        public string SubMatrix
        {
            get { return matrix.Subtract().Show(); }
        }
        public string MulMatrix
        {
            get { return matrix.Multiply().Show(); }
        }

        public string MultiplyByNumber
        {
            get { return matrix.MultiplyByNumber().Show(); }
        }
    }
}
