using OxyPlot;
using ProgrammingLanguage2024.Integrals;
using ProgrammingLanguage2024.Libraries;
using ProgrammingLanguage2024.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProgrammingLanguage2024.Integrals
{
    abstract public class BaseSquaresIntegralClass : BaseIntegralClass
    {
        public BaseSquaresIntegralClass()
        {
            Description = "Метод численного интегрирования функции одной переменной, заключающийся в замене подынтегральной " +
                "функции на многочлен нулевой степени, то есть константу, на каждом элементарном отрезке";
        }
        protected override void AddSubdivision(double x1, double y1, double x2, double y2)
        {
            _subdivisionPoints.Add(new DataPoint(x1, y1));
            _subdivisionPoints.Add(new DataPoint(x1, y2));
            _subdivisionPoints.Add(new DataPoint(x2, y2));
            _subdivisionPoints.Add(new DataPoint(x2, y1));
        }

        public override double CalculateResult(string functionString, double b, double a, double subdivisionLength, double epsilon)
        {
            double step = (b - a) / subdivisionLength;
            double sum = SumFromLoop(subdivisionLength, a, step, functionString);

            sum *= step;

            return sum;
        }
    }
}

public class MiddleSquareIntegralClass : BaseSquaresIntegralClass
{
    public MiddleSquareIntegralClass() : base()
    {
        Title = "Метод средних прямоугольников";
        Description += " Высоты прямоугольников равны значениям функции в серединах промежуточных отрезков. Простейший из методов и наиболее точный";
        GraphColor = ColorConfig.GetColor("MiddleSquare");
    }

    protected override double BodyOfLoop(double x, double step, string functionString, double sum)
    {
        double newX = x + (step / 2);
        double y = OxyHelper.GetResultFromFunction(functionString, newX);
        AddSubdivision(x, 0, x + step, y);

        sum += y;
        return sum;
    }
}

public class LeftSquareIntegralClass : BaseSquaresIntegralClass
{
    public LeftSquareIntegralClass() : base()
    {
        Title = "Метод левых прямоугольников";
        Description += "Высоты прямоугольников равны значениям функции в левых концах промежуточных отрезков";
        GraphColor = ColorConfig.GetColor("LeftSquare");
    }

    protected override double BodyOfLoop(double x, double step, string functionString, double sum)
    {
        double y = OxyHelper.GetResultFromFunction(functionString, x);
        AddSubdivision(x, 0, x + step, y);

        sum += y;
        return sum;
    }
}

public class RightSquareIntegralClass : BaseSquaresIntegralClass
{
    public RightSquareIntegralClass() : base()
    {
        Title = "Метод правых прямоугольников";
        Description += "Высоты прямоугольников равны значениям функции в правых концах промежуточных отрезков";
        GraphColor = ColorConfig.GetColor("RightSquare");
    }

    protected override double BodyOfLoop(double x, double step, string functionString, double sum)
    {
        double newX = x + step;
        double y = OxyHelper.GetResultFromFunction(functionString, newX);
        AddSubdivision(x, 0, x + step, y);

        sum += y;
        return sum;
    }
}
