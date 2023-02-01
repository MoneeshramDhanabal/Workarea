using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Charts;

namespace SfChartTrackball
{
    public class CustomTrackBallBehavior : ChartTrackBallBehavior
    {

        bool isReleased = true;
        bool eventsActive = true;
        bool isDoubleClick = false;
        SfChart area;
        public SolidColorBrush tooltipbgcolorbrush = new SolidColorBrush(Colors.LightYellow);
        public SolidColorBrush tooltipforcolorbrush = new SolidColorBrush(Colors.Blue);
        public ToolTip lockedcursortooltip = new ToolTip();
        private double xValue, yValue;
        private bool islocked = false;





        public SfChart Area
        {
            get
            {
                return area;
            }
            set
            {
                if (value != null)
                {
                    area = value;
                    area.MouseRightButtonDown += OnMouseRightButtonDown; //Unlock the track ball
                }
            }
        }


        public void ShowTrackBall(Point point)
        {
            try
            {
                IsActivated = true;
                OnPointerPositionChanged(point);
            }
            catch (Exception ex)
            {
                //NWSLogger.Logger.Error("Error in ShowTrackBall: ", ex);
            }

        }

        public void ChangePosition(Point newPoint)
        {
            try
            {
                IsActivated = true;
            }
            catch (Exception ex)
            {
                //NWSLogger.Logger.Error("Error in ChangePosition: ", ex);
            }
        }

        public void StopEvents()
        {
            eventsActive = false;
        }

        public void StartEvents()
        {
            eventsActive = true;
        }

        public void StopCursorPosition()
        {
            try
            {
                if (isDoubleClick) return;
                IsActivated = true;
                isReleased = false;

            }
            catch (Exception ex)
            {
                //NWSLogger.Logger.Error("Error in StopCursorPosition: ", ex);
            }
        }

        void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eventsActive)
            {
                try
                {
                    IsActivated = false;
                    isReleased = true;
                    isDoubleClick = true;
                    SfChart chart = e.Source as SfChart;

                    GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);


                }
                catch (Exception ex)
                {
                    //NWSLogger.Logger.Error("Error in OnMouseRightButtonDown: ", ex);
                }
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            //if (eventsActive)
            //{
            //    try
            //    {
            //        SfChart chart = e.Source as SfChart;
            //        if (isReleased)
            //        {
            //            isReleased = false;
            //            IsActivated = true;



            //            GlobalFunctions.ShowTooltip(ref lockedcursortooltip, true, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
            //        }

            //        if (isReleased == false)
            //        {
            //            isReleased = true;
            //            IsActivated = true;
            //            //base.OnMouseMove(e);
            //            //Stores the point value to relock the track ball in another position.
            //            var point = new Point
            //            {
            //                X = e.GetPosition(this.AdorningCanvas).X - Area.SeriesClipRect.Left,
            //                Y = e.GetPosition(this.AdorningCanvas).Y - Area.SeriesClipRect.Top
            //            };
            //            xValue = Area.PointToValue(Area.PrimaryAxis, point);
            //            yValue = Area.PointToValue(Area.SecondaryAxis, point);
            //            isReleased = false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //NWSLogger.Logger.Error("Error in OnMouseLeftButtonDown: ", ex);
            //    }
            //}
            var chart = Area = e.Source as SfChart;
            ViewModel vm = (ViewModel)chart.DataContext;

            islocked = !islocked;
            
            // To get store the pointer value before locking the track ball
            var point = new Point
            {
                X = e.GetPosition(this.AdorningCanvas).X - Area.SeriesClipRect.Left,
                Y = e.GetPosition(this.AdorningCanvas).Y - Area.SeriesClipRect.Top
            };

            xValue = Area.PointToValue(Area.PrimaryAxis, point);
            yValue = Area.PointToValue(Area.SecondaryAxis, point);

            if (islocked)
            {
                foreach (var annotation in chart.Annotations)
                {
                    annotation.Visibility = Visibility.Visible;
                    vm.AnnotationX = Math.Round(xValue);
                    if (annotation is TextAnnotation)
                    {
                        vm.AnnotationTxt = "" + Math.Round(xValue);
                    }
                }
            }
            else
            {
                foreach (var annotation in chart.Annotations)
                {
                    annotation.Visibility = Visibility.Collapsed;
                }
                GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var chart = Area = e.Source as SfChart;
            // To get store the pointer value before locking the track ball
            var point = new Point
            {
                X = e.GetPosition(this.AdorningCanvas).X - Area.SeriesClipRect.Left,
                Y = e.GetPosition(this.AdorningCanvas).Y - Area.SeriesClipRect.Top
            };

            if (ChartArea.SeriesClipRect.Contains(point)) // Move the track ball only when cursor is within the Chart area.
            {
                if (islocked)
                {
                    GlobalFunctions.ShowTooltip(ref lockedcursortooltip, true, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
                }
                else
                {
                    base.OnMouseMove(e);
                }
            }
        }

        //protected override void OnMouseLeave(MouseEventArgs e)
        //{
        //    if (eventsActive)
        //    {
        //        try
        //        {
        //            if (!isReleased)
        //                IsActivated = true;
        //            SfChart chart = e.Source as SfChart;
        //            GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
        //        }
        //        catch (Exception ex)
        //        {
        //            //NWSLogger.Logger.Error("Error in OnMouseLeave: ", ex);
        //        }
        //    }
        //}


        //protected override void OnMouseEnter(MouseEventArgs e)
        //{
        //    if (eventsActive)
        //    {
        //        try
        //        {

        //            SfChart chart = e.Source as SfChart;
        //            GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
        //        }
        //        catch (Exception ex)
        //        {
        //            //NWSLogger.Logger.Error("Error in OnMouseLeave: ", ex);
        //        }
        //    }
        //}

        // Method to Update the trackball position in SfTrackballBehavior.
        //private void UpdatePosition()
        //{
        //    double xPoint = Area.ValueToPoint(Area.PrimaryAxis, xValue);
        //    double yPoint = Area.ValueToPoint(Area.SecondaryAxis, yValue);
        //    OnPointerPositionChanged(new Point(xPoint, yPoint));
        //}
    }

    internal class Constants
    {
        public const string TXTCURSORLOCKED = "TXT_Cursor_Locked";
    }

    public class GlobalFunctions
    {
        public static void ShowTooltip(ref ToolTip tooltip, bool IsOpen, ref SfChart chart, ref SolidColorBrush tooltipbgcolorbrush, ref SolidColorBrush tooltipforcolorbrush, string languageTextId)
        {
            try
            {
                if (!IsOpen)
                {
                    tooltip.IsOpen = false;

                    if (chart != null)
                        chart.ToolTip = null;//Added to instantly remove tool tip
                }
                else
                {
                    tooltip.IsOpen = false;
                    tooltip.IsOpen = true;
                    tooltip.Background = tooltipbgcolorbrush;
                    tooltip.Foreground = tooltipforcolorbrush;
                    tooltip.Content = "TXT_" + languageTextId;

                    if (chart != null)
                        chart.ToolTip = tooltip;
                }

            }
            catch (Exception ex)
            {
                //NWSLogger.Logger.Error("Error in ShowTooltip: ", ex);
            }

        }
    }
}
