using System;
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





        public SfChart Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
                area.MouseRightButtonDown += OnMouseRightButtonDown;
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
            if (eventsActive)
            {
                try
                {
                    SfChart chart = e.Source as SfChart;
                    if (isReleased)
                    {
                        isReleased = false;
                        IsActivated = true;



                        GlobalFunctions.ShowTooltip(ref lockedcursortooltip, true, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
                    }

                    if (isReleased == false)
                    {
                        isReleased = true;
                        IsActivated = true;
                        base.OnMouseMove(e);
                        isReleased = false;
                    }
                }
                catch (Exception ex)
                {
                    //NWSLogger.Logger.Error("Error in OnMouseLeftButtonDown: ", ex);
                }
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (eventsActive)
            {
                try
                {
                    IsActivated = true;
                    isReleased = false;
                }
                catch (Exception ex)
                {
                    //NWSLogger.Logger.Error("Error in OnMouseLeftButtonUp: ", ex);
                }
            }
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (eventsActive)
            {
                try
                {
                    SfChart chart = e.Source as SfChart;
                    if (isReleased)
                    {

                        base.OnMouseMove(e);
                        IsActivated = true;

                        GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);

                    }
                    else
                    {
                        GlobalFunctions.ShowTooltip(ref lockedcursortooltip, true, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
                    }
                }
                catch (Exception ex)
                {
                    //NWSLogger.Logger.Error("Error in OnMouseMove: ", ex);
                }
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            if (eventsActive)
            {
                try
                {
                    if (!isReleased)
                        IsActivated = true;
                    SfChart chart = e.Source as SfChart;
                    GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
                }
                catch (Exception ex)
                {
                    //NWSLogger.Logger.Error("Error in OnMouseLeave: ", ex);
                }
            }
        }


        protected override void OnMouseEnter(MouseEventArgs e)
        {
            if (eventsActive)
            {
                try
                {

                    SfChart chart = e.Source as SfChart;
                    GlobalFunctions.ShowTooltip(ref lockedcursortooltip, false, ref chart, ref tooltipbgcolorbrush, ref tooltipforcolorbrush, Constants.TXTCURSORLOCKED);
                }
                catch (Exception ex)
                {
                    //NWSLogger.Logger.Error("Error in OnMouseLeave: ", ex);
                }
            }
        }
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
