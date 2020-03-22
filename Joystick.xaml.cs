using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Drawing.Drawing2D;


namespace HomeWork
{
    public partial class Joystick
    {
        public double x1 { set; get; }
        public double y1 { set; get; }

        private double initX;
        private double initY;

        public bool mouseIsPressed = false;
        public bool mouseReturn = false;


        public Joystick()
        {
           InitializeComponent();
            initX = this.knobPosition.X;  
            initY = this.knobPosition.Y;
            



        }

        private void MouseLeftDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mouseIsPressed = true;
            
        }


        void centerKnob_Completed(object sender, EventArgs e)
        {

        }
        private void MouseMove_J(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point position = e.GetPosition(dummy_centre);

            x1 = position.X;
            y1 = position.Y;
            double radius_Small = KnobBase.Height / 2;
            double radius = OuttestEllipse.Width / 2;




            if (mouseIsPressed)
            {

                bool checkBoard = (Math.Pow(x1 + knobPosition.X  - initX, 2) + 
                    Math.Pow(y1 + knobPosition.Y - initY, 2)) <= Math.Pow(radius - radius_Small + 50, 2);
                if (checkBoard)
                {
                    knobPosition.X += x1;
                    knobPosition.Y += y1;
   
                }
                else
                {
                    mouseReturn = true;
                   //ellipse_part_3.Height = 900;
                }
            }
        }
        public void SetPiptickToCenter()
        {
            knobPosition.X = initX;
            knobPosition.Y = initY;
        }

        private void MouseReturnToJOY(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(dummy_centre);
             
            //Point position = e.GetPosition(Base);
            if (mouseIsPressed)
            {
                knobPosition.X -= -position.X ;
                knobPosition.Y -= -position.Y ;
            }
        }
    }

   

}

