   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5      C ?HCRM.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HCRM.App.Views.ConvertersHCRM.App.Views.Converters 5	      M+clr-namespace:HCRM.App.Views.CustomControlsHCRM.App.Views.CustomControls 5
      )   #HCRM.App.Pages.Products.ListProduct   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      7	converter'clr-namespace:HCRM.App.Views.Converters  5	      ?customControl+clr-namespace:HCRM.App.Views.CustomControls  5
      .��5      � .+�5   
   %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��busyIndicator��5          IsBusy  62   �� *IsBusy+   BusyContent 5      �� 5      .+�5      �� $��Center=�6    Please wait...6M   5      ��5      �� 5      .��5      �� -   5        $��rootForm��5   !   $	��500��61   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��20q�6>   .+�5      �� $��Tìm kiếm��6(      Heading2#��[  68   -   'System.Windows.Controls.AutoCompleteBox  5      $
��10 0q�67      ValueMemberPath$ Title��5   /      IsTextCompletionEnabled .    MinimumPrefixLength$ 1��5   /      MinimumPopulateDelay$	 100��5    /   $��Center=�5!   /   $	��200��5"   /      ItemsSource 5   E   �� *
Products+   
ItemFilter 5   /   �� *ProductFilter+	   SelectedItem	 5   /   �� *CurrentItem+
 �� Mode$
 OneWayToSource=�   ItemTemplate 5$   "   �� 5%   &   .R�5&   *   �� .+�5'   .   �� ��68   �� *Title+�� 5(   .   ��68   �� *
Material+5)   +   5*   '   5,      �� 5-      $��Tạo mới��6%   $
��Left=�6]   ��67   �� *NewProductCommand+6]   5.      � 5/      $
��Left=�6$    � Orientation$ 
Horizontal=�6?   .+�50      ��  � DataContext 6)   �� *PagingDataGrid+.+�51   "   &   System.Windows.Controls.DataGrid     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6+      AutoGenerateColumns .     	RowHeight$ 50Q�52         CanUserAddRows .     CanUserDeleteRows .  $��Center=�53      $��Center=�54      $	��300��55      ��51   Y   �� *
LstDisplay+ �� SelectedItem 6|   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" >� �� Path$ DataContext.CurrentItem� J� InputBindings 57   &   �� 58   *   
 �� Key$ Delete��65    �� Command 6B   �� *DeletePersonCommand+   Columns 5:   &   0  *System.Windows.Controls.DataGridTextColumn  5;   *   ,  &System.Windows.Controls.DataGridColumn   Header$
 Tên��6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *Title+4  .System.Windows.Controls.DataGridTemplateColumn  5<   *   $ Hình ảnh��6A      CellTemplate 5=   .   �� 5>   2   .R�5?   6   �� $
��Left=�6<   $��50��6p   ��6W   �� *Image+6p   5@   3   5B   +     5C   *   $ 	Tồn kho��6=    6N   �� *TotalRemain+  5D   *   $ 	Đã bán��6=    6M   �� *
TotalSaled+5G   #   5	  /HCRM.App.Views.CustomControls.PaginDataGridView	  5H   "   $
��Auto��6B   $��Center=�6P   5I      �� 5J      .+�5K   "   �� $��20q�6M   $	��150��6Y   ��6(   �� *CurrentItem.Image+6Y   5L      5M      �� 5N       6%   �� *CurrentItem+.+�5O      �� $��Chi tiết sản phẩm��6(   #��[  6B   $
��0 20q�6d   �� 5P      $ 
Horizontal=�6)   .+�5Q   "   �� $��Số lượng nhập��6,   $
��Bold"�6A   $��Center=�6S   $
��10 0q�6o   )
  #Xceed.Wpf.Toolkit.AutoSelectTextBox
  5R   "   ��69   �� *	IImport+�� 5T   "   $ 
Horizontal=�6-   .+�5U   &   �� $
��Lưu��6-     NormalButtonStyle#��[ 6;   $
��Left=�6�   $
��10 0q�6�   ��6f   �� *SaveCommand+6�   �� 5V   &   $
��Xóa��6-     RedButtonStyle#��[ 6;   $
��Left=�6�   $
��10 0q�6�   ��6c   �� *RemoveCommand+6�   5W   #   5X      � 5Y        	WrapInfos#��[ 6(   $ 
Horizontal=�6K   .+�5[   "   �� .+�5\   &   �� $��Mã sản phẩm��60   
  5]   &   ��6=   �� *Code+5^   #   �� 5`   "   .+�5a   &   �� $��Tên sản phẩm��60   
  5b   &   ��6=   �� *Title+5c   #   �� 5d   "   .+�5e   &   �� $��Xuất xứ��60   
  5f   &   ��6=   �� *Source+5g   #   �� 5h   "   .+�5i   &   �� $��	Quy cách��60   
  5j   &   ��6=   �� *Size+5k   #   �� 5l   "   .+�5m   &   �� $��Chất liệu��60   
  5n   &   ��6=   �� *
Material+5o   #   �� 5q   "   .+�5r   &   �� $
��Giá��60   
  5s   &   ��6>   �� *NormalPrice+5t   #   �� 5v   "   .+�5w   &   �� $��Chiết khấu��60   
  5x   &   ��6=   �� *
Discount+5y   #   �� 5~   "   .+�5   &   �� $��	Tồn kho��60   $��Center=�6?   
  5�   &    �� 
IsReadOnly . ��6O   �� *TotalRemain+5�   #   �� 5�   "    6-   �� *	FileDlg+.+�5�   &   �� $��Hình ảnh��60   
  5�   &    . $	��130��6O   ��6[   �� *
FileName+�� 5�   &   $��Browse��6-   $��30��6>   ��6M   �� *OpenCommand+5�   #   5�      5�      5�      5�      5�      5�      5�      