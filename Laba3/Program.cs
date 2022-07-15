using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    class Program
    {
        static double[] x=new double[200];
        static double[] y = new double[200];
        static double gamma = 2;
        static double m = 5.5;
        static double[] Range = new double[5];
        static double min;
        static double max;
        static double[] f = new double[200];
        static int split = 5;

        static void Main(string[] args)
        {
            Lottery();
            min = Math.Round(y.Min());
            max = Math.Round(y.Max())+1;
            _Range(split, y);
            Out(Range);
            Range = new double[5];
            _Range(split,f);
            Out(Range);
            
            Out(x);
            Out(y);
            
            Plotnost();
            Out(f);
        }

        static void Lottery()
        {
            Random r = new Random();
            
            for(int i=0;i<x.Length;i++)
            {
                double sum = 0;
                for(int j=0;j<12;j++)
                {
                    sum += r.NextDouble();
                }
                x[i] = sum - 6;
                y[i] = gamma * x[i] + m;
            }
        }

        static double[] _Range(int splitter, double[] arr)
        {
            double n = (min + max) / splitter;
            double r = min;
            double l = min + n;
            for (int i=0;i<Range.Length;i++)
            {
                for(int j=0;j<arr.Length;j++)
                {
                    if(r<arr[j] && arr[j]<l)
                    {
                        Range[i]++;
                    }
                }
                r = l;
                l = l + n;
            }
            return arr;
        }

        static void Out(Array arr)
        {
            int i = 0;
            foreach(var e in arr)
            {
                //Console.WriteLine(i+") "+e);
                //i++;
                Console.WriteLine( e);
            }
            Console.WriteLine();
        }

        static void Plotnost()
        {
            for(int i=0;i<y.Length;i++)
            {
                f[i] = Math.Exp( (Math.Pow((x[i] - m), 2)/((-2)*Math.Pow(gamma,2))) )/(Math.Pow(2*Math.PI,0.5)*gamma);
            }
        }
    }
}
