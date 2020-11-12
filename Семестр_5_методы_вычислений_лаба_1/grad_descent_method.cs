using System;
using System.Collections.Generic;
using System.Text;



namespace Семестр_5_методы_вычислений_лаба_1
{
    class grad_descent_method
    {
        public List<double> list_x = new List<double>();
        public List<double> list_y = new List<double>();
        public List<double> list_f_x_y = new List<double>();
        public List<double> list_df_dx = new List<double>();
        public List<double> list__df_dy = new List<double>();
        public List<double> list_alpha = new List<double>();
        private double a = 2, b = -1.3, c = 0.04, d= 0.12 ;
        //private double a = 3, b = -1.2, c = 0.02, d = 0.13;

        public grad_descent_method() 
        {
            
        } 
        public double New_coord_x(double x, double y, double alpha)
        {
            double _x = x - alpha * df_dx(x,y);
            return _x;
        }

        public double New_coord_y(double x, double y, double alpha)
        {
            double _y = y - alpha * df_dy(x,y);
            return _y;
        }

        public double function(double x, double y)
        {
            double func = a * x + b* y + Math.Exp(c* x * x + d* y * y);
            return func;
        }

        public double end_of_calculate(double x, double y)
        {
            double dx = 2 + 0.08 * x * Math.Exp(c * (x * x) + d* y * y);
            double dy = -1.3 + 0.24 * y * Math.Exp(0.04 * (x * x) + 0.12 * y * y);
            double df = Math.Pow(Math.Pow(dx, 2) + Math.Pow(dy, 2), 1 / 2);
            return df;
        }

        public double df_dx(double x, double y)
        {
            double df_dx = a + 2 * c * x * Math.Exp(c * (x * x) + d * y * y);
            return df_dx;
        }
        public double df_dy(double x, double y)
        {
            double df_dy = b + 2 * d * y * Math.Exp(c * (x * x) + d * y * y);
            return df_dy;
        }
        
    }
}
