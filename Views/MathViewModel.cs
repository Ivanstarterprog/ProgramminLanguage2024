using OxyPlot;
using ProgrammingLanguage2024.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ProgrammingLanguage2024.Views
{
    public class MathViewModel : BaseViewModel
    {
        BaseNumericalMethod method = new GoldenRatioMethod();

        private string _chosenMethod = "G";
        public string ChosenMethod
        {
            get { return _chosenMethod; }
            set
            {
                _chosenMethod = value;
                switch (_chosenMethod)
                {
                    case "G":
                        method = new GoldenRatioMethod();
                        break;
                }
                Set(ref _chosenMethod, value);
            }
        }

        private string _minMax = "False";
        public string MinMax
        {
            get { return _minMax; }
            set
            {
                _minMax = value;
                Set(ref _minMax, value);
            }
        }


        public string FunctionString
        {
            get { return method.FunctionString; }
            set
            {
                method.FunctionString = value;
                OnPropertyChanged(nameof(method.FunctionString));
            }
        }

        public double BeginInterval
        {
            get { return method.BeginInterval; }
            set
            {
                method.BeginInterval = value;
                OnPropertyChanged(nameof(method.BeginInterval));
            }
        }

        public double A
        {
            get { return method.A; }
            set
            {
                method.A = Convert.ToDouble(value);
                OnPropertyChanged(nameof(method.A));
            }
        }

        public double B
        {
            get { return method.B; }
            set
            {
                method.B = Convert.ToDouble(value);
                OnPropertyChanged(nameof(method.B));
            }
        }

        public double Epsilon
        {
            get { return method.Epsilon; }
            set
            {
                method.Epsilon = Convert.ToDouble(value);
                OnPropertyChanged(nameof(method.Epsilon));
            }
        }

        public double EndInterval
        {
            get { return method.EndInterval; }
            set
            {
                method.EndInterval = value;
                OnPropertyChanged(nameof(method.EndInterval));
            }
        }

        private string _result = "Пока здесь ничего нет...";
        public string Result
        {
            get { return _result; }
            set
            {
                Set(ref _result, value);
            }
        }
        public PlotModel Plot
        {
            get { return method.Graph; }
            set
            {
                Set(ref method.Graph, value);
            }
        }

        public ICommand CalculateResult
        {
            get
            {

                return new DelegateCommand((obj) =>
                {
                    if (_minMax.ToString() == "False")
                    {
                        Result = method.CalculateMinResult();
                    }
                    else
                    {
                        Result = method.CalculateMaxResult();
                    }
                });
            }
        }

        public ICommand CalculateFunction
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Plot = method.CalculateGraph();
                });
            }
        }

        public ICommand ClearFields
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    FunctionString = "";
                    A = 0;
                    B = 0;
                    Epsilon = 0;
                });
            }
        }
    }
}
