   M S B A M L   `   `   `  ????K  GSfChartTrackball, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SfChartTrackballSfChartTrackball  5   	   !    SfChartTrackball.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SfChartTrackball     5   	   b ^Syncfusion.SfChart.WPF, Version=20.4460.0.41, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
syncfusion!http://schemas.syncfusion.com/wpf  5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)    ? 	Resources 5
         TrackballTemplate ?? 
TargetType5  /Syncfusion.UI.Xaml.Charts.ChartTrackBallControl ?? Property ?? Value ?? 
TargetType   Stroke   StrokeThickness  	lineStyle  ScatterTrackBall ?? Mode	 ?? UpdateSourceTrigger??%?  &	        &	 .    &	 ?    ?? 5   
   "  5      .?5      ??  ? ??$ 1??5      6!   ?? 5       ? ??$ 1??5      6!   ?? 5       ? ?? 5      ?? 5      "  6&   .R?5      A? 
??? ???#??z 5   "   #??z??5   "   #??z??5   "   #??z 5   "   6X   5      5      5      ?? 5   
   " ??6   .?5      ??  ? ??
 ??  ?5       ?? 5!       ? ??$ 1??5"      5#      ?? 5$   
   .R?5%      ?? .+?5&      ?? -   5        $y?Hidden=?5'      ??5&      ?? *ValueX+$ TwoWay=?$	 PropertyChanged=?5(      ?? 5)      $??5q?5*      
?????????5)      ?? *ValueY+5+      5,      5.      5/      .??50      ? 
 ? RowDefinitions
 52   
   ?? 53      $??* ?6    ? ColumnDefinitions 55   
   ?? 56      $??8* ?6   ?? 57      $??2* ?6   .+?59   
   '  !Syncfusion.UI.Xaml.Charts.SfChart  $??0??6      	Behaviors 5;      .   (SfChartTrackball.CustomTrackBallBehavior  -   5        	behaviour??6  0Syncfusion.UI.Xaml.Charts.ChartTrackBallBehavior   ChartTrackBallStyle# [  5<   0      AxisLabelAlignment$ Center=?5=   0      LabelHorizontalAlignment$
 Near=?5>   0      LabelVerticalAlignment$
 Near=?5?   0      	LineStyle# [ 5@   0   ?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$ 
Horizontal=?5A   0   1  +System.Diagnostics.PresentationTraceSources   
TraceLevel$
 None=?5B   0   5C   3   4  .Syncfusion.UI.Xaml.Charts.ChartZoomPanBehavior  5D         EnableZoomingToolBar . 62      PrimaryAxis 5F      -  'Syncfusion.UI.Xaml.Charts.NumericalAxis  5G      /	  )Syncfusion.UI.Xaml.Charts.ChartAxisBase2D 	  EnableScrollBar . 6D      SecondaryAxis 5I        5J         Maximum$ 40X?6+      Minimum$ 0X?68   6F      Annotations 5M      6
  0Syncfusion.UI.Xaml.Charts.VerticalLineAnnotation
  -   5         
 Name$
 line??5M   4   $y?	Collapsed=?6]   *  $Syncfusion.UI.Xaml.Charts.Annotation	   X1 6B   ?? *AnnotationX+6]   .  (Syncfusion.UI.Xaml.Charts.TextAnnotation  5N      -   5          Name$
 view??5N   ,   	   Y1$ 20??6U   $y?	Collapsed=?6|    6:   ?? *AnnotationX+   Text 6]   ?? *AnnotationTxt+6|       Series.  5P      7  1Syncfusion.UI.Xaml.Charts.FastScatterBitmapSeries  /  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase!   XBindingPath$! XValue??5Q   1   ,  &Syncfusion.UI.Xaml.Charts.XyDataSeries"   YBindingPath$" YValue??5R   1   #   TrackBallLabelTemplate## [ 5S   1   $   ScatterHeight$$ 10Q?5T   1   %   ScatterWidth$% 10Q?5U   1   &   ItemsSource& 5P   1   ?? *	ChartData+5U   E   5V      ?? 5X   
   $??1??6   .+?5Y      ?? -   5        $??	PointerUp??5Y      $??40??6)   $	??150??65   6A   ?? 5Z      -   5        $??PointerDown??5Z      $??40??6+   $	??150??67   6C   ?? 5[      -   5        $??LastTrackball??5[      $??40??6-   $	??150??69   6E   5\      5]      5^      