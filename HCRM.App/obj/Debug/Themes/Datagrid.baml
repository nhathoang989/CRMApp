   M S B A M L   `   `   `  ����U  QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a9  �� 
TargetType   BaseButtonStyle �� BasedOn �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� 
ResourceId �� Property �� ValueG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader J� IsHitTestVisible  ColumnHeaderGripperStyle �� Padding  RowHeaderGripperStyle  ColumnFloatingHeaderStyle " ColumnHeaderDropSeparatorStyle  DataGridDropSeparator	 J� SnapsToDevicePixels)  #System.Windows.Controls.DataGridRow
 ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation �� RelativeSource �� AncestorType �� Path#    RowDetailsScrollingConverter �� 	Converter;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter:  4System.Windows.Controls.Primitives.DataGridRowHeader!    HeadersVisibilityConverter7	  1System.Windows.Controls.DataGridHeadersVisibility
 	  Row �� Triggers P� Property P� Value  DataGridCellBackgroundHover*
  $System.Windows.Controls.DataGridCell  DataGridCellBackground  DataGridCellForeground �� Triggers 	 DataGridCellForegroundHover "
 DataGridCellBackgroundSelected " DataGridCellForegroundSelected  DataGridHeaderBackground  DataGridHeaderForeground  DefaultFontFamily  DefaultFontSize �Name F�Name �� Stretch  J� Opacity! J� RenderTransformOrigin" n�Name# �� 
TargetName$ �� Angle ! DataGridHeaderBackgroundHover ! DataGridHeaderForegroundHover # DataGridHeaderBackgroundPressed # DataGridHeaderForegroundPressed  DataGridGridLines% �� Orientation   BooleanToVisibilityConverter $  DataGridHeaderBackgroundSelected $  DataGridHeaderForegroundSelected  DataGridBackground  DataGridForeground&    SelectAllCommand
' 	  All( 	  Column) ��Name* �� CanContentScroll+ �� Orientation, �� ScrollableHeight- � Maximum. �� ViewportHeight/ �� ViewportSize*0 �� #ComputedVerticalScrollBarVisibility1 � Value2 �� Mode3 �� ScrollableWidth4 �� ViewportWidth,5 �� %ComputedHorizontalScrollBarVisibility�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0mui&http://firstfloorsoftware.com/ModernUI  5      %3#  (��       5      "   $" DataGridSelectAllButtonStyle��)7   '  n     &	 B    &	 X    &	 n    &	 �    '  �    '  -
    '
  �
    '  C    7  7  '  r    7  7  7  '       7  7  �� 6   "  ��6{   8   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � ��$ 0q�6,   5	      �� 5      "   6<   .�5   
   ��  � �� 5      �� 5      "  6"   .R�5      � .+�5        $��PART_FillerColumnHeader��6H    .  �� 5      5      5      5      5      �� 5      "  n�6-   .�5   
   ��  � ��$ 8��6"   �� 5   
    � ��
 ���� 6'   �� 5   
    �@�Cursor$ SizeWE��6#   �� 5   
    � �� 5      �� 5      " n�6"   .R�5       �� # z��6   #��z��5!      5"      5$      5%      �� 5'      "  n�6*   .�5(   
   ��  � ��$ 8��6#   �� 5)   
    � ��
 ���� 6'   �� 5*   
    �@�Cursor$ SizeNS��6#   �� 5+   
    � �� 5,      �� 5-      " n�6"   .R�5.      �� # z��6   #��z��5/      50      52      53      �� 55      "  ��6.   .�56   
   ��  �@J�Opacity$	 0.6Q�6$   62   �� 57   
    � ��$ 0q�6,   68   �� 58   
    � �� 59      �� 5:      " ��6"   .R�5;      �� #��z��6   #��z��5<      # z��5=      #��z��5>      ._�5?      � .+�5@      �� $��PART_VisualBrushCanvas��6%   $��10q�6C   5A      5B      5C      5E      5F      �� 5H      "  ��63   .�5I   
   ��  � ��# �  6'   �� 5J   
    � �� 5K      �� 5L      " ��6"   .R�5M      �� #��z��6   #��z��5N      #��z��5O      	 . 5Q      5R      5T      5U      �� 5W      "   6)   .�5X   
   ��  � ��
 ���� 6'   �� 5Y   
    �@J�SnapsToDevicePixels . 60   �� 5Z   
    �@=�ErrorTemplate 65   Z� �� 5[   
    �@ ValidationErrorTemplate 5\      �� 5]      .R�5^      �� $��2,0,0,0q�6    $��Center=�61   ���	#FFdc000c$��!��6c   5_      5a      �� 5b   
    � �� 5c      �� 5d      "  6"   .R�5e      �� $
 
DGR_Border��6   #��z��5f      #��z��5g      #��z��5h      	 . ._�5j         5k      �� 5l   "   $
��Auto �63   �� 5m   "   $��* �63    5p      �� 5q   "   $��* �60   �� 5r   "   $
��Auto �60   .+�5u        $��1��65   #��z 5v   5   #	 z	 5w   5     5y      $��1��5z   8   $��1��6H   #y�z 5{   8    5y   8   ��  �� "   $ AreRowDetailsFrozen�# Z # Z 5{   8     5}      $ Vertical=�60   $��2��5~   0   y�5   0   ��  �� "   $ HeadersVisibility�# Z # Z 5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� # �  6;    � ��5�      5�      5�      5�      �� 5�      "   64   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� 5�      5�      5�      �� 5�      "  
 6*   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$	 5,1q�6$   �� 5�   
    � �� 5�      �� 5�      " 
 6"   .R�5�      �� #��z��6   #��z��5�      #��z��5�      # z��5�      	 . ._�5�      �� #	 z	 6+   $��Center=�6g   $��5q�6�   5�      5�      5�       5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��# �  6/   �� 5�       � ��# � 	 6/   5�      P� 5�       �@
 
IsSelected . . �5�      ��  � ��# � 
 6/   �� 5�       � ��# �  6/   5�      5�      �� 5�      "   62   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$
 Bold"�6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��# �  6%   �� 5�   
    � ��$ 4,3,4,3q�6$   �� 5�   
    � ��$ Center=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � .+�5�      �� #��z��6!   #��z��5�   !   #��z��5�   !   # z��5�   !   ._�5�      � $ containerGrid��6#   $��5q�6:   $
��Left=�6E    5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� $��0��63   #��z��5�   3   #	 z	 5�   3   #��z��5�   3   F� 5�   "   $ 	SortArrow��6'   $��1��5�   '   $��Center=�5�   '   $��Center=�6D   $��8��5�   '   $��6��61   $��5,0,5,0q�6=   $
 Fill=�5�   '   $	  0.5Q�66   #��z��6D   $! 0.5,0.4&�5�   '   $y�Hidden=�5�   '   "����        �@B     � � @B 	5�   '   5�      5�      n� 5�      $" PART_LeftHeaderGripper��6    $
��Left=�5�       8��  5�       n� 5�      $" PART_RightHeaderGripper��6    $��Right=�5�       8�� 5�       5�       5�      P� 5�       �@ SortDirection$ 	AscendingX�6;   . �5�      �� $# 	SortArrow��6%    � y�$ Visible=�6R   �� 5�      $# 	SortArrow��6%    � z� 5�   "   �� 5�   &   $	$ 180Q�66   5�      5�      P� 5�       �@ SortDirection$ 
DescendingX�6;   . �5�      �� $# 	SortArrow��6%    � y�$ Visible=�6R   5�      5�      5�       5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��# �  6/   �� 5�       � ��# �  6/   5�      P� 5�       � �� . . �5�      ��  � ��# �  6/   �� 5�       � ��# �  6/   5�      5      �� 5     "   6/   .�5  
   ��  � ��# �  6'   �� 5  
    � ��# �  6'   �� 5  
    � ��# �  6(   �� 5  
    � ��$ 0,0,0,1q�6,   �� 5  
    � ��$ 16��6"   �� 5  
    � �� 5	     �� 5
     "  6"   .R�5     � .+�5     �� #��z��6!   #��z��5  !   #��z��5  !   # z��5  !   ._�5     �� $% 
Horizontal=�6)   .+�5  "   �� #	 z	 63   $��Center=�6o   �� 5  "   	 .  y�5  *   ��  �� "  $ (Validation.HasError)�8   ��5  *   ��  �� "  $ ValidationErrorTemplate�5     5     n� 5     $" PART_TopHeaderGripper��6    $	��Top=�5      8�� 5      n� 5     $" PART_BottomHeaderGripper��6    $��Bottom=�5      8�� 5      5     5     5!      5#  
   P� 5$      �@J�IsMouseOver . . �5%     ��  � ��# �  6/   �� 5&      � ��# �  6/   5'     P� 5(      � �� . . �5)     ��  � ��# �  6/   �� 5*      � ��# �  6/   5+     P� 5,      �@ IsRowSelected . . �5-     ��  � ��# �  6/   �� 5.      � ��# �  6/   5/     51     �� 53     "    6&   .�54  
   ��  � ��# �  6'   �� 55  
    � ��# �  6'   �� 56  
    � ��$ 0q�6,   �� 57  
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 58  
     �@  HorizontalGridLinesBrush# �  65   �� 59  
    �@  VerticalGridLinesBrush# �  63   �� 5:  
    �@  DragIndicatorStyle8   6/   �� 5;  
   " �@  DropLocationIndicatorStyle8  67   �� 5<  
    �@  GridLinesVisibility$ 
Horizontal=�60   �� 5=  
    � �� . 6:   �� 5>  
    �@��PanningMode$
 Both=�65   �� 5?  
    �@��IsFlicksEnabled .  63   �� 5A  
    � �� 5B     �� 5C     "   6"   .R�5D     �� #��z��6   #��z��5E     #��z��5F     	 . # z��5H     ._�5I     �� $��DG_ScrollViewer��69   |�.  ��5J     �� 5K  "   " ��62   .R�5L  &   �  5M  *   �� 5N  .   $
��Auto �6<   �� 5O  .   $��* �6<   �� 5P  .   $
��Auto �6<    5S  *   �� 5T  .   $
��Auto �6?   �� 5U  .   $��* �6?   �� 5V  .   $
��Auto �6?   .+�5Y  *   �� #��Z& 61   |�.  ��5Z  1   ��  �� "   $  CellsPanelHorizontalOffset���5[  1   C� *�� "   $" DataGridSelectAllButtonStyle��+y�5]  1   ��  �� "   $ HeadersVisibility�# Z # Z'   5^  *   $!��PART_ColumnHeadersPresenter��5_  I   $��1��5^  I   y�5`  I   ��  �� "   $ HeadersVisibility�# Z # Z( �� 5b  *   $!) PART_ScrollContentPresenter��6A   $��1��6f   $��2��6s   #* z��6�   �� 5d  *   $��PART_VerticalScrollBar��6Q   $��1��64   $��2��6A   $+ Vertical=�5e  4   #- z, 5f  4   #/ z. 5g  4   #y�z0 5i  4   1 5h  4   �� $ VerticalOffset� �� *TemplatedParent+$2 OneWay=�5i  4   � 5k  *   $��2��6/   $��1��6<    5l  .   �� 5m  2   ��6C   ��  �� "   $. (NonFrozenColumnsViewportHorizontalOffset��� 5n  2   $��* �6C   .+�5p  .   �� $��PART_HorizontalScrollBar��5q  8   $��1��5p  8   $+ 
Horizontal=�5r  8   #- z3 5s  8   #/ z4 5t  8   #y�z5 5v  8   1 5u  8   �� $ HorizontalOffset� �� *TemplatedParent+$2 OneWay=�5v  8   5x  +   5y  '   5z  #   .��5|     �� #	 z	 6-   5}     5~     5     5�      5�  
   P� 5�      �@��
IsGrouping . . �5�     ��  � �� .  6B   5�     5�     5�     