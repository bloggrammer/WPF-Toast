using System;
using System.Windows;
using WPF.Toast.Enums;

namespace WPF.Toast.Utils {
    public static class PositionCalculator {

        public static Tuple<double,double> GetFromWindow(Positions position, double width, double height, Thickness borderThickness) 
        {
            var workAreaRectangle = SystemParameters.WorkArea;
            return Calculate(position, width, height, borderThickness, workAreaRectangle);
        }

        public static Tuple<double, double> GetFromOwner(Rect workArea, Positions position, double width, double height, Thickness borderThickness)
        {
            return Calculate(position, width, height, borderThickness, workArea);
        }

        private static Tuple<double, double> Calculate(Positions position, double width, double height, Thickness borderThickness, Rect workAreaRectangle)
        {
            double top, left;
            switch (position) {
                case Positions.East:
                    left = workAreaRectangle.Right - width - borderThickness.Right;
                    top = (workAreaRectangle.Bottom / 2) - (height / 2) - borderThickness.Bottom;
                    break;
                case Positions.West:
                    left = workAreaRectangle.Left + borderThickness.Right;
                    top = (workAreaRectangle.Bottom / 2) - (height / 2) - borderThickness.Bottom;
                    break;
                case Positions.North:
                    left = (workAreaRectangle.Right / 2) - (width / 2) - borderThickness.Right;
                    top = workAreaRectangle.Top + borderThickness.Bottom;
                    break;
                case Positions.South:
                    left = (workAreaRectangle.Right / 2) - (width / 2) - borderThickness.Right;
                    top = workAreaRectangle.Bottom - height - borderThickness.Bottom;
                    break;
                case Positions.Central:
                    left = (workAreaRectangle.Right / 2) - (width / 2) - borderThickness.Right;
                    top = (workAreaRectangle.Bottom / 2) - (height / 2) - borderThickness.Bottom;
                    break;
                case Positions.NorthEast:
                    left = workAreaRectangle.Right - width - borderThickness.Right;
                    top = workAreaRectangle.Top + borderThickness.Bottom;
                    break;
                case Positions.NorthWest:
                    left = workAreaRectangle.Left + borderThickness.Right;
                    top = workAreaRectangle.Top + borderThickness.Bottom;
                    break;
                case Positions.SouthEast:
                    left = workAreaRectangle.Right - width - borderThickness.Right;
                    top = workAreaRectangle.Bottom - height - borderThickness.Bottom;
                    break;
                case Positions.SouthWest:
                    left = workAreaRectangle.Left + borderThickness.Right;
                    top = workAreaRectangle.Bottom - height - borderThickness.Bottom;
                    break;
                default:
                    left = workAreaRectangle.Right - width - borderThickness.Right;
                    top = workAreaRectangle.Bottom - height - borderThickness.Bottom;
                    break;
            }

            return Tuple.Create(top, left);
        }
    }
}
