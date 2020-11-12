using System;
using System.Collections.Generic;

namespace Семестр_5_методы_вычислений_лаба_1
{
    class Program
    {
        static void Main(string[] args)
        {
            grad_descent_method gdm = new grad_descent_method();
            int  step=0;
            double eps = 0.0001, alpha0 = 1, x0 = 0, y0 = 0, dx, dy;          
            double f0 = gdm.function(x0, y0);
            dx = Math.Abs(gdm.df_dx(x0, y0));
            dy = Math.Abs(gdm.df_dy(x0, y0));

            while ((dx >= eps / 2) && (dy >= eps / 2))
            {
                gdm.list_df_dx.Add(dx);
                gdm.list__df_dy.Add(dy);
                double x1 = gdm.New_coord_x(x0, y0, alpha0);
                double y1 = gdm.New_coord_y(x0, y0, alpha0);
                double f1 = gdm.function(x1, y1);
                if (f0 < f1)
                {
                    alpha0 = alpha0 / 2;
                    x0 = gdm.New_coord_x(x0, y0, alpha0);
                    y0 = gdm.New_coord_y(x0, y0, alpha0);
                    f0 = gdm.function(x0, y0);
                    gdm.list_f_x_y.Add(f0);
                    gdm.list_x.Add(x0);
                    gdm.list_y.Add(y0);
                    gdm.list_alpha.Add(alpha0);
                    step++;
                }

                else if (f0 > f1)
                {
                    gdm.list_f_x_y.Add(f0);
                    gdm.list_x.Add(x1);
                    gdm.list_y.Add(y1);
                    gdm.list_alpha.Add(alpha0);
                    f0 = f1; x0 = x1; y0 = y1;
                    step++;
                }
                dx = Math.Abs(gdm.df_dx(x0, y0));
                dy = Math.Abs(gdm.df_dy(x0, y0));
            }

            for (int i = 0; i < step; i++)
            {
                Console.WriteLine("x= " + gdm.list_x[i] + " " + 
                                  "y= " + gdm.list_y[i] + " " + 
                                  "f(x,y)= " + gdm.list_f_x_y[i] + " " + 
                                  "alpha= " + gdm.list_alpha[i] + " " + 
                                  "df/dx= " + gdm.list_df_dx[i] + " " + 
                                  "df/dy= " + gdm.list__df_dy[i] + " ");
            }
        }
        
    }
}
